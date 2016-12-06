namespace TraktApiSharp.Experimental.Requests.Syncs.OAuth
{
    using Base.Delete;
    using System;

    internal sealed class TraktSyncPlaybackDeleteRequest : ATraktNoContentDeleteByIdRequest
    {
        internal TraktSyncPlaybackDeleteRequest(TraktClient client) : base(client) { }

        public override string UriTemplate
        {
            get
            {
                throw new NotImplementedException();
            }
        }
    }
}
