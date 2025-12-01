using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLiteKapcsoltAdattablakGyakorlasJarmuvek
{
    static class ABKezelo
    {
        static SQLiteConnection connection;
        static SQLiteCommand command;

        static ABKezelo()
        {
            try
            {
                connection = new SQLiteConnection(ConfigurationManager.ConnectionStrings["ABEleres"].ConnectionString);
                connection.Open();

                command = new SQLiteCommand();
                command.Connection = connection;

                using (SQLiteCommand cmd = new SQLiteCommand("PRAGMA foreign_keys = ON;", connection))
                {
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new ABKivetel("Adatbázis kapcsolat felépítése sikertelen!", ex);
            }
        }

        public static void KapcsolatBontasa()
        {
            try
            {
                connection.Close();
            }
            catch (Exception ex)
            {
                throw new ABKivetel("Adatbázis kapcsolat lezárása sikertelen!", ex);
            }
        }

        public static List<Jarmu> Beolvasas()
        {
            try
            {
                //auto
                command.Parameters.Clear();
                List<Jarmu> jarmuvek = new List<Jarmu>();
                command.CommandText = "SELECT * FROM Jarmu INNER JOIN Auto ON Jarmu.Rendszam = Auto.Rendszam;";
                using (SQLiteDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        jarmuvek.Add(new Auto(
                            reader["Rendszam"].ToString(),
                            reader["Marka"].ToString(),
                            reader["Tipus"].ToString(),
                            reader["Szin"].ToString(),
                            Convert.ToInt32(reader["FutottKm"]),
                            (AutoTipus)Convert.ToInt32(reader["AutoTipus"])));
                    }
                }

                //motor
                command.Parameters.Clear();
                command.CommandText = "SELECT * FROM Jarmu INNER JOIN Motor ON Jarmu.Rendszam = Motor.Rendszam;";
                using (SQLiteDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        jarmuvek.Add(new Motor(
                            reader["Rendszam"].ToString(),
                            reader["Marka"].ToString(),
                            reader["Tipus"].ToString(),
                            reader["Szin"].ToString(),
                            Convert.ToInt32(reader["FutottKm"]),
                            Convert.ToSingle(reader["HengerUrtartalom"])));
                    }
                }
                return jarmuvek;
            }
            catch (Exception ex)
            {
                throw new ABKivetel("Az adatbázis kiolvasás sikertelen!", ex);
            }
        }

        public static void UjJarmu(Jarmu jarmu)
        {
            SQLiteTransaction transaction = null;
            try
            {
                command.Parameters.Clear();
                transaction = connection.BeginTransaction();
                command.Transaction = transaction;

                //Jarmuvek tábla feltöltése
                command.CommandText = "INSERT INTO Jarmu (Rendszam, Marka, Tipus, Szin, FutottKm) VALUES (@rendszam, @marka, @tipus, @szin, @futottKm);";
                command.Parameters.AddWithValue("@rendszam", jarmu.Rendszam);
                command.Parameters.AddWithValue("@marka", jarmu.Marka);
                command.Parameters.AddWithValue("@tipus", jarmu.Tipus);
                command.Parameters.AddWithValue("@szin", jarmu.Szin);
                command.Parameters.AddWithValue("@futottKm", jarmu.FutottKm);
                command.ExecuteNonQuery();

                //auto vagy motor tábla feltöltése
                command.Parameters.Clear();
                if (jarmu is Auto auto)
                {
                    command.CommandText = "INSERT INTO Auto (Rendszam, AutoTipus) VALUES (@rendszam, @autoTipus);";
                    command.Parameters.AddWithValue("@rendszam", auto.Rendszam);
                    command.Parameters.AddWithValue("@autoTipus", (int)auto.AutoTipus);
                }
                else if (jarmu is Motor motor)
                {
                    command.CommandText = "INSERT INTO Motor (Rendszam, HengerUrtartalom) VALUES (@rendszam, @hengerUrtartalom);";
                    command.Parameters.AddWithValue("@rendszam", motor.Rendszam);
                    command.Parameters.AddWithValue("@hengerUrtartalom", motor.HengerUrtartalom);
                }
                command.ExecuteNonQuery();

                transaction.Commit();
            }
            catch (Exception ex)
            {
                if (transaction != null)
                {
                    transaction.Rollback();
                }
                throw new ABKivetel("Új jármű hozzáadása az adatbázishoz sikertelen!", ex);
            }
        }
        public static void Modositas(Jarmu jarmu)
        {
            SQLiteTransaction transaction = null;
            try
            {
                command.Parameters.Clear();
                transaction = connection.BeginTransaction();
                command.Transaction = transaction;

                //Jarmuvek tábla módosítása
                command.CommandText = "UPDATE Jarmu SET Szin = @szin, FutottKm = @futottKm WHERE Rendszam = @rendszam;";
                command.Parameters.AddWithValue("@szin", jarmu.Szin);
                command.Parameters.AddWithValue("@futottKm", jarmu.FutottKm);
                command.Parameters.AddWithValue("@rendszam", jarmu.Rendszam);
                command.ExecuteNonQuery();

                //auto vagy motor tábla módosítása
                command.Parameters.Clear();
                if (jarmu is Auto auto)
                {
                    command.CommandText = "UPDATE Auto SET AutoTipus = @autoTipus WHERE Rendszam = @rendszam;";
                    command.Parameters.AddWithValue("@autoTipus", (int)auto.AutoTipus);
                    command.Parameters.AddWithValue("@rendszam", auto.Rendszam);
                }
                else if (jarmu is Motor motor)
                {
                    command.CommandText = "UPDATE Motor SET HengerUrtartalom = @hengerUrtartalom WHERE Rendszam = @rendszam;";
                    command.Parameters.AddWithValue("@hengerUrtartalom", (float)motor.HengerUrtartalom);
                    command.Parameters.AddWithValue("@rendszam", motor.Rendszam);
                }
                command.ExecuteNonQuery();

                transaction.Commit();
            }
            catch (Exception ex)
            {
                if (transaction != null)
                {
                    transaction.Rollback();
                }
                throw new ABKivetel("A jármű módosítása az adatbázisban sikertelen!", ex);
            }
        }
        public static void Torles(Jarmu jarmu)
        {
            SQLiteTransaction transaction = null;
            try
            {
                command.Parameters.Clear();
                transaction = connection.BeginTransaction();
                command.Transaction = transaction;

                //auto vagy motor táblából törlés   
                command.CommandText = $"DELETE FROM {(jarmu is Auto ? "Auto" : "Motor")} WHERE rendszam = @rendszam;";
                command.Parameters.AddWithValue("@rendszam", jarmu.Rendszam);
                command.ExecuteNonQuery();

                //Jarmuvek táblából törlés
                command.CommandText = "DELETE FROM Jarmu WHERE rendszam = @rendszam;";
                command.ExecuteNonQuery();

                transaction.Commit();
            }
            catch (Exception ex)
            {
                if (transaction != null)
                {
                    transaction.Rollback();
                }
                throw new ABKivetel("A jármű törlése az adatbázisból sikertelen!", ex);
            }
        }
    }
}
