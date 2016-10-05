namespace TraktApiSharp.Example.UWP.ViewModels.Movies
{
    using Models.Movies;
    using Requests.Params;
    using Services.TraktService;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Threading.Tasks;
    using Views;
    using Windows.UI.Xaml.Navigation;

    public class BoxOfficeMoviesPageViewModel : BaseViewModel
    {
        protected const int DEFAULT_LIMIT = 40;

        protected static readonly TraktExtendedInfo DEFAULT_EXTENDED_INFO =
            new TraktExtendedInfo { Full = true, Images = true };

        private TraktMoviesService Movies { get; } = TraktMoviesService.Instance;

        private ObservableCollection<BoxOfficeMovie> _boxOfficeMovies = new ObservableCollection<BoxOfficeMovie>();

        public ObservableCollection<BoxOfficeMovie> BoxOfficeMovies
        {
            get { return _boxOfficeMovies; }

            set
            {
                _boxOfficeMovies = value;
                base.RaisePropertyChanged();
            }
        }

        public override async Task OnNavigatedToAsync(object parameter, NavigationMode mode, IDictionary<string, object> state)
        {
            if (BoxOfficeMovies != null && BoxOfficeMovies.Count <= 0)
                await LoadPage(1, DEFAULT_LIMIT);
        }

        protected async Task LoadPage(int? page = null, int? limit = null)
        {
            Busy.SetBusy(true, "Loading box office movies...");
            var traktBoxOfficeMovies = await Movies.GetBoxOfficeMoviesAsync(DEFAULT_EXTENDED_INFO);

            if (traktBoxOfficeMovies != null)
                BoxOfficeMovies = traktBoxOfficeMovies;

            Busy.SetBusy(false);
        }
    }
}
