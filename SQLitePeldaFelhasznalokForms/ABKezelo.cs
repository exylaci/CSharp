using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLitePeldaFelhasznalokForms
{
    static class ABKezelo
    {
        static SQLiteConnection connection;
        static SQLiteCommand command;

        static ABKezelo()
        {
            try
            {
                connection = new SQLiteConnection(ConfigurationManager.ConnectionStrings["FelhasznalokSQLite"].ConnectionString);
                connection.Open();
            }
            catch (Exception ex)
            {
                throw new ABKivetel("Adatbázis csatlakozási hiba: ", ex);
            }
        }

        public static void KapcsolatBontas()
        {
            try
            {
                connection.Close();
            }
            catch (Exception ex)
            {

                throw new ABKivetel("A kapcsolat bontási hiba", ex);
            }
        }

        public static List<Felhasznalo> Beolvasas(int limit = -1)
        {
            try
            {
                List<Felhasznalo> eredmeny = new List<Felhasznalo>();
                string sql = "SELECT Id, FelhasznaloNev, Jelszo, RegisztracioIdeje, Aktiv FROM Felhasznalok";
                if (limit > 0)
                {
                    sql += " LIMIT @limit";
                }

                command = new SQLiteCommand(sql, connection);
                if (limit > 0)
                {
                    command.Parameters.AddWithValue("@limit", limit);
                }

                using (SQLiteDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int id = Convert.ToInt32(reader["Id"]);
                        string felhasznaloNev = reader["FelhasznaloNev"].ToString();
                        string jelszo = reader["Jelszo"].ToString();
                        DateTime regisztracioIdeje = DateTime.Parse(reader["RegisztracioIdeje"].ToString());
                        bool aktiv = reader.GetBoolean(4);
                        eredmeny.Add(new Felhasznalo(id, felhasznaloNev, jelszo, regisztracioIdeje, aktiv));
                    }
                    return eredmeny;
                }
            }
            catch (Exception ex)
            {
                throw new ABKivetel("Adatbázis rekord olvasási hiba: ", ex);
            }
        }

        public static void Hozzaadas(Felhasznalo felhasznalo)
        {
            try
            {
                string sql = @"
                        INSERT INTO Felhasznalok 
                            (FelhasznaloNev, Jelszo, RegisztracioIdeje, Aktiv) 
                        VALUES (@felhasznaloNev, @jelszo, @regisztracioIdeje, @aktiv);
                        SELECT last_insert_rowid()";

                command = new SQLiteCommand(sql, connection);
                command.Parameters.AddWithValue("@felhasznaloNev", felhasznalo.FelhasznaloNev);
                command.Parameters.AddWithValue("@jelszo", felhasznalo.Jelszo);
                command.Parameters.AddWithValue("@regisztracioIdeje", felhasznalo.RegisztracioIdeje);
                command.Parameters.AddWithValue("@aktiv", felhasznalo.Aktiv);

                object result = command.ExecuteScalar();
                felhasznalo.Id = Convert.ToInt32(result);
            }
            catch (Exception ex)
            {
                throw new ABKivetel("Adatbázis rekord írási hiba: ", ex);
            }
        }

        public static void Modositas(Felhasznalo felhasznalo)
        {
            try
            {
                string sql = @"
                    UPDATE Felhasznalok
                    SET FelhasznaloNev = @nev,
                        Jelszo = @jelszo,
                        Aktiv = @aktiv
                    WHERE Id = @id";

                command = new SQLiteCommand(sql, connection);
                command.Parameters.AddWithValue("@nev", felhasznalo.FelhasznaloNev);
                command.Parameters.AddWithValue("@jelszo", felhasznalo.Jelszo);
                command.Parameters.AddWithValue("@aktiv", felhasznalo.Aktiv);
                command.Parameters.AddWithValue("@id", felhasznalo.Id);

                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new ABKivetel("Adatbázis rekord módosítási hiba: ", ex);
            }
        }

        public static void Torles(Felhasznalo felhasznalo)
        {
            try
            {
                string sql = @"
                    DELETE FROM Felhasznalok
                    WHERE Id = @id";

                command = new SQLiteCommand(sql, connection);
                command.Parameters.AddWithValue("@id", felhasznalo.Id);

                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new ABKivetel("Adatbázis record törlési hiba: ", ex);
            }
        }
    }
}
