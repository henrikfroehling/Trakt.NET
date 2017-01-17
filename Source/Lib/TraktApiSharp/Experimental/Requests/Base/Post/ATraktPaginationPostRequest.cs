namespace TraktApiSharp.Experimental.Requests.Base.Post
{
    using Interfaces.Base;
    using Interfaces.Base.Post;
    using System.Net.Http;
    using TraktApiSharp.Requests;

    internal abstract class ATraktPaginationPostRequest<TItem, TRequestBody> : ATraktPaginationRequest<TItem>, ITraktPaginationPostRequest<TItem, TRequestBody>
    {
        internal ATraktPaginationPostRequest(TraktClient client) : base(client)
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
