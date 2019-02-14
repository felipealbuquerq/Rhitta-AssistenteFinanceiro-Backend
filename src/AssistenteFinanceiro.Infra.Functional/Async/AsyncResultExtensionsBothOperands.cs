using System;
using System.Threading.Tasks;

namespace AssistenteFinanceiro.Infra.Functional.Async
{
    /// <summary>
    /// Extentions for async operations where the task appears in the both operands
    /// </summary>
    public static class AsyncResultExtensionsBothOperands
    {
        public static async Task<Result<K>> OnSuccess<T, K>(this Task<Result<T>> resultTask, Func<T, Task<K>> func, bool continueOnCapturedContext = true)
        {
            Result<T> result = await resultTask.ConfigureAwait(continueOnCapturedContext);

            if (result.IsFailure)
                return Result.Fail<K>(result.Errors);

            K value = await func(result.Value);

            return Result.Ok(value);
        }

        public static async Task<Result<T>> OnSuccess<T>(this Task<Result> resultTask, Func<Task<T>> func, bool continueOnCapturedContext = true)
        {
            Result result = await resultTask.ConfigureAwait(continueOnCapturedContext);

            if (result.IsFailure)
                return Result.Fail<T>(result.Errors);

            T value = await func().ConfigureAwait(continueOnCapturedContext);

            return Result.Ok(value);
        }

        public static async Task<Result<K>> OnSuccess<T, K>(this Task<Result<T>> resultTask, Func<T, Task<Result<K>>> func, bool continueOnCapturedContext = true)
        {
            Result<T> result = await resultTask.ConfigureAwait(continueOnCapturedContext);

            if (result.IsFailure)
                return Result.Fail<K>(result.Errors);

            return await func(result.Value);
        }

        public static async Task<Result<T>> OnSuccess<T>(this Task<Result> resultTask, Func<Task<Result<T>>> func, bool continueOnCapturedContext = true)
        {
            Result result = await resultTask.ConfigureAwait(continueOnCapturedContext);

            if (result.IsFailure)
                return Result.Fail<T>(result.Errors);

            return await func().ConfigureAwait(continueOnCapturedContext);
        }

        public static async Task<Result<K>> OnSuccess<T, K>(this Task<Result<T>> resultTask, Func<Task<Result<K>>> func, bool continueOnCapturedContext = true)
        {
            Result<T> result = await resultTask.ConfigureAwait(continueOnCapturedContext);

            if (result.IsFailure)
                return Result.Fail<K>(result.Errors);

            return await func().ConfigureAwait(continueOnCapturedContext);
        }

        public static async Task<Result> OnSuccess<T>(this Task<Result<T>> resultTask, Func<T, Task<Result>> func, bool continueOnCapturedContext = true)
        {
            Result<T> result = await resultTask.ConfigureAwait(continueOnCapturedContext);

            if (result.IsFailure)
                return Result.Fail(result.Errors);

            return await func(result.Value).ConfigureAwait(continueOnCapturedContext);
        }

        public static async Task<Result> OnSuccess(this Task<Result> resultTask, Func<Task<Result>> func, bool continueOnCapturedContext = true)
        {
            Result result = await resultTask.ConfigureAwait(continueOnCapturedContext);

            if (result.IsFailure)
                return result;

            return await func().ConfigureAwait(continueOnCapturedContext);
        }

        public static async Task<Result<T>> Ensure<T>(this Task<Result<T>> resultTask, Func<T, Task<bool>> predicate, string[] errorMessages, bool continueOnCapturedContext = true)
        {
            Result<T> result = await resultTask.ConfigureAwait(continueOnCapturedContext);

            if (result.IsFailure)
                return Result.Fail<T>(result.Errors);

            if (!await predicate(result.Value).ConfigureAwait(continueOnCapturedContext))
                return Result.Fail<T>(errorMessages);

            return Result.Ok(result.Value);
        }

        public static async Task<Result> Ensure(this Task<Result> resultTask, Func<Task<bool>> predicate, string errorMessage, bool continueOnCapturedContext = true)
        {
            Result result = await resultTask.ConfigureAwait(continueOnCapturedContext);

            if (result.IsFailure)
                return Result.Fail(result.Errors);

            if (!await predicate().ConfigureAwait(continueOnCapturedContext))
                return Result.Fail(errorMessage);

            return Result.Ok();
        }

        public static async Task<Result<K>> Map<T, K>(this Task<Result<T>> resultTask, Func<T, Task<K>> func, bool continueOnCapturedContext = true)
        {
            Result<T> result = await resultTask.ConfigureAwait(continueOnCapturedContext);

            if (result.IsFailure)
                return Result.Fail<K>(result.Errors);

            K value = await func(result.Value).ConfigureAwait(continueOnCapturedContext);

            return Result.Ok(value);
        }

        public static async Task<Result<T>> Map<T>(this Task<Result> resultTask, Func<Task<T>> func, bool continueOnCapturedContext = true)
        {
            Result result = await resultTask.ConfigureAwait(continueOnCapturedContext);

            if (result.IsFailure)
                return Result.Fail<T>(result.Errors);

            T value = await func().ConfigureAwait(continueOnCapturedContext);

            return Result.Ok(value);
        }

        public static async Task<Result<T>> OnSuccess<T>(this Task<Result<T>> resultTask, Func<T, Task> action, bool continueOnCapturedContext = true)
        {
            Result<T> result = await resultTask.ConfigureAwait(continueOnCapturedContext);

            if (result.IsSuccess)
            {
                await action(result.Value).ConfigureAwait(continueOnCapturedContext);
            }

            return result;
        }

        public static async Task<Result> OnSuccess(this Task<Result> resultTask, Func<Task> action, bool continueOnCapturedContext = true)
        {
            Result result = await resultTask.ConfigureAwait(continueOnCapturedContext);

            if (result.IsSuccess)
            {
                await action().ConfigureAwait(continueOnCapturedContext);
            }

            return result;
        }

        public static async Task<T> OnBoth<T>(this Task<Result> resultTask, Func<Result, Task<T>> func, bool continueOnCapturedContext = true)
        {
            Result result = await resultTask.ConfigureAwait(continueOnCapturedContext);
            return await func(result).ConfigureAwait(continueOnCapturedContext);
        }

        public static async Task<K> OnBoth<T, K>(this Task<Result<T>> resultTask, Func<Result<T>, Task<K>> func, bool continueOnCapturedContext = true)
        {
            Result<T> result = await resultTask.ConfigureAwait(continueOnCapturedContext);
            return await func(result).ConfigureAwait(continueOnCapturedContext);
        }

        public static async Task<Result<T>> OnFailure<T>(this Task<Result<T>> resultTask, Func<Task> func, bool continueOnCapturedContext = true)
        {
            Result<T> result = await resultTask.ConfigureAwait(continueOnCapturedContext);

            if (result.IsFailure)
            {
                await func().ConfigureAwait(continueOnCapturedContext);
            }

            return result;
        }

        public static async Task<Result> OnFailure(this Task<Result> resultTask, Func<Task> func, bool continueOnCapturedContext = true)
        {
            Result result = await resultTask.ConfigureAwait(continueOnCapturedContext);

            if (result.IsFailure)
            {
                await func().ConfigureAwait(continueOnCapturedContext);
            }

            return result;
        }

        public static async Task<Result<T>> OnFailure<T>(this Task<Result<T>> resultTask, Func<string[], Task> func, bool continueOnCapturedContext = true)
        {
            Result<T> result = await resultTask.ConfigureAwait(continueOnCapturedContext);

            if (result.IsFailure)
            {
                await func(result.Errors).ConfigureAwait(continueOnCapturedContext);
            }

            return result;
        }
    }
}
