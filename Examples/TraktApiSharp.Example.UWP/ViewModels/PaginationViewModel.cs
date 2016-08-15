namespace TraktApiSharp.Example.UWP.ViewModels
{
    public abstract class PaginationViewModel : BaseViewModel
    {
        protected const int DEFAULT_LIMIT = 40;

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
    }
}
