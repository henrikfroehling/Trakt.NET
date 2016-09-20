namespace TraktApiSharp.Experimental.Requests.Base.Post
{
    using Interfaces.Requests;
    using System.Net.Http;
    using TraktApiSharp.Requests;

    internal abstract class ATraktSingleItemPostRequest<TItem, TRequestBody> : ATraktSingleItemRequest<TItem>, ITraktRequest, ITraktHasRequestBody<TRequestBody>
    {
        public ATraktSingleItemPostRequest(TraktClient client) : base(client)
        {
            RequestBody = new TraktRequestBody<TRequestBody>();
        }

        public TraktAuthorizationRequirement AuthorizationRequirement => TraktAuthorizationRequirement.Required;

        public HttpMethod Method => HttpMethod.Post;

        public TraktRequestBody<TRequestBody> RequestBody { get; set; }

        public TRequestBody RequestBodyContent
        {
            get { return RequestBody.RequestBody; }
            set { RequestBody.RequestBody = value; }
        }
    }
}
