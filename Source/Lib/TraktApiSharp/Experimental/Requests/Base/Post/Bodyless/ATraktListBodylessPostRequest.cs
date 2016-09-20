namespace TraktApiSharp.Experimental.Requests.Base.Post
{
    using System.Net.Http;
    using TraktApiSharp.Requests;

    internal abstract class ATraktListBodylessPostRequest<TItem> : ATraktListRequest<TItem, object>
    {
        public ATraktListBodylessPostRequest(TraktClient client) : base(client) { }

        protected override HttpMethod Method => HttpMethod.Put;

        protected override TraktAuthorizationRequirement AuthorizationRequirement => TraktAuthorizationRequirement.Required;
    }
}
