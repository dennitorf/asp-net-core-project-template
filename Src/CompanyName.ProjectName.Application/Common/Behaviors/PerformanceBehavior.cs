﻿using MediatR;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace CompanyName.ProjectName.Application.Common.Behaviors
{
    public class PerformanceBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        private readonly Stopwatch timer;
        private readonly ILogger logger;

        public PerformanceBehavior(ILogger<PerformanceBehavior<TRequest, TResponse>> logger)
        {
            this.timer = new Stopwatch();
            this.logger = logger;
        }        

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            timer.Start();

            var response = await next();

            timer.Stop();

            var requestName = typeof(TRequest);

            logger.LogInformation("CompanyName.ProjectName {Name} Execution Time {time}", requestName, timer.ElapsedMilliseconds);

            return response;
        }
    }
}
