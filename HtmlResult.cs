namespace NJUPT_AspNetCore_Exp1;

using System.Net.Mime;
using System.Text;

static class ResultsExtensions
{
    public static IResult Html(this IResultExtensions extensions, string html)
    {
        ArgumentNullException.ThrowIfNull(extensions);

        return new HtmlResult(html);
    }
}

class HtmlResult(string html) : IResult
{
    public Task ExecuteAsync(HttpContext httpContext)
    {
        httpContext.Response.ContentType = MediaTypeNames.Text.Html;
        httpContext.Response.ContentLength = Encoding.UTF8.GetByteCount(html);
        return httpContext.Response.WriteAsync(html);
    }
}
