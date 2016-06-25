namespace TraktApiSharp.Modules
{
    using Enums;
    using Extensions;
    using Objects.Basic;
    using Requests;
    using Requests.WithoutOAuth.Search;
    using System;
    using System.Threading.Tasks;

    public class TraktSearchModule : TraktBaseModule
    {
        public TraktSearchModule(TraktClient client) : base(client) { }

        public async Task<TraktPaginationListResult<TraktSearchResult>> GetTextQueryResultsAsync(string query, TraktSearchResultType? type = null,
                                                                                                 int? year = null, int? page = null, int? limit = null)
        {
            Validate(query);

            return await QueryAsync(new TraktSearchTextQueryRequest(Client)
            {
                Query = query,
                Type = type,
                Year = year,
                PaginationOptions = new TraktPaginationOptions(page, limit)
            });
        }

        public async Task<TraktPaginationListResult<TraktSearchIdLookupResult>> GetIdLookupResultsAsync(TraktSearchIdLookupType type, string lookupId,
                                                                                                        int? page = null, int? limit = null)
        {
            Validate(type, lookupId);

            return await QueryAsync(new TraktSearchIdLookupRequest(Client)
            {
                Type = type,
                LookupId = lookupId,
                PaginationOptions = new TraktPaginationOptions(page, limit)
            });
        }

        private void Validate(string query)
        {
            if (string.IsNullOrEmpty(query))
                throw new ArgumentException("search query not valid", nameof(query));
        }

        private void Validate(TraktSearchIdLookupType type, string lookupId)
        {
            if (type == TraktSearchIdLookupType.Unspecified)
                throw new ArgumentException("search id lookup type not valid", nameof(type));

            if (string.IsNullOrEmpty(lookupId) || lookupId.ContainsSpace())
                throw new ArgumentException("search lookup id not valid", nameof(lookupId));
        }
    }
}
