namespace UserService.API.Middleware.Interfaces
{
    public interface IHeaderHandler
    {
        void SetHttpResponseTime(HttpResponse httpResponse, long responseTime);
    }
}
