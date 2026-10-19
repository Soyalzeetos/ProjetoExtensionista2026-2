using DotNetEnv;
using Npgsql;
using System;
using System.IO;
using System.Text.RegularExpressions;

namespace ProjetoExtensionista2026_2.SQL
{
    public class Connection : IDisposable
    {
        private static string _cachedConnectionString;
        private static readonly object _lock = new object();
        public NpgsqlConnection Conexao { get; private set; }
        //public NpgsqlConnection Conexao => _conexao;
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
        private static void CarregarVariaveisAmbiente()
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
        }
        private static string ObterConnectionStringSupabase()
        {
            var rawConn = Environment.GetEnvironmentVariable("SUPABASE_CONNECTION");
            if (string.IsNullOrWhiteSpace(rawConn))
                throw new InvalidOperationException("Connection string is not set in the environment variables.");

            // Corrige sintaxe se vier com Server=
            rawConn = Regex.Replace(rawConn, @"\bServer=", "Host=", RegexOptions.IgnoreCase);

            var builder = new NpgsqlConnectionStringBuilder(rawConn);
            if (string.IsNullOrWhiteSpace(builder.Host))
                throw new InvalidOperationException("Invalid connection string: Host is missing.");

            // Parâmetros cruciais para evitar "Exception while reading from stream" no Supabase:
            builder.SslMode = SslMode.Require;
            builder.TrustServerCertificate = true;
            builder.KeepAlive = 30;              // Envia sinal periódico para o firewall/Supabase não derrubar o socket
            builder.Timeout = 15;                // Tempo máximo para negociar a abertura da conexão
            builder.CommandTimeout = 30;         // Tempo limite padrão para execução dos comandos

            // Se estiveres a usar a porta de Transaction Pooling do Supabase (porta 6543 / PgBouncer):
            // É recomendável desativar ou gerir pooling local para evitar descompasso de sockets
            // builder.Pooling = false; 

            return builder.ConnectionString;
        }

        public void IniciarConexao2()
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
            Conexao = new NpgsqlConnection(builder.ConnectionString);
            Conexao.Open();
        }
        public void IniciarConexao()
        {
            // 1. Garante que a connection string seja lida do disco e resolvida apenas uma vez
            if (string.IsNullOrEmpty(_cachedConnectionString))
            {
                lock (_lock)
                {
                    if (string.IsNullOrEmpty(_cachedConnectionString))
                    {
                        CarregarVariaveisAmbiente();
                        _cachedConnectionString = ObterConnectionStringSupabase();
                    }
                }
            }

            // 2. Abre a conexão usando a string otimizada
            Conexao = new NpgsqlConnection(_cachedConnectionString);
            Conexao.Open();
        }

        public void FecharConexao()
        {
            if (Conexao != null && Conexao.State == System.Data.ConnectionState.Open)
            {
                Conexao.Close();
                Conexao.Dispose();
            }
        }
        public void Dispose()
        {
            FecharConexao();
        }
    }
}