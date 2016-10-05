namespace TraktApiSharp.Example.UWP.ViewModels.Movies
{
    using Models.Movies;
    using Services.TraktService;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Threading.Tasks;
    using Views;
    using Windows.UI.Xaml.Navigation;

    public class MostCollectedMoviesPageViewModel : PaginationViewModel
    {
        private TraktMoviesService Movies { get; } = TraktMoviesService.Instance;

        private ObservableCollection<MostPWCMovie> _mostCollectedMovies = new ObservableCollection<MostPWCMovie>();

        public ObservableCollection<MostPWCMovie> MostCollectedMovies
        {
            get { return _mostCollectedMovies; }

            set
            {
                _mostCollectedMovies = value;
                base.RaisePropertyChanged();
            }
        }

        public override async Task OnNavigatedToAsync(object parameter, NavigationMode mode, IDictionary<string, object> state)
        {
            if (MostCollectedMovies != null && MostCollectedMovies.Count <= 0)
                await LoadPage(1, DEFAULT_LIMIT);
        }

        protected override async Task LoadPage(int? page = null, int? limit = null)
        {
            Busy.SetBusy(true, "Loading most collected movies...");
            var traktMostCollectedMovies = await Movies.GetMostCollectedMoviesAsync(DEFAULT_EXTENDED_INFO, whichPage: page, limitPerPage: limit);

            if (traktMostCollectedMovies.Items != null)
            {
                MostCollectedMovies = traktMostCollectedMovies.Items;
                SetPaginationValues(traktMostCollectedMovies);
            }

            Busy.SetBusy(false);
        }
    }
}
