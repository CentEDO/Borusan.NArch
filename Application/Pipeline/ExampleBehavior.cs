using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Pipeline
{
    public class ExampleBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            Console.WriteLine("Example Behavior çalıştı.");
            TResponse response = await next();
            Console.WriteLine("Req çalıştı. Example Behavior tekrar çalıştı");
            return response;
        }
    }
}
