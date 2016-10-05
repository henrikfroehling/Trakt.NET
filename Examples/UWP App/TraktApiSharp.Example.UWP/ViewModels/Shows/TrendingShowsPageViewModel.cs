namespace TraktApiSharp.Example.UWP.ViewModels.Shows
{
    using Models.Shows;
    using Services.TraktService;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Threading.Tasks;
    using Views;
    using Windows.UI.Xaml.Navigation;

    public class TrendingShowsPageViewModel : PaginationViewModel
    {
        private TraktShowsService Shows { get; } = TraktShowsService.Instance;

        private ObservableCollection<TrendingShow> _trendingShows = new ObservableCollection<TrendingShow>();

        public ObservableCollection<TrendingShow> TrendingShows
        {
            get { return _trendingShows; }

            set
            {
                _trendingShows = value;
                base.RaisePropertyChanged();
            }
        }

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
                await LoadPage(1, DEFAULT_LIMIT);
        }

        protected override async Task LoadPage(int? page = null, int? limit = null)
        {
            Busy.SetBusy(true, "Loading trending shows...");
            var traktTrendingShows = await Shows.GetTrendingShowsAsync(DEFAULT_EXTENDED_INFO, whichPage: page, limitPerPage: limit);

            if (traktTrendingShows.Items != null)
            {
                TrendingShows = traktTrendingShows.Items;
                SetPaginationValues(traktTrendingShows);
                TotalUsers = traktTrendingShows.TotalUserCount.GetValueOrDefault();
            }

            Busy.SetBusy(false);
        }
    }
}
