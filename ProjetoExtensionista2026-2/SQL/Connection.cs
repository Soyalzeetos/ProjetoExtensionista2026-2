using DotNetEnv;
using Microsoft.IdentityModel.Protocols;
using Npgsql;
using System;
using System.Configuration;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace ProjetoExtensionista2026_2.SQL
{
    public class Connection
    {
        public static bool TestConnection()
        {
            DotNetEnv.Env.Load();
            var connString = Environment.GetEnvironmentVariable("SUPABASE_CONNECTION");
            if (string.IsNullOrWhiteSpace(connString))
                throw new ArgumentException("SUPABASE_CONNECTION está nula ou vazia.");


            connString = Regex.Replace(connString, "Server=", "Host=", RegexOptions.IgnoreCase);

            var builder = new NpgsqlConnectionStringBuilder(connString);
            if (string.IsNullOrWhiteSpace(builder.Host))
                throw new ArgumentException("Host can't be null. Defina 'Host' na connection string.");

            var conn = new NpgsqlConnection(builder.ConnectionString);
            conn.Open();
            conn.Close();
            return true;
        }
    }
}