namespace TraktApiSharp.Example.UWP.ViewModels.Movies
{
    using Models.Movies;
    using Services.TraktService;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Threading.Tasks;
    using Views;
    using Windows.UI.Xaml.Navigation;

    public class MostPlayedMoviesPageViewModel : PaginationViewModel
    {
        private TraktMoviesService Movies { get; } = TraktMoviesService.Instance;

        private ObservableCollection<MostPWCMovie> _mostPlayedMovies = new ObservableCollection<MostPWCMovie>();

        public ObservableCollection<MostPWCMovie> MostPlayedMovies
        {
            get { return _mostPlayedMovies; }

            set
            {
                _mostPlayedMovies = value;
                base.RaisePropertyChanged();
            }
        }

        public override async Task OnNavigatedToAsync(object parameter, NavigationMode mode, IDictionary<string, object> state)
        {
            if (MostPlayedMovies != null && MostPlayedMovies.Count <= 0)
                await LoadPage(1, DEFAULT_LIMIT);
        }

        protected override async Task LoadPage(int? page = null, int? limit = null)
        {
            Busy.SetBusy(true, "Loading most played movies...");
            var traktMostPlayedMovies = await Movies.GetMostPlayedMoviesAsync(DEFAULT_EXTENDED_OPTION, whichPage: page, limitPerPage: limit);

            if (traktMostPlayedMovies.Items != null)
            {
                MostPlayedMovies = traktMostPlayedMovies.Items;
                SetPaginationValues(traktMostPlayedMovies);
            }

            Busy.SetBusy(false);
        }
    }
}
