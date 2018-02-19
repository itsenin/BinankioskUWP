using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinanKiosk.Repository
{
    public class RepositoryBase
    {
        private MySqlConnection connection;
        private string server;
        private string database;
        private string uid;
        private string password;
        private string port;
        private string SSLMODE;
        private string connectionString;
        private string charset;
        private MySqlCommand command;
        protected MySqlDataReader reader;
        String Message = "";

        //Constructor
        public RepositoryBase()
        {
            Initialize();
        }

        //Initialize values
        private void Initialize()
        {
            server = "localhost";
            database = "binan_kiosk";
            uid = "root";
            port = "3306";
            password = " ";
            SSLMODE = "None";
            charset = "utf8";
            connectionString = "server= " + server + ";" + "user= " + uid + ";" + " database= " + database +
                ";" + " port= " + port + ";" + " password= " + password + ";" + " SslMode= " + SSLMODE + ";" + " charset= " + charset;
            //connectionString = "SERVER=" + server + ";" + "DATABASE=" +
            //database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";" + " SslMode= " + SSLMODE;
            System.Text.EncodingProvider ppp;
            ppp = System.Text.CodePagesEncodingProvider.Instance;
            Encoding.RegisterProvider(ppp);

        }

        //Insert statement
        public int Post_or_Put(String query, Dictionary<String, Object> dictionary)
        {
            using (connection = new MySqlConnection(connectionString))
            {
                using (command = connection.CreateCommand())
                {
                    command.CommandText = query;
                    foreach (var item in dictionary)
                    {
                        command.Parameters.AddWithValue(item.Key, item.Value);
                    }
                    connection.Open();
                    return command.ExecuteNonQuery();
                }
            }
        }

        //Select statement
        public List<Object> Get(String query, Dictionary<String, Object> dictionary)
        {
            List<Object> Objects = new List<Object>();
            using (connection = new MySqlConnection(connectionString))
            {
                using (command = connection.CreateCommand())
                {
                    command.CommandText = query;
                    if (dictionary != null)
                    {
                        foreach (var item in dictionary)
                        {
                            command.Parameters.AddWithValue(item.Key.ToString(), item.Value);
                        }
                    }
                    connection.Open();
                    using (reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                Objects.Add(reader[reader.GetName(i)]);
                            }
                        }
                        return Objects;
                    }
                }
            }
        }

        //open connection to database
        public bool OpenConnection()
        {
            try
            {
                connection.Open();
                return true;
            }
            catch (MySqlException ex)
            {
                //When handling errors, you can your application's response based 
                //on the error number.
                //The two most common error numbers when connecting are as follows:
                //0: Cannot connect to server.
                //1045: Invalid user name and/or password.
                switch (ex.Number)
                {
                    case 0:
                        Message = "Cannot connect to server.  Contact administrator";
                        break;

                    case 1045:
                        Message = "Invalid username/password, please try again";
                        break;
                }
                return false;
            }
        }

        //Close connection
        public bool CloseConnection()
        {
            try
            {
                connection.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                Message = ex.Message;
                return false;
            }
        }
    }
}