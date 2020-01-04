
using FindMyWord.ViewModels;
using FindMyWord.Views;
using Prism.DryIoc;
using Prism.Ioc;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FindMyWord
{
    public partial class App : PrismApplication
    {
        protected override IContainerExtension CreateContainerExtension() => PrismContainerExtension.Current;

        protected override async void OnInitialized()
        {
            InitializeComponent();
            await NavigationService.NavigateAsync("SearchPage");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<SearchPage, SearchPageViewModel>();
        }
    }
}
