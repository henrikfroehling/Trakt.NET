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
            var extendedOption = new TraktExtendedOption
            {
                Full = true,
                Images = true
            };

            Busy.SetBusy(true, "Loading most played movies...");
            var traktMostPlayedMovies = await Movies.GetMostPlayedMoviesAsync(extendedOption, whichPage: page, limitPerPage: limit);

            if (traktMostPlayedMovies.Items != null)
            {
                MostPlayedMovies = traktMostPlayedMovies.Items;
                CurrentPage = traktMostPlayedMovies.CurrentPage.GetValueOrDefault();
                ItemsPerPage = traktMostPlayedMovies.LimitPerPage.GetValueOrDefault();
                TotalItems = traktMostPlayedMovies.TotalItemCount.GetValueOrDefault();
                TotalPages = traktMostPlayedMovies.TotalPages.GetValueOrDefault();
                SelectedLimit = ItemsPerPage;
                SelectedPage = CurrentPage;
            }

            Busy.SetBusy(false);
        }
    }
}
