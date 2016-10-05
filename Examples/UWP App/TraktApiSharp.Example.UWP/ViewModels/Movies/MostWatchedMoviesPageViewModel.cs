namespace TraktApiSharp.Example.UWP.ViewModels.Movies
{
    using Models.Movies;
    using Services.TraktService;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Threading.Tasks;
    using Views;
    using Windows.UI.Xaml.Navigation;

    public class MostWatchedMoviesPageViewModel : PaginationViewModel
    {
        private TraktMoviesService Movies { get; } = TraktMoviesService.Instance;

        private ObservableCollection<MostPWCMovie> _mostWatchedMovies = new ObservableCollection<MostPWCMovie>();

        public ObservableCollection<MostPWCMovie> MostWatchedMovies
        {
            get { return _mostWatchedMovies; }

            set
            {
                _mostWatchedMovies = value;
                base.RaisePropertyChanged();
            }
        }

        public override async Task OnNavigatedToAsync(object parameter, NavigationMode mode, IDictionary<string, object> state)
        {
            if (MostWatchedMovies != null && MostWatchedMovies.Count <= 0)
                await LoadPage(1, DEFAULT_LIMIT);
        }

        protected override async Task LoadPage(int? page = null, int? limit = null)
        {
            Busy.SetBusy(true, "Loading most watched movies...");
            var traktMostWatchedMovies = await Movies.GetMostWatchedMoviesAsync(DEFAULT_EXTENDED_INFO, whichPage: page, limitPerPage: limit);

            if (traktMostWatchedMovies.Items != null)
            {
                MostWatchedMovies = traktMostWatchedMovies.Items;
                SetPaginationValues(traktMostWatchedMovies);
            }

            Busy.SetBusy(false);
        }
    }
}
