namespace TraktApiSharp.Experimental.Requests.Shows.OAuth
{
    using Objects.Get.Shows;

    internal sealed class TraktShowCollectionProgressRequest : ATraktShowProgressRequest<TraktShowCollectionProgress>
    {
        public TraktShowCollectionProgressRequest(TraktClient client) : base(client) { }

        public override string UriTemplate => "shows/{id}/progress/collection{?hidden,specials,count_specials}";
    }
}
