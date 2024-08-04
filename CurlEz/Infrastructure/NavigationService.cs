namespace CurlEz.Infrastructure;

public class NavigationService : INavigationService
{
    public async Task NavigateToAsync(string route, IDictionary<string, object>? parameters = null)
    {
        if (parameters == null)
        {
            await Shell.Current.GoToAsync(route);
        }
        else
        {
            await Shell.Current.GoToAsync(route, parameters);
        }
    }

    public async Task GoBackAsync()
    {
        await Shell.Current.GoToAsync("..");
    }
}
