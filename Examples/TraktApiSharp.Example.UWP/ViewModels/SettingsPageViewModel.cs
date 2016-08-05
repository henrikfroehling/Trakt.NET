namespace TraktApiSharp.Example.UWP.ViewModels
{
    using System;
    using System.Threading.Tasks;
    using Template10.Mvvm;
    using Windows.UI.Xaml;

    public class SettingsPageViewModel : ViewModelBase
    {
        public TraktClientPartViewModel TraktClientPartViewModel { get; } = new TraktClientPartViewModel();
        public SettingsPartViewModel SettingsPartViewModel { get; } = new SettingsPartViewModel();
        public AboutPartViewModel AboutPartViewModel { get; } = new AboutPartViewModel();
    }

    public class TraktClientPartViewModel : ViewModelBase
    {
        private string _clientId = string.Empty;

        public string ClientId
        {
            get { return _clientId; }

            set
            {
                _clientId = value;
                base.RaisePropertyChanged();
            }
        }

        private string _clientSecret = string.Empty;

        public string ClientSecret
        {
            get { return _clientSecret; }

            set
            {
                _clientSecret = value;
                base.RaisePropertyChanged();
            }
        }

        private string _clientAccessToken;

        public string ClientAccessToken
        {
            get { return _clientAccessToken; }

            set
            {
                _clientAccessToken = value;
                base.RaisePropertyChanged();
            }
        }

        private bool _useStagingUrl = false;

        public bool UseStagingUrl
        {
            get { return _useStagingUrl; }

            set
            {
                _useStagingUrl = value;
                base.RaisePropertyChanged();
            }
        }

        private bool _forceAuthorization = false;

        public bool ForceAuthorization
        {
            get { return _forceAuthorization; }

            set
            {
                _forceAuthorization = value;
                base.RaisePropertyChanged();
            }
        }
    }

    public class SettingsPartViewModel : ViewModelBase
    {
        Services.SettingsServices.SettingsService _settings;

        public SettingsPartViewModel()
        {
            if (Windows.ApplicationModel.DesignMode.DesignModeEnabled)
            {
                // designtime
            }
            else
            {
                _settings = Services.SettingsServices.SettingsService.Instance;
            }
        }

        public bool UseShellBackButton
        {
            get { return _settings.UseShellBackButton; }
            set { _settings.UseShellBackButton = value; base.RaisePropertyChanged(); }
        }

        public bool UseLightThemeButton
        {
            get { return _settings.AppTheme.Equals(ApplicationTheme.Light); }
            set { _settings.AppTheme = value ? ApplicationTheme.Light : ApplicationTheme.Dark; base.RaisePropertyChanged(); }
        }

        private string _BusyText = "Please wait...";
        public string BusyText
        {
            get { return _BusyText; }
            set
            {
                Set(ref _BusyText, value);
                _ShowBusyCommand.RaiseCanExecuteChanged();
            }
        }

        DelegateCommand _ShowBusyCommand;
        public DelegateCommand ShowBusyCommand
            => _ShowBusyCommand ?? (_ShowBusyCommand = new DelegateCommand(async () =>
            {
                Views.Busy.SetBusy(true, _BusyText);
                await Task.Delay(5000);
                Views.Busy.SetBusy(false);
            }, () => !string.IsNullOrEmpty(BusyText)));
    }

    public class AboutPartViewModel : ViewModelBase
    {
        public string Logo => Windows.ApplicationModel.Package.Current.Logo.AbsolutePath;

        public string DisplayName => Windows.ApplicationModel.Package.Current.DisplayName;

        public string Publisher => Windows.ApplicationModel.Package.Current.PublisherDisplayName;

        public string Version
        {
            get
            {
                var v = Windows.ApplicationModel.Package.Current.Id.Version;
                return $"{v.Major}.{v.Minor}.{v.Build}.{v.Revision}";
            }
        }

        public Uri RateMe => new Uri("http://aka.ms/template10");
    }
}
