namespace TraktApiSharp.Experimental.Requests.Shows.OAuth
{
    using Objects.Get.Shows;
    using TraktApiSharp.Requests;

    internal sealed class TraktShowCollectionProgressRequest : ATraktShowProgressRequest<TraktShowCollectionProgress>
    {
        public TraktShowCollectionProgressRequest(TraktClient client) : base(client) { }

        public override TraktAuthorizationRequirement AuthorizationRequirement => TraktAuthorizationRequirement.Required;

        public override string UriTemplate => "shows/{id}/progress/collection{?hidden,specials,count_specials}";
    }
}
