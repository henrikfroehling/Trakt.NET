namespace TraktApiSharp.Example.UWP.Dialogs
{
    using Windows.ApplicationModel.DataTransfer;
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;

    public sealed partial class ExceptionDialog : ContentDialog
    {
        public static readonly DependencyProperty ExceptionContentProperty =
            DependencyProperty.Register("ExceptionContent", typeof(string), typeof(DeviceAuthenticationDialog),
                new PropertyMetadata(string.Empty));

        public ExceptionDialog()
        {
            InitializeComponent();
            (Content as FrameworkElement).DataContext = this;
        }

        public string ExceptionContent
        {
            get { return (string)GetValue(ExceptionContentProperty); }
            set { SetValue(ExceptionContentProperty, value); }
        }

        private void btnCopyContent_Click(object sender, RoutedEventArgs e)
        {
            DataPackage dataPackage = new DataPackage();

            dataPackage.RequestedOperation = DataPackageOperation.Copy;
            dataPackage.SetText(ExceptionContent);

            Clipboard.SetContent(dataPackage);
        }
    }
}
