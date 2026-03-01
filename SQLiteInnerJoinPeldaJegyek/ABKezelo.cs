using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLiteInnerJoinPeldaJegyek
{
    static class ABKezelo
    {
        static SQLiteConnection connection;
        static SQLiteCommand command;


        static ABKezelo()
        {
            try
            {
                connection = new SQLiteConnection(
                           ConfigurationManager.ConnectionStrings["TanulokABConnStr"].ConnectionString);
                connection.Open();
                command = connection.CreateCommand();
                command.Connection = connection;

                using (SQLiteCommand c = new SQLiteCommand("PRAGMA foreign_keys = ON;", connection))
                {
                    c.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {

                throw new ABKivetel("Nem sikerűlt csatlakozni az adatbázishoz!", ex);
            }
        }

        public static void KapcsolatBontas()
        {
            try
            {
                connection.Close();
                command = null;
            }
            catch (Exception ex)
            {
                throw new ABKivetel("Nem sikerűlt bontani az adatbázis kapcsolatot!", ex);
            }
        }
        public static List<Tanulo> TanulokBeolvasasa()
        {
            try
            {
                command.Parameters.Clear();
                command.CommandText = @"
                    SELECT Jegy.Id as Jid, Tid, Did, Jegy, Tanulo.Nev as Dnev, Tanar.Nev as Tnev, Tantargy
                        FROM Jegy 
                    LEFT JOIN Tanulo ON Jegy.Did = Tanulo.Id   
                    INNER JOIN Tanar ON Jegy.Tid = Tanar.Id
                    ORDER BY Tanulo.Id;";

                List<Tanulo> tanulok = new List<Tanulo>();

                using (SQLiteDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int did = Convert.ToInt32(reader["Did"]);
                        if (tanulok.Count == 0 || tanulok.Last().Id != did)
                        {
                            tanulok.Add(new Tanulo(Convert.ToInt32(reader["Did"]),
                                                    reader["Dnev"].ToString()));
                        }
                        tanulok.Last().Jegyek.Add(new Jegy(Convert.ToInt32(reader["Jid"]),
                                                           Convert.ToByte(reader["Jegy"]),
                                                            new Tanar(Convert.ToInt32(reader["Tid"]),
                                                                      reader["Tnev"].ToString(),
                                                                      reader["Tantargy"].ToString())));
                    }
                    return tanulok;
                }

            }
            catch (Exception ex)
            {
                throw new ABKivetel("Nem sikerűlt beolvasni a tanulókat az adatbázisból!", ex);
            }
        }
        public static List<Tanar> TanarokBeolvasasa()
        {
            try
            {
                command.Parameters.Clear();
                command.CommandText = "SELECT * FROM Tanar";

                List<Tanar> tanarok = new List<Tanar>();

                using (SQLiteDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        tanarok.Add(new Tanar(Convert.ToInt32(reader["Id"]), reader["Nev"].ToString(), reader["Tantargy"].ToString()));
                    }
                }
                return tanarok;
            }
            catch (Exception ex)
            {
                throw new ABKivetel("Nem sikerült beolvasni a tanárokat az adatbázisból!", ex);
            }
        }
        public static void TanarFelvitele(Tanar tanar)
        {
            try
            {
                command.Parameters.Clear();
                command.CommandText = @"INSERT INTO Tanar (Nev, Tantargy) VALUES (@nev, @tantargy);
                                        SELECT last_insert_rowid();";
                command.Parameters.AddWithValue("@nev", tanar.Nev);
                command.Parameters.AddWithValue("@tantargy", tanar.Tantargy);

                tanar.Id = Convert.ToInt32(command.ExecuteNonQuery());
            }
            catch (Exception ex)
            {
                throw new ABKivetel("Nem sikerült új tanárt felvenni az adatbázisba!", ex);
            }
        }
        public static void TanuloFelvitele(Tanulo tanulo)
        {
            try
            {
                command.Parameters.Clear();
                command.Transaction = connection.BeginTransaction();

                command.CommandText = @"INSERT INTO Tanulo (Nev) VALUES (@nev);
                                        SELECT last_insert_rowid();";
                command.Parameters.AddWithValue("@nev", tanulo.Nev);
                tanulo.Id = Convert.ToInt32(command.ExecuteNonQuery());

                foreach (Jegy jegy in tanulo.Jegyek)
                {
                    command.Parameters.Clear();
                    command.CommandText = @"INSERT INTO Jegy (Tid, Did, Jegy) VALUES (@tid, @did, @jegy);
                                            SELECT last_insert_rowid();";
                    command.Parameters.AddWithValue("@tid", (decimal)jegy.Tanar.Id);
                    command.Parameters.AddWithValue("@did", tanulo.Id);
                    command.Parameters.AddWithValue("@jegy", jegy.JegyErtek);
                    jegy.Id = Convert.ToInt32(command.ExecuteNonQuery());
                }
                command.Transaction.Commit();
            }
            catch (Exception ex)
            {
                if (command.Transaction != null)
                {
                    command.Transaction.Rollback();
                }
                throw new ABKivetel("Nem sikerült új tanulót felvenni az adatbázisba!", ex);
            }
        }
    }
}

