namespace TraktApiSharp.Example.UWP.ViewModels.Movies
{
    using Models.Movies;
    using Services.TraktService;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Threading.Tasks;
    using Views;
    using Windows.UI.Xaml.Navigation;

    public class MostAnticipatedMoviesPageViewModel : PaginationViewModel
    {
        private TraktMoviesService Movies { get; } = TraktMoviesService.Instance;

        private ObservableCollection<AnticipatedMovie> _mostAnticipatedMovies = new ObservableCollection<AnticipatedMovie>();

        public ObservableCollection<AnticipatedMovie> MostAnticipatedMovies
        {
            get { return _mostAnticipatedMovies; }

            set
            {
                _mostAnticipatedMovies = value;
                base.RaisePropertyChanged();
            }
        }

        public override async Task OnNavigatedToAsync(object parameter, NavigationMode mode, IDictionary<string, object> state)
        {
            if (MostAnticipatedMovies != null && MostAnticipatedMovies.Count <= 0)
                await LoadPage(1, DEFAULT_LIMIT);
        }

        protected override async Task LoadPage(int? page = null, int? limit = null)
        {
            Busy.SetBusy(true, "Loading most anticipated movies...");
            var traktMostAnticipatedMovies = await Movies.GetMostAnticipatedMoviesAsync(DEFAULT_EXTENDED_INFO, whichPage: page, limitPerPage: limit);

            if (traktMostAnticipatedMovies.Items != null)
            {
                MostAnticipatedMovies = traktMostAnticipatedMovies.Items;
                SetPaginationValues(traktMostAnticipatedMovies);
            }

            Busy.SetBusy(false);
        }
    }
}
