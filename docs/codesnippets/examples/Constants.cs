namespace Trakt.NET.Examples;

internal static class Constants
{
    internal static class Commands
    {
        internal const string AuthCommand = "auth";

        internal const string ModuleCommand = "module";

        internal const string ParametersCommand = "parameters";

        internal const string SerializationCommand = "serialization";

        internal static class Auth
        {
            internal const string DeviceExample = "device";

            internal const string OAuthExample = "oauth";
        }

        internal static class Modules
        {
            internal const string ShowsModuleCommand = "shows";

            internal static class Shows
            {
                internal const string GetSingleShow = "get-single-show";

                internal const string GetSingleShowExtended = "get-single-show-extended";

                internal const string GetTrengingShows = "get-trending-shows";

                internal const string GetTrendingShowsPaged = "get-trending-shows-paged";

                internal const string GetMultipleShows = "get-multiple-shows";
            }
        }

        internal static class Parameters
        {
            internal const string FilterCommand = "filter";

            internal const string PostBuilderCommand = "postbuilder";

            internal static class Filter
            {
                internal const string Calendar = "calendar";
            }

            internal static class PostBuilder
            {
                internal const string Favorites = "favorites";
            }
        }
    }
}
