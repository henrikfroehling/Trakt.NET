namespace TraktApiSharp.Requests.People
{
    using Objects.Get.People.Credits;

    internal sealed class TraktPersonShowCreditsRequest : APersonRequest<ITraktPersonShowCredits>
    {
        public override string UriTemplate => "people/{id}/shows{?extended}";
    }
}
