using SistemaVenda.Models;

namespace Aplicacao.Servico.Interfaces
{
    public interface IServicoAplicacaoCategoria
    {
        IEnumerable<CategoriaViewModel> Listagem();

    }
}
