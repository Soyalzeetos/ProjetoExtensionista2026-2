using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace ProjetoExtensionista2026_2.SQL.SQL_functions
{
    internal class LoginSQL
    {
        public int RegisterUser(string username, string passwordHash, string tableName = "\"Users\"")
        {
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(passwordHash))
                return -1;

            using (var conn = new ProjetoExtensionista2026_2.SQL.Connection())
            {
                conn.IniciarConexao();
                try
                {
                    using (var cmd = conn.Conexao.CreateCommand())
                    {
                        // Inserção direta do hash calculado
                        cmd.CommandText = $"INSERT INTO {tableName} (username, hash) VALUES (@u, @p) RETURNING id;";
                        cmd.Parameters.AddWithValue("u", username);
                        cmd.Parameters.AddWithValue("p", passwordHash);

                        var result = cmd.ExecuteScalar();
                        if (result != null)
                        {
                            try
                            {
                                // Tenta converter diretamente (suporta Int64 -> Int32 também)
                                return Convert.ToInt32(result);
                            }
                            catch (Exception convEx)
                            {
                                // Registro de conversão falhou; tenta parsear como fallback
                                Log(convEx);
                                MessageBox.Show(convEx.Message, "Erro de Conversão", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                if (int.TryParse(result.ToString(), out int id))
                                    return id;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Log(ex);
                    return -1;
                }
                finally
                {
                    conn.FecharConexao();
                }
            }

            return -1;
        }

        private void Log(Exception ex)
        {
            try
            {
                var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "login_sql.log");
                var text = $"[{DateTime.UtcNow:o}] {ex.GetType().FullName}: {ex.Message}\r\n{ex.StackTrace}\r\n";
                File.AppendAllText(path, text, Encoding.UTF8);
            }
            catch
            {
                // Não interrompe a execução se o log falhar
            }
        }
    }
}
