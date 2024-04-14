using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace АРМ_Швейная_фабрика
{
    class DB
    {
        SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\D диск\АРМ швейная фабрика\АРМ Швейная фабрика\DB.mdf;Integrated Security=True");
        //C:\Users\corte\OneDrive\Магистратура\Программирование\Информационная система «Портфолио ППС кафедры»\PPS\DB.mdf
        public void CloseConnection()
        {
            if (connection.State != System.Data.ConnectionState.Closed) connection.Close();
        }

        public void OpenConnection()
        {
            if (connection.State != System.Data.ConnectionState.Open) connection.Open();
        }

        public SqlConnection GetConnection()
        {
            return connection;
        }
    }
}
