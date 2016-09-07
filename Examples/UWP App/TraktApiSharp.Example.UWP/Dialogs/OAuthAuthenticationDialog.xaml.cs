namespace TraktApiSharp.Example.UWP.Dialogs
{
    using System;
    using Windows.System;
    using Windows.UI.Popups;
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;

    public sealed partial class OAuthAuthenticationDialog : ContentDialog
    {
        public static readonly DependencyProperty WebsiteUrlProperty =
            DependencyProperty.Register("WebsiteUrl", typeof(string), typeof(DeviceAuthenticationDialog),
                new PropertyMetadata(string.Empty));

        public static readonly DependencyProperty CodeProperty =
            DependencyProperty.Register("Code", typeof(string), typeof(DeviceAuthenticationDialog),
                new PropertyMetadata(string.Empty));

        public OAuthAuthenticationDialog()
        {
            InitializeComponent();
            (Content as FrameworkElement).DataContext = this;
        }

        public string WebsiteUrl
        {
            get { return (string)GetValue(WebsiteUrlProperty); }
            set { SetValue(WebsiteUrlProperty, value); }
        }

        public string Code
        {
            get { return (string)GetValue(CodeProperty); }
            set { SetValue(CodeProperty, value); }
        }

        private async void btnVisitWebsite_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(WebsiteUrl))
                await Launcher.LaunchUriAsync(new Uri(WebsiteUrl));
        }

        private async void ContentDialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            if (string.IsNullOrEmpty(Code))
            {
                args.Cancel = true;
                var dialog = new MessageDialog("No, you didn't!", "No OAuth Code");
                await dialog.ShowAsync();
                txtCode.Focus(FocusState.Programmatic);
            }
        }
    }
}
