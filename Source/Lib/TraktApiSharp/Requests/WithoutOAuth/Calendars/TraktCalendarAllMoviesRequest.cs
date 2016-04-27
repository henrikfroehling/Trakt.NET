namespace TraktApiSharp.Requests.WithoutOAuth.Calendars
{
    using Objects.Get.Calendars;

    internal class TraktCalendarAllMoviesRequest : TraktCalendarAllRequest<TraktCalendarMovieItem>
    {
        internal TraktCalendarAllMoviesRequest(TraktClient client) : base(client) { }

        protected override TraktRequestObjectType RequestObjectType => TraktRequestObjectType.Movies;

        protected override string UriTemplate => "calendars/all/movies/{start_date}/{days}";
    }
}
