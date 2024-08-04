using CurlEz.Data;

namespace CurlEz;
public partial class App : Application
{
    private readonly IAppDbContext _dbContext;
    private readonly IServiceProvider _serviceProvider;

    public App(IAppDbContext dbContext, IServiceProvider serviceProvider)
    {
        InitializeComponent();
        _dbContext = dbContext;
        _serviceProvider = serviceProvider;
        MainPage = _serviceProvider.GetRequiredService<AppShell>();
    }

    protected override async void OnStart()
    {
        await _dbContext.InitializeAsync();
        base.OnStart();
    }
}