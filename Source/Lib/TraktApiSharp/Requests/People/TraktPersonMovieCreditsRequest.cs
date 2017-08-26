namespace TraktApiSharp.Requests.People
{
    using Objects.Get.People.Credits;

    internal sealed class TraktPersonMovieCreditsRequest : APersonRequest<ITraktPersonMovieCredits>
    {
        public override string UriTemplate => "people/{id}/movies{?extended}";
    }
}
