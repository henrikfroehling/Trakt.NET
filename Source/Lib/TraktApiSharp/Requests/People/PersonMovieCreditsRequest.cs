namespace TraktApiSharp.Requests.People
{
    using Objects.Get.People.Credits;

    internal sealed class PersonMovieCreditsRequest : APersonRequest<ITraktPersonMovieCredits>
    {
        public override string UriTemplate => "people/{id}/movies{?extended}";
    }
}
