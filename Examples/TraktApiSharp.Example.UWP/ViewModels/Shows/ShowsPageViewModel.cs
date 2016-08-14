namespace TraktApiSharp.Example.UWP.ViewModels.Shows
{
    using Template10.Mvvm;

    public class ShowsPageViewModel : ViewModelBase
    {
        public TrendingShowsPartViewModel TrendingShowsViewModel { get; } = new TrendingShowsPartViewModel();

        public PopularShowsPartViewModel PopularShowsViewModel { get; } = new PopularShowsPartViewModel();

        public MostPlayedShowsPartViewModel MostPlayedShowsViewModel { get; } = new MostPlayedShowsPartViewModel();

        public MostWatchedShowsPartViewModel MostWatchedShowsViewModel { get; } = new MostWatchedShowsPartViewModel();

        public MostCollectedShowsPartViewModel MostCollectedShowsViewModel { get; } = new MostCollectedShowsPartViewModel();

        public MostAnticipatedShowsPartViewModel MostAnticipatedShowsViewModel { get; } = new MostAnticipatedShowsPartViewModel();

        public RecentlyUpdatedShowsPartViewModel RecentlyUpdatedShowsViewModel { get; } = new RecentlyUpdatedShowsPartViewModel();

        public void GotoTraktSettings() =>
            NavigationService.Navigate(typeof(Views.SettingsPage), 0);

        public void GotoSettings() =>
            NavigationService.Navigate(typeof(Views.SettingsPage), 1);

        public void GotoAbout() =>
            NavigationService.Navigate(typeof(Views.SettingsPage), 2);
    }

    public class TrendingShowsPartViewModel : ViewModelBase
    {

    }

    public class PopularShowsPartViewModel : ViewModelBase
    {

    }

    public class MostPlayedShowsPartViewModel : ViewModelBase
    {

    }

    public class MostWatchedShowsPartViewModel : ViewModelBase
    {

    }

    public class MostCollectedShowsPartViewModel : ViewModelBase
    {

    }

    public class MostAnticipatedShowsPartViewModel : ViewModelBase
    {

    }

    public class RecentlyUpdatedShowsPartViewModel : ViewModelBase
    {

    }
}
