namespace TraktApiSharp.Experimental.Requests.Shows.OAuth
{
    using Objects.Get.Shows;

    internal sealed class TraktShowWatchedProgressRequest : ATraktShowProgressRequest<TraktShowWatchedProgress>
    {
        internal TraktShowWatchedProgressRequest(TraktClient client) : base(client) { }

        public string UriTemplate => "shows/{id}/progress/watched{?hidden,specials,count_specials}";
    }
}
