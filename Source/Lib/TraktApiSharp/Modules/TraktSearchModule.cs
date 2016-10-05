namespace TraktApiSharp.Modules
{
    using Attributes;
    using Enums;
    using Extensions;
    using Objects.Basic;
    using Requests;
    using Requests.Params;
    using Requests.WithoutOAuth.Search;
    using System;
    using System.Threading.Tasks;

    /// <summary>
    /// Provides access to data retrieving methods specific to search.
    /// <para>
    /// This module contains all methods of the <a href ="http://docs.trakt.apiary.io/#reference/search">"Trakt API Doc - Search"</a> section.
    /// </para>
    /// </summary>
    public class TraktSearchModule : TraktBaseModule
    {
        internal TraktSearchModule(TraktClient client) : base(client) { }

        /// <summary>
        /// Searches for movies, shows, episodes, people and / or lists with the given search query.
        /// <para>OAuth authorization not required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/search/text-query/get-text-query-results">"Trakt API Doc - Search: Text Query"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="searchResultTypes">
        /// The object type(s), for which will be searched. See also <seealso cref="TraktSearchResultType" />.
        /// Multiple <see cref="TraktSearchResultType" /> values can be combined with a binary operator, like this: TraktSearchResultType.Movie | TraktSearchResultType.Show.
        /// </param>
        /// <param name="searchQuery">The query, for which will be searched.</param>
        /// <param name="searchFields">Determines the text fields, which will be searched. See also <seealso cref="TraktSearchField" />.</param>
        /// <param name="filter">Optional filter for genres, year, runtimes, ratings, etc. See also <seealso cref="TraktSearchFilter" />.</param>
        /// <param name="extendedInfo">
        /// The extended info, which determines how much data about the movies, shows, episodes, people and / or lists should be queried.
        /// See also <seealso cref="TraktExtendedInfo" />.
        /// </param>
        /// <param name="page">The page of the search results list, that should be queried. Defaults to the first page.</param>
        /// <param name="limitPerPage">The maximum count of results for each page, that should be queried.</param>
        /// <returns>
        /// An <see cref="TraktPaginationListResult{TraktSearchResult}"/> instance containing the found movies, shows, episodes, people and / or lists and which also
        /// contains the queried page number, the page's item count, maximum page count and maximum item count.
        /// <para>
        /// See also <seealso cref="TraktPaginationListResult{ListItem}" /> and <seealso cref="TraktSearchResult" />.
        /// </para>
        /// </returns>
        /// <exception cref="Exceptions.TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="ArgumentException">
        /// Thrown, if the given searchQuery is null, empty or contains spaces.
        /// Thrown, if the given searchResultType is unspecified.
        /// </exception>
        /// <exception cref="ArgumentNullException">Thrown, if the given searchResultType is null</exception>
        [OAuthAuthorizationRequired(false)]
        public async Task<TraktPaginationListResult<TraktSearchResult>> GetTextQueryResultsAsync(TraktSearchResultType searchResultTypes, [NotNull] string searchQuery,
                                                                                                 TraktSearchField searchFields = null, TraktSearchFilter filter = null,
                                                                                                 TraktExtendedInfo extendedInfo = null,
                                                                                                 int? page = null, int? limitPerPage = null)
        {
            Validate(searchResultTypes);
            Validate(searchQuery);

            return await QueryAsync(new TraktSearchTextQueryRequest(Client)
            {
                ResultTypes = searchResultTypes,
                Query = searchQuery,
                SearchFields = searchFields,
                Filter = filter,
                ExtendedInfo = extendedInfo,
                PaginationOptions = new TraktPaginationOptions(page, limitPerPage)
            });
        }

        /// <summary>
        /// Looks up items by their Trakt-, IMDB-, TMDB-, TVDB- or TVRage-Id.
        /// <para>OAuth authorization not required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/search/text-query/get-id-lookup-results">"Trakt API Doc - Search: Id Lookup"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="searchIdType">The id type, which should be looked up. See also <seealso cref="TraktSearchIdType" />.</param>
        /// <param name="lookupId">The Trakt-, IMDB-, TMDB-, TVDB- or TVRage-Id, which will be looked up.</param>
        /// <param name="searchResultType">The object type(s), which will be looked up. See also <seealso cref="TraktSearchResultType" />.</param>
        /// <param name="extendedInfo">
        /// The extended info, which determines how much data about the lookup object(s) should be queried.
        /// See also <seealso cref="TraktExtendedInfo" />.
        /// </param>
        /// <param name="page">The page of the search results list, that should be queried. Defaults to the first page.</param>
        /// <param name="limitPerPage">The maximum count of results for each page, that should be queried.</param>
        /// <returns>
        /// An <see cref="TraktPaginationListResult{TraktSearchResult}"/> instance containing the found movies, shows, episodes, people and / or lists and which also
        /// contains the queried page number, the page's item count, maximum page count and maximum item count.
        /// <para>
        /// See also <seealso cref="TraktPaginationListResult{ListItem}" /> and <seealso cref="TraktSearchResult" />.
        /// </para>
        /// </returns>
        /// <exception cref="Exceptions.TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="ArgumentException">
        /// Thrown, if the given lookupId is null, empty or contains spaces.
        /// Thrown, if the given searchIdType is unspecified.
        /// </exception>
        /// <exception cref="ArgumentNullException">Thrown, if the given searchIdType is null.</exception>
        [OAuthAuthorizationRequired(false)]
        public async Task<TraktPaginationListResult<TraktSearchResult>> GetIdLookupResultsAsync(TraktSearchIdType searchIdType, [NotNull] string lookupId,
                                                                                                TraktSearchResultType searchResultType = null,
                                                                                                TraktExtendedInfo extendedInfo = null,
                                                                                                int? page = null, int? limitPerPage = null)
        {
            Validate(searchIdType, lookupId);

            return await QueryAsync(new TraktSearchIdLookupRequest(Client)
            {
                IdType = searchIdType,
                LookupId = lookupId,
                ResultType = searchResultType,
                ExtendedInfo = extendedInfo,
                PaginationOptions = new TraktPaginationOptions(page, limitPerPage)
            });
        }

        /// <summary>
        /// Searches for movies, shows, episodes, people and / or lists with the given search query.
        /// <para>OAuth authorization not required.</para>
        /// <para>This method is DEPRECATED. Please use <see cref="GetTextQueryResultsAsync(TraktSearchResultType, string, TraktSearchField, TraktSearchFilter, TraktExtendedInfo, int?, int?)" />.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/search/text-query/get-text-query-results">"Trakt API Doc - Search: Text Query"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="searchQuery">The query, for which will be searched.</param>
        /// <param name="searchResultType">The object type, for which will be searched. See also <seealso cref="TraktSearchResultType" />.</param>
        /// <param name="year">The year, for which will be searched.</param>
        /// <param name="page">The page of the search results list, that should be queried. Defaults to the first page.</param>
        /// <param name="limitPerPage">The maximum count of results for each page, that should be queried.</param>
        /// <returns>
        /// An <see cref="TraktPaginationListResult{TraktSearchResult}"/> instance containing the found movies, shows, episodes, people and / or lists and which also
        /// contains the queried page number, the page's item count, maximum page count and maximum item count.
        /// <para>
        /// See also <seealso cref="TraktPaginationListResult{ListItem}" /> and <seealso cref="TraktSearchResult" />.
        /// </para>
        /// </returns>
        /// <exception cref="Exceptions.TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="ArgumentException">
        /// Thrown, if the given searchQuery is null, empty or contains spaces.
        /// Thrown, if the given searchResultType has an unspecified value.
        /// </exception>
        [Obsolete("This search method still works, but might be removed in a future release.")]
        [OAuthAuthorizationRequired(false)]
        public async Task<TraktPaginationListResult<TraktSearchResult>> GetTextQueryResultsAsync([NotNull] string searchQuery, TraktSearchResultType searchResultType = null,
                                                                                                 int? year = null, int? page = null, int? limitPerPage = null)
        {
            Validate(searchQuery);

            return await QueryAsync(new TraktSearchOldTextQueryRequest(Client)
            {
                Query = searchQuery,
                Type = searchResultType,
                Year = year,
                PaginationOptions = new TraktPaginationOptions(page, limitPerPage)
            });
        }

        /// <summary>
        /// Looks up items by their Trakt-, IMDB-, TMDB-, TVDB- or TVRage-Id.
        /// <para>OAuth authorization not required.</para>
        /// <para>This method is DEPRECATED. Please use <see cref="GetIdLookupResultsAsync(TraktSearchIdType, string, TraktSearchResultType, TraktExtendedInfo, int?, int?)" />.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/search/text-query/get-id-lookup-results">"Trakt API Doc - Search: Id Lookup"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="searchIdLookupType">The id type, which should be looked up. See also <seealso cref="TraktSearchIdLookupType" />.</param>
        /// <param name="lookupId">The Trakt-, IMDB-, TMDB-, TVDB- or TVRage-Id, which will be looked up.</param>
        /// <param name="page">The page of the search results list, that should be queried. Defaults to the first page.</param>
        /// <param name="limitPerPage">The maximum count of results for each page, that should be queried.</param>
        /// <returns>
        /// An <see cref="TraktPaginationListResult{TraktSearchResult}"/> instance containing the found movies, shows, episodes, people and / or lists and which also
        /// contains the queried page number, the page's item count, maximum page count and maximum item count.
        /// <para>
        /// See also <seealso cref="TraktPaginationListResult{ListItem}" /> and <seealso cref="TraktSearchResult" />.
        /// </para>
        /// </returns>
        /// <exception cref="Exceptions.TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="ArgumentException">
        /// Thrown, if the given lookupId is null, empty or contains spaces.
        /// Thrown, if the given searchIdLookupType is unspecified.
        /// </exception>
        /// <exception cref="ArgumentNullException">Thrown, if the given searchIdLookupType is null.</exception>
        [Obsolete("This search method still works, but might be removed in a future release.")]
        [OAuthAuthorizationRequired(false)]
        public async Task<TraktPaginationListResult<TraktSearchResult>> GetIdLookupResultsAsync(TraktSearchIdLookupType searchIdLookupType, [NotNull] string lookupId,
                                                                                                int? page = null, int? limitPerPage = null)
        {
            Validate(searchIdLookupType, lookupId);

            return await QueryAsync(new TraktSearchOldIdLookupRequest(Client)
            {
                Type = searchIdLookupType,
                LookupId = lookupId,
                PaginationOptions = new TraktPaginationOptions(page, limitPerPage)
            });
        }

        private void Validate(string searchQuery)
        {
            if (string.IsNullOrEmpty(searchQuery))
                throw new ArgumentException("search query not valid", nameof(searchQuery));
        }

        private void Validate(TraktSearchResultType searchResultType)
        {
            if (searchResultType == null)
                throw new ArgumentNullException(nameof(searchResultType), "search result type must not be null");

            if (searchResultType == TraktSearchResultType.Unspecified)
                throw new ArgumentException("search result type not valid", nameof(searchResultType));
        }

        private void Validate(TraktSearchIdType searchIdType, string lookupId)
        {
            if (searchIdType == null)
                throw new ArgumentNullException(nameof(searchIdType), "search id type must not be null");

            if (searchIdType == TraktSearchIdType.Unspecified)
                throw new ArgumentException("search id lookup type not valid", nameof(searchIdType));

            if (string.IsNullOrEmpty(lookupId) || lookupId.ContainsSpace())
                throw new ArgumentException("search lookup id not valid", nameof(lookupId));
        }

        private void Validate(TraktSearchIdLookupType searchIdLookupType, string lookupId)
        {
            if (searchIdLookupType == null)
                throw new ArgumentNullException(nameof(searchIdLookupType), "search id lookup type must not be null");

            if (searchIdLookupType == TraktSearchIdLookupType.Unspecified)
                throw new ArgumentException("search id lookup type not valid", nameof(searchIdLookupType));

            if (string.IsNullOrEmpty(lookupId) || lookupId.ContainsSpace())
                throw new ArgumentException("search lookup id not valid", nameof(lookupId));
        }
    }
}
