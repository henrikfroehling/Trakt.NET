namespace TraktApiSharp.Requests.Shows.OAuth
{
    using Objects.Get.Shows.Implementations;

    internal sealed class TraktShowWatchedProgressRequest : ATraktShowProgressRequest<TraktShowWatchedProgress>
    {
        public override string UriTemplate => "shows/{id}/progress/watched{?hidden,specials,count_specials}";
    }
}
