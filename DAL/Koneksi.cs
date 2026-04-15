using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Ucp_pabd_lab.DAL
{
    internal class Koneksi
    {
        private string stringKoneksi = "Data Source=DESKTOP-2Q8C9J6;Initial Catalog=DBLabSekolah;Integrated Security=True";
        
        public SqlConnection GetConn()
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = stringKoneksi;
            return conn;
        }
    }
}
