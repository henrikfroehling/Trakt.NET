namespace TraktApiSharp.Experimental.Requests.Seasons
{
    using Base.Get;
    using Objects.Basic;
    using System;
    using TraktApiSharp.Requests;

    internal sealed class TraktSeasonRatingsRequest : ATraktSingleItemGetByIdRequest<TraktRating>
    {
        public TraktSeasonRatingsRequest(TraktClient client) : base(client) { }

        public override TraktAuthorizationRequirement AuthorizationRequirement
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
