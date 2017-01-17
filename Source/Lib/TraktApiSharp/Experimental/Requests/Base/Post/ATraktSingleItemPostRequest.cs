namespace TraktApiSharp.Experimental.Requests.Base.Post
{
    using Interfaces.Base;
    using Interfaces.Base.Post;
    using System.Net.Http;
    using TraktApiSharp.Requests;

    internal abstract class ATraktSingleItemPostRequest<TItem, TRequestBody> : ATraktSingleItemRequest<TItem>, ITraktSingleItemPostRequest<TItem, TRequestBody>
    {
        internal ATraktSingleItemPostRequest(TraktClient client) : base(client)
        {
            RequestBody = new TraktRequestBody<TRequestBody>();
        }

        public override TraktAuthorizationRequirement AuthorizationRequirement => TraktAuthorizationRequirement.Required;

        public override HttpMethod Method => HttpMethod.Post;

        public ITraktPostable<TRequestBody> RequestBody { get; set; }

        public TRequestBody RequestBodyContent
        {
            get { return RequestBody.RequestBody; }
            set { RequestBody.RequestBody = value; }
        }
    }
}
