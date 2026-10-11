using System;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.IO;
using DotNetEnv;
using Npgsql;

namespace ProjetoExtensionista2026_2.SQL
{
    public class Connection
    {
        // fallback para SQL Server caso SUPABASE_CONNECTION não exista
        private readonly string fallbackConnectionString = "Server=localhost;Database=PE20262;Integrated Security=True;TrustServerCertificate=True;";

        public bool TestConnection()
        {
            // tenta carregar .env (se DotNetEnv estiver disponível)
            try { Env.Load(); } catch { /* ignorar se falhar */ }

            // 1) tentar variável de ambiente
            var conn = Environment.GetEnvironmentVariable("SUPABASE_CONNECTION");

            // 2) se não encontrada, tentar arquivo .env na pasta de saída
            if (string.IsNullOrWhiteSpace(conn))
            {
                var envPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, ".env");
                if (File.Exists(envPath))
                {
                    foreach (var line in File.ReadAllLines(envPath))
                    {
                        var trimmed = line.Trim();
                        if (trimmed.StartsWith("SUPABASE_CONNECTION=", StringComparison.OrdinalIgnoreCase))
                        {
                            conn = trimmed.Substring(trimmed.IndexOf('=') + 1).Trim();
                            break;
                        }
                    }
                }
            }

            if (!string.IsNullOrWhiteSpace(conn))
            {
                // normaliza "Server=" para "Host=" (Npgsql espera Host)
                conn = Regex.Replace(conn, "(?i)\\bServer=", "Host=");

                var builder = new NpgsqlConnectionStringBuilder(conn);
                if (string.IsNullOrWhiteSpace(builder.Host))
                    throw new ArgumentException("Host can't be null. Defina 'Host' na connection string SUPABASE_CONNECTION.");

                using (var npg = new NpgsqlConnection(builder.ConnectionString))
                {
                    npg.Open();
                    npg.Close();
                }

                return true;
            }

            // fallback para SQL Server existente
            using (SqlConnection conexao = new SqlConnection(fallbackConnectionString))
            {
                try
                {
                    conexao.Open();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }
    }
}
