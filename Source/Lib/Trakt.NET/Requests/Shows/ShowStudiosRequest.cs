namespace TraktNet.Requests.Shows
{
    using Requests.Base;

    internal sealed class ShowStudiosRequest : AStudiosRequest
    {
        public override string UriTemplate => "shows/{id}/studios";

        public override RequestObjectType RequestObjectType => RequestObjectType.Shows;
    }
}
