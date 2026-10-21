using System;
using ProjetoExtensionista2026_2;

namespace ProjetoExtensionista2026_2
{
    internal class rolesClass
    {
        public void RoleSidebar(formPrincipal formPrincipal, String role, String username, String passwordHash)
        {
            formPrincipal.listBoxSidebar.Items.Clear();
            if (role == "admin")
            {
                // Admin tem acesso a todas as opções
                formPrincipal.listBoxSidebar.Items.Add("Principal");
                formPrincipal.listBoxSidebar.Items.Add("Cadastro");
                formPrincipal.listBoxSidebar.Items.Add("Vendas");
                formPrincipal.listBoxSidebar.Items.Add("Configurações");
                formPrincipal.listBoxSidebar.Items.Add("Sair");
            }
            else if (role == "seller")
            {
                // Vendedor tem acesso limitado
                formPrincipal.listBoxSidebar.Items.Add("Principal");
                formPrincipal.listBoxSidebar.Items.Add("Vendas");
                formPrincipal.listBoxSidebar.Items.Add("Configurações");
                formPrincipal.listBoxSidebar.Items.Add("Sair");
            }
            else if (role == "stocker")
            {
                // Estoque tem acesso limitado
                formPrincipal.listBoxSidebar.Items.Add("Principal");
                formPrincipal.listBoxSidebar.Items.Add("Estoque");
                formPrincipal.listBoxSidebar.Items.Add("Configurações");
                formPrincipal.listBoxSidebar.Items.Add("Sair");
            }
            else if (role == "monetary")
            {
                // Financeiro tem acesso limitado
                formPrincipal.listBoxSidebar.Items.Add("Principal");
                formPrincipal.listBoxSidebar.Items.Add("Financeiro");
                formPrincipal.listBoxSidebar.Items.Add("Configurações");
                formPrincipal.listBoxSidebar.Items.Add("Sair");
            }
            else
            {
                // Caso o papel não seja reconhecido, exibir apenas a opção de sair
                formPrincipal.listBoxSidebar.Items.Add("Sair");
            }
        }
    }
}
