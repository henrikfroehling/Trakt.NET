namespace TraktApiSharp.Example.UWP.ViewModels.Movies
{
    using Template10.Mvvm;

    public class BoxOfficeMoviesPageViewModel : ViewModelBase
    {
        public void GotoTraktSettings() =>
            NavigationService.Navigate(typeof(Views.SettingsPage), 0);

        public void GotoSettings() =>
            NavigationService.Navigate(typeof(Views.SettingsPage), 1);

        public void GotoAbout() =>
            NavigationService.Navigate(typeof(Views.SettingsPage), 2);
    }
}
