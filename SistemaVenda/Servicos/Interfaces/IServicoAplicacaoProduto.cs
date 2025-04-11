using SistemaVenda.Models;

namespace Aplicacao.Servico.Interfaces
{
    public interface IServicoAplicacaoProduto
    {
        IEnumerable<ProdutoViewModel> Listagem();

        ProdutoViewModel CarregarRegistro(int codigoProduto);
        void Cadastrar(ProdutoViewModel produto);
        void Excluir(int id);

    }
}
