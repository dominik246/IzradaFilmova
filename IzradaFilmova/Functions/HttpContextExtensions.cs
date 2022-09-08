using Microsoft.AspNetCore.Mvc.ModelBinding;

using System.Diagnostics.CodeAnalysis;
using System.Security.Claims;

namespace IzradaFilmova.Functions
{
    public static class HttpContextExtensions
    {
        public static string? FindUserId([NotNull] this HttpContext httpContext)
        {
            return httpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
        }
    }
}
