namespace TraktApiSharp.Example.UWP.ViewModels.Shows
{
    using Models.Shows;
    using Services.TraktService;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Threading.Tasks;
    using Views;
    using Windows.UI.Xaml.Navigation;

    public class RecentlyUpdatedShowsPageViewModel : PaginationViewModel
    {
        private TraktShowsService Shows { get; } = TraktShowsService.Instance;

        private ObservableCollection<RecentlyUpdatedShow> _recentlyUpdatedShows = new ObservableCollection<RecentlyUpdatedShow>();

        public ObservableCollection<RecentlyUpdatedShow> RecentlyUpdatedShows
        {
            get { return _recentlyUpdatedShows; }

            set
            {
                _recentlyUpdatedShows = value;
                base.RaisePropertyChanged();
            }
        }

        public override async Task OnNavigatedToAsync(object parameter, NavigationMode mode, IDictionary<string, object> state)
        {
            if (RecentlyUpdatedShows != null && RecentlyUpdatedShows.Count <= 0)
                await LoadPage(1, DEFAULT_LIMIT);
        }

        protected override async Task LoadPage(int? page = null, int? limit = null)
        {
            Busy.SetBusy(true, "Loading recently updated shows...");
            var traktRecentlyUpdatedMovies = await Shows.GetRecentlyUpdatedShowsAsync(extendedInfo: DEFAULT_EXTENDED_OPTION, whichPage: page, limitPerPage: limit);

            if (traktRecentlyUpdatedMovies.Items != null)
            {
                RecentlyUpdatedShows = traktRecentlyUpdatedMovies.Items;
                SetPaginationValues(traktRecentlyUpdatedMovies);
            }

            Busy.SetBusy(false);
        }
    }
}
