using IzradaFilmova.Database.Models;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

using System.Diagnostics.CodeAnalysis;

namespace IzradaFilmova.Functions
{
    public static class DatabaseExtensions
    {
#pragma warning disable CA1715
        public static async Task<(U, int)> UseTransactionAsync<T, U>([NotNull] this T dbContext, [NotNull] Func<EntityEntry<U>> func, CancellationToken token)
#pragma warning restore CA1715
            where T : DbContext
            where U : BaseEntity
        {
            await dbContext.Database.BeginTransactionAsync(token);

            var result = func.Invoke();

            var saveChangesResult = await dbContext.SaveChangesAsync(token);
            await dbContext.Database.CommitTransactionAsync(token);
            return (result.Entity, saveChangesResult);
        }
    }
}
