namespace TraktApiSharp.Example.UWP.Controls
{
    using Template10.Mvvm;
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;

    public sealed partial class PaginationControl : UserControl
    {
        public static readonly DependencyProperty CurrentPageProperty =
            DependencyProperty.Register("CurrentPage", typeof(int), typeof(PaginationControl),
                new PropertyMetadata(0));

        public static readonly DependencyProperty ItemsPerPageProperty =
            DependencyProperty.Register("ItemsPerPage", typeof(int), typeof(PaginationControl),
                new PropertyMetadata(0));

        public static readonly DependencyProperty TotalPageCountProperty =
            DependencyProperty.Register("TotalPageCount", typeof(int), typeof(PaginationControl),
                new PropertyMetadata(0));

        public static readonly DependencyProperty TotalItemCountProperty =
            DependencyProperty.Register("TotalItemCount", typeof(int), typeof(PaginationControl),
                new PropertyMetadata(0));

        public static readonly DependencyProperty SelectedPageProperty =
            DependencyProperty.Register("SelectedPage", typeof(int), typeof(PaginationControl),
                new PropertyMetadata(0));

        public static readonly DependencyProperty SelectedLimitProperty =
            DependencyProperty.Register("SelectedLimit", typeof(int), typeof(PaginationControl),
                new PropertyMetadata(0));

        public static readonly DependencyProperty PreviousPageCommandProperty =
            DependencyProperty.Register("PreviousPageCommand", typeof(DelegateCommand), typeof(PaginationControl),
                new PropertyMetadata(null));

        public static readonly DependencyProperty NextPageCommandProperty =
            DependencyProperty.Register("NextPageCommand", typeof(DelegateCommand), typeof(PaginationControl),
                new PropertyMetadata(null));

        public static readonly DependencyProperty SelectPageCommandProperty =
            DependencyProperty.Register("SelectPageCommand", typeof(DelegateCommand), typeof(PaginationControl),
                new PropertyMetadata(null));

        public PaginationControl()
        {
            InitializeComponent();
            (Content as FrameworkElement).DataContext = this;
        }

        public DelegateCommand PreviousPageCommand
        {
            get { return (DelegateCommand)GetValue(PreviousPageCommandProperty); }
            set { SetValue(PreviousPageCommandProperty, value); }
        }

        public DelegateCommand NextPageCommand
        {
            get { return (DelegateCommand)GetValue(NextPageCommandProperty); }
            set { SetValue(NextPageCommandProperty, value); }
        }

        public DelegateCommand SelectPageCommand
        {
            get { return (DelegateCommand)GetValue(SelectPageCommandProperty); }
            set { SetValue(SelectPageCommandProperty, value); }
        }

        public int CurrentPage
        {
            get { return (int)GetValue(CurrentPageProperty); }
            set { SetValue(CurrentPageProperty, value); }
        }

        public int ItemsPerPage
        {
            get { return (int)GetValue(ItemsPerPageProperty); }
            set { SetValue(ItemsPerPageProperty, value); }
        }

        public int TotalPageCount
        {
            get { return (int)GetValue(TotalPageCountProperty); }
            set { SetValue(TotalPageCountProperty, value); }
        }

        public int TotalItemCount
        {
            get { return (int)GetValue(TotalItemCountProperty); }
            set { SetValue(TotalItemCountProperty, value); }
        }

        public int SelectedPage
        {
            get { return (int)GetValue(SelectedPageProperty); }
            set { SetValue(SelectedPageProperty, value); }
        }

        public int SelectedLimit
        {
            get { return (int)GetValue(SelectedLimitProperty); }
            set { SetValue(SelectedLimitProperty, value); }
        }
    }
}
