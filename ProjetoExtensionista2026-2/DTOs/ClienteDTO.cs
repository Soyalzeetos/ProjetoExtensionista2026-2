using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoExtensionista2026_2.DTOs
{
    public class ClienteDTO
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public string Apelido { get; set; }
        public string CpfCnpj { get; set; }
        public string RgIe { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public string Cep { get; set; }
        public string Rua { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Uf { get; set; }
        public decimal LimiteCredito { get; set; }
        public bool Ativo { get; set; }
        public string Observacoes { get; set; }
    }
}

