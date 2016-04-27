namespace TraktApiSharp.Requests.WithoutOAuth.Search
{
    using Base.Get;
    using Objects.Basic;

    internal abstract class TraktSearchRequest<T> : TraktGetRequest<TraktPaginationListResult<T>, T>
    {
        internal TraktSearchRequest(TraktClient client) : base(client) { }

        protected override TraktAuthenticationRequirement AuthenticationRequirement => TraktAuthenticationRequirement.NotRequired;

        protected override bool IsSearchRequest => true;

        protected override bool IsListResult => true;

        protected override bool SupportsPagination => true;

        protected override string UriTemplate => "search";
    }
}
