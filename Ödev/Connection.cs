using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Ödev
{
    public class Connection
    {
        public SqlConnection con = new SqlConnection("Data Source=DESKTOP-IN1QIJK\\SQLEXPRESS;Initial Catalog=Northwind;Integrated Security=True");
        public SqlDataAdapter adtr { get; set; }
        public SqlCommand komut { get; set; }
        
    }
}
