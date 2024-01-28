namespace TraktNET
{
    public static class TraktContextExtensions
    {
        public static TraktAuthModule Auth(this ITraktContext context) => new(context);

        public static TraktCalendarModule Calendar(this ITraktContext context) => new(context);

        public static TraktCheckinsModule Checkins(this ITraktContext context) => new(context);

        public static TraktCommentsModule Comments(this ITraktContext context) => new(context);

        public static TraktCountriesModule Countries(this ITraktContext context) => new(context);

        public static TraktEpisodesModule Episodes(this ITraktContext context) => new(context);

        public static TraktGenresModule Genres(this ITraktContext context) => new(context);

        public static TraktLanguagesModule Languages(this ITraktContext context) => new(context);

        public static TraktListsModule Lists(this ITraktContext context) => new(context);

        public static TraktMoviesModule Movies(this ITraktContext context) => new(context);

        public static TraktNetworksModule Networks(this ITraktContext context) => new(context);

        public static TraktPeopleModule People(this ITraktContext context) => new(context);

        public static TraktRecommendationsModule Recommendations(this ITraktContext context) => new(context);

        public static TraktScrobbleModule Scrobble(this ITraktContext context) => new(context);

        public static TraktSearchModule Search(this ITraktContext context) => new(context);

        public static TraktSeasonsModule Seasons(this ITraktContext context) => new(context);

        public static TraktShowsModule Shows(this ITraktContext context) => new(context);

        public static TraktSyncModule Sync(this ITraktContext context) => new(context);

        public static TraktUsersModule Users(this ITraktContext context) => new(context);
    }
}
