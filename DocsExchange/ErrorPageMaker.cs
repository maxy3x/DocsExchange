using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;

namespace DocsExchangeGoogle
{
    public class ErrorPageMaker
    {
        public Exception Ex { get; set; }
        public HttpContext Context { get; set; }
        public ErrorPageMaker()
        {

        }

        public ErrorPageMaker(Exception ex, HttpContext context)
        {
            Ex = ex;
            Context = context;
        }

        public string PageMaker()
        {
            return $"<html>" +
                   $"<body>" +
                   $"<title>Error Page Maker</title>" +
                   $"<h1>You want to link a {Context.Request.GetDisplayUrl()}</h1>" +
                   $"<h3>Error: {Context.Response.StatusCode}</h3>" +
                   $"<h3>Error message: {Ex.Message}</h3>" +
                   $"<h3>Error was caused by {Ex.Source}</h3>" +
                   $"<h3>HResult: {Ex.HResult}</h3>" +
                   $"<h5>StackTrace: {Ex.StackTrace}</h5>" +
                   $"<h5>Inner: {Ex.InnerException}" +
                   $"</body>" +
                   $"</html>";
        }
    }
}