using System;
using System.Linq;
using System.Threading.Tasks;
using Grpc.Core;
using GrpcBlazorApp.Shared;

namespace GrpcBlazorApp.Server.GrpcControllers
{
    public class CountImpl : CountService.CountServiceBase
    {
        public override async Task CountMultiple(CountRequest request, IServerStreamWriter<CountMultipleResponse> responseStream, ServerCallContext context)
        {
            var result = request.StartFrom;
            foreach (long count in Enumerable.Range(1, 100))
            {
                Console.WriteLine($"The server received the request : {result + count}");
                await responseStream.WriteAsync(new CountMultipleResponse() {Result = (result + count)});
                await Task.Delay(100);
            }
        }
    }
}