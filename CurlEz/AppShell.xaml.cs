using CurlEz.Infrastructure;

namespace CurlEz;

public partial class AppShell : Shell
{
    public AppShell(IRouteRegistrar routeRegistrar)
    {
        InitializeComponent();
        routeRegistrar.RegisterRoutes();
    }
}
