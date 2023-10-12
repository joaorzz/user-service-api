using System.Diagnostics;
using UserService.API.Middleware.Interfaces;

namespace UserService.API.Middleware
{
    public class StopwatchProvider : IStopwatchProvider
    {
        public Stopwatch GetStopwatch()
        {
            return new Stopwatch();
        }
    }
}
