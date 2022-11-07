namespace TraktNet.Requests.Users.OAuth
{
    using Base;
    using Interfaces;
    using Parameters;
    using System.Collections.Generic;
    using TraktNet.Parameters;

    internal abstract class AUsersGetRequest<TResponseContentType> : AGetRequest<TResponseContentType>, ISupportsExtendedInfo
    {
        public TraktExtendedInfo ExtendedInfo { get; set; }

        public override AuthorizationRequirement AuthorizationRequirement => AuthorizationRequirement.Optional;

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
