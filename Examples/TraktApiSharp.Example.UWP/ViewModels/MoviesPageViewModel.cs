namespace TraktApiSharp.Example.UWP.ViewModels
{
    using Template10.Mvvm;

    public class MoviesPageViewModel : ViewModelBase
    {
        public void GotoSettings() =>
            NavigationService.Navigate(typeof(Views.SettingsPage), 0);

        public void GotoPrivacy() =>
            NavigationService.Navigate(typeof(Views.SettingsPage), 1);

        public void GotoAbout() =>
            NavigationService.Navigate(typeof(Views.SettingsPage), 2);
    }
}
