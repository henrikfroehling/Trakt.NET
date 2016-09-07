namespace TraktApiSharp.Example.UWP.ViewModels.Movies
{
    using Models;
    using System.Collections.Generic;
    using Template10.Mvvm;

    public class MoviesPageViewModel : BaseViewModel
    {
        public MoviesPageViewModel()
        {
            NavigationItems = new List<PageNavigationItem>()
            {
                new PageNavigationItem
                {
                    Title = "Trending",
                    GoTo = new DelegateCommand(Navigation.GotoTrendingMovies)
                },
                new PageNavigationItem
                {
                    Title = "Popular",
                    GoTo = new DelegateCommand(Navigation.GotoPopularMovies)
                },
                new PageNavigationItem
                {
                    Title = "Most Played",
                    GoTo = new DelegateCommand(Navigation.GotoMostPlayedMovies)
                },
                new PageNavigationItem
                {
                    Title = "Most Watched",
                    GoTo = new DelegateCommand(Navigation.GotoMostWatchedMovies)
                },
                new PageNavigationItem
                {
                    Title = "Most Collected",
                    GoTo = new DelegateCommand(Navigation.GotoMostCollectedMovies)
                },
                new PageNavigationItem
                {
                    Title = "Most Anticipated",
                    GoTo = new DelegateCommand(Navigation.GotoMostAnticipatedMovies)
                },
                new PageNavigationItem
                {
                    Title = "Box Office",
                    GoTo = new DelegateCommand(Navigation.GotoBoxOfficeMovies)
                },
                new PageNavigationItem
                {
                    Title = "Recently Updated",
                    GoTo = new DelegateCommand(Navigation.GotoRecentlyUpdatedMovies)
                }
            };
        }

        public IEnumerable<PageNavigationItem> NavigationItems { get; }
    }
}
