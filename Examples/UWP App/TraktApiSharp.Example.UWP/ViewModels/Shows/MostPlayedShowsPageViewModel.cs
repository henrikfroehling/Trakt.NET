namespace TraktApiSharp.Example.UWP.ViewModels.Shows
{
    using Models.Shows;
    using Services.TraktService;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Threading.Tasks;
    using Views;
    using Windows.UI.Xaml.Navigation;

    public class MostPlayedShowsPageViewModel : PaginationViewModel
    {
        private TraktShowsService Shows { get; } = TraktShowsService.Instance;

        private ObservableCollection<MostPWCShow> _mostPlayedShows = new ObservableCollection<MostPWCShow>();

        public ObservableCollection<MostPWCShow> MostPlayedShows
        {
            get { return _mostPlayedShows; }

            set
            {
                _mostPlayedShows = value;
                base.RaisePropertyChanged();
            }
        }

        public override async Task OnNavigatedToAsync(object parameter, NavigationMode mode, IDictionary<string, object> state)
        {
            if (MostPlayedShows != null && MostPlayedShows.Count <= 0)
                await LoadPage(1, DEFAULT_LIMIT);
        }

        protected override async Task LoadPage(int? page = null, int? limit = null)
        {
            Busy.SetBusy(true, "Loading most played shows...");
            var traktMostPlayedMovies = await Shows.GetMostPlayedShowsAsync(DEFAULT_EXTENDED_OPTION, whichPage: page, limitPerPage: limit);

            if (traktMostPlayedMovies.Items != null)
            {
                MostPlayedShows = traktMostPlayedMovies.Items;
                SetPaginationValues(traktMostPlayedMovies);
            }

            Busy.SetBusy(false);
        }
    }
}
