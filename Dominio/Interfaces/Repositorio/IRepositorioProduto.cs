using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repositorio;
using SistemaVenda.Dominio.Entidades;

namespace Dominio.Interfaces.Repositorio
{
    public interface IRepositorioProduto : IRepositorio<Produto>
        
    {
        new IEnumerable<Produto> Read();
    }
}
