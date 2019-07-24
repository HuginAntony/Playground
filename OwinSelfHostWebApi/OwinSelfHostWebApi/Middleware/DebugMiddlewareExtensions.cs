using System.Diagnostics;
using Pluralsight.Owin.Demo.Middleware;

namespace Owin
{
    public static class DebugMiddlewareExtensions
    {
        public static void UseDebugMiddleware(this IAppBuilder app, DebugMiddlewareOptions options = null)
        {
            if (options == null)
                options = new DebugMiddlewareOptions();

            app.Use<DebugMiddleware>(options);
        }

        public static DebugMiddlewareOptions GetDefaultOptions()
        {
            return new DebugMiddlewareOptions
            {
                OnIncomingRequest = (ctx) =>
                {
                    var watch = new Stopwatch();
                    watch.Start();
                    ctx.Environment["DebugStopwatch"] = watch;
                },
                OnOutgoingRequest = (ctx) =>
                {
                    var watch = (Stopwatch) ctx.Environment["DebugStopwatch"];
                    watch.Stop();
                    Debug.WriteLine("Request took: " + watch.ElapsedMilliseconds + " ms");
                }
            };
        }
    }
}