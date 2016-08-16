namespace TraktApiSharp.Example.UWP.ViewModels.Shows
{
    using Models.Shows;
    using Requests.Params;
    using Services.TraktService;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Threading.Tasks;
    using Views;
    using Windows.UI.Xaml.Navigation;

    public class PopularShowsPageViewModel : PaginationViewModel
    {
        private TraktShowsService Shows { get; } = TraktShowsService.Instance;

        private ObservableCollection<Show> _popularShows = new ObservableCollection<Show>();

        public ObservableCollection<Show> PopularShows
        {
            get { return _popularShows; }

            set
            {
                _popularShows = value;
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

        public override async Task OnNavigatedToAsync(object parameter, NavigationMode mode, IDictionary<string, object> state)
        {
            if (PopularShows != null && PopularShows.Count <= 0)
                await LoadPage(1, DEFAULT_LIMIT);
        }

        protected override async Task LoadPage(int? page = null, int? limit = null)
        {
            var extendedOption = new TraktExtendedOption
            {
                Full = true,
                Images = true
            };

            Busy.SetBusy(true, "Loading popular shows...");
            var traktPopularShows = await Shows.GetPopularShowsAsync(extendedOption, whichPage: page, limitPerPage: limit);

            if (traktPopularShows.Items != null)
            {
                PopularShows = traktPopularShows.Items;
                TotalUsers = traktPopularShows.TotalUserCount.GetValueOrDefault();
                CurrentPage = traktPopularShows.CurrentPage.GetValueOrDefault();
                ItemsPerPage = traktPopularShows.LimitPerPage.GetValueOrDefault();
                TotalItems = traktPopularShows.TotalItemCount.GetValueOrDefault();
                TotalPages = traktPopularShows.TotalPages.GetValueOrDefault();
                SelectedLimit = ItemsPerPage;
                SelectedPage = CurrentPage;
            }

            Busy.SetBusy(false);
        }
    }
}
