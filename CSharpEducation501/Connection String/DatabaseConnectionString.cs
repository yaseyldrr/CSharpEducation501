using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpEducation501.Connection_String
{
    public static class DatabaseConnectionString
    {
        public static void SQLDatabaseConnectionString() {
            SqlConnection connection = new SqlConnection(
            "Data Source=;YASEMONSTER\\MSSQLSERVER01" +
            "Initial Catalog=Education501DB;" +
            "Integrated Security=True");
    }
    }
}
