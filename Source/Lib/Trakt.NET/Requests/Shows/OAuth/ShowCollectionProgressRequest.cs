namespace TraktNet.Requests.Shows.OAuth
{
    using Objects.Get.Shows;

    internal sealed class ShowCollectionProgressRequest : AShowProgressRequest<ITraktShowCollectionProgress>
    {
        public override string UriTemplate => "shows/{id}/progress/collection{?hidden,specials,count_specials,last_activity}";
    }
}
