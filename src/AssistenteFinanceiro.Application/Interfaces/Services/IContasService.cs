using AssistenteFinanceiro.Domain.Model;
using AssistenteFinanceiro.Infra.SharedKernel.Command;
using InsurSoft.Backend.Shared.Functional;

namespace AssistenteFinanceiro.Application.Interfaces.Services
{
    public interface IContasService
    {
        Result CriarConta(ICommand<Conta> command);
    }
}
