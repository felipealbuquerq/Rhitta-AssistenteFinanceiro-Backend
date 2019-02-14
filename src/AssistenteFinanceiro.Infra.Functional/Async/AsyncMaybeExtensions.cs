using System.Threading.Tasks;

namespace AssistenteFinanceiro.Infra.Functional.Async
{
    public static class AsyncMaybeExtensions
    {
        public static async Task<Result<T>> ToResult<T>(this Task<Maybe<T>> maybeTask, string[] errorMessages, bool continueOnCapturedContext = true)
            where T : class
        {
            Maybe<T> maybe = await maybeTask.ConfigureAwait(continueOnCapturedContext);
            return maybe.ToResult(errorMessages);
        }
    }
}
