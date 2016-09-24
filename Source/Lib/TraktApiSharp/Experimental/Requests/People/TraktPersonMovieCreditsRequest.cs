namespace TraktApiSharp.Experimental.Requests.People
{
    using Objects.Get.People.Credits;
    using TraktApiSharp.Requests;

    internal sealed class TraktPersonMovieCreditsRequest : ATraktPersonCreditsRequest<TraktPersonMovieCredits>
    {
        public TraktPersonMovieCreditsRequest(TraktClient client) : base(client) { }

        public override TraktAuthorizationRequirement AuthorizationRequirement => TraktAuthorizationRequirement.NotRequired;

        public override string UriTemplate => "people/{id}/movies{?extended}";
    }
}
