using System;
using Template10.Common;
using Template10.Utils;
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

        public string TraktClientId
        {
            get { return _helper.Read<string>(nameof(TraktClientId), string.Empty); }
            set { _helper.Write(nameof(TraktClientId), value); }
        }

        public string TraktClientSecret
        {
            get { return _helper.Read<string>(nameof(TraktClientSecret), string.Empty); }
            set { _helper.Write(nameof(TraktClientSecret), value); }
        }

        public string TraktClientAccessToken
        {
            get { return _helper.Read<string>(nameof(TraktClientAccessToken), string.Empty); }
            set { _helper.Write(nameof(TraktClientAccessToken), value); }
        }

        public bool TraktUseStagingUrl
        {
            get { return _helper.Read<bool>(nameof(TraktUseStagingUrl), false); }
            set { _helper.Write(nameof(TraktUseStagingUrl), value); }
        }

        public bool TraktForceAuthorization
        {
            get { return _helper.Read<bool>(nameof(TraktForceAuthorization), false); }
            set { _helper.Write(nameof(TraktForceAuthorization), value); }
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
