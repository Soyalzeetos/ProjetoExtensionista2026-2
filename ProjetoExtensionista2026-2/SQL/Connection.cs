using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace ProjetoExtensionista2026_2.SQL
{
    public class Connection
    {
        // 1. Montando o "formulário de identificação"
        string connectionString = "Server=localhost;Database=PE20262;Integrated Security=True;TrustServerCertificate=True;";

        // 2. O bloco 'using' é fundamental aqui. 
        // Ele funciona como uma porta com mola: garante que a conexão será fechada 
        // automaticamente no final, mesmo que aconteça um erro no meio do caminho.
        public bool TestConnection()
        {
            using (SqlConnection conexao = new SqlConnection(connectionString))
            {
                try
                {
                    // Tentando abrir a porta do banco
                    conexao.Open();
                    return true;
                    
                    // Aqui é onde você faria suas consultas (SELECT, INSERT, etc.)
                    
                }
                catch (Exception)
                {
                    // Se o porteiro barrar, ele avisa o motivo aqui
                    return false;
                }
            }
        }
    }
}
