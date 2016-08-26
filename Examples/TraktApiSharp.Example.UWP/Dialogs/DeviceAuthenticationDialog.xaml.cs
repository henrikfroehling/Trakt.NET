namespace TraktApiSharp.Example.UWP.Dialogs
{
    using Windows.ApplicationModel.DataTransfer;
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;

    public sealed partial class DeviceAuthenticationDialog : ContentDialog
    {
        public static readonly DependencyProperty WebsiteUrlProperty =
            DependencyProperty.Register("WebsiteUrl", typeof(string), typeof(DeviceAuthenticationDialog),
                new PropertyMetadata(string.Empty));

        public static readonly DependencyProperty UserCodeProperty =
            DependencyProperty.Register("UserCode", typeof(string), typeof(DeviceAuthenticationDialog),
                new PropertyMetadata(string.Empty));

        public DeviceAuthenticationDialog()
        {
            InitializeComponent();
            (Content as FrameworkElement).DataContext = this;
        }

        public string WebsiteUrl
        {
            get { return (string)GetValue(WebsiteUrlProperty); }
            set { SetValue(WebsiteUrlProperty, value); }
        }

        public string UserCode
        {
            get { return (string)GetValue(UserCodeProperty); }
            set { SetValue(UserCodeProperty, value); }
        }

        private void btnCopyCode_Click(object sender, RoutedEventArgs e)
        {
            DataPackage dataPackage = new DataPackage();

            dataPackage.RequestedOperation = DataPackageOperation.Copy;
            dataPackage.SetText(UserCode);

            Clipboard.SetContent(dataPackage);
        }
    }
}
