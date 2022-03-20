using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;

namespace ednevnik
{
    class Konekcija
    {
        static public SqlConnection connect()
        {
            string CS;
            CS = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            SqlConnection veza = new SqlConnection(CS);
            return veza;
        }

    }
}
