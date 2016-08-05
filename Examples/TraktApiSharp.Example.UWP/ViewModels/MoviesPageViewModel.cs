namespace TraktApiSharp.Example.UWP.ViewModels
{
    using Template10.Mvvm;

    public class MoviesPageViewModel : ViewModelBase
    {
        public TrendingMoviesPartViewModel TrendingMoviesViewModel { get; } = new TrendingMoviesPartViewModel();

        public PopularMoviesPartViewModel PopularMoviesViewModel { get; } = new PopularMoviesPartViewModel();

        public MostPlayedMoviesPartViewModel MostPlayedMoviesViewModel { get; } = new MostPlayedMoviesPartViewModel();

        public MostWatchedMoviesPartViewModel MostWatchedMoviesViewModel { get; } = new MostWatchedMoviesPartViewModel();

        public MostCollectedMoviesPartViewModel MostCollectedMoviesViewModel { get; } = new MostCollectedMoviesPartViewModel();

        public MostAnticipatedMoviesPartViewModel MostAnticipatedMoviesViewModel { get; } = new MostAnticipatedMoviesPartViewModel();

        public BoxOfficeMoviesPartViewModel BoxOfficeMoviesViewModel { get; } = new BoxOfficeMoviesPartViewModel();

        public RecentlyUpdatedMoviesPartViewModel RecentlyUpdatedMoviesViewModel { get; } = new RecentlyUpdatedMoviesPartViewModel();

        public void GotoTraktSettings() =>
            NavigationService.Navigate(typeof(Views.SettingsPage), 0);

        public void GotoSettings() =>
            NavigationService.Navigate(typeof(Views.SettingsPage), 1);

        public void GotoAbout() =>
            NavigationService.Navigate(typeof(Views.SettingsPage), 2);
    }

    public class TrendingMoviesPartViewModel : ViewModelBase
    {

    }

    public class PopularMoviesPartViewModel : ViewModelBase
    {

    }

    public class MostPlayedMoviesPartViewModel : ViewModelBase
    {

    }

    public class MostWatchedMoviesPartViewModel : ViewModelBase
    {

    }

    public class MostCollectedMoviesPartViewModel : ViewModelBase
    {

    }

    public class MostAnticipatedMoviesPartViewModel : ViewModelBase
    {

    }

    public class BoxOfficeMoviesPartViewModel : ViewModelBase
    {

    }

    public class RecentlyUpdatedMoviesPartViewModel : ViewModelBase
    {

    }
}
