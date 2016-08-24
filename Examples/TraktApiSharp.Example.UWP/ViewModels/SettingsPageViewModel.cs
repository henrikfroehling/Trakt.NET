namespace TraktApiSharp.Example.UWP.ViewModels
{
    using Authentication;
    using Template10.Mvvm;
    using Windows.UI.Xaml;

    public class SettingsPageViewModel : ViewModelBase
    {
        public TraktClientPartViewModel TraktClientPartViewModel { get; } = new TraktClientPartViewModel();
        public TraktAuthorizationPartViewModel TraktAuthorizationPartViewModel { get; } = new TraktAuthorizationPartViewModel();
        public SettingsPartViewModel SettingsPartViewModel { get; } = new SettingsPartViewModel();
        public AboutPartViewModel AboutPartViewModel { get; } = new AboutPartViewModel();
    }

    public class TraktClientPartViewModel : ViewModelBase
    {
        Services.SettingsServices.SettingsService _settings;

        public TraktClientPartViewModel()
        {
            _settings = Services.SettingsServices.SettingsService.Instance;
        }

        public string ClientId
        {
            get { return _settings.TraktClientId; }

            set
            {
                _settings.TraktClientId = value;
                base.RaisePropertyChanged();
            }
        }

        public string ClientSecret
        {
            get { return _settings.TraktClientSecret; }

            set
            {
                _settings.TraktClientSecret = value;
                base.RaisePropertyChanged();
            }
        }

        public string ClientAccessToken
        {
            get { return _settings.TraktClientAccessToken; }

            set
            {
                _settings.TraktClientAccessToken = value;
                base.RaisePropertyChanged();
            }
        }

        public bool UseStagingUrl
        {
            get { return _settings.TraktUseStagingUrl; }

            set
            {
                _settings.TraktUseStagingUrl = value;
                base.RaisePropertyChanged();
            }
        }

        public bool ForceAuthorization
        {
            get { return _settings.TraktForceAuthorization; }

            set
            {
                _settings.TraktForceAuthorization = value;
                base.RaisePropertyChanged();
            }
        }
    }

    public class TraktAuthorizationPartViewModel : ViewModelBase
    {
        private const int OAUTH_AUTHENTICATION = 1;
        private const int DEVICE_AUTHENTICATION = 2;

        Services.SettingsServices.SettingsService _settings;

        private TraktAuthorization _authorization = null;

        public TraktAuthorizationPartViewModel()
        {
            _settings = Services.SettingsServices.SettingsService.Instance;
            _authorization = _settings.TraktClientAuthorization;
        }

        public string AccessToken
        {
            get { return _authorization.AccessToken; }
        }

        public string RefreshToken
        {
            get { return _authorization.RefreshToken; }
        }

        public int ExpiresInDays
        {
            get { return _authorization.ExpiresInSeconds / 3600 / 24; }
        }

        public bool IsExpired
        {
            get { return _authorization.IsExpired; }
        }

        public bool IsValid
        {
            get { return _authorization.IsValid; }
        }

        public bool IsRefreshPossible
        {
            get { return _authorization.IsRefreshPossible; }
        }

        public string CreatedAt
        {
            get { return _authorization.Created.ToString(); }
        }

        private int _authenticationMethod = OAUTH_AUTHENTICATION;

        public int AuthenticationMethod
        {
            get { return _authenticationMethod; }

            set
            {
                _authenticationMethod = value;
                base.RaisePropertyChanged(nameof(OAuthAuthentication));
                base.RaisePropertyChanged(nameof(DeviceAuthentication));
            }
        }

        public bool? OAuthAuthentication
        {
            get { return AuthenticationMethod == OAUTH_AUTHENTICATION; }

            set
            {
                if (value == true)
                    AuthenticationMethod = OAUTH_AUTHENTICATION;
            }
        }

        public bool? DeviceAuthentication
        {
            get { return AuthenticationMethod == DEVICE_AUTHENTICATION; }

            set
            {
                if (value == true)
                    AuthenticationMethod = DEVICE_AUTHENTICATION;
            }
        }

        //public TraktAuthorization Authorization
        //{
        //    get { return _settings.TraktClientAuthorization; }

        //    set
        //    {
        //        _settings.TraktClientAuthorization = value;
        //        base.RaisePropertyChanged();
        //    }
        //}
    }

    public class SettingsPartViewModel : ViewModelBase
    {
        Services.SettingsServices.SettingsService _settings;

        public SettingsPartViewModel()
        {
            _settings = Services.SettingsServices.SettingsService.Instance;
        }

        public bool UseShellBackButton
        {
            get { return _settings.UseShellBackButton; }

            set
            {
                _settings.UseShellBackButton = value;
                base.RaisePropertyChanged();
            }
        }

        public bool UseLightThemeButton
        {
            get { return _settings.AppTheme.Equals(ApplicationTheme.Light); }

            set
            {
                _settings.AppTheme = value ? ApplicationTheme.Light : ApplicationTheme.Dark;
                base.RaisePropertyChanged();
            }
        }
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
    }
}
