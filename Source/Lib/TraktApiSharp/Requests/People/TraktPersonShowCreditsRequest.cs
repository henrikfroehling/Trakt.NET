namespace TraktApiSharp.Requests.People
{
    using Objects.Get.People.Credits;
    using TraktApiSharp.Objects.Get.People.Credits.Implementations;

    internal sealed class TraktPersonShowCreditsRequest : ATraktPersonRequest<TraktPersonShowCredits>
    {
        public override string UriTemplate => "people/{id}/shows{?extended}";
    }
}
