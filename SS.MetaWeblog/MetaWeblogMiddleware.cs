using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace SS.MetaWeblog
{
    public class MetaWeblogMiddleware
    {
        private ILogger _logger;
        private readonly RequestDelegate _next;
        private MetaWeblogService _service;
        private string _urlEndpoint;

        public MetaWeblogMiddleware(RequestDelegate next, ILogger<MetaWeblogMiddleware> logger, string urlEndpoint, MetaWeblogService service)
        {
            _next = next;
            _logger = logger;
            _urlEndpoint = urlEndpoint;
            _service = service;
        }

        public async Task Invoke(HttpContext context)
        {
            if (context.Request.Method == "POST" &&
              context.Request.Path.StartsWithSegments(_urlEndpoint) &&
              context.Request != null &&
              context.Request.ContentType.ToLower().Contains("text/xml"))
            {

                var rdr = new StreamReader(context.Request.Body);
                var xml = rdr.ReadToEnd();
                _logger.LogInformation($"Request XMLRPC: {xml}");
                var result = _service.Invoke(xml);
                _logger.LogInformation($"Result XMLRPC: {result}");


                //var result = "<methodResponse><params><param><value><array><data><value><struct><member><name>blogid</name><value><string>stw</string></value></member><member><name>url</name><value><string>/</string></value></member><member><name>blogName</name><value><string>Shawn Wildermuth's Rants and Raves</string></value></member></struct></value></data></array></value></param></params></methodResponse>";
                context.Response.OnStarting((state) =>
                {
                    context.Response.ContentType = "text/xml";
                    context.Response.StatusCode = 200;
                    var buffer = Encoding.UTF8.GetBytes(result);
                    context.Response.Body.Write(buffer, 0, buffer.Length); return Task.FromResult(0);
                }, null);

            }

            // Continue On
            await _next.Invoke(context);
        }
    }
}
