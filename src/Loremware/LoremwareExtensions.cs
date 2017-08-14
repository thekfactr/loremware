using Microsoft.AspNetCore.Builder;

namespace Loremware
{
    public static class LoremwareExtensions
    {
        public static IApplicationBuilder UseLoremware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<LoremwareMiddleware>();
        }
    }
}
