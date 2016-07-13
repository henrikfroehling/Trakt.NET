namespace TraktApiSharp.Modules
{
    using Enums;
    using Extensions;
    using Objects.Basic;
    using Requests;
    using Requests.Params;
    using Requests.WithoutOAuth.Search;
    using System;
    using System.Threading.Tasks;

    public class TraktSearchModule : TraktBaseModule
    {
        internal TraktSearchModule(TraktClient client) : base(client) { }

        public async Task<TraktPaginationListResult<TraktSearchResult>> GetTextQueryResultsAsync(TraktSearchResultType resultType, string query,
                                                                                                 TraktSearchFilter filter = null,
                                                                                                 TraktExtendedOption extended = null,
                                                                                                 int? page = null, int? limit = null)
        {
            Validate(resultType);
            Validate(query);

            return await QueryAsync(new TraktSearchTextQueryRequest(Client)
            {
                ResultType = resultType,
                Query = query,
                Filter = filter,
                ExtendedOption = extended,
                PaginationOptions = new TraktPaginationOptions(page, limit)
            });
        }

        public async Task<TraktPaginationListResult<TraktSearchResult>> GetIdLookupResultsAsync(TraktSearchIdType idType, string lookupId,
                                                                                                TraktSearchResultType? resultType = null,
                                                                                                TraktExtendedOption extended = null,
                                                                                                int? page = null, int? limit = null)
        {
            Validate(idType, lookupId);

            return await QueryAsync(new TraktSearchIdLookupRequest(Client)
            {
                IdType = idType,
                LookupId = lookupId,
                ResultType = resultType,
                ExtendedOption = extended,
                PaginationOptions = new TraktPaginationOptions(page, limit)
            });
        }

        [Obsolete("This search method still works, but might be removed in a future release.")]
        public async Task<TraktPaginationListResult<TraktSearchResult>> GetTextQueryResultsAsync(string query, TraktSearchResultType? type = null,
                                                                                                 int? year = null, int? page = null, int? limit = null)
        {
            Validate(query);

            return await QueryAsync(new TraktSearchOldTextQueryRequest(Client)
            {
                Query = query,
                Type = type,
                Year = year,
                PaginationOptions = new TraktPaginationOptions(page, limit)
            });
        }

        [Obsolete("This search method still works, but might be removed in a future release.")]
        public async Task<TraktPaginationListResult<TraktSearchResult>> GetIdLookupResultsAsync(TraktSearchIdLookupType type, string lookupId,
                                                                                                int? page = null, int? limit = null)
        {
            Validate(type, lookupId);

            return await QueryAsync(new TraktSearchOldIdLookupRequest(Client)
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

        private void Validate(TraktSearchResultType type)
        {
            if (type == TraktSearchResultType.Unspecified)
                throw new ArgumentException("search result type not valid", nameof(type));
        }

        private void Validate(TraktSearchIdType idType, string lookupId)
        {
            if (idType == TraktSearchIdType.Unspecified)
                throw new ArgumentException("search id lookup type not valid", nameof(idType));

            if (string.IsNullOrEmpty(lookupId) || lookupId.ContainsSpace())
                throw new ArgumentException("search lookup id not valid", nameof(lookupId));
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
