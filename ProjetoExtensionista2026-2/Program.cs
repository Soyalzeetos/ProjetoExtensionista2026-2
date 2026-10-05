using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjetoExtensionista2026_2
{
    internal static class Program
    {
        /// <summary>
        /// Ponto de entrada principal para o aplicativo.
        /// </summary>
        private static string token2 = "Pablo é lindo";
        private static string senhaOriginal = "123456";

        public static bool verificarHash2(string hashSended, string token)
        {
            if (token == token2) 
            {
                if (hashSended == senhaOriginal.GetHashCode().ToString())
                {
                    MessageBox.Show("Hash correta!");
                    return true;
                }
                else
                {
                    MessageBox.Show("Hash incorreta!");
                    return false;
                }
            }
            return false;
        }

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new formLogin());
        }
    }
}
