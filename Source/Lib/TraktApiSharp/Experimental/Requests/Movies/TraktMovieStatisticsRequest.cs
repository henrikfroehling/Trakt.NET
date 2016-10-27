namespace TraktApiSharp.Experimental.Requests.Movies
{
    using Base.Get;
    using Objects.Basic;
    using System;
    using TraktApiSharp.Requests;

    internal sealed class TraktMovieStatisticsRequest : ATraktSingleItemGetByIdRequest<TraktStatistics>
    {
        internal TraktMovieStatisticsRequest(TraktClient client) : base(client) { }

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
