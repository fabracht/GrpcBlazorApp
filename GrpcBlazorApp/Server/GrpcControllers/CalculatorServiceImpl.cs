using System.Threading.Tasks;
using Grpc.Core;
using GrpcBlazorApp.Shared;

namespace GrpcBlazorApp.Server.GrpcControllers
{
    public class CalculatorServiceImpl : CalculatorService.CalculatorServiceBase
    {
        public override Task<SumResponse> Sum(SumRequest request, ServerCallContext context)
        {
            double result = request.A + request.B;
            return Task.FromResult(new SumResponse()
            {
                Result = result
            });
        }
    }
}