namespace TraktNet.Requests.Shows.OAuth
{
    using Objects.Get.Shows;

    internal sealed class ShowWatchedProgressRequest : AShowProgressRequest<ITraktShowWatchedProgress>
    {
        public override string UriTemplate => "shows/{id}/progress/watched{?hidden,specials,count_specials,last_activity}";
    }
}
