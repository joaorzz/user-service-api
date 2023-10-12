using System.Diagnostics;
using UserService.API.Middleware.Interfaces;

namespace UserService.API.Middleware
{
    public class ResponseTimeMiddleware : IMiddleware
    {
        private readonly IStopwatchProvider _stopwatchProvider;
        private readonly IHeaderHandler _headerHandler;

        public ResponseTimeMiddleware(IStopwatchProvider stopwatchProvider, IHeaderHandler headerHandler)
        {
            _stopwatchProvider = stopwatchProvider;
            _headerHandler = headerHandler;
        }

        public async Task InvokeAsync(HttpContext httpContext, RequestDelegate next)
        {
            Stopwatch stopwatch = _stopwatchProvider.GetStopwatch();
            stopwatch.Start();

            httpContext.Response.OnStarting(() =>
            {
                stopwatch.Stop();
                _headerHandler.SetHttpResponseTime(httpContext.Response, stopwatch.ElapsedMilliseconds);
                return Task.CompletedTask;
            });

            await next(httpContext);
        }
    }
}
