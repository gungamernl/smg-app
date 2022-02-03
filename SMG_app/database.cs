using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;
using System.Windows;

namespace SMG_app
{
    class database
    {
        static MySqlConnection _connection = new MySqlConnection("Server = localhost; Database= smg; Uid=root; Pwd=;");

        private static DataTable select(string query)
        {


            MySqlCommand mySqlCommand = new MySqlCommand(query, _connection);

            return select(mySqlCommand);
        }
        private static void ExecuteNonQuery(MySqlCommand mySqlCommand)
        {
            try
            {
                _connection.Open();
                if (_connection.State == ConnectionState.Open)
                {
                    int rowsAffected = mySqlCommand.ExecuteNonQuery();
                    if (rowsAffected != 1)
                    {
                        MessageBox.Show("Er ging iets fout. Controleer uw internetverbinding", "Oeps", MessageBoxButton.OK);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Er ging iets fout.\r\n " + ex.Message, "Oeps", MessageBoxButton.OK);
            }
            finally
            {
                _connection.Close();
            }

        }
        public static DataTable get_nummers()
        {

            return select("SELECT * FROM `nummers` LEFT JOIN artiesten ON artiesten.artiest_id = nummers.artiest_id");
        }
        private static DataTable select(MySqlCommand mySqlCommand)
        {


            DataTable result = new DataTable();
            _connection.Open();
            if (_connection.State == ConnectionState.Open)
            {

                try
                {
                    MySqlDataReader reader = mySqlCommand.ExecuteReader();

                    result.Load(reader);
                }
                catch (Exception)
                {
                    MessageBox.Show("er ging iets fout. controleer uw internetverbinding", "oeps", MessageBoxButton.OK);
                }
            }


            _connection.Close();
            return result;

        }
        //UPDATE `nummers` SET `nummer_link`="https://www.youtube.com/embed/aqrr3Dj_Jn8",`nummer_naam`="chasing" WHERE `nummer_id` = '8'

        public static void updatenummer(string nummerlink, string nummernaam, string nummerid)

        {

            MySqlCommand mysqlcommand = new MySqlCommand("UPDATE `nummers` SET `nummer_link`=@nummerlink,`nummer_naam`=@nummernaam WHERE `nummer_id` = @nummerid", _connection);
            mysqlcommand.Parameters.AddWithValue("@nummerlink", nummerlink);
            mysqlcommand.Parameters.AddWithValue("@nummernaam", nummernaam);
            mysqlcommand.Parameters.AddWithValue("@nummerid", nummerid);

            ExecuteNonQuery(mysqlcommand);
        }
        //SELECT * FROM `gebruikers` WHERE `gebruikersnaam` = 'admin' AND `wachtwoord` = '1234'
        public static bool login(string gebruikersnaam, string wachtwoord)
        {
            bool result = false;
            _connection.Open();
            if (_connection.State == ConnectionState.Open)
            {

                try
                {
                    MySqlCommand mysqlcommand = new MySqlCommand("SELECT COUNT(*) FROM `gebruikers` WHERE `gebruikersnaam` = @gebruikersnaam AND `wachtwoord` = @wachtwoord AND `rechten`=1", _connection);
                    mysqlcommand.Parameters.AddWithValue("@gebruikersnaam", gebruikersnaam);
                    mysqlcommand.Parameters.AddWithValue("@wachtwoord", wachtwoord);

                    long count = (long)mysqlcommand.ExecuteScalar();
                    if (count==1)
                    {
                        result = true;
                    }
               
                }
                catch (Exception)
                {
                    MessageBox.Show("er ging iets fout. controleer uw internetverbinding", "oeps", MessageBoxButton.OK);
                }
            }


            _connection.Close();
            return result;         
        }
        public static void insertnummer(string nummerlink, string nummernaam)

        //UPDATE `student` SET `student_id`=[value-1],`student_naam`=[value-2]
        {


            MySqlCommand mysqlcommand = new MySqlCommand("INSERT INTO `nummers`(`nummer_id`, `nummer_link`, `nummer_naam`, `artiest_id`) VALUES (	NULL,@nummerlink,@nummernaam,NULL)",_connection);
            mysqlcommand.Parameters.AddWithValue("@nummerlink", nummerlink);
            mysqlcommand.Parameters.AddWithValue("@nummernaam", nummernaam);

            ExecuteNonQuery(mysqlcommand);
        }
        public static void deletenummer(string nummerid)

        //UPDATE `student` SET `student_id`=[value-1],`student_naam`=[value-2]
        {

            MySqlCommand mysqlcommand = new MySqlCommand("DELETE FROM `nummers` WHERE `nummer_id` = @nummerid", _connection);
            mysqlcommand.Parameters.AddWithValue("@nummerid", nummerid);

            
            ExecuteNonQuery(mysqlcommand);

        }
        public static DataTable getongekoppeldnummer()
        {
            MySqlCommand mySqlCommand = new MySqlCommand("SELECT * FROM `nummers` WHERE `artiest_id` IS NULL", _connection);
            return select(mySqlCommand);
        }
        public static DataTable getartiesten()
        {
            MySqlCommand mySqlCommand = new MySqlCommand("SELECT * FROM `artiesten`", _connection);
            return select(mySqlCommand);
        }
        public static DataTable get_gekoppeld(string artiest_id)
        {

            //MySqlCommand mysqlcommand = new MySqlCommand("SELECT * FROM `nummers` INNER JOIN artiesten ON artiesten.artiest_id = nummers.artiest_id WHERE artiesten.artiest_id = @artiestid;");
            MySqlCommand mysqlcommand = new MySqlCommand("SELECT * FROM `nummers` INNER JOIN artiesten ON artiesten.artiest_id = nummers.artiest_id WHERE artiesten.artiest_id = @artiestid;", _connection);

            mysqlcommand.Parameters.AddWithValue("@artiestid", artiest_id);
            return select(mysqlcommand);
        }
        //UPDATE `nummers` SET `artiest_id` = NULL WHERE `nummers`.`nummer_id` = 22;
        public static void ontkoppel_nummer(string nummerid)

        {

            MySqlCommand mysqlcommand = new MySqlCommand("UPDATE `nummers` SET `artiest_id` = NULL WHERE `nummers`.`nummer_id` = @nummerid;", _connection);

            mysqlcommand.Parameters.AddWithValue("@nummerid", nummerid);

            ExecuteNonQuery(mysqlcommand);
        }
        public static void koppel_nummer(string nummerid, string artiestid)

        {

            MySqlCommand mysqlcommand = new MySqlCommand("UPDATE `nummers` SET `artiest_id` = @artiestid WHERE `nummers`.`nummer_id` = @nummerid;", _connection);

           
            mysqlcommand.Parameters.AddWithValue("@nummerid", nummerid);
            mysqlcommand.Parameters.AddWithValue("@artiestid", artiestid);


            ExecuteNonQuery(mysqlcommand);
        }
        public static void updateartiest(string artiestnaam, string artiestfoto, string artiestinfo, string artiestlink, string artiestid)

        {

            MySqlCommand mysqlcommand = new MySqlCommand("UPDATE `artiesten` SET `artiest_naam`=@artiestnaam,`artiestfoto`=@artiestfoto,`info_artiest`=@artiestinfo,`artiest_link`=@artiestlink WHERE `artiest_id` = @artiestid;", _connection);
            mysqlcommand.Parameters.AddWithValue("@artiestnaam", artiestnaam);
            mysqlcommand.Parameters.AddWithValue("@artiestfoto", artiestfoto);
            mysqlcommand.Parameters.AddWithValue("@artiestinfo", artiestinfo);
            mysqlcommand.Parameters.AddWithValue("@artiestlink", artiestlink);
            mysqlcommand.Parameters.AddWithValue("@artiestid", artiestid);



            ExecuteNonQuery(mysqlcommand);
        }
        public static void insertartiest(string artiestnaam, string artiestfoto, string artiestinfo, string artiestlink)

        {


            MySqlCommand mysqlcommand = new MySqlCommand("INSERT INTO `artiesten`(`artiest_id`, `artiest_naam`, `artiestfoto`, `info_artiest`, `artiest_link`) VALUES (NULL, @artiestnaam,@artiestfoto,@artiestinfo,@artiestlink)", _connection);
            mysqlcommand.Parameters.AddWithValue("@artiestnaam", artiestnaam);
            mysqlcommand.Parameters.AddWithValue("@artiestfoto", artiestfoto);
            mysqlcommand.Parameters.AddWithValue("@artiestinfo", artiestinfo);
            mysqlcommand.Parameters.AddWithValue("@artiestlink", artiestlink);
            ExecuteNonQuery(mysqlcommand);
        }
        //deleteartiest
        public static void deleteartiest(string artiestid)

        //UPDATE `student` SET `student_id`=[value-1],`student_naam`=[value-2]
        {

            MySqlCommand mysqlcommand = new MySqlCommand("DELETE FROM `artiesten` WHERE `artiest_id` = @artiestid", _connection);
            mysqlcommand.Parameters.AddWithValue("@artiestid", artiestid);


            ExecuteNonQuery(mysqlcommand);

        }
        public static DataTable get_gebruikers()
        {

            return select("SELECT * FROM `gebruikers`");

        }
        public static void updategebruiker(string gebruikersnaam, string voornaam, string achternaam, string email, string wachtwoord, string gebruikersid)

        {

            MySqlCommand mysqlcommand = new MySqlCommand("UPDATE `gebruikers` SET `gebruikersnaam`=@gebruikersnaam,`voornaam`=@voornaam,`achternaam`=@achternaam,`email`=@email,`wachtwoord`=@wachtwoord WHERE `gebruiker_id` = @gebruikersid;", _connection);
            mysqlcommand.Parameters.AddWithValue("@gebruikersnaam", gebruikersnaam);
            mysqlcommand.Parameters.AddWithValue("@voornaam", voornaam);
            mysqlcommand.Parameters.AddWithValue("@achternaam", achternaam);
            mysqlcommand.Parameters.AddWithValue("@email", email);
            mysqlcommand.Parameters.AddWithValue("@wachtwoord", wachtwoord);
            mysqlcommand.Parameters.AddWithValue("@gebruikersid", gebruikersid);




            ExecuteNonQuery(mysqlcommand);
        }
        public static void deletegebruiker(string gebruikersid)

        //UPDATE `student` SET `student_id`=[value-1],`student_naam`=[value-2]
        {

            MySqlCommand mysqlcommand = new MySqlCommand("DELETE FROM `gebruikers` WHERE `gebruiker_id` = @gebruikersid", _connection);
            mysqlcommand.Parameters.AddWithValue("@gebruikersid", gebruikersid);


            ExecuteNonQuery(mysqlcommand);

        }
        public static void insertgebruiker(string gebruikersnaam, string voornaam, string achternaam, string email, string wachtwoord)

        {


            MySqlCommand mysqlcommand = new MySqlCommand("INSERT INTO `gebruikers`(`gebruiker_id`, `gebruikersnaam`, `voornaam`, `achternaam`, `email`, `wachtwoord`) VALUES (NULL, @gebruikersnaam,@voornaam,@achternaam,@email,@wachtwoord)", _connection);
            mysqlcommand.Parameters.AddWithValue("@gebruikersnaam", gebruikersnaam);
            mysqlcommand.Parameters.AddWithValue("@voornaam", voornaam);
            mysqlcommand.Parameters.AddWithValue("@achternaam", achternaam);
            mysqlcommand.Parameters.AddWithValue("@email", email);
            mysqlcommand.Parameters.AddWithValue("@wachtwoord", wachtwoord);
            ExecuteNonQuery(mysqlcommand);
        }

    }   

}
