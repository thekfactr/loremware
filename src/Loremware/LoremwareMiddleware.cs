using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Loremware.Views;

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
            if (!context.Response.HasStarted)
            {
                if (context.Request.Path.ToString().Contains("tlw") || context.Request.QueryString.ToString().Contains("tlw"))
                {
                    var page = new LoremPage();
                    await page.ExecuteAsync(context);
                    return;
                }
            }

            await _next(context);
        }
    }
}
