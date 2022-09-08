using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Diagnostics.CodeAnalysis;

namespace IzradaFilmova.Functions
{
    public static class ModelStateExtensions
    {
        public static void AddErrorToModelStateIfPropertyIsNull([NotNull] this ModelStateDictionary modelState, string nullProperty)
        {
            modelState.AddModelError(nullProperty, $"{nullProperty} is null.");
        }
    }
}
