namespace TraktApiSharp.Experimental.Requests.Base.Post
{
    using System.Net.Http;
    using TraktApiSharp.Requests;

    internal abstract class ATraktPaginationPostRequest<TItem, TRequestBody> : ATraktPaginationRequest<TItem>, ITraktHasRequestBody<TRequestBody>
    {
        internal ATraktPaginationPostRequest(TraktClient client) : base(client)
        {
            RequestBody = new TraktRequestBody<TRequestBody>();
        }

        public override TraktAuthorizationRequirement AuthorizationRequirement => TraktAuthorizationRequirement.Required;

        public override HttpMethod Method => HttpMethod.Post;

        public TraktRequestBody<TRequestBody> RequestBody { get; set; }

        public TRequestBody RequestBodyContent
        {
            get { return RequestBody.RequestBody; }
            set { RequestBody.RequestBody = value; }
        }
    }
}
