using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLitePeldaFelhasznalokConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(ConfigurationManager.ConnectionStrings["FelhasznalokConnStr"].ConnectionString);
            SQLiteConnection conn = new SQLiteConnection();
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["FelhasznalokConnStr"].ConnectionString;
            conn.Open();

            SQLiteCommand cmd1 = new SQLiteCommand("INSERT INTO Felhasznalok(FelhasznaloNev, Jelszo, RegisztracioIdeje, Aktiv) VALUES(@nev, @jelszo, @reg, @aktiv)", conn);
            cmd1.Parameters.AddWithValue("@nev", "Teszt Elek");
            cmd1.Parameters.AddWithValue("@jelszo", "alam1234");
            cmd1.Parameters.AddWithValue("@reg", DateTime.Now);
            cmd1.Parameters.AddWithValue("@aktiv", 1);
            int erintettSorokSzama = cmd1.ExecuteNonQuery();
            Console.WriteLine($"Érintett sorok száma: {erintettSorokSzama}");

            SQLiteCommand cmd2 = new SQLiteCommand("SELECT * FROM Felhasznalok", conn);
            SQLiteDataReader reader = cmd2.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Console.WriteLine($"ID: {reader["ID"]}, Felhasználónév: {reader["FelhasznaloNev"]}, Jelszó: {reader["Jelszo"]}, Regisztráció ideje: {reader["RegisztracioIdeje"]}, Aktív: {reader["Aktiv"]}");
                    Console.WriteLine($"ID: {reader[0]}, Felhasználónév: {reader[1]}, Jelszó: {reader[2]}, Regisztráció ideje: {reader[3]}, Aktív: {reader.GetBoolean(4)}");
                }
            }
            reader.Close();
            Console.ReadKey();
        }
    }
}
