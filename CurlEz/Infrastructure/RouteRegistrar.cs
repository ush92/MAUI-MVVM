using CurlEz.Views;

namespace CurlEz.Infrastructure;

public class RouteRegistrar : IRouteRegistrar
{
    public void RegisterRoutes()
    {
        Routing.RegisterRoute(Routes.SecondPage, typeof(SecondPage));
        Routing.RegisterRoute(Routes.TestView, typeof(TestView));
    }
}
