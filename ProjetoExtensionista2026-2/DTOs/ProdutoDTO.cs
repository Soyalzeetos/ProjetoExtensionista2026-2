using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoExtensionista2026_2
{
    public class ProdutoDTO
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public decimal PrecoCompra { get; set; }
        public decimal PrecoVenda { get; set; }
        public string Localizacao { get; set; }
        public int Estoque { get; set; }
        public int EstoqueMinimo { get; set; }
        public string Unidade { get; set; }
        public string Categoria { get; set; }
        public string Fornecedor { get; set; }
        public bool Ativo { get; set; }
        public string FotoUrl { get; set; }
    }
}
