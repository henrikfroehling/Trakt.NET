namespace TraktApiSharp.Requests.Shows.OAuth
{
    using Objects.Get.Shows;

    internal sealed class TraktShowWatchedProgressRequest : AShowProgressRequest<ITraktShowWatchedProgress>
    {
        public override string UriTemplate => "shows/{id}/progress/watched{?hidden,specials,count_specials}";
    }
}
