namespace TraktApiSharp.Example.UWP.ViewModels
{
    using Authentication;
    using Dialogs;
    using Enums;
    using Exceptions;
    using Services.TraktService;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Template10.Mvvm;
    using Template10.Services.NavigationService;
    using Views;
    using Windows.System;
    using Windows.UI.Popups;
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;
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

        public string AccessToken => Authorization.AccessToken;

        public string RefreshToken => Authorization.RefreshToken;

        public string ExpiresInDays
        {
            get
            {
                var created = Authorization.Created;
                var expirationDate = created.AddSeconds(Authorization.ExpiresIn);
                var difference = expirationDate - DateTime.UtcNow;

                var days = difference.Days > 0 ? difference.Days : 0;
                var hours = difference.Hours > 0 ? difference.Hours : 0;
                var minutes = difference.Minutes > 0 ? difference.Minutes : 0;

                return $"{days} Days, {hours} Hours, {minutes} Minutes";
            }
        }

        public bool IsExpired => Authorization.IsExpired;

        public bool IsValid => Authorization.IsValid;

        public bool IsRefreshPossible => Authorization.IsRefreshPossible;

        public string CreatedAt => Authorization.Created.ToString();

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
                TraktServiceProvider.Instance.Client.Authorization = value;
                base.RaisePropertyChanged();
                base.RaisePropertyChanged(nameof(AccessToken));
                base.RaisePropertyChanged(nameof(RefreshToken));
                base.RaisePropertyChanged(nameof(ExpiresInDays));
                base.RaisePropertyChanged(nameof(IsExpired));
                base.RaisePropertyChanged(nameof(IsValid));
                base.RaisePropertyChanged(nameof(IsRefreshPossible));
                base.RaisePropertyChanged(nameof(CreatedAt));
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
            try
            {
                var authentication = TraktAuthenticationService.Instance;

                Busy.SetBusy(true, "Create authorization device...");
                var deviceInfo = await authentication.CreateDeviceAsync();
                Busy.SetBusy(false);

                if (deviceInfo.Success)
                {
                    var primaryButtonDelegate = new DelegateCommand(async () =>
                    {
                        var success = await Launcher.LaunchUriAsync(new Uri(deviceInfo.Url));

                        if (success)
                        {
                            Busy.SetBusy(true, "Retrieve authorization...");

                            var newAuthorization = await authentication.GetDeviceAuthorizationAsync();

                            if (newAuthorization.IsValid)
                                Authorization = newAuthorization;

                            Busy.SetBusy(false);
                        }
                    });

                    var dialog = new DeviceAuthenticationDialog
                    {
                        WebsiteUrl = deviceInfo.Url,
                        UserCode = deviceInfo.UserCode,
                        PrimaryButtonCommand = primaryButtonDelegate
                    };

                    await dialog.ShowAsync();
                }
            }
            catch (TraktException ex)
            {
                ShowTraktExceptionMessage(ex);
            }
            catch (Exception ex)
            {
                ShowExceptionMessage(ex);
            }
            finally
            {
                Busy.SetBusy(false);
            }
        }

        private async void OAuthAuthenticate()
        {
            try
            {
                var authentication = TraktAuthenticationService.Instance;
                var authenticationUrl = authentication.GetOAuthAuthorizationUrl();

                if (!string.IsNullOrEmpty(authenticationUrl))
                {
                    var dialog = new OAuthAuthenticationDialog { WebsiteUrl = authenticationUrl };
                    var result = await dialog.ShowAsync();

                    if (result == ContentDialogResult.Primary)
                    {
                        var code = dialog.Code;

                        if (!string.IsNullOrEmpty(code))
                        {
                            Busy.SetBusy(true, "Retrieve authorization...");

                            var newAuthorization = await authentication.GetOAuthAuthorizationAsync(code);

                            if (newAuthorization.IsValid)
                                Authorization = newAuthorization;

                            Busy.SetBusy(false);
                        }
                    }
                }
            }
            catch (TraktException ex)
            {
                ShowTraktExceptionMessage(ex);
            }
            catch (Exception ex)
            {
                ShowExceptionMessage(ex);
            }
            finally
            {
                Busy.SetBusy(false);
            }
        }

        private async void RefreshAuthorization()
        {
            try
            {
                Busy.SetBusy(true, "Refresh authorization...");

                var newAuthorization = await TraktAuthenticationService.Instance.RefreshAuthorizationAsync();

                if (newAuthorization != null)
                    Authorization = newAuthorization;

                Busy.SetBusy(false);
            }
            catch (TraktException ex)
            {
                ShowTraktExceptionMessage(ex);
            }
            catch (Exception ex)
            {
                ShowExceptionMessage(ex);
            }
            finally
            {
                Busy.SetBusy(false);
            }
        }

        private async void Revoke()
        {
            try
            {
                const int RESULT_YES = 0;
                string message = "Are you sure you want to revoke your current access token?";

                var dialog = new MessageDialog(message, "Revoke current Trakt.TV access token");

                dialog.Commands.Add(new UICommand("Yes") { Id = RESULT_YES });
                dialog.Commands.Add(new UICommand("No") { Id = 1 });

                var result = await dialog.ShowAsync();

                if ((int)result.Id == RESULT_YES)
                {
                    Busy.SetBusy(true, "Revoke authorization...");

                    await TraktAuthenticationService.Instance.RevokeAuthorizationAsync();
                    Authorization = DEFAULT_AUTHORIZATION;

                    Busy.SetBusy(false);
                }
            }
            catch (TraktException ex)
            {
                ShowTraktExceptionMessage(ex);
            }
            catch (Exception ex)
            {
                ShowExceptionMessage(ex);
            }
            finally
            {
                Busy.SetBusy(false);
            }
        }

        private async void ShowTraktExceptionMessage(TraktException ex)
        {
            var content = $"Exception message: {ex.Message}\n" +
                          $"Status code: {ex.StatusCode}\n" +
                          $"Request URL: {ex.RequestUrl}\n" +
                          $"Request message: {ex.RequestBody}\n" +
                          $"Request response: {ex.Response}\n" +
                          $"Server Reason Phrase: {ex.ServerReasonPhrase}\n" +
                          "----------------------------------------------------\n" +
                          $"Stacktrace: {ex.StackTrace}";

            var dialog = new ExceptionDialog
            {
                Title = "Trakt Exception",
                ExceptionContent = content
            };

            await dialog.ShowAsync();
        }

        private async void ShowExceptionMessage(Exception ex)
        {
            var content = $"Exception message: {ex.Message}\n" +
                          "----------------------------------------------------\n" +
                          $"Stacktrace: {ex.StackTrace}";

            var dialog = new ExceptionDialog
            {
                Title = "Exception",
                ExceptionContent = content
            };

            await dialog.ShowAsync();
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
