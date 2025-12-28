using MySql.Data.MySqlClient;
using System;
using System.Configuration;
using Vizsgaremek_Szallashelyek.AccommodationProfileDLL;

namespace Vizsgaremek_Szallashelyek
{
    static internal class Repositories
    {
        private static MySqlConnection connection;
        private static MySqlCommand command;


        static Repositories()
        {
            try
            {
                connection = new MySqlConnection(ConfigurationManager.ConnectionStrings["SzallashelyekDB"].ConnectionString);
                connection.Open();
                command = new MySqlCommand();
                command.Connection = connection;
            }
            catch (Exception ex)
            {
                Log.Append(ex);
                throw new DBExceptions("Nem sikerűlt csatlakozni az adatbázishoz!", ex);
            }
        }


        static internal void CloseConnection()
        {
            try
            {
                connection.Close();
                command = null;
            }
            catch (Exception ex)
            {
                Log.Append(ex);
                throw new DBExceptions("Nem sikerűlt bontani az adatbázis kapcsolatot!", ex);
            }
        }

        static internal void InsertAccommodation(Accommodation accommodation)
        {
            try
            {
                command.Parameters.Clear();
                command.Transaction = connection.BeginTransaction();
                {
                    //store the address
                    command.CommandText = @"
                        INSERT INTO `Address` (`ZipCode`, `City`, `Street`, `Housenumber`)
                            VALUES (@zipcode, @city, @street, @housenumber);
                        SELECT LAST_INSERT_ID();";
                    command.Parameters.AddWithValue("@zipcode", accommodation.Address.ZipCode);
                    command.Parameters.AddWithValue("@city", accommodation.Address.City);
                    command.Parameters.AddWithValue("@street", accommodation.Address.City);
                    command.Parameters.AddWithValue("@housenumber", accommodation.Address.HouseNumber);
                    accommodation.Address.Id = Convert.ToInt32(command.ExecuteScalar());

                    //store the accomodation
                    command.Parameters.Clear();
                    command.CommandText = @"
                        INSERT INTO `Accommodation` (`Id`, `Name`, `Profile`, `AddressId`)
                            VALUES (@id, @name, @profile, @addressid);";
                    command.Parameters.AddWithValue("@id", accommodation.Id);
                    command.Parameters.AddWithValue("@name", accommodation.Name);
                    command.Parameters.AddWithValue("@profile", accommodation.Profile.ToString());
                    command.Parameters.AddWithValue("@addressid", accommodation.Address.Id);
                    command.ExecuteNonQuery();

                    if (accommodation is Camping)
                    {
                        //store to camping
                        command.Parameters.Clear();
                        command.CommandText = @"
                            INSERT INTO `Camping` (`CampingId`, `AtWaterfront`)
                                VALUES (@campingid, @atwaterfront);";
                        command.Parameters.AddWithValue("@campingid", accommodation.Id);
                        command.Parameters.AddWithValue("@atwaterfront", ((Camping)accommodation).AtWaterfront);
                        command.ExecuteNonQuery();
                    }
                    else
                    {
                        //store to building
                        command.Parameters.Clear();
                        command.CommandText = @"
                            INSERT INTO `Building` (`BuildingId`, `BasePrice`, `Stars`)
                                VALUES (@buildingid, @baseprice, @stars);";
                        command.Parameters.AddWithValue("@buildingid", accommodation.Id);
                        command.Parameters.AddWithValue("@baseprice", ((Building)accommodation).BasePrice);
                        command.Parameters.AddWithValue("@stars", ((Building)accommodation).Stars);
                        command.ExecuteNonQuery();
                        if (accommodation is Guesthouse)
                        {
                            //store to Guesthouse
                            command.Parameters.Clear();
                            command.CommandText = @"
                                INSERT INTO `Guesthouse` (`GuesthouseId`, `HasBreakfast`)
                                    VALUES (@guesthouseid, @hasbreakfast);";
                            command.Parameters.AddWithValue("@guesthouseid", accommodation.Id);
                            command.Parameters.AddWithValue("@hasbreakfast", ((Guesthouse)accommodation).HasBreakfast);
                            command.ExecuteNonQuery();
                        }
                        else
                        {
                            //store to Hotel
                            command.Parameters.Clear();
                            command.CommandText = @"
                                INSERT INTO `Hotel` (`HotelId`, `HasWellness`)
                                    VALUES (@hotelid, @haswellness);";
                            command.Parameters.AddWithValue("@hotelid", accommodation.Id);
                            command.Parameters.AddWithValue("@haswellness", ((Hotel)accommodation).HasWellness);
                            command.ExecuteNonQuery();
                        }
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
                    Log.Append(ex);
                    throw new DBExceptions("Végzetes hiba történt! A hozzáadás tranzakció lezárása sikertelen!", e);
                }
                Log.Append(ex);
                throw new DBExceptions("Nem sikerűlt új szálláshelyet felvenni az adatbázisba!", ex);
            }
        }

        static internal void UpdateAccommodation(Accommodation accommodation)
        {
            try
            {
                command.Parameters.Clear();
                command.Transaction = connection.BeginTransaction();
                {
                    //update the address
                    command.CommandText = @"
                        UPDATE `Address` 
                            SET `ZipCode` = @zipcode,
                                `City` = @city,
                                `Street` = @street,
                                `Housenumber` = @housenumber
                            WHERE `Id` = @id;";
                    command.Parameters.AddWithValue("@id", accommodation.Address.Id);
                    command.Parameters.AddWithValue("@zipcode", accommodation.Address.ZipCode);
                    command.Parameters.AddWithValue("@city", accommodation.Address.City);
                    command.Parameters.AddWithValue("@street", accommodation.Address.Street);
                    command.Parameters.AddWithValue("@housenumber", accommodation.Address.HouseNumber);
                    command.ExecuteNonQuery();

                    //update the accomodation
                    command.Parameters.Clear();
                    command.CommandText = @"
                        UPDATE `Accommodation`
                            SET `Name` = @name,
                                `Profile` = @profile
                            WHERE `Id` = @id;";
                    command.Parameters.AddWithValue("@id", accommodation.Id);
                    command.Parameters.AddWithValue("@name", accommodation.Name);
                    command.Parameters.AddWithValue("@profile", accommodation.Profile.ToString());
                    command.ExecuteNonQuery();

                    if (accommodation is Camping)
                    {
                        //update in camping
                        command.Parameters.Clear();
                        command.CommandText = @"
                            UPDATE `Camping`
                                SET `AtWaterfront` = @atwaterfront
                                WHERE `CampingId` = @campingid;";
                        command.Parameters.AddWithValue("@campingid", accommodation.Id);
                        command.Parameters.AddWithValue("@atwaterfront", ((Camping)accommodation).AtWaterfront);
                        command.ExecuteNonQuery();
                    }
                    else
                    {
                        //update in building
                        command.Parameters.Clear();
                        command.CommandText = @"
                            UPDATE `Building`
                                SET `BasePrice` = @baseprice,
                                    `Stars` = @stars
                                WHERE `BuildingId` = @buildingid;";
                        command.Parameters.AddWithValue("@buildingid", accommodation.Id);
                        command.Parameters.AddWithValue("@baseprice", ((Building)accommodation).BasePrice);
                        command.Parameters.AddWithValue("@stars", ((Building)accommodation).Stars);
                        command.ExecuteNonQuery();
                        if (accommodation is Guesthouse)
                        {
                            //update in Guesthouse
                            command.Parameters.Clear();
                            command.CommandText = @"
                                UPDATE `Guesthouse`
                                    SET  `HasBreakfast` = @hasbreakfast
                                    WHERE `GuesthouseId` = @guesthouseid;";
                            command.Parameters.AddWithValue("@guesthouseid", accommodation.Id);
                            command.Parameters.AddWithValue("@hasbreakfast", ((Guesthouse)accommodation).HasBreakfast);
                            command.ExecuteNonQuery();
                        }
                        else
                        {
                            //update in Hotel
                            command.Parameters.Clear();
                            command.CommandText = @"
                                UPDATE `Hotel` 
                                    SET `HasWellness` = @haswellness
                                    WHERE `HotelId` = @hotelid;";
                            command.Parameters.AddWithValue("@hotelid", accommodation.Id);
                            command.Parameters.AddWithValue("@haswellness", ((Hotel)accommodation).HasWellness);
                            command.ExecuteNonQuery();
                        }
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
                    Log.Append(ex);
                    throw new DBExceptions("Végzetes hiba történt! A módosítás tranzakció lezárása sikertelen!", e);
                }
                Log.Append(ex);
                throw new DBExceptions("Nem sikerűlt a szálláshely adatait módosítani a adatbázisban!", ex);
            }
        }

        static internal void DeleteAccommodation(Accommodation accommodation)
        {
            try
            {
                command.Parameters.Clear();
                command.Transaction = connection.BeginTransaction();
                {
                    if (accommodation is Camping)
                    {
                        //delelte from camping
                        command.CommandText = @"
                            DELETE FROM `Camping`
                                WHERE `CampingId` = @campingid;";
                        command.Parameters.AddWithValue("@campingid", accommodation.Id);
                        command.ExecuteNonQuery();
                    }
                    else
                    {
                        if (accommodation is Guesthouse)
                        {
                            //delete from Guesthouse
                            command.Parameters.Clear();
                            command.CommandText = @"
                                DELETE FROM `Guesthouse`
                                    WHERE `GuesthouseId` = @guesthouseid;";
                            command.Parameters.AddWithValue("@guesthouseid", accommodation.Id);
                            command.ExecuteNonQuery();
                        }
                        else
                        {
                            //delete from Hotel
                            command.Parameters.Clear();
                            command.CommandText = @"
                                DELETE FROM `Hotel` 
                                    WHERE `HotelId` = @hotelid;";
                            command.Parameters.AddWithValue("@hotelid", accommodation.Id);
                            command.ExecuteNonQuery();
                        }
                        //delete from Building
                        command.Parameters.Clear();
                        command.CommandText = @"
                            DELETE FROM `Building`
                                WHERE `BuildingId` = @buildingid;";
                        command.Parameters.AddWithValue("@buildingid", accommodation.Id);
                        command.ExecuteNonQuery();
                    }
                    //delete from Accomodation
                    command.Parameters.Clear();
                    command.CommandText = @"
                        DELETE FROM `Accommodation`
                            WHERE `Id` = @id;";
                    command.Parameters.AddWithValue("@id", accommodation.Id);
                    command.ExecuteNonQuery();

                    //delete from Address
                    command.Parameters.Clear();
                    command.CommandText = @"
                        DELETE FROM `Address` 
                            WHERE `Id` = @id;";
                    command.Parameters.AddWithValue("@id", accommodation.Address.Id);
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
                    Log.Append(ex);
                    throw new DBExceptions("Végzetes hiba történt! A törlés tranzakció lezárása sikertelen!", e);
                }
                Log.Append(ex);
                throw new DBExceptions("Nem sikerűlt a szálláshely adatait törölni a adatbázisból!", ex);
            }
        }

        static internal AccommodationList LoadAllAccommodations()
        {
            try
            {
                AccommodationList accommodations = new AccommodationList();

                //read every Camping
                command.Parameters.Clear();
                command.CommandText = @"
                    SELECT `A`.`Id`, `A`.`Name`, `A`.`Profile`, `A`.`AddressId`, 
                           `Ad`.`ZipCode`, `Ad`.`City`, `Ad`.`Street`, `Ad`.`Housenumber`, 
                           `C`.`AtWaterfront`
	                    FROM `Accommodation` AS `A`
                        RIGHT JOIN `Camping` AS `C` ON `C`.`CampingId` = `A`.`Id`
                        LEFT JOIN `Address` AS `Ad` ON `A`.`AddressId` = `Ad`.`Id`;";
                command.ExecuteNonQuery();
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        accommodations.Add(new Camping(
                            reader.GetString("Id"),
                            reader.GetString("Name"),
                            (AccommodationProfile)Enum.Parse(typeof(AccommodationProfile), reader.GetString("Profile")),
                            new Address(
                                reader.GetInt32("AddressId"),
                                reader.GetInt16("ZipCode"),
                                reader.GetString("City"),
                                reader.GetString("Street"),
                                reader.GetString("Housenumber")
                                ),
                            reader.GetBoolean("AtWaterfront")
                            )
                        );
                    }
                }

                //read every Guesthouse
                command.Parameters.Clear();
                command.CommandText = @"
                    SELECT `A`.`Id`, `A`.`Name`, `A`.`Profile`, `A`.`AddressId`, 
                           `Ad`.`ZipCode`, `Ad`.`City`, `Ad`.`Street`, `Ad`.`Housenumber`, 
                           `B`.`BasePrice`, `B`.`Stars`, 
                           `G`.`HasBreakfast`
	                    FROM `Accommodation` AS `A`
                        RIGHT JOIN `Building` AS `B` ON `B`.`BuildingId` = `A`.`Id`
                        RIGHT JOIN `Guesthouse` AS `G` ON `G`.`GuesthouseId` = `B`.`BuildingId`
                        LEFT JOIN `Address` AS `Ad` ON `A`.`AddressId` = `Ad`.`Id`;";
                command.ExecuteNonQuery();
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        accommodations.Add(new Guesthouse(
                            reader.GetString("Id"),
                            reader.GetString("Name"),
                            (AccommodationProfile)Enum.Parse(typeof(AccommodationProfile), reader.GetString("Profile")),
                            new Address(
                                reader.GetInt32("AddressId"),
                                reader.GetInt16("ZipCode"),
                                reader.GetString("City"),
                                reader.GetString("Street"),
                                reader.GetString("Housenumber")
                                ),
                            reader.GetFloat("BasePrice"),
                            reader.GetByte("Stars"),
                            reader.GetBoolean("HasBreakfast")
                            )
                        );
                    }
                }

                //read every Hotel
                command.Parameters.Clear();
                command.CommandText = @"
                    SELECT `A`.`Id`, `A`.`Name`, `A`.`Profile`, `A`.`AddressId`, 
                           `Ad`.`ZipCode`, `Ad`.`City`, `Ad`.`Street`, `Ad`.`Housenumber`, 
                           `B`.`BasePrice`, `B`.`Stars`, 
                           `H`.`HasWellness`
	                    FROM `Accommodation` AS `A`
                        RIGHT JOIN `Building` AS `B` ON `B`.`BuildingId` = `A`.`Id`
                        RIGHT JOIN `Hotel` AS `H` ON `H`.`HotelId` = `B`.`BuildingId`
                        LEFT JOIN `Address` AS `Ad` ON `A`.`AddressId` = `Ad`.`Id`;";
                command.ExecuteNonQuery();
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        accommodations.Add(new Hotel(
                            reader.GetString("Id"),
                            reader.GetString("Name"),
                            (AccommodationProfile)Enum.Parse(typeof(AccommodationProfile), reader.GetString("Profile")),
                            new Address(
                                reader.GetInt32("AddressId"),
                                reader.GetInt16("ZipCode"),
                                reader.GetString("City"),
                                reader.GetString("Street"),
                                reader.GetString("Housenumber")
                                ),
                            reader.GetFloat("BasePrice"),
                            reader.GetByte("Stars"),
                            reader.GetBoolean("HasWellness")
                            )
                        );
                    }
                }
                return accommodations;
            }
            catch (Exception ex)
            {
                Log.Append(ex);
                throw new DBExceptions("Nem sikerűlt a szálláshelyek adatait beolvasni az adatbázisból!", ex);
            }
        }
    }
}
