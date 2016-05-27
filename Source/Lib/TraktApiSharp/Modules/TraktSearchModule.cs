namespace TraktApiSharp.Modules
{
    using Enums;
    using Objects.Basic;
    using Requests;
    using Requests.WithoutOAuth.Search;
    using System;
    using System.Threading.Tasks;

    public class TraktSearchModule : TraktBaseModule
    {
        public TraktSearchModule(TraktClient client) : base(client) { }

        public async Task<TraktPaginationListResult<TraktSearchResult>> SearchTextQueryAsync(string query, TraktSearchResultType? type = null,
                                                                                             int? year = null, int? page = null, int? limit = null)
        {
            ValidateQuery(query);

            return await QueryAsync(new TraktSearchTextQueryRequest(Client)
            {
                Query = query,
                Type = type,
                Year = year,
                PaginationOptions = new TraktPaginationOptions(page, limit)
            });
        }

        public async Task<TraktPaginationListResult<TraktSearchIdLookupResult>> SearchIdLookupAsync(TraktSearchLookupIdType type, string lookupId,
                                                                                                    int? page = null, int? limit = null)
        {
            ValidateIdLookup(lookupId);

            return await QueryAsync(new TraktSearchIdLookupRequest(Client)
            {
                Type = type,
                LookupId = lookupId,
                PaginationOptions = new TraktPaginationOptions(page, limit)
            });
        }

        private void ValidateQuery(string query)
        {
            if (string.IsNullOrEmpty(query))
                throw new ArgumentException("search query not valid", "query");
        }

        private void ValidateIdLookup(string lookupId)
        {
            if (string.IsNullOrEmpty(lookupId))
                throw new ArgumentException("search lookup id not valid", "lookupId");
        }
    }
}
