namespace TraktApiSharp.Experimental.Requests.Checkins.OAuth
{
    using Base.Delete;
    using System;

    internal sealed class TraktCheckinsDeleteRequest : ATraktNoContentDeleteRequest
    {
        public TraktCheckinsDeleteRequest(TraktClient client) : base(client) { }

        public override string UriTemplate
        {
            get
            {
                throw new NotImplementedException();
            }
        }
    }
}
