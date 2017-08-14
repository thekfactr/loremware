using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Loremware
{
    public class LoremwareMiddleware
    {
        private readonly RequestDelegate _next;

        public LoremwareMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            await _next(context);
        }
    }
}
