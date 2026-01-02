using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySqlOroklesPeldaJarmukolcsonzo
{
    static class ABKezeloMySQL
    {
        static MySqlConnection connection;
        static MySqlCommand command;

        static ABKezeloMySQL()
        {
            try
            {
                connection = new MySqlConnection(ConfigurationManager.ConnectionStrings["KolcsonzokABMysql"].ConnectionString.Replace("@pass", "Str0ng!Passw0rd"));
                connection.Open(); 
                command = new MySqlCommand();
                command.Connection = connection;
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

        public static List<Kolcsonzo> TeljesBeolvasas()
        {
            try
            {
                command.Parameters.Clear();
                command.CommandText = @"
                    SELECT `K`.*, `J`.*, `S`.`SzallSzemSzam`, `S`.`Tipus` AS SzgTipus, `H`.`MaxTeher`
                        FROM `Kolcsonzok` AS `K`
                        LEFT JOIN `Jarmuvek` AS `J` ON `K`.`Megnevezes` = `J`.`KolcsonzoMegnevezes`
                            AND `K`.`Cim` = `J`.`KolcsonzoCim`
                        LEFT JOIN `SzemelyGepjarmuvek` AS `S` ON `J`.`Rendszam` = `S`.`Rendszam`
                        LEFT JOIN `KishaszonGepjarmuvek` AS `H` ON `J`.`Rendszam` = `H`.`Rendszam`;";
                //SELECT `K`.*, `J`.*, `S`.`SzallSzemSzam`, `S`.`Tipus` AS `SzgTipus`, `KH`.`MaxTeher` FROM `Kolcsonzok` AS `K` LEFT JOIN `Jarmuvek` AS `J` ON `K`.`Megnevezes` = `J`.`KolcsonzoMegnevezes` AND `K`.`Cim` = `J`.`KolcsonzoCim` LEFT JOIN `SzemelyGepjarmuvek` AS `S` ON `J`.`Rendszam` = `S`.`Rendszam` LEFT JOIN `KishaszonGepjarmuvek` AS `KH` ON `J`.`Rendszam` = `KH`.`Rendszam`
                List<Kolcsonzo> kolcsonzok = new List<Kolcsonzo>();
                List<string> enumErtekek = new List<string>();
                foreach (SzemelyGepjarmuTipus item in Enum.GetValues(typeof(SzemelyGepjarmuTipus)))
                {
                    enumErtekek.Add(item.ToString());
                }
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        if (kolcsonzok.Count == 0 || kolcsonzok.Last().Cim != reader["Cim"].ToString() || kolcsonzok.Last().Megnevezes != reader["Megnevezes"].ToString())
                        {
                            kolcsonzok.Add(new Kolcsonzo(
                                reader.GetString("Megnevezes"),
                                reader.GetString("Cim"),
                                reader.GetString("Tulajdonos")
                                ));
                        }
                        if (!string.IsNullOrEmpty(reader["Rendszam"].ToString()))
                        {
                            if (string.IsNullOrEmpty(reader["Maxteher"].ToString()))
                            {
                                kolcsonzok.Last().Jarmuvek.Add(
                                    new SzemelyGepjarmu(
                                        reader["Rendszam"].ToString(),
                                        reader["Marka"].ToString(),
                                        reader["Tipus"].ToString(),
                                        Convert.ToInt32(reader["Foglalt"].ToString()) == 1,
                                        byte.Parse(reader["SzallSzemSzam"].ToString()),
                                        (SzemelyGepjarmuTipus)enumErtekek.IndexOf(reader["SzgTipus"].ToString())
                                        ));
                            }
                            else
                            {
                                kolcsonzok.Last().Jarmuvek.Add(
                                    new KishaszonGepjarmu(
                                        reader["Rendszam"].ToString(),
                                        reader["Marka"].ToString(),
                                        reader["Tipus"].ToString(),
                                        Convert.ToInt32(reader["Foglalt"].ToString()) == 1,
                                        float.Parse(reader["MaxTeher"].ToString())
                                        ));
                                //kolcsonzok.Last().Jarmuvek.Add(
                                //    new KishaszonGepjarmu(
                                //        reader["Rendszam"].ToString(),
                                //        reader["Marka"].ToString(),
                                //        reader["Tipus"].ToString(),
                                //        Convert.ToInt32(reader["Foglalt"].ToString()) == 1,
                                //        int.Parse(reader["MaxTeher"].ToString())
                                //        ));
                            }
                        }

                    }
                }
                return kolcsonzok;
            }
            catch (Exception ex)
            {
                throw new ABKivetel("Nem sikerűlt lekérdezni a kölcsönzőket az adatbázisból!", ex);
            }
        }

        public static void UjKolcsonzoFelvetel(Kolcsonzo kolcsonzo)
        {
            try
            {
                command.Parameters.Clear();
                command.CommandText = @"
                    INSERT INTO `Kolcsonzok` (`Megnevezes`, `Cim`, `Tulajdonos`)
                        VALUES (@megnevezes, @cim, @tulajdonos);";
                command.Parameters.AddWithValue("@megnevezes", kolcsonzo.Megnevezes);
                command.Parameters.AddWithValue("@cim", kolcsonzo.Cim);
                command.Parameters.AddWithValue("@tulajdonos", kolcsonzo.Tulajdonos);
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new ABKivetel("Nem sikerűlt új kölcsönzőt felvenni az adatbázisba!", ex);
            }
        }

        public static void UjJarmuFelvetel(Jarmu jarmu, Kolcsonzo kolcsonzo)
        {
            try
            {
                command.Parameters.Clear();
                command.Transaction = connection.BeginTransaction();
                command.CommandText = @"
                    INSERT INTO `Jarmuvek` (`Rendszam`, `Marka`, `Tipus`, `Foglalt`, `KolcsonzoMegnevezes`, `KolcsonzoCim`)
                        VALUES (@rendszam, @marka, @tipus, @foglalt, @kolcsonzomegnevezes, @kolcsonzocim);";
                command.Parameters.AddWithValue("@rendszam", jarmu.Rendszam);
                command.Parameters.AddWithValue("@marka", jarmu.Marka);
                command.Parameters.AddWithValue("@tipus", jarmu.Tipus);
                command.Parameters.AddWithValue("@foglalt", jarmu.Foglalt ? 1 : 0);
                command.Parameters.AddWithValue("@kolcsonzomegnevezes", kolcsonzo.Megnevezes);
                command.Parameters.AddWithValue("@kolcsonzocim", kolcsonzo.Cim);
                command.ExecuteNonQuery();

                command.Parameters.Clear();
                command.Parameters.AddWithValue("@rendszam", jarmu.Rendszam);
                if (jarmu is SzemelyGepjarmu szemelyGepjarmu)
                {
                    command.CommandText = @"
                        INSERT INTO `SzemelyGepjarmuvek` (`Rendszam`, `SzallSzemSzam`, `Tipus`)
                            VALUES (@rendszam, @szallszemszam, @tipus);";
                    command.Parameters.AddWithValue("@szallszemszam", szemelyGepjarmu.MaxSzemely);
                    command.Parameters.AddWithValue("@tipus", szemelyGepjarmu.Tipus.ToString());
                }
                else if (jarmu is KishaszonGepjarmu kishaszonGepjarmu)
                {
                    command.CommandText = @"
                        INSERT INTO `KishaszonGepjarmuvek` (`Rendszam`, `MaxTeher`)
                            VALUES (@rendszam, @maxteher);";
                    command.Parameters.AddWithValue("@maxteher", kishaszonGepjarmu.MaxTeher);
                }
                command.ExecuteNonQuery();
                command.Transaction.Commit();
            }
            catch (Exception ex)
            {
                try
                {
                    command.Transaction.Rollback();
                }
                catch (Exception e)
                {
                    throw new ABKivetel("Végzetes hiba történt! A tranzakció lezárása sikertelen!", e);
                }
                throw new ABKivetel("Nem sikerűlt új járművet felvenni az adatbázisba!", ex);
            }
        }

        public static void KolcsonzoModositas(Kolcsonzo kolcsonzo)
        {
            try
            {
                command.Parameters.Clear();
                command.CommandText = @"
                    UPDATE `Kolcsonzok`
                        SET `Tulajdonos` = @tulajdonos, `Cim` = @cim
                        WHERE `Megnevezes` = @megnevezes;";
                command.Parameters.AddWithValue("@tulajdonos", kolcsonzo.Tulajdonos);
                command.Parameters.AddWithValue("@cim", kolcsonzo.Cim);
                command.Parameters.AddWithValue("@megnevezes", kolcsonzo.Megnevezes);
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new ABKivetel("Nem sikerűlt módosítani a kölcsönző adatait az adatbázisban!", ex);
            }
        }

        public static void JarmuModositas(Jarmu jarmu)
        {
            try
            {
                command.Parameters.Clear();
                command.Transaction = connection.BeginTransaction();
                {
                    command.CommandText = @"
                        UPDATE `Jarmuvek`
                            SET `Foglalt` = @foglalt
                            WHERE `Rendszam` = @rendszam;";
                    command.Parameters.AddWithValue("@foglalt", jarmu.Foglalt ? 1 : 0);
                    command.Parameters.AddWithValue("@rendszam", jarmu.Rendszam);
                    command.ExecuteNonQuery();

                    command.Parameters.RemoveAt("@foglalt");
                    if (jarmu is KishaszonGepjarmu kishaszonGepjarmu)
                    {
                        command.CommandText = @"
                            UPDATE `KishaszonGepjarmuvek`
                                SET `MaxTeher` = @maxteher
                                WHERE `Rendszam` = @rendszam;";
                        command.Parameters.AddWithValue("@maxteher", kishaszonGepjarmu.MaxTeher);
                        command.ExecuteNonQuery();
                    }
                }
                command.Transaction.Commit();
            }
            catch (Exception ex)
            {
                try
                {
                    command.Transaction.Rollback();
                }
                catch (Exception e)
                {
                    throw new ABKivetel("Végzetes hiba történt! A tranzakció visszavonása sikertelen volt!", e);
                }
                throw new ABKivetel("Nem sikerült módosítani a jármű adatait az adatbázisban!", ex);
            }
        }

        public static void KolcsonzoTorles(Kolcsonzo kolcsonzo)
        {
            try
            {
                command.Parameters.Clear();
                command.Transaction = connection.BeginTransaction();
                {
                    command.Parameters.AddWithValue("@megnevezes", kolcsonzo.Megnevezes);
                    command.Parameters.AddWithValue("@cim", kolcsonzo.Cim);
                    foreach (string tabla in new string[] { "KishaszonGepjarmuvek", "SzemelyGepjarmuvek" })
                    {
                        command.CommandText = $@"
                            DELETE FROM `{tabla}`
                                WHERE `Rendszam` IN (
                                    SELECT `Rendszam` FROM `Jarmuvek` 
                                    WHERE `KolcsonzoMegnevezes` = @megnevezes AND `KolcsonzoCim` = @cim);";
                        command.ExecuteNonQuery();
                    }

                    command.CommandText = @"
                        DELETE FROM `Jarmuvek`
                            WHERE `KolcsonzoMegnevezes` = @megnevezes AND `KolcsonzoCim` = @cim;";
                    command.ExecuteNonQuery();

                    // command.CommandText = @"
                    //    DELETE `J`, `S`, `H`
                    //        FROM `Jarmuvek` AS `J`
                    //        LEFT JOIN `SzemelyGepjarmuvek` AS `S` ON `J`.`Rendszam` = `S`.`Rendszam`
                    //        LEFT JOIN `KishaszonGepjarmuvek` AS `H` ON `J`.`Rendszam` = `H`.`Rendszam`
                    //        WHERE `J`.`KolcsonzoMegnevezes` = @megnevezes AND `KolcsonzoCim` = @cim);";
                    // command.Parameters.AddWithValue("@megnevezes", kolcsonzo.Megnevezes);
                    // command.Parameters.AddWithValue("@cim", kolcsonzo.Cim);
                    // command.ExecuteNonQuery();

                    command.CommandText = @"
                        DELETE FROM `Kolcsonzok`
                            WHERE `Megnevezes` = @megnevezes AND `Cim` = @cim;";
                    command.ExecuteNonQuery();
                }
                command.Transaction.Commit();
            }
            catch (Exception ex)
            {
                try
                {
                    command.Transaction.Rollback();
                }
                catch (Exception e)
                {
                    throw new ABKivetel("Végzetes hiba történt! A tranzakció visszavonása sikertelen volt!", e);
                }
                throw new ABKivetel("Nem sikerült törölni a kölcsönzőt az adatbázisból!", ex);
            }
        }

        public static void JarmuTorles(Jarmu jarmu)
        {
            try
            {
                command.Parameters.Clear();
                command.Transaction = connection.BeginTransaction();
                {
                    command.Parameters.AddWithValue("@rendszam", jarmu.Rendszam);
                    command.CommandText = $@"
                            DELETE FROM {((jarmu is SzemelyGepjarmu) ? "`SzemelyGepjarmuvek`" : "`KishaszonGepjarmuvek`")} 
                                WHERE `Rendszam` = @rendszam;";
                    command.ExecuteNonQuery();

                    command.CommandText = @"
                        DELETE FROM `Jarmuvek`
                            WHERE `Rendszam` = @rendszam;";
                    command.ExecuteNonQuery();
                }
                command.Transaction.Commit();
            }
            catch (Exception ex)
            {
                try
                {
                    command.Transaction.Rollback();
                }
                catch (Exception e)
                {
                    throw new ABKivetel("Végzetes hiba történt! A tranzakció visszavonása sikertelen volt!", e);
                }
                throw new ABKivetel("Nem sikerült törölni a járművet az adatbázisból!", ex);
            }
        }
    }
}
