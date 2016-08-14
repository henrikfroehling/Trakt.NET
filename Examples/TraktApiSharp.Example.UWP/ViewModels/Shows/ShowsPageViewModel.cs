namespace TraktApiSharp.Example.UWP.ViewModels.Shows
{
    using Models;
    using System.Collections.Generic;
    using Template10.Mvvm;
    using Views.Shows;

    public class ShowsPageViewModel : ViewModelBase
    {
        public ShowsPageViewModel()
        {
            NavigationItems = new List<PageNavigationItem>()
            {
                new PageNavigationItem
                {
                    Title = "Trending",
                    GoTo = new DelegateCommand(() => NavigationService.Navigate(typeof(TrendingShowsPage), 0))
                },
                new PageNavigationItem
                {
                    Title = "Popular",
                    GoTo = new DelegateCommand(() => NavigationService.Navigate(typeof(PopularShowsPage), 0))
                },
                new PageNavigationItem
                {
                    Title = "Most Played",
                    GoTo = new DelegateCommand(() => NavigationService.Navigate(typeof(MostPlayedShowsPage), 0))
                },
                new PageNavigationItem
                {
                    Title = "Most Watched",
                    GoTo = new DelegateCommand(() => NavigationService.Navigate(typeof(MostWatchedShowsPage), 0))
                },
                new PageNavigationItem
                {
                    Title = "Most Collected",
                    GoTo = new DelegateCommand(() => NavigationService.Navigate(typeof(MostCollectedShowsPage), 0))
                },
                new PageNavigationItem
                {
                    Title = "Most Anticipated",
                    GoTo = new DelegateCommand(() => NavigationService.Navigate(typeof(MostAnticipatedShowsPage), 0))
                },
                new PageNavigationItem
                {
                    Title = "Recently Updated",
                    GoTo = new DelegateCommand(() => NavigationService.Navigate(typeof(RecentlyUpdatedShowsPage), 0))
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
