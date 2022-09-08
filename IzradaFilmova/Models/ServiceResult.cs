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

        public ServiceResult(IReadOnlyCollection<string>? reasons = default)
        {
            FailedReason = reasons;
            IsFailed = true;
        }

        public static ServiceResult SuccessfulResult { get; } = new ServiceResult(true);
        public static ServiceResult FailedResult { get; } = new ServiceResult(false);

        public bool IsSuccessful { get; protected set; }
        public bool IsFailed { get; protected set; }
        public IReadOnlyCollection<string>? FailedReason { get; set; }
    }

    public class ServiceResult<T> : ServiceResult where T : class
    {
        public ServiceResult(T returnValue, IReadOnlyCollection<string>? reasons = default) : base(reasons)
        {
            ReturnValue = returnValue;
            if(returnValue is null)
            {
                IsFailed = true;
            }
            else
            {
                IsSuccessful = true;
            }
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
