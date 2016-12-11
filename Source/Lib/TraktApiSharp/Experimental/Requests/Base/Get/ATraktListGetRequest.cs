namespace TraktApiSharp.Experimental.Requests.Base.Get
{
    using System.Net.Http;
    using TraktApiSharp.Requests;

    internal abstract class ATraktListGetRequest<TItem> : ATraktListRequest<TItem>
    {
        internal ATraktListGetRequest(TraktClient client) : base(client) { }

        public override TraktAuthorizationRequirement AuthorizationRequirement { get; }

        public override HttpMethod Method => HttpMethod.Get;
    }
}
