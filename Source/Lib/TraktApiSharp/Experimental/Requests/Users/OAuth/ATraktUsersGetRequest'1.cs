namespace TraktApiSharp.Experimental.Requests.Users.OAuth
{
    using Base;
    using Interfaces;
    using System.Collections.Generic;
    using TraktApiSharp.Requests;
    using TraktApiSharp.Requests.Params;

    internal abstract class ATraktUsersGetRequest<TContentType> : ATraktGetRequest<TContentType>, ITraktSupportsExtendedInfo
    {
        public TraktExtendedInfo ExtendedInfo { get; set; }

        public override TraktAuthorizationRequirement AuthorizationRequirement => TraktAuthorizationRequirement.Optional;

        public override IDictionary<string, object> GetUriPathParameters()
        {
            var uriParams = new Dictionary<string, object>();

            if (ExtendedInfo != null && ExtendedInfo.HasAnySet)
                uriParams.Add("extended", ExtendedInfo.ToString());

            return uriParams;
        }
    }
}
