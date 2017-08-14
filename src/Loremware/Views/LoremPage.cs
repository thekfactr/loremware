using Loremware.Generators;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Loremware.Views
{
    public class LoremPage
    {
        public async Task ExecuteAsync(HttpContext context)
        {
            await context.Response.WriteAsync(@"<html>");
            await context.Response.WriteAsync(@"<head>");
            await context.Response.WriteAsync(@"<style type=""text/css"">");
            await context.Response.WriteAsync(@".l-main {
                                                    position: relative;
                                                    display: flex;
                                                    flex-direction: column;
                                                    min-width: 0;
                                                    word-wrap: break-word;
                                                    background-color: #F5F5F5;
                                                    background-clip: border-box;
                                                    border: 1px solid rgba(0,0,0,0.125);
                                                    border-radius: .25rem;
                                                }

                                                .l-main-body {
                                                    flex: 1 1 auto;
                                                    padding: 1.25rem;
                                                }");
            await context.Response.WriteAsync(@"</style>");
            await context.Response.WriteAsync(@"</head>");
            await context.Response.WriteAsync(@"<body>");
            var paragraph1 = LoremTextGenerator.GenerateLoremIpsumText();
            await context.Response.WriteAsync($@"<br/>
                                                <div class=""container"">
                                                    <div class=""l-main"">
                                                        <div class=""l-main-body"">
                                                        <h3>Lorem Ipsum</h3>
                                                        {paragraph1}
                                                        </div>
                                                    </div>
                                                </div>");
            await context.Response.WriteAsync(@"</body>");
            await context.Response.WriteAsync(@"</html>");
        }
    }
}
