namespace TraktApiSharp.Example.UWP.ViewModels.Shows
{
    using Models.Shows;
    using Services.TraktService;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Threading.Tasks;
    using Views;
    using Windows.UI.Xaml.Navigation;

    public class MostCollectedShowsPageViewModel : PaginationViewModel
    {
        private TraktShowsService Shows { get; } = TraktShowsService.Instance;

        private ObservableCollection<MostPWCShow> _mostCollectedShows = new ObservableCollection<MostPWCShow>();

        public ObservableCollection<MostPWCShow> MostCollectedShows
        {
            get { return _mostCollectedShows; }

            set
            {
                _mostCollectedShows = value;
                base.RaisePropertyChanged();
            }
        }

        public override async Task OnNavigatedToAsync(object parameter, NavigationMode mode, IDictionary<string, object> state)
        {
            if (MostCollectedShows != null && MostCollectedShows.Count <= 0)
                await LoadPage(1, DEFAULT_LIMIT);
        }

        protected override async Task LoadPage(int? page = null, int? limit = null)
        {
            Busy.SetBusy(true, "Loading most collected shows...");
            var traktMostCollectedMovies = await Shows.GetMostCollectedShowsAsync(DEFAULT_EXTENDED_INFO, whichPage: page, limitPerPage: limit);

            if (traktMostCollectedMovies.Items != null)
            {
                MostCollectedShows = traktMostCollectedMovies.Items;
                SetPaginationValues(traktMostCollectedMovies);
            }

            Busy.SetBusy(false);
        }
    }
}
