using Microsoft.AspNetCore.Mvc.ModelBinding;

using System.Diagnostics.CodeAnalysis;

namespace IzradaFilmova.Models
{
    public class ServiceResult
    {
        public ServiceResult(bool value, IReadOnlyCollection<string>? reasons = default)
        {
            if (value)
            {
                IsSuccessful = true;
            }
            else
            {
                IsFailed = true;
            }

            FailedReason = reasons;
        }

        public static ServiceResult SuccessfulResult { get; } = new ServiceResult(true);

        public bool IsSuccessful { get; protected set; }
        public bool IsFailed { get; protected set; }
        public IReadOnlyCollection<string>? FailedReason { get; set; }
    }

    public class ServiceResult<T> : ServiceResult where T : class
    {
        public ServiceResult(bool value, T returnValue, IReadOnlyCollection<string>? reasons = default) : base(value, reasons)
        {
            ReturnValue = returnValue;
        }

        public T ReturnValue { get; set; }
    }

    public static class ServiceResultExtensions
    {
        public static void AddFailedReasonToModelState([NotNull] this ServiceResult serviceResult, [NotNull] ModelStateDictionary modelState)
        {
            if (serviceResult.FailedReason is not { Count: > 0 })
            {
                return;
            }

            modelState.AddModelError(nameof(ServiceResult), string.Join(", ", serviceResult.FailedReason));
        }
    }
}
