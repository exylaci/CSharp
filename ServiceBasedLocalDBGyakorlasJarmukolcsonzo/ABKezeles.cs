using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceBasedLocalDBGyakorlasJarmukolcsonző
{
    internal class ABKezeles
    {
        static SqlConnection connection;
        static SqlCommand command;
        public ABKezeles()
        {
            try
            {
                connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ServiceBaseLocalDB"].ConnectionString);
                connection.Open();
                command = new SqlCommand();
                command.Connection = connection;

            }
            catch (Exception e)
            {
                throw new ABKivetel("Nem sikerült csatlakozni az adatbázishoz!", e);
            }
        }
        public static void KapcsolatBontas()
        {
            try
            {
                connection.Close();
            }
            catch (Exception e)
            {
                throw new ABKivetel("Nem sikerült bontani az adatbázis kapcsolatot!", e);
            }
        }
        public static List<Kolcsonzo> TeljesBeolvasas()
        {
            List<Kolcsonzo> kolcsonzok = new List<Kolcsonzo>();
            List<string> kialakitasok = new List<string>();
            foreach (Kialakitas kialakitas in Enum.GetValues(typeof(Kialakitas)))
            {
                kialakitasok.Add(kialakitas.ToString());
            }
            try
            {
                command.Parameters.Clear();
                command.CommandText = @"
                    SELECT Nev, Cim, MaxJarmu, j.Rendszam, Marka, Foglalt, KolcsonzoNev, KolcsonzoCim, a.Rendszam, Kialakitas, m.Rendszam, Kobcenti
                    FROM Kolcsonzok AS k
                    LEFT JOIN Jarmuvek as j ON k.Nev = j.KolcsonzoNev AND k.Cim = j.KolcsonzoCim
                    LEFT JOIN Autok AS a ON j.Rendszam = a. Rendszam
                    LEFT JOIN Motorok AS m ON j.Rendszam = m.Rendszam
                    ORDER BY Nev, Cim;";
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    if (kolcsonzok.Count == 0 || kolcsonzok.Last().Nev != reader["Nev"].ToString() || kolcsonzok.Last().Cim != reader["Cim"].ToString())
                    {
                        kolcsonzok.Add(new Kolcsonzo(
                            reader["Nev"].ToString(),
                            reader["Cim"].ToString(),
                            Convert.ToByte(reader["MaxJarmu"])
                            ));
                    }
                    if (!string.IsNullOrEmpty(reader["Rendszam"].ToString()))
                    {
                        Jarmu jarmu;
                        if (string.IsNullOrEmpty(reader["Kobcenti"].ToString())) // Auto
                        {
                            jarmu = new Auto(
                                reader["Rendszam"].ToString(),
                                reader["Marka"].ToString(),
                                Convert.ToBoolean(reader["Foglalt"]),
                                (Kialakitas)kialakitasok.IndexOf(reader["Kialakitas"].ToString())
                                );
                        }
                        else  // Motor
                        {
                            jarmu = new Motor(
                                reader["Rendszam"].ToString(),
                                reader["Marka"].ToString(),
                                Convert.ToBoolean(reader["Foglalt"]),
                                Convert.ToInt16(reader["Kobcenti"])
                                );
                        }
                        kolcsonzok.Last().Jarmuvek.Add(jarmu);
                    }
                }
                reader.Close();

                return kolcsonzok;
            }
            catch (Exception e)
            {
                throw new ABKivetel("Nem sikerült beolvasni az adatbázist!", e);
            }
        }
        public static void KolcsonzoHozzaadas(Kolcsonzo kolcsonzo)
        {
            try
            {
                command.Parameters.Clear();
                command.CommandText = @"
                    INSERT INTO Kolcsonzok (Nev, Cim, MaxJarmu)
                    VALUES (@nev, @cim, @maxjarmu);";
                command.Parameters.AddWithValue("@nev", kolcsonzo.Nev);
                command.Parameters.AddWithValue("@cim", kolcsonzo.Cim);
                command.Parameters.AddWithValue("@maxjarmu", kolcsonzo.MaxJarmu);
                command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw new ABKivetel("Nem sikrült a kölcsönzőt hozzáadni az adatbázishoz!", e);
            }
        }
        public static void KolcsonzoModositas(Kolcsonzo kolcsonzo)
        {
            try
            {
                command.Parameters.Clear();
                command.CommandText = @"
                    UPDATE Kolcsonzok
                    SET MaxJarmu = @maxjarmu
                    WHERE Nev = @nev AND Cim = @cim;";
                command.Parameters.AddWithValue("@nev", kolcsonzo.Nev);
                command.Parameters.AddWithValue("@cim", kolcsonzo.Cim);
                command.Parameters.AddWithValue("@maxjarmu", kolcsonzo.MaxJarmu);
                command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw new ABKivetel("Nem sikrült a kölcsönzőt módosítani!", e);
            }
        }
        public static void KolcsonzoTorlese(Kolcsonzo kolcsonzo)
        {
            try
            {
                command.Parameters.Clear();
                command.Transaction = connection.BeginTransaction();
                command.Parameters.AddWithValue("@nev", kolcsonzo.Nev);
                command.Parameters.AddWithValue("@cim", kolcsonzo.Cim);

                //jarmuvek torlese
                foreach (string tabla in new string[] { "Motorok", "Autok" })
                {
                    command.CommandText = $@"
                        DELETE FROM {tabla} WHERE Rendszam IN 
                            (SELECT Rendszam FROM Jarmuvek WHERE KolcsonzoNev = @nev AND KolcsonzoCim = @cim);";
                    command.ExecuteNonQuery();

                }
                command.CommandText = $@"
                    DELETE FROM Jarmuvek
                    WHERE KolcsonzoNev = @nev AND KolcsonzoCim = @cim;";
                command.ExecuteNonQuery();

                //kolcsonzo torlese
                command.CommandText = @"
                    DELETE FROM Kolcsonzok
                    WHERE Nev = @nev AND Cim = @cim;";
                command.ExecuteNonQuery();

                command.Transaction.Commit();
            }
            catch (Exception e)
            {
                command.Transaction.Rollback();
                throw new ABKivetel("Nem sikrült a kölcsönzőt törölni az adatbázisból!", e);
            }
        }
        public static void JarmuHozzaadas(Jarmu jarmu, Kolcsonzo kolcsonzo)
        {
            try
            {
                command.Parameters.Clear();
                command.Transaction = connection.BeginTransaction();
                {
                    command.CommandText = @"
                    INSERT INTO Jarmuvek (Rendszam, Marka, Foglalt, KolcsonzoNev, KolcsonzoCim)
                    VALUES (@rendszam, @marka, @foglalt, @kolcsonzonev, @kolcsonzocim);";
                    command.Parameters.AddWithValue("@rendszam", jarmu.Rendszam);
                    command.Parameters.AddWithValue("@marka", jarmu.Marka);
                    command.Parameters.AddWithValue("@foglalt", jarmu.Foglalt);
                    command.Parameters.AddWithValue("@kolcsonzonev", kolcsonzo.Nev);
                    command.Parameters.AddWithValue("@kolcsonzocim", kolcsonzo.Cim);
                    command.ExecuteNonQuery();

                    command.Parameters.Clear();
                    command.Parameters.AddWithValue("@rendszam", jarmu.Rendszam);
                    if (jarmu is Auto)
                    {
                        command.CommandText = @"
                        INSERT INTO Autok (Rendszam, Kialakitas)
                        VALUES (@rendszam, @kialakitas);";
                        command.Parameters.AddWithValue("@kialakitas", ((Auto)jarmu).Kialakitas.ToString());
                    }
                    else
                    {
                        command.CommandText = @"
                    INSERT INTO Autok (Rendszam, Kialakitas)
                    VALUES (@rendszam, @kialakitas);";
                        command.Parameters.AddWithValue("@kobcenti", ((Motor)jarmu).Kobcenti);
                    }
                    command.ExecuteNonQuery();
                }
                command.Transaction.Commit();
            }
            catch (Exception e)
            {
                command.Transaction.Rollback();
                throw new ABKivetel("Nem sikrült a járművet hozzáadni az adatbázishoz!", e);
            }
        }
        public static void JarmuModositas(Jarmu jarmu)
        {
            try
            {
                command.Parameters.Clear();
                command.CommandText = @"
                    UPDATE Jarmuvek
                    SET Foglalt = @foglalt
                    WHERE Rendszam = @rendszam;";
                command.Parameters.AddWithValue("@rendszam", jarmu.Rendszam);
                command.Parameters.AddWithValue("@foglalt", jarmu.Foglalt);
                command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw new ABKivetel("Nem sikrült a járművet módosítani az adatbázisban!", e);
            }
        }
        public static void JarmuTorlese(Jarmu jarmu)
        {
            try
            {
                command.Parameters.Clear();
                command.Transaction = connection.BeginTransaction();
                {
                    command.CommandText = $"DELETE FROM {(jarmu is Auto ? "Autok" : "Motorok")}  WHERE Rendszam = @rendszam; ";
                    command.Parameters.AddWithValue("@rendszam", jarmu.Rendszam);
                    command.ExecuteNonQuery();

                    command.CommandText = $"DELETE FROM Jarmuvek  WHERE Rendszam = @rendszam; ";
                    command.ExecuteNonQuery();
                }
                command.Transaction.Commit();
            }
            catch (Exception ex)
            {
                command.Transaction.Rollback();
                throw new ABKivetel("Nem sikerült a járművet törölni az adatbázisból!", ex);
            }
        }
    }
}
