namespace TraktApiSharp.Experimental.Requests.People
{
    using Objects.Get.People.Credits;

    internal sealed class TraktPersonShowCreditsRequest : ATraktPersonCreditsRequest<TraktPersonShowCredits>
    {
        public TraktPersonShowCreditsRequest(TraktClient client) : base(client) { }

        public override string UriTemplate => "people/{id}/shows{?extended}";
    }
}
