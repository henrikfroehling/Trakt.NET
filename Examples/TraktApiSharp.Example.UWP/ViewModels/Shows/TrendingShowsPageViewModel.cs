namespace TraktApiSharp.Example.UWP.ViewModels.Shows
{
    using Models.Shows;
    using Requests.Params;
    using Services.TraktService;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Threading.Tasks;
    using Views;
    using Windows.UI.Xaml.Navigation;

    public class TrendingShowsPageViewModel : PaginationViewModel
    {
        private TraktShowsService Movies { get; } = TraktShowsService.Instance;

        public ObservableCollection<TrendingShow> TrendingShows { get; set; } = new ObservableCollection<TrendingShow>();

        private int _totalUsers = 0;

        public int TotalUsers
        {
            get { return _totalUsers; }

            set
            {
                _totalUsers = value;
                base.RaisePropertyChanged();
            }
        }

        public override async Task OnNavigatedToAsync(object parameter, NavigationMode mode, IDictionary<string, object> state)
        {
            if (TrendingShows != null && TrendingShows.Count <= 0)
            {
                var extendedOption = new TraktExtendedOption
                {
                    Full = true,
                    Images = true
                };

                Busy.SetBusy(true, "Loading trending movies...");
                var trendingShows = await Movies.GetTrendingShowsAsync(extendedOption, limitPerPage: DEFAULT_LIMIT);

                if (trendingShows.Items != null)
                {
                    TrendingShows = trendingShows.Items;
                    TotalUsers = trendingShows.TotalUserCount.GetValueOrDefault();
                    CurrentPage = trendingShows.CurrentPage.GetValueOrDefault();
                    ItemsPerPage = trendingShows.LimitPerPage.GetValueOrDefault();
                    TotalItems = trendingShows.TotalItemCount.GetValueOrDefault();
                    TotalPages = trendingShows.TotalPages.GetValueOrDefault();
                }

                Busy.SetBusy(false);
            }
        }
    }
}
