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
            int sensId = 0;
            string dtInSql = "";
            dtInSql = $"{dt.Year}-{dt.Month}-{dt.Day} {dt.Hour}:{dt.Minute}:{dt.Second}";
            if(ipa == "192.168.1.1")
            {
                sensId = 1;
            }

            if(ipa == "192.168.1.2")
            {
                sensId = 2;
            }
            //DB "2022-05-12 11:17:00"
            string insert = $"INSERT INTO klimawerte (temperature,humidity,pressure,datetime,ipa,sensId) VALUES('{t.Value}', '{h.Value}', '{p.Value}', '{dtInSql}', '{ipa}', '{sensId}')";

            cmd.CommandText = insert;
            cmd.Connection = _con;

            cmd.ExecuteNonQuery();
        }
    }
}
