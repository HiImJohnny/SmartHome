using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace UniversalServer.Model
{
    public delegate EventHandler ErrorEventHandler(string msg);
    public class DBAccess
    {
        MySqlConnection _con;

        public DBAccess()
        {
            //Hier die Verbindung zur DB herstellen. Siehe Info-Pool
            //Verbindungsdaten dürfen "hard codiert" werden.
            _con = new MySqlConnection(@"SERVER = 127.0.0.1;DATABASE=Test;PORT=3306;UID=root;");
           
            _con.Open();
        }

        ///Diese Methode für den Datensatz in die Datenbank ein. Siehe Info-Pool      
        public void InsertData(TempValue t, HumidValue h, PressureValue p, DateTime dt, string ipa)
        {
            MySqlCommand cmd = new MySqlCommand(); 

            string insert = "INSERT INTO person (id,name) VALUES('1','Patrick')";

            cmd.CommandText = insert;
            cmd.Connection = _con;

            cmd.ExecuteNonQuery();
        }
    }
}
