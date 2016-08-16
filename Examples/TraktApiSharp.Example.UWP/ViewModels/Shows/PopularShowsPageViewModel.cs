namespace TraktApiSharp.Example.UWP.ViewModels.Shows
{
    using Models.Shows;
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
            Busy.SetBusy(true, "Loading popular shows...");
            var traktPopularShows = await Shows.GetPopularShowsAsync(DEFAULT_EXTENDED_OPTION, whichPage: page, limitPerPage: limit);

            if (traktPopularShows.Items != null)
            {
                PopularShows = traktPopularShows.Items;
                SetPaginationValues(traktPopularShows);
            }

            Busy.SetBusy(false);
        }
    }
}
