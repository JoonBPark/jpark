using System;
using System.Collections.Generic;
using System.Data.EntityClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OAuth2
{
    static public class DBUtils
    {
        static public string GetConnectionString(string connectionString)
        {
            EntityConnectionStringBuilder entityString = new EntityConnectionStringBuilder()
            {
                Provider = "System.Data.SqlClient",
                Metadata = "res://*/Chevron.csdl|res://*/Chevron.ssdl|res://*/Chevron.msl",
                ProviderConnectionString = connectionString
            };
            return entityString.ConnectionString;
        }
    }
}
