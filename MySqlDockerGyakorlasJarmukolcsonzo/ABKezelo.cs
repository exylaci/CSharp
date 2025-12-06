using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace MySqlDockerGyakorlasJarmukolcsonzo
{
    static class ABKezelo
    {
        static MySqlConnection connection;
        static MySqlCommand command;

        static ABKezelo()
        {
            try
            {
                connection = new MySqlConnection(
                    ConfigurationManager.ConnectionStrings["SqlConnection"].ConnectionString);
                connection.Open();

                command = new MySqlCommand();
                command.Connection = connection;
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

        public static void UjJarmuFelvetele(Jarmu jarmu, int kolcsonzoId)
        {
            try
            {
                command.Parameters.Clear();

                if (jarmu is Szemelyauto)
                {
                    command.CommandText = @"
                        INSERT INTO Szemelyauto (Rendszam, Marka, Jarmutipus, Foglalt, KolcsonzoId, Szemelyautotipus, MaxSzemely) 
                        VALUES (@rendszam, @marka, @jarmutipus, @foglalt, @kolcsonzoid, @szemelyautotipus, @maxszemely);";

                    command.Parameters.AddWithValue("@rendszam", jarmu.Rendszam);
                    command.Parameters.AddWithValue("@marka", jarmu.Marka);
                    command.Parameters.AddWithValue("@jarmutipus", jarmu.Jarmutipus.ToString());
                    command.Parameters.AddWithValue("@foglalt", jarmu.Foglalt);
                    command.Parameters.AddWithValue("@kolcsonzoid", kolcsonzoId);
                    command.Parameters.AddWithValue("@szemelyautotipus", (jarmu as Szemelyauto).Szemelyautotipus.ToString());
                    command.Parameters.AddWithValue("@maxszemely", (jarmu as Szemelyauto).MaxSzemely);
                }
                else
                {
                    command.CommandText = @"
                        INSERT INTO Kisteherauto (Rendszam, Marka, Jarmutipus, Foglalt, KolcsonzoId, MaxTeher) 
                        VALUES (@rendszam, @marka, @jarmutipus, @foglalt, @kolcsonzoid, @maxteher);";

                    command.Parameters.AddWithValue("@rendszam", jarmu.Rendszam);
                    command.Parameters.AddWithValue("@marka", jarmu.Marka);
                    command.Parameters.AddWithValue("@jarmutipus", jarmu.Jarmutipus.ToString());
                    command.Parameters.AddWithValue("@foglalt", jarmu.Foglalt);
                    command.Parameters.AddWithValue("@kolcsonzoid", kolcsonzoId);
                    command.Parameters.AddWithValue("@maxteher", ((Kisteherauto)jarmu).MaxTeher);
                }

                command.ExecuteNonQuery();
                jarmu.Id = (int)command.LastInsertedId;
            }
            catch (Exception ex)
            {
                throw new ABKivetel("Új jármű hozzáadása az adatbázishoz sikertelen!", ex);
            }
        }

        public static void JarmuModositasa(Jarmu jarmu)
        {
            try
            {
                command.Parameters.Clear();

                if (jarmu is Szemelyauto szemelyauto)
                {
                    command.CommandText = @"
                        UPDATE Szemelyauto
                        SET Rendszam = @rendszam,
                            Marka = @marka,
                            Jarmutipus = @jarmutipus,
                            Foglalt = @foglalt,
                            Szemelyautotipus = @szemelyautotipus,
                            MaxSzemely = @maxszemely
                        WHERE Id = @id;";

                    command.Parameters.AddWithValue("@id", jarmu.Id);
                    command.Parameters.AddWithValue("@rendszam", jarmu.Rendszam);
                    command.Parameters.AddWithValue("@marka", jarmu.Marka);
                    command.Parameters.AddWithValue("@jarmutipus", jarmu.Jarmutipus.ToString());
                    command.Parameters.AddWithValue("@foglalt", jarmu.Foglalt);
                    command.Parameters.AddWithValue("@szemelyautotipus", szemelyauto.Szemelyautotipus.ToString());
                    command.Parameters.AddWithValue("@maxszemely", szemelyauto.MaxSzemely);
                }
                else
                {
                    command.CommandText = @"
                        UPDATE Kisteherauto
                        SET Rendszam = @rendszam,
                            Marka = @marka,
                            Jarmutipus = @jarmutipus,
                            Foglalt = @foglalt,
                            MaxTeher = @maxteher
                        WHERE Id = @id;";

                    command.Parameters.AddWithValue("@id", jarmu.Id);
                    command.Parameters.AddWithValue("@rendszam", jarmu.Rendszam);
                    command.Parameters.AddWithValue("@marka", jarmu.Marka);
                    command.Parameters.AddWithValue("@jarmutipus", jarmu.Jarmutipus.ToString());
                    command.Parameters.AddWithValue("@foglalt", jarmu.Foglalt);
                    command.Parameters.AddWithValue("@maxteher", ((Kisteherauto)jarmu).MaxTeher);
                }

                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new ABKivetel("A jármű módosítása az adatbázisban sikertelen!", ex);
            }
        }
        public static void JarmuTorlese(Jarmu jarmu)
        {
            try
            {
                command.Parameters.Clear();

                if (jarmu is Szemelyauto)
                {
                    command.CommandText = "DELETE FROM Szemelyauto WHERE Id = @id;";
                    command.Parameters.AddWithValue("@id", jarmu.Id);
                }
                else
                {
                    command.CommandText = "DELETE FROM Kisteherauto WHERE Id = @id;";
                    command.Parameters.AddWithValue("@id", jarmu.Id);
                }

                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new ABKivetel("A jármű törlése az adatbázisból sikertelen!", ex);
            }
        }

        public static List<Kolcsonzo> KolcsonzokLekerdezese()
        {
            try
            {
                //Kölcsönzők lekérdezése
                List<Kolcsonzo> kolcsonzok = new List<Kolcsonzo>();
                command.Parameters.Clear();
                command.CommandText = "SELECT * FROM Kolcsonzo;";
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        kolcsonzok.Add(new Kolcsonzo(
                            reader.GetInt32("Id"),
                            reader.GetString("Nev"),
                            reader.GetString("Cim"),
                            reader.GetString("Tulajdonos")
                        ));
                    }
                }

                //Személyautók lekérdezése és hozzárendelése a kölcsönzőkhöz
                command.Parameters.Clear();
                command.CommandText = "SELECT * FROM Szemelyauto;";
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Jarmu jarmu = new Szemelyauto(
                            reader.GetInt32("Id"),
                            reader.GetString("Rendszam"),
                            reader.GetString("Marka"),
                            (JarmuTipus)Enum.Parse(typeof(JarmuTipus), reader.GetString("Jarmutipus")),
                            reader.GetBoolean("Foglalt"),
                            (SzemelyautoTipus)Enum.Parse(typeof(SzemelyautoTipus), reader.GetString("Szemelyautotipus")),
                            reader.GetByte("MaxSzemely")
                        );
                        foreach (var kolcsonzo in kolcsonzok)
                        {
                            if (kolcsonzo.Id == reader.GetInt32("KolcsonzoId"))
                            {
                                kolcsonzo.Jarmuvek.Add(jarmu);
                                break;
                            }
                        }
                    }
                }

                //Kisteherautók lekérdezése és hozzárendelése a kölcsönzőkhöz
                command.Parameters.Clear();
                command.CommandText = "SELECT * FROM Kisteherauto;";
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Jarmu jarmu = new Kisteherauto(
                            reader.GetInt32("Id"),
                            reader.GetString("Rendszam"),
                            reader.GetString("Marka"),
                            (JarmuTipus)Enum.Parse(typeof(JarmuTipus), reader.GetString("Jarmutipus")),
                            reader.GetBoolean("Foglalt"),
                            reader.GetInt32("MaxTeher")
                        );
                        foreach (var kolcsonzo in kolcsonzok)
                        {
                            if (kolcsonzo.Id == reader.GetInt32("KolcsonzoId"))
                            {
                                kolcsonzo.Jarmuvek.Add(jarmu);
                                break;
                            }
                        }
                    }
                }

                return kolcsonzok;
            }
            catch (Exception ex)
            {
                throw new ABKivetel("A kölcsönzők lekérdezése az adatbázisból sikertelen!", ex);
            }
        }
        public static void EgyKolcsonzoEsJarmuveiMentese(Kolcsonzo kolcsonzo)
        {
            MySqlTransaction transaction = null;

            try
            {
                command.Parameters.Clear();
                transaction = connection.BeginTransaction();
                command.Transaction = transaction;

                //Kölcsönző eltárolása
                command.CommandText = @"
                    INSERT INTO Kolcsonzo (Nev, Cim, Tulajdonos) 
                    VALUES (@nev, @cim, @tulajdonos);";

                command.Parameters.AddWithValue("@nev", kolcsonzo.Nev);
                command.Parameters.AddWithValue("@cim", kolcsonzo.Cim);
                command.Parameters.AddWithValue("@tulajdonos", kolcsonzo.Tulajdonos);
                command.ExecuteNonQuery();
                kolcsonzo.Id = (int)command.LastInsertedId;

                //Járművek eltárolása
                foreach (var jarmu in kolcsonzo.Jarmuvek)
                {
                    command.Parameters.Clear();

                    if (jarmu is Szemelyauto szemelyauto)
                    {
                        command.CommandText = @"
                            INSERT INTO Szemelyauto (Rendszam, Marka, Jarmutipus, Foglalt, Szemelyautotipus, MaxSzemely, KolcsonzoId) 
                            VALUES (@rendszam, @marka, @jarmutipus, @foglalt, @szemelyautotipus, @maxszemely, @kolcsonzoId);";

                        command.Parameters.AddWithValue("@rendszam", jarmu.Rendszam);
                        command.Parameters.AddWithValue("@marka", jarmu.Marka);
                        command.Parameters.AddWithValue("@jarmutipus", jarmu.Jarmutipus.ToString());
                        command.Parameters.AddWithValue("@foglalt", jarmu.Foglalt);
                        command.Parameters.AddWithValue("@szemelyautotipus", szemelyauto.Szemelyautotipus.ToString());
                        command.Parameters.AddWithValue("@maxszemely", szemelyauto.MaxSzemely);
                        command.Parameters.AddWithValue("@kolcsonzoId", kolcsonzo.Id);
                    }
                    else
                    {
                        command.CommandText = @"
                            INSERT INTO Kisteherauto (Rendszam, Marka, Jarmutipus, Foglalt, MaxTeher, KolcsonzoId) 
                            VALUES (@rendszam, @marka, @jarmutipus, @foglalt, @maxteher, @kolcsonzoId);";

                        command.Parameters.AddWithValue("@rendszam", jarmu.Rendszam);
                        command.Parameters.AddWithValue("@marka", jarmu.Marka);
                        command.Parameters.AddWithValue("@jarmutipus", jarmu.Jarmutipus.ToString());
                        command.Parameters.AddWithValue("@foglalt", jarmu.Foglalt);
                        command.Parameters.AddWithValue("@maxteher", ((Kisteherauto)jarmu).MaxTeher);
                        command.Parameters.AddWithValue("@kolcsonzoId", kolcsonzo.Id);
                    }

                    command.ExecuteNonQuery();
                    jarmu.Id = (int)command.LastInsertedId;
                }

                transaction.Commit();
            }
            catch (Exception ex)
            {
                if (transaction != null)
                {
                    transaction.Rollback();
                }
                throw new ABKivetel("A kölcsönző és járművei mentése az adatbázisba sikertelen!", ex);
            }
        }
        public static void KolcsonzoMentese(Kolcsonzo kolcsonzo)
        {
            try
            {
                command.Parameters.Clear();
                command.CommandText = @"
                    INSERT INTO Kolcsonzo (Nev, Cim, Tulajdonos) 
                    VALUES (@nev, @cim, @tulajdonos);";

                command.Parameters.AddWithValue("@nev", kolcsonzo.Nev);
                command.Parameters.AddWithValue("@cim", kolcsonzo.Cim);
                command.Parameters.AddWithValue("@tulajdonos", kolcsonzo.Tulajdonos);
                command.ExecuteNonQuery();
                kolcsonzo.Id = (int)command.LastInsertedId;
            }
            catch (Exception ex)
            {
                throw new ABKivetel("A kölcsönző mentése az adatbázisba sikertelen!", ex);
            }
        }
        public static void KolcsonzoModositasa(Kolcsonzo kolcsonzo)
        {
            try
            {
                command.Parameters.Clear();
                command.CommandText = @"
                    UPDATE Kolcsonzo
                    SET Nev = @nev,
                        Cim = @cim,
                        Tulajdonos = @tulajdonos
                    WHERE Id = @id;";

                command.Parameters.AddWithValue("@nev", kolcsonzo.Nev);
                command.Parameters.AddWithValue("@cim", kolcsonzo.Cim);
                command.Parameters.AddWithValue("@tulajdonos", kolcsonzo.Tulajdonos);
                command.Parameters.AddWithValue("@id", kolcsonzo.Id);

                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new ABKivetel("A kölcsönző módosítása az adatbázisban sikertelen!", ex);
            }
        }
        public static void KolcsonzoTorléseJarmuveivel(Kolcsonzo kolcsonzo)
        {
            MySqlTransaction transaction = null;
            try
            {
                command.Parameters.Clear();
                transaction = connection.BeginTransaction();
                command.Transaction = transaction;

                //Személyautók törlése
                command.CommandText = "DELETE FROM Szemelyauto WHERE KolcsonzoId = @id;";
                command.Parameters.AddWithValue("@id", kolcsonzo.Id);
                command.ExecuteNonQuery();

                //Kisteherautók törlése
                command.Parameters.Clear();
                command.CommandText = "DELETE FROM Kisteherauto WHERE KolcsonzoId = @id;";
                command.Parameters.AddWithValue("@id", kolcsonzo.Id);
                command.ExecuteNonQuery();

                //Kölcsönző törlése
                command.Parameters.Clear();
                command.CommandText = "DELETE FROM Kolcsonzo WHERE Id = @id;";
                command.Parameters.AddWithValue("@id", kolcsonzo.Id);
                command.ExecuteNonQuery();

                transaction.Commit();
            }
            catch (Exception ex)
            {
                if (transaction != null)
                {
                    transaction.Rollback();
                }
                throw new ABKivetel("A kölcsönző és járművei törlése az adatbázisból sikertelen!", ex);
            }
        }
    }
}
