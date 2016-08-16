namespace TraktApiSharp.Example.UWP.ViewModels.Shows
{
    using Models.Shows;
    using Services.TraktService;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Threading.Tasks;
    using Views;
    using Windows.UI.Xaml.Navigation;

    public class MostAnticipatedShowsPageViewModel : PaginationViewModel
    {
        private TraktShowsService Shows { get; } = TraktShowsService.Instance;

        private ObservableCollection<AnticipatedShow> _mostAnticipatedShows = new ObservableCollection<AnticipatedShow>();

        public ObservableCollection<AnticipatedShow> MostAnticipatedShows
        {
            get { return _mostAnticipatedShows; }

            set
            {
                _mostAnticipatedShows = value;
                base.RaisePropertyChanged();
            }
        }

        public override async Task OnNavigatedToAsync(object parameter, NavigationMode mode, IDictionary<string, object> state)
        {
            if (MostAnticipatedShows != null && MostAnticipatedShows.Count <= 0)
                await LoadPage(1, DEFAULT_LIMIT);
        }

        protected override async Task LoadPage(int? page = null, int? limit = null)
        {
            Busy.SetBusy(true, "Loading most anticipated shows...");
            var traktMostAnticipatedMovies = await Shows.GetMostAnticipatedShowsAsync(DEFAULT_EXTENDED_OPTION, whichPage: page, limitPerPage: limit);

            if (traktMostAnticipatedMovies.Items != null)
            {
                MostAnticipatedShows = traktMostAnticipatedMovies.Items;
                SetPaginationValues(traktMostAnticipatedMovies);
            }

            Busy.SetBusy(false);
        }
    }
}
