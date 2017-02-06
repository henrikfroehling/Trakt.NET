namespace TraktApiSharp.Experimental.Requests.Syncs.OAuth
{
    using Base;
    using System.Collections.Generic;
    using TraktApiSharp.Requests;

    internal abstract class ATraktSyncGetRequest<TContentType> : ATraktGetRequest<TContentType>
    {
        public override TraktAuthorizationRequirement AuthorizationRequirement => TraktAuthorizationRequirement.Required;

        public override IDictionary<string, object> GetUriPathParameters() => new Dictionary<string, object>();

        public override void Validate() { }
    }
}
