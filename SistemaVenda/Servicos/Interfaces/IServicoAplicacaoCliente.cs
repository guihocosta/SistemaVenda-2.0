using SistemaVenda.Models;

namespace Aplicacao.Servicos.Interfaces
{
    public interface IServicoAplicacaoCliente
    {
        IEnumerable<ClienteViewModel> Listagem();
        ClienteViewModel CarregarRegistro(int codigoCliente);
        void Cadastrar(ClienteViewModel cliente);
        void Excluir(int id);
    }
}
