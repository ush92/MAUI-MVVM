using CurlEz.ViewModels;

namespace CurlEz.Views;

public partial class SecondPage : ContentPage
{
    public SecondPage(SecondPageViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}
