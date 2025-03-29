using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Dominio.Entidades;

namespace SistemaVenda.Dominio.Entidades
{
    public class Venda : EntityBase
    {
        public DateTime Data { get; set; }
        public decimal Total { get; set; }

        [ForeignKey("Cliente")]
        public int CodigoCliente { get; set; }

        public Cliente Cliente { get; set; }

        public ICollection<VendaProdutos> Produtos { get; set; }

    }
}
