namespace TraktApiSharp.Example.UWP.ViewModels
{
    using Authentication;
    using Dialogs;
    using Enums;
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Threading.Tasks;
    using Template10.Mvvm;
    using Template10.Services.NavigationService;
    using Windows.System;
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Navigation;

    public class SettingsPageViewModel : ViewModelBase
    {
        Services.SettingsServices.SettingsService _settings;

        public SettingsPageViewModel()
        {
            _settings = Services.SettingsServices.SettingsService.Instance;
        }

        public TraktClientPartViewModel TraktClientPartViewModel { get; } = new TraktClientPartViewModel();
        public TraktAuthorizationPartViewModel TraktAuthorizationPartViewModel { get; } = new TraktAuthorizationPartViewModel();
        public SettingsPartViewModel SettingsPartViewModel { get; } = new SettingsPartViewModel();
        public AboutPartViewModel AboutPartViewModel { get; } = new AboutPartViewModel();

        public override Task OnNavigatedToAsync(object parameter, NavigationMode mode, IDictionary<string, object> state)
        {
            var authorization = _settings.TraktClientAuthorization;

            if (authorization != null && authorization.IsValid)
                TraktAuthorizationPartViewModel.Authorization = authorization;

            return base.OnNavigatedToAsync(parameter, mode, state);
        }

        public override Task OnNavigatingFromAsync(NavigatingEventArgs args)
        {
            _settings.TraktClientAuthorization = TraktAuthorizationPartViewModel.Authorization;
            return base.OnNavigatingFromAsync(args);
        }
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

        private static readonly TraktAuthorization DEFAULT_AUTHORIZATION = new TraktAuthorization
        {
            AccessToken = "no token",
            RefreshToken = "no token",
            AccessScope = TraktAccessScope.Public,
            ExpiresIn = 0,
            TokenType = TraktAccessTokenType.Bearer
        };

        public TraktAuthorizationPartViewModel()
        {
            AuthenticateCommand = new DelegateCommand(Authenticate);
            RefreshCommand = new DelegateCommand(RefreshAuthorization);
            RevokeCommand = new DelegateCommand(Revoke);
        }

        public string AccessToken
        {
            get { return Authorization.AccessToken; }
        }

        public string RefreshToken
        {
            get { return Authorization.RefreshToken; }
        }

        public int ExpiresInDays
        {
            get { return Authorization.ExpiresInSeconds / 3600 / 24; }
        }

        public bool IsExpired
        {
            get { return Authorization.IsExpired; }
        }

        public bool IsValid
        {
            get { return Authorization.IsValid; }
        }

        public bool IsRefreshPossible
        {
            get { return Authorization.IsRefreshPossible; }
        }

        public string CreatedAt
        {
            get { return Authorization.Created.ToString(); }
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

        private TraktAuthorization _authorization = DEFAULT_AUTHORIZATION;

        public TraktAuthorization Authorization
        {
            get { return _authorization; }

            set
            {
                _authorization = value;
                base.RaisePropertyChanged();
            }
        }

        private bool _isAuthorizationInfoVisible = true;

        public bool IsAuthorizationInfoVisible
        {
            get { return _isAuthorizationInfoVisible; }

            set
            {
                _isAuthorizationInfoVisible = value;
                base.RaisePropertyChanged();
            }
        }

        private bool _isWebContentVisible = false;

        public bool IsWebContentVisible
        {
            get { return _isWebContentVisible; }

            set
            {
                _isWebContentVisible = value;
                base.RaisePropertyChanged();
            }
        }

        public DelegateCommand AuthenticateCommand { get; }

        public DelegateCommand RefreshCommand { get; }

        public DelegateCommand RevokeCommand { get; }

        private void Authenticate()
        {
            if (AuthenticationMethod == OAUTH_AUTHENTICATION)
                OAuthAuthenticate();
            else if (AuthenticationMethod == DEVICE_AUTHENTICATION)
                DeviceAuthenticate();
        }

        private async void DeviceAuthenticate()
        {
            var dialog = new DeviceAuthenticationDialog
            {
                WebsiteUrl = "https://www.trakt.tv",
                UserCode = "12345678",
                PrimaryButtonCommand = new DelegateCommand(async () =>
                {
                    var success = await Launcher.LaunchUriAsync(new Uri("https://www.trakt.tv"));

                    if (success)
                        Debug.WriteLine("Website launched successfully");
                })
            };

            await dialog.ShowAsync();
        }

        private void OAuthAuthenticate()
        {
            Debug.WriteLine("OAuthAuthenticate");
        }

        private void RefreshAuthorization()
        {
            Debug.WriteLine("RefreshAuthorization");
        }

        private void Revoke()
        {
            Debug.WriteLine("Revoke");
        }
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
