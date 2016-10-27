namespace TraktApiSharp.Experimental.Requests.Movies
{
    using Base.Get;
    using Extensions;
    using Objects.Get.Movies.Common;
    using System;
    using System.Collections.Generic;
    using TraktApiSharp.Requests;

    internal sealed class TraktMoviesRecentlyUpdatedRequest : ATraktPaginationGetRequest<TraktRecentlyUpdatedMovie>
    {
        internal TraktMoviesRecentlyUpdatedRequest(TraktClient client) : base(client) { }

        internal DateTime? StartDate { get; set; }

        public override IDictionary<string, object> GetUriPathParameters()
        {
            var uriParams = base.GetUriPathParameters();

            if (StartDate.HasValue)
                uriParams.Add("start_date", StartDate.Value.ToTraktDateString());

            return uriParams;
        }

        public override TraktAuthorizationRequirement AuthorizationRequirement => TraktAuthorizationRequirement.NotRequired;

        public override string UriTemplate => "movies/updates{/start_date}{?extended,page,limit}";
    }
}
