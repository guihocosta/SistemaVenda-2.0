using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistemaVenda.Dominio.Entidades;

namespace Dominio.Interfaces
{
    public interface IServicoCategoria
    {
        IEnumerable<Categoria> Listagem();
        void Cadastrar(Categoria categoria);
        Categoria CarregarRegistro(int id);
        void Excluir(int id);
    }
}
