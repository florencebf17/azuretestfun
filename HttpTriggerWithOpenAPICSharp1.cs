using System.IO;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Attributes;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;

namespace Company.Function
{
    public class HttpTriggerWithOpenAPICSharp1
    {
        private readonly ILogger<HttpTriggerWithOpenAPICSharp1> _logger;

        public HttpTriggerWithOpenAPICSharp1(ILogger<HttpTriggerWithOpenAPICSharp1> log)
        {
            _logger = log;
        }

        [FunctionName("HttpTriggerWithOpenAPICSharp1")]
        [OpenApiOperation(operationId: "Run", tags: new[] { "name" })]
        [OpenApiParameter(name: "rollNo", In = ParameterLocation.Path, Required = true, Type = typeof(int), Description = "The **RollNo** parameter")]
        //[OpenApiResponseWithBody(statusCode: HttpStatusCode.OK, contentType: "text/plain", bodyType: typeof(string), Description = "The OK response")]
        public  IActionResult Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get",  Route = "Test/{rollNo}")] HttpRequest req, int rollNo)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");
            string responseMessage =  $"Hello, ${rollNo}. This HTTP triggered function executed successfully.";
            return new OkObjectResult(responseMessage);
        }
    }
}

