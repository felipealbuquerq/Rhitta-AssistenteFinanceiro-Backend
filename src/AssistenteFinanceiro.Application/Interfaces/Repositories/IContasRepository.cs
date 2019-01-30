using AssistenteFinanceiro.Domain.Model;

namespace AssistenteFinanceiro.Application.Interfaces.Repositories
{
    public interface IContasRepository
    {
        void AdicionarConta(Conta conta);
    }
}
