using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Loremware.Views;
using Microsoft.Extensions.Options;

namespace Loremware
{
    public class LoremwareMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly LoremContentOptions _contentOptions;

        public LoremwareMiddleware(RequestDelegate next, IOptions<LoremContentOptions> contentOptions)
        {
            _next = next;
            _contentOptions = contentOptions.Value;
        }

        public async Task Invoke(HttpContext context)
        {
            if (!context.Response.HasStarted)
            {
                var requestObject = new LoremRequestObject(context.Request);
                if (requestObject.ContentType != LoremContentType.None)
                {
                    var page = new LoremPage(requestObject);
                    await page.ExecuteAsync(context);
                    return;
                }
            }

            await _next(context);
        }
    }
}
