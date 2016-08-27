using System;
using Template10.Common;
using Template10.Utils;
using TraktApiSharp.Authentication;
using TraktApiSharp.Example.UWP.Services.TraktService;
using TraktApiSharp.Services;
using Windows.UI.Xaml;

namespace TraktApiSharp.Example.UWP.Services.SettingsServices
{
    public class SettingsService
    {
        public static SettingsService Instance { get; } = new SettingsService();

        private Template10.Services.SettingsService.ISettingsHelper _helper;

        private SettingsService()
        {
            _helper = new Template10.Services.SettingsService.SettingsHelper();
        }

        public bool UseShellBackButton
        {
            get { return _helper.Read<bool>(nameof(UseShellBackButton), true); }

            set
            {
                _helper.Write(nameof(UseShellBackButton), value);

                BootStrapper.Current.NavigationService.Dispatcher.Dispatch(() =>
                {
                    BootStrapper.Current.ShowShellBackButton = value;
                    BootStrapper.Current.UpdateShellBackButton();
                    BootStrapper.Current.NavigationService.Refresh();
                });
            }
        }

        public static string DEFAULT_CLIENT_ID_VALUE { get; } = string.Empty;

        public static string DEFAULT_CLIENT_SECRET_VALUE { get; } = string.Empty;

        public string TraktClientId
        {
            get { return _helper.Read<string>(nameof(TraktClientId), DEFAULT_CLIENT_ID_VALUE); }

            set
            {
                _helper.Write(nameof(TraktClientId), value);
                TraktServiceProvider.Instance.Client.ClientId = value;
            }
        }

        public string TraktClientSecret
        {
            get { return _helper.Read<string>(nameof(TraktClientSecret), DEFAULT_CLIENT_ID_VALUE); }

            set
            {
                _helper.Write(nameof(TraktClientSecret), value);
                TraktServiceProvider.Instance.Client.ClientSecret = value;
            }
        }

        public TraktAuthorization TraktClientAuthorization
        {
            get
            {
                var authorizationJson = _helper.Read<string>(nameof(TraktClientAuthorization), string.Empty);

                if (!string.IsNullOrEmpty(authorizationJson))
                {
                    var authorization = TraktSerializationService.DeserializeAuthorization(authorizationJson);

                    if (authorization == null)
                        return new TraktAuthorization();

                    return authorization;
                }

                return new TraktAuthorization();
            }

            set
            {
                if (value != null)
                {
                    TraktServiceProvider.Instance.Client.Authorization = value;

                    if (!string.IsNullOrEmpty(value.AccessToken))
                    {
                        var authorizationJson = TraktSerializationService.Serialize(value);

                        if (!string.IsNullOrEmpty(authorizationJson))
                            _helper.Write(nameof(TraktClientAuthorization), authorizationJson);
                    }
                }
            }
        }

        public bool TraktUseStagingUrl
        {
            get { return _helper.Read<bool>(nameof(TraktUseStagingUrl), false); }

            set
            {
                _helper.Write(nameof(TraktUseStagingUrl), value);
                TraktServiceProvider.Instance.Client.Configuration.UseStagingUrl = value;
            }
        }

        public bool TraktForceAuthorization
        {
            get { return _helper.Read<bool>(nameof(TraktForceAuthorization), false); }

            set
            {
                _helper.Write(nameof(TraktForceAuthorization), value);
                TraktServiceProvider.Instance.Client.Configuration.ForceAuthorization = value;
            }
        }

        public ApplicationTheme AppTheme
        {
            get
            {
                var theme = ApplicationTheme.Light;
                var value = _helper.Read<string>(nameof(AppTheme), theme.ToString());

                return Enum.TryParse<ApplicationTheme>(value, out theme) ? theme : ApplicationTheme.Dark;
            }

            set
            {
                _helper.Write(nameof(AppTheme), value.ToString());
                (Window.Current.Content as FrameworkElement).RequestedTheme = value.ToElementTheme();
                Views.Shell.HamburgerMenu.RefreshStyles(value);
            }
        }

        public TimeSpan CacheMaxDuration
        {
            get { return _helper.Read<TimeSpan>(nameof(CacheMaxDuration), TimeSpan.FromDays(2)); }

            set
            {
                _helper.Write(nameof(CacheMaxDuration), value);
                BootStrapper.Current.CacheMaxDuration = value;
            }
        }
    }
}
