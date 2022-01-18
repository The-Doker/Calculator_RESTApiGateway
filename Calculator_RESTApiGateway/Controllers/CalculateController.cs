using Calculator_gRPC.BL;
using Calculator_RESTApiGateway.Models;
using Grpc.Net.Client;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Authorization;

namespace Calculator_RESTApiGateway.Controllers
{
    [ApiController]
    [Authorize]
    [Route("[controller]")]
    public class CalculateController : ControllerBase
    {
        [HttpPost]
        async public Task<string> Post(Request req)
        {
            try
            {
                using (var channel = GrpcChannel.ForAddress("https://localhost:5001"))
                {
                    var client = new Calculator.CalculatorClient(channel);
                    var gRPCReply = await client.CalculateAsync(new CalcRequest { JsonData = JsonConvert.SerializeObject(req) });
                    return gRPCReply.JsonData;
                }
            } catch
            {
                return JsonConvert.SerializeObject(new ReplyWithErrors() { Error = "gRPC Server is unavaliable" });
            }
        }
    }
}
