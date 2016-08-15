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

    public class TrendingMoviesPageViewModel : PaginationViewModel
    {
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
