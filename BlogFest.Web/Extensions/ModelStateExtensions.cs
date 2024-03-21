using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace BlogFest.Web.Infrastructure.Extensions
{
    public static class ModelStateExtensions
    {
        public static IEnumerable<KeyValuePair<string, IEnumerable<string>>> Errors(this ModelStateDictionary modelState)
        {
            return modelState.ToDictionary(
                    x => x.Key,
                    x => x.Value.Errors.Select(y => y.ErrorMessage))
                .Where(x => x.Value.Any());
        }
    }
}
