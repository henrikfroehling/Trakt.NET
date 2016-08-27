namespace TraktApiSharp.Example.UWP.ViewModels
{
    using Services.AppNavigationService;
    using Template10.Mvvm;

    public abstract class BaseViewModel : ViewModelBase
    {
        public BaseViewModel()
        {
            Navigation = AppNavigationService.Instance;
        }

        public AppNavigationService Navigation { get; }
    }
}
