namespace TraktApiSharp.Experimental.Requests.Users.OAuth
{
    using System;
    using TraktApiSharp.Requests;

    internal sealed class TraktUserDenyFollowerRequest : ATraktUsersDeleteByIdRequest
    {
        internal TraktUserDenyFollowerRequest(TraktClient client) : base(client) { }

        public override TraktRequestObjectType RequestObjectType
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override string UriTemplate
        {
            get
            {
                throw new NotImplementedException();
            }
        }
    }
}
