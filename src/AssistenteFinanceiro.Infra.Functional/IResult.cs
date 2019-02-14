namespace AssistenteFinanceiro.Infra.Functional
{
    public interface IResult
    {
        bool IsFailure { get; }
        bool IsSuccess  { get; }
    }
}
