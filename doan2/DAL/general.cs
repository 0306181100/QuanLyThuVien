using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace DAL
{
    public class general
    {
        public SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-92BFU8UB\GIABAO;Initial Catalog=QLTV;Integrated Security=True");
        public SqlConnection Getcon()
        {
            if (ConnectionState.Closed == con.State)
                con.Open();
            return con;
        }
    }
}
