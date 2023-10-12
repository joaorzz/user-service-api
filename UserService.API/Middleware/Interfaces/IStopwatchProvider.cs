using System.Diagnostics;

namespace UserService.API.Middleware.Interfaces
{
    public interface IStopwatchProvider
    {
        Stopwatch GetStopwatch();
    }
}
