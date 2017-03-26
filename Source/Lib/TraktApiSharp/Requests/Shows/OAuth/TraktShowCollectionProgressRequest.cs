namespace TraktApiSharp.Requests.Shows.OAuth
{
    using Objects.Get.Shows.Implementations;

    internal sealed class TraktShowCollectionProgressRequest : ATraktShowProgressRequest<TraktShowCollectionProgress>
    {
        public override string UriTemplate => "shows/{id}/progress/collection{?hidden,specials,count_specials}";
    }
}
