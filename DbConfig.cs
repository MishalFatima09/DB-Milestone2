using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelEase
{
    public static class DbConfig
    {
        public static string ConnectionString =>
            "Data Source=MISHALSLAPPY\\SQLEXPRESS;Initial Catalog=TravelEase;Integrated Security=True;";

      //  public static string ConnectionString =>
         //  "Data Source=ALEENA-LAPTOP\\SQLEXPRESS;Initial Catalog=TravelEase;Integrated Security=True;TrustServerCertificate=True";
    }
}