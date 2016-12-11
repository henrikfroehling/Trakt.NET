namespace TraktApiSharp.Experimental.Requests.Base.Post.Bodyless
{
    using System.Net.Http;
    using TraktApiSharp.Requests;

    internal abstract class ATraktNoContentBodylessPostRequest : ATraktNoContentRequest
    {
        internal ATraktNoContentBodylessPostRequest(TraktClient client) : base(client) { }

        public override TraktAuthorizationRequirement AuthorizationRequirement => TraktAuthorizationRequirement.Required;

        public override HttpMethod Method => HttpMethod.Post;
    }
}
