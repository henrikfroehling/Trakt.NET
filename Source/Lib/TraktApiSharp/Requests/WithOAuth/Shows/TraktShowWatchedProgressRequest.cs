namespace TraktApiSharp.Requests.WithOAuth.Shows
{
    using Objects.Get.Shows;

    internal class TraktShowWatchedProgressRequest : TraktShowProgressRequest<TraktShowWatchedProgress>
    {
        internal TraktShowWatchedProgressRequest(TraktClient client) : base(client) { }

        protected override string UriTemplate => "shows/{id}/progress/watched";

        protected override TraktRequestObjectType? RequestObjectType => TraktRequestObjectType.Shows;
    }
}
