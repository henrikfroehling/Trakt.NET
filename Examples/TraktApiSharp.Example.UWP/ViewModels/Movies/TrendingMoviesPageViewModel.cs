namespace TraktApiSharp.Example.UWP.ViewModels.Movies
{
    using Models.Movies;
    using Requests.Params;
    using Services.TraktService;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Threading.Tasks;
    using Template10.Mvvm;
    using Views;
    using Windows.UI.Xaml.Navigation;

    public class TrendingMoviesPageViewModel : PaginationViewModel
    {
        private TraktMoviesService Movies { get; } = TraktMoviesService.Instance;

        public TrendingMoviesPageViewModel()
        {
            GoToPreviousPage = new DelegateCommand(PreviousPage);
            GoToNextPage = new DelegateCommand(NextPage);
            GoToSelectedPage = new DelegateCommand(SelectPage);
        }

        private ObservableCollection<TrendingMovie> _trendingMovies = new ObservableCollection<TrendingMovie>();

        public ObservableCollection<TrendingMovie> TrendingMovies
        {
            get { return _trendingMovies; }

            set
            {
                _trendingMovies = value;
                base.RaisePropertyChanged();
            }
        }

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

        public DelegateCommand GoToPreviousPage { get; }

        public DelegateCommand GoToNextPage { get; }

        public DelegateCommand GoToSelectedPage { get; }

        public override async Task OnNavigatedToAsync(object parameter, NavigationMode mode, IDictionary<string, object> state)
        {
            if (TrendingMovies != null && TrendingMovies.Count <= 0)
                await LoadPage(1, DEFAULT_LIMIT);
        }

        protected async void PreviousPage()
        {
            if (CurrentPage > 1)
                await LoadPage(CurrentPage - 1, SelectedLimit > 0 ? SelectedLimit : DEFAULT_LIMIT);
        }

        protected async void NextPage()
        {
            if (CurrentPage < TotalPages)
                await LoadPage(CurrentPage + 1, SelectedLimit > 0 ? SelectedLimit : DEFAULT_LIMIT);
        }

        protected async void SelectPage()
        {
            if (SelectedPage > 0 && SelectedPage <= TotalPages)
                await LoadPage(SelectedPage, SelectedLimit > 0 ? SelectedLimit : DEFAULT_LIMIT);
        }

        protected async Task LoadPage(int? page = null, int? limit = null)
        {
            var extendedOption = new TraktExtendedOption
            {
                Full = true,
                Images = true
            };

            Busy.SetBusy(true, "Loading trending movies...");
            var trendingMovies = await Movies.GetTrendingMoviesAsync(extendedOption, whichPage: page, limitPerPage: limit);

            if (trendingMovies.Items != null)
            {
                TrendingMovies = trendingMovies.Items;
                TotalUsers = trendingMovies.TotalUserCount.GetValueOrDefault();
                CurrentPage = trendingMovies.CurrentPage.GetValueOrDefault();
                ItemsPerPage = trendingMovies.LimitPerPage.GetValueOrDefault();
                TotalItems = trendingMovies.TotalItemCount.GetValueOrDefault();
                TotalPages = trendingMovies.TotalPages.GetValueOrDefault();
                SelectedLimit = ItemsPerPage;
                SelectedPage = CurrentPage;
            }

            Busy.SetBusy(false);
        }
    }
}
