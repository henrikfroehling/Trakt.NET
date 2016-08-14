namespace TraktApiSharp.Example.UWP.ViewModels.Shows
{
    using Models;
    using System.Collections.Generic;
    using Template10.Mvvm;

    public class ShowsPageViewModel : BaseViewModel
    {
        public ShowsPageViewModel()
        {
            NavigationItems = new List<PageNavigationItem>()
            {
                new PageNavigationItem
                {
                    Title = "Trending",
                    GoTo = new DelegateCommand(Navigation.GotoTrendingShows)
                },
                new PageNavigationItem
                {
                    Title = "Popular",
                    GoTo = new DelegateCommand(Navigation.GotoPopularShows)
                },
                new PageNavigationItem
                {
                    Title = "Most Played",
                    GoTo = new DelegateCommand(Navigation.GotoMostPlayedShows)
                },
                new PageNavigationItem
                {
                    Title = "Most Watched",
                    GoTo = new DelegateCommand(Navigation.GotoMostWatchedShows)
                },
                new PageNavigationItem
                {
                    Title = "Most Collected",
                    GoTo = new DelegateCommand(Navigation.GotoMostCollectedShows)
                },
                new PageNavigationItem
                {
                    Title = "Most Anticipated",
                    GoTo = new DelegateCommand(Navigation.GotoMostAnticipatedShows)
                },
                new PageNavigationItem
                {
                    Title = "Recently Updated",
                    GoTo = new DelegateCommand(Navigation.GotoRecentlyUpdatedShows)
                }
            };
        }

        public IEnumerable<PageNavigationItem> NavigationItems { get; }
    }
}
