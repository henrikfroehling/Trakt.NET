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

    public class TrendingMoviesPageViewModel : BaseViewModel
    {
        private const int DEFAULT_LIMIT = 40;

        private TraktMoviesService Movies { get; } = TraktMoviesService.Instance;

        public ObservableCollection<TrendingMovie> TrendingMovies { get; set; } = new ObservableCollection<TrendingMovie>();

        private int _totalUsers = 0;

        public int TotalUsers
        {
            get { return _totalUsers; }

            set
            {
                _totalUsers = value;
                base.RaisePropertyChanged();
            }
        }

        private int _currentPage = 0;

        public int CurrentPage
        {
            get { return _currentPage; }

            set
            {
                _currentPage = value;
                base.RaisePropertyChanged();
            }
        }

        private int _itemsPerPage = 0;

        public int ItemsPerPage
        {
            get { return _itemsPerPage; }

            set
            {
                _itemsPerPage = value;
                base.RaisePropertyChanged();
            }
        }

        private int _totalPages = 0;

        public int TotalPages
        {
            get { return _totalPages; }

            set
            {
                _totalPages = value;
                base.RaisePropertyChanged();
            }
        }

        private int _totalItems = 0;

        public int TotalItems
        {
            get { return _totalItems; }

            set
            {
                _totalItems = value;
                base.RaisePropertyChanged();
            }
        }

        public override async Task OnNavigatedToAsync(object parameter, NavigationMode mode, IDictionary<string, object> state)
        {
            if (TrendingMovies != null && TrendingMovies.Count <= 0)
            {
                var extendedOption = new TraktExtendedOption
                {
                    Full = true,
                    Images = true
                };

                Busy.SetBusy(true, "Loading trending movies...");
                var trendingMovies = await Movies.GetTrendingMoviesAsync(extendedOption, limitPerPage: DEFAULT_LIMIT);

                if (trendingMovies.Items != null)
                {
                    TrendingMovies = trendingMovies.Items;
                    TotalUsers = trendingMovies.TotalUserCount.GetValueOrDefault();
                    CurrentPage = trendingMovies.CurrentPage.GetValueOrDefault();
                    ItemsPerPage = trendingMovies.LimitPerPage.GetValueOrDefault();
                    TotalItems = trendingMovies.TotalItemCount.GetValueOrDefault();
                    TotalPages = trendingMovies.TotalPages.GetValueOrDefault();
                }

                Busy.SetBusy(false);
            }
        }
    }
}
