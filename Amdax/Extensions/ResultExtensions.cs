using Ardalis.GuardClauses;

using FluentResults;

using Microsoft.AspNetCore.Mvc;

namespace Amdax.Extensions
{
    public static class ResultExtensions
    {
        public static IActionResult AsActionResult<T>(this Result<T> result)
        {
            Guard.Against.Null(result, nameof(result));

            return result.IsSuccess
                ? new OkResult()
                : GetError(result.ToResult());
        }

        private static IActionResult GetError(this Result result)
        {
            //TODO validate other erros
            var errorMessages = result.Errors.Select(e => e.Message).ToArray();
            return new BadRequestObjectResult(errorMessages);
        }
    }
}
