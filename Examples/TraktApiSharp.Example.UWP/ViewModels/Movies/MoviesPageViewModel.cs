namespace TraktApiSharp.Example.UWP.ViewModels.Movies
{
    using Models;
    using System.Collections.Generic;
    using Template10.Mvvm;
    using Views.Movies;

    public class MoviesPageViewModel : ViewModelBase
    {
        public MoviesPageViewModel()
        {
            NavigationItems = new List<PageNavigationItem>()
            {
                new PageNavigationItem
                {
                    Title = "Trending",
                    GoTo = new DelegateCommand(() => NavigationService.Navigate(typeof(TrendingMoviesPage), 0))
                },
                new PageNavigationItem
                {
                    Title = "Popular",
                    GoTo = new DelegateCommand(() => NavigationService.Navigate(typeof(PopularMoviesPage), 0))
                },
                new PageNavigationItem
                {
                    Title = "Most Played",
                    GoTo = new DelegateCommand(() => NavigationService.Navigate(typeof(MostPlayedMoviesPage), 0))
                },
                new PageNavigationItem
                {
                    Title = "Most Watched",
                    GoTo = new DelegateCommand(() => NavigationService.Navigate(typeof(MostWatchedMoviesPage), 0))
                },
                new PageNavigationItem
                {
                    Title = "Most Collected",
                    GoTo = new DelegateCommand(() => NavigationService.Navigate(typeof(MostCollectedMoviesPage), 0))
                },
                new PageNavigationItem
                {
                    Title = "Most Anticipated",
                    GoTo = new DelegateCommand(() => NavigationService.Navigate(typeof(MostAnticipatedMoviesPage), 0))
                },
                new PageNavigationItem
                {
                    Title = "Box Office",
                    GoTo = new DelegateCommand(() => NavigationService.Navigate(typeof(BoxOfficeMoviesPage), 0))
                },
                new PageNavigationItem
                {
                    Title = "Recently Updated",
                    GoTo = new DelegateCommand(() => NavigationService.Navigate(typeof(RecentlyUpdatedMoviesPage), 0))
                }
            };
        }

        public IEnumerable<PageNavigationItem> NavigationItems { get; }

        public void GotoTraktSettings() =>
            NavigationService.Navigate(typeof(Views.SettingsPage), 0);

        public void GotoSettings() =>
            NavigationService.Navigate(typeof(Views.SettingsPage), 1);

        public void GotoAbout() =>
            NavigationService.Navigate(typeof(Views.SettingsPage), 2);
    }
}
