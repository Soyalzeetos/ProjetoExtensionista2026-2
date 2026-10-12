using DotNetEnv;
using Npgsql;
using System;
using System.IO;
using System.Text.RegularExpressions;

namespace ProjetoExtensionista2026_2.SQL
{
    public class Connection : IDisposable
    {
        private NpgsqlConnection _conexao;
        public static bool TestConnection()
        {
            try
            {
                string envFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, ".env");
                if (File.Exists(envFile))
                {
                    DotNetEnv.Env.Load(envFile);
                }
                else
                {
                    DotNetEnv.Env.TraversePath().Load();
                }

                var connString = Environment.GetEnvironmentVariable("SUPABASE_CONNECTION");
                if (string.IsNullOrWhiteSpace(connString))
                    return false;

                connString = Regex.Replace(connString, "Server=", "Host=", RegexOptions.IgnoreCase);

                var builder = new NpgsqlConnectionStringBuilder(connString);
                if (string.IsNullOrWhiteSpace(builder.Host))
                    return false;

                using (var conn = new NpgsqlConnection(builder.ConnectionString))
                {
                    conn.Open();
                    conn.Close();
                }

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public void IniciarConexao()
        {
            string envFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, ".env");
            if (File.Exists(envFile))
            {
                DotNetEnv.Env.Load(envFile);
            }
            else
            {
                DotNetEnv.Env.TraversePath().Load();
            }

            var connString = Environment.GetEnvironmentVariable("SUPABASE_CONNECTION");
            if (string.IsNullOrWhiteSpace(connString))
                throw new InvalidOperationException("Connection string is not set in the environment variables.");

            connString = Regex.Replace(connString, "Server=", "Host=", RegexOptions.IgnoreCase);

            var builder = new NpgsqlConnectionStringBuilder(connString);
            if (string.IsNullOrWhiteSpace(builder.Host))
                throw new InvalidOperationException("Invalid connection string: Host is missing.");
            _conexao = new NpgsqlConnection(builder.ConnectionString);
            _conexao.Open();
        }

        public void FecharConexao()
        {
            if (_conexao != null && _conexao.State == System.Data.ConnectionState.Open)
            {
                _conexao.Close();
                _conexao.Dispose();
            }
        }
        public void Dispose()
        {
            FecharConexao();
        }
    }
}