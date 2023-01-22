using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Exam
{
    
    class DataBase
    {
        SqlConnection sqlConnection = new SqlConnection(@"DATA Source=LAPTOP-QEONRIHN\SQLEXPRESS;Initial Catalog=test;Integrated Security=True");

        public void openConnection()
        {
            if (sqlConnection.State == System.Data.ConnectionState.Closed)
            {
                sqlConnection.Open();
            }

        }

        public void CloseConnection()
        {
            if (sqlConnection.State == System.Data.ConnectionState.Open)
            {
                sqlConnection.Close();
            }

        }

        public SqlConnection getConnection()
        {
            return sqlConnection;
        }

    }
}
