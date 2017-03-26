namespace TraktApiSharp.Requests.People
{
    using Objects.Get.People.Credits.Implementations;

    internal sealed class TraktPersonMovieCreditsRequest : ATraktPersonRequest<TraktPersonMovieCredits>
    {
        public override string UriTemplate => "people/{id}/movies{?extended}";
    }
}
