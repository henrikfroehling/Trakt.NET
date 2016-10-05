namespace TraktApiSharp.Example.UWP.ViewModels.Shows
{
    using Models.Shows;
    using Services.TraktService;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Threading.Tasks;
    using Views;
    using Windows.UI.Xaml.Navigation;

    public class MostWatchedShowsPageViewModel : PaginationViewModel
    {
        private TraktShowsService Shows { get; } = TraktShowsService.Instance;

        private ObservableCollection<MostPWCShow> _mostWatchedShows = new ObservableCollection<MostPWCShow>();

        public ObservableCollection<MostPWCShow> MostWatchedShows
        {
            get { return _mostWatchedShows; }

            set
            {
                _mostWatchedShows = value;
                base.RaisePropertyChanged();
            }
        }

        public override async Task OnNavigatedToAsync(object parameter, NavigationMode mode, IDictionary<string, object> state)
        {
            if (MostWatchedShows != null && MostWatchedShows.Count <= 0)
                await LoadPage(1, DEFAULT_LIMIT);
        }

        protected override async Task LoadPage(int? page = null, int? limit = null)
        {
            Busy.SetBusy(true, "Loading most watched shows...");
            var traktMostWatchedMovies = await Shows.GetMostWatchedShowsAsync(DEFAULT_EXTENDED_INFO, whichPage: page, limitPerPage: limit);

            if (traktMostWatchedMovies.Items != null)
            {
                MostWatchedShows = traktMostWatchedMovies.Items;
                SetPaginationValues(traktMostWatchedMovies);
            }

            Busy.SetBusy(false);
        }
    }
}
