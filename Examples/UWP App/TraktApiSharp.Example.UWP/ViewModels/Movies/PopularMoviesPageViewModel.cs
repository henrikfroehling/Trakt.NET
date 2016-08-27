namespace TraktApiSharp.Example.UWP.ViewModels.Movies
{
    using Models.Movies;
    using Services.TraktService;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Threading.Tasks;
    using Views;
    using Windows.UI.Xaml.Navigation;

    public class PopularMoviesPageViewModel : PaginationViewModel
    {
        private TraktMoviesService Movies { get; } = TraktMoviesService.Instance;

        private ObservableCollection<Movie> _popularMovies = new ObservableCollection<Movie>();

        public ObservableCollection<Movie> PopularMovies
        {
            get { return _popularMovies; }

            set
            {
                _popularMovies = value;
                base.RaisePropertyChanged();
            }
        }

        public override async Task OnNavigatedToAsync(object parameter, NavigationMode mode, IDictionary<string, object> state)
        {
            if (PopularMovies != null && PopularMovies.Count <= 0)
                await LoadPage(1, DEFAULT_LIMIT);
        }

        protected override async Task LoadPage(int? page = default(int?), int? limit = default(int?))
        {
            Busy.SetBusy(true, "Loading popular movies...");
            var traktPopularMovies = await Movies.GetPopularMoviesAsync(DEFAULT_EXTENDED_OPTION, whichPage: page, limitPerPage: limit);

            if (traktPopularMovies.Items != null)
            {
                PopularMovies = traktPopularMovies.Items;
                SetPaginationValues(traktPopularMovies);
            }

            Busy.SetBusy(false);
        }
    }
}
