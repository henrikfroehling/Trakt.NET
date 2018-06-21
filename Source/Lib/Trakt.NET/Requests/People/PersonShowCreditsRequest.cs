namespace TraktNet.Requests.People
{
    using Objects.Get.People.Credits;

    internal sealed class PersonShowCreditsRequest : APersonRequest<ITraktPersonShowCredits>
    {
        public override string UriTemplate => "people/{id}/shows{?extended}";
    }
}
