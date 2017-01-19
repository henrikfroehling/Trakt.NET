namespace TraktApiSharp.Experimental.Requests.Shows.OAuth
{
    using Objects.Get.Shows;

    internal sealed class TraktShowCollectionProgressRequest : ATraktShowProgressRequest<TraktShowCollectionProgress>
    {
        internal TraktShowCollectionProgressRequest(TraktClient client) : base(client) { }

        public string UriTemplate => "shows/{id}/progress/collection{?hidden,specials,count_specials}";
    }
}
