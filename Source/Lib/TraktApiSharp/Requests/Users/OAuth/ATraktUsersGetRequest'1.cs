namespace TraktApiSharp.Requests.Users.OAuth
{
    using Base;
    using Interfaces;
    using Parameters;
    using System.Collections.Generic;

    internal abstract class ATraktUsersGetRequest<TResponseContentType> : ATraktGetRequest<TResponseContentType>, ITraktSupportsExtendedInfo
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

        public override void Validate() { }
    }
}
