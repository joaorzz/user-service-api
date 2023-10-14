using UserService.API.Middleware.Interfaces;

namespace UserService.API.Middleware
{
    public class HeaderHandler : IHeaderHandler
    {
        public void SetHttpResponseTime(HttpResponse httpResponse, long responseTime)
        {
            const string responseTimeHeader = "X-Response-Time-ms";

            httpResponse.Headers.TryAdd(responseTimeHeader, responseTime.ToString());
        }
    }
}
