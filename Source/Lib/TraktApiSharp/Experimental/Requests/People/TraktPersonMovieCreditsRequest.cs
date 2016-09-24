namespace TraktApiSharp.Experimental.Requests.People
{
    using Objects.Get.People.Credits;

    internal sealed class TraktPersonMovieCreditsRequest : ATraktPersonCreditsRequest<TraktPersonMovieCredits>
    {
        public TraktPersonMovieCreditsRequest(TraktClient client) : base(client) { }

        public override string UriTemplate => "people/{id}/movies{?extended}";
    }
}
