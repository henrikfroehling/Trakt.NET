namespace TraktApiSharp.Requests.WithOAuth.Shows
{
    using Objects.Get.Shows;

    internal class TraktShowCollectionProgressRequest : TraktShowProgressRequest<TraktShowCollectionProgress>
    {
        internal TraktShowCollectionProgressRequest(TraktClient client) : base(client) { }

        protected override string UriTemplate => "shows/{id}/progress/collection{?hidden,specials,count_specials}";

        protected override TraktRequestObjectType? RequestObjectType => TraktRequestObjectType.Shows;
    }
}
