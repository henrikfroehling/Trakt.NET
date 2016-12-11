namespace TraktApiSharp.Experimental.Requests.Syncs.OAuth
{
    using Objects.Post.Syncs.Ratings;
    using Objects.Post.Syncs.Ratings.Responses;
    using System;

    internal sealed class TraktSyncRatingsRemoveRequest : ATraktSyncSingleItemPostRequest<TraktSyncRatingsRemovePostResponse, TraktSyncRatingsPost>
    {
        internal TraktSyncRatingsRemoveRequest(TraktClient client) : base(client) { }

        public override string UriTemplate
        {
            get
            {
                throw new NotImplementedException();
            }
        }
    }
}
