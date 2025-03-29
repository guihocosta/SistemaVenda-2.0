using SistemaVenda.Models;

namespace Aplicacao.Servico.Interfaces
{
    public interface IServicoAplicacaoCategoria
    {
        IEnumerable<CategoriaViewModel> Listagem();

        CategoriaViewModel CarregarRegistro(int codigoCategoria);
        void Cadastrar(CategoriaViewModel categoria);
        void Excluir(int id);

    }
}
