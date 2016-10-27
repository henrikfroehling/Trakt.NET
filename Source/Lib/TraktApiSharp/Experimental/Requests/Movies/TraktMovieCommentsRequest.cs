namespace TraktApiSharp.Experimental.Requests.Movies
{
    using Base.Get;
    using Enums;
    using Interfaces;
    using Objects.Basic;
    using System.Collections.Generic;
    using TraktApiSharp.Requests;

    internal sealed class TraktMovieCommentsRequest : ATraktPaginationGetByIdRequest<TraktComment>, ITraktObjectRequest
    {
        internal TraktMovieCommentsRequest(TraktClient client) : base(client) { }

        internal TraktCommentSortOrder Sorting { get; set; }

        public override IDictionary<string, object> GetUriPathParameters()
        {
            return base.GetUriPathParameters();
        }

        public override TraktAuthorizationRequirement AuthorizationRequirement => TraktAuthorizationRequirement.NotRequired;

        public TraktRequestObjectType RequestObjectType => TraktRequestObjectType.Movies;

        public override string UriTemplate => "movies/{id}/comments{/sorting}{?page,limit}";
    }
}
