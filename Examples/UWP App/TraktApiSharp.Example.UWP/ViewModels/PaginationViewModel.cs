namespace TraktApiSharp.Example.UWP.ViewModels
{
    using Models;
    using Requests.Params;
    using System.Threading.Tasks;
    using Template10.Mvvm;

    public abstract class PaginationViewModel : BaseViewModel
    {
        protected const int DEFAULT_LIMIT = 40;

        protected static readonly TraktExtendedInfo DEFAULT_EXTENDED_INFO =
            new TraktExtendedInfo { Full = true, Images = true };

        protected PaginationViewModel()
        {
            GoToPreviousPage = new DelegateCommand(PreviousPage);
            GoToNextPage = new DelegateCommand(NextPage);
            GoToSelectedPage = new DelegateCommand(SelectPage);
        }

        public DelegateCommand GoToPreviousPage { get; }

        public DelegateCommand GoToNextPage { get; }

        public DelegateCommand GoToSelectedPage { get; }

        protected void SetPaginationValues<T>(PaginationList<T> paginationList)
        {
            CurrentPage = paginationList.CurrentPage.GetValueOrDefault();
            ItemsPerPage = paginationList.LimitPerPage.GetValueOrDefault();
            TotalItems = paginationList.TotalItemCount.GetValueOrDefault();
            TotalPages = paginationList.TotalPages.GetValueOrDefault();
            SelectedLimit = ItemsPerPage;
            SelectedPage = CurrentPage;
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

        protected abstract Task LoadPage(int? page = null, int? limit = null);

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

        private int _selectedPage;

        public int SelectedPage
        {
            get { return _selectedPage; }

            set
            {
                _selectedPage = value;
                base.RaisePropertyChanged();
            }
        }

        private int _selectedLimit;

        public int SelectedLimit
        {
            get { return _selectedLimit; }

            set
            {
                _selectedLimit = value;
                base.RaisePropertyChanged();
            }
        }
    }
}
