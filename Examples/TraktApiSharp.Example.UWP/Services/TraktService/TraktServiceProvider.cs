namespace TraktApiSharp.Example.UWP.Services.TraktService
{
    public class TraktServiceProvider
    {
        public static TraktServiceProvider Instance { get; } = new TraktServiceProvider();

        private TraktServiceProvider()
        {
            var settings = SettingsServices.SettingsService.Instance;
            Client = new TraktClient(settings.TraktClientId, settings.TraktClientSecret);
        }

        public TraktClient Client { get; }
    }
}
