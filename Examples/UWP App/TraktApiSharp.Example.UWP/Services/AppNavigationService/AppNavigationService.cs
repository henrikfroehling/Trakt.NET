namespace TraktApiSharp.Example.UWP.Services.AppNavigationService
{
    using Template10.Services.NavigationService;
    using Views;
    using Views.Movies;
    using Views.Shows;

    public class AppNavigationService
    {
        private INavigationService NavigationService { get; }

        private AppNavigationService()
        {
            NavigationService = App.Current.NavigationService;
        }

        public static AppNavigationService Instance { get; } = new AppNavigationService();

        // ---------------------------------------
        // Common
        // ---------------------------------------

        public void GotoTraktSettings() => NavigationService.Navigate(typeof(SettingsPage), 0);
        public void GotoTraktAuthorization() => NavigationService.Navigate(typeof(SettingsPage), 1);
        public void GotoSettings() => NavigationService.Navigate(typeof(SettingsPage), 2);
        public void GotoAbout() => NavigationService.Navigate(typeof(SettingsPage), 3);

        // ---------------------------------------
        // Movies
        // ---------------------------------------

        public void GotoTrendingMovies() => NavigationService.Navigate(typeof(TrendingMoviesPage));
        public void GotoPopularMovies() => NavigationService.Navigate(typeof(PopularMoviesPage));
        public void GotoMostPlayedMovies() => NavigationService.Navigate(typeof(MostPlayedMoviesPage));
        public void GotoMostWatchedMovies() => NavigationService.Navigate(typeof(MostWatchedMoviesPage));
        public void GotoMostCollectedMovies() => NavigationService.Navigate(typeof(MostCollectedMoviesPage));
        public void GotoMostAnticipatedMovies() => NavigationService.Navigate(typeof(MostAnticipatedMoviesPage));
        public void GotoBoxOfficeMovies() => NavigationService.Navigate(typeof(BoxOfficeMoviesPage));
        public void GotoRecentlyUpdatedMovies() => NavigationService.Navigate(typeof(RecentlyUpdatedMoviesPage));

        // ---------------------------------------
        // Shows
        // ---------------------------------------

        public void GotoTrendingShows() => NavigationService.Navigate(typeof(TrendingShowsPage));
        public void GotoPopularShows() => NavigationService.Navigate(typeof(PopularShowsPage));
        public void GotoMostPlayedShows() => NavigationService.Navigate(typeof(MostPlayedShowsPage));
        public void GotoMostWatchedShows() => NavigationService.Navigate(typeof(MostWatchedShowsPage));
        public void GotoMostCollectedShows() => NavigationService.Navigate(typeof(MostCollectedShowsPage));
        public void GotoMostAnticipatedShows() => NavigationService.Navigate(typeof(MostAnticipatedShowsPage));
        public void GotoRecentlyUpdatedShows() => NavigationService.Navigate(typeof(RecentlyUpdatedShowsPage));
    }
}
