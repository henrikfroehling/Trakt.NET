namespace TraktApiSharp.Modules
{
    using Enums;
    using Exceptions;
    using Objects.Basic.Implementations;
    using Requests.Handler;
    using Requests.Parameters;
    using Requests.Search;
    using Responses;
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
        /// An <see cref="TraktPagedResponse{TraktSearchResult}"/> instance containing the found movies, shows, episodes, people and / or lists and which also
        /// contains the queried page number, the page's item count, maximum page count and maximum item count.
        /// <para>
        /// See also <seealso cref="TraktPagedResponse{ListItem}" /> and <seealso cref="TraktSearchResult" />.
        /// </para>
        /// </returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="ArgumentException">
        /// Thrown, if the given searchQuery is null, empty or contains spaces.
        /// Thrown, if the given searchResultType is unspecified.
        /// </exception>
        /// <exception cref="ArgumentNullException">Thrown, if the given searchResultType is null</exception>
        public async Task<TraktPagedResponse<TraktSearchResult>> GetTextQueryResultsAsync(TraktSearchResultType searchResultTypes, string searchQuery,
                                                                                          TraktSearchField searchFields = null, TraktSearchFilter filter = null,
                                                                                          TraktExtendedInfo extendedInfo = null,
                                                                                          int? page = null, int? limitPerPage = null)
        {
            var requestHandler = new TraktRequestHandler(Client);

            return await requestHandler.ExecutePagedRequestAsync(new TraktSearchTextQueryRequest
            {
                ResultTypes = searchResultTypes,
                Query = searchQuery,
                SearchFields = searchFields,
                Filter = filter,
                ExtendedInfo = extendedInfo,
                Page = page,
                Limit = limitPerPage
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
        /// <param name="searchResultTypes">The object type(s), which will be looked up. See also <seealso cref="TraktSearchResultType" />.</param>
        /// <param name="extendedInfo">
        /// The extended info, which determines how much data about the lookup object(s) should be queried.
        /// See also <seealso cref="TraktExtendedInfo" />.
        /// </param>
        /// <param name="page">The page of the search results list, that should be queried. Defaults to the first page.</param>
        /// <param name="limitPerPage">The maximum count of results for each page, that should be queried.</param>
        /// <returns>
        /// An <see cref="TraktPagedResponse{TraktSearchResult}"/> instance containing the found movies, shows, episodes, people and / or lists and which also
        /// contains the queried page number, the page's item count, maximum page count and maximum item count.
        /// <para>
        /// See also <seealso cref="TraktPagedResponse{ListItem}" /> and <seealso cref="TraktSearchResult" />.
        /// </para>
        /// </returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="ArgumentException">
        /// Thrown, if the given lookupId is null, empty or contains spaces.
        /// Thrown, if the given searchIdType is unspecified.
        /// </exception>
        /// <exception cref="ArgumentNullException">Thrown, if the given searchIdType is null.</exception>
        public async Task<TraktPagedResponse<TraktSearchResult>> GetIdLookupResultsAsync(TraktSearchIdType searchIdType, string lookupId,
                                                                                         TraktSearchResultType searchResultTypes = null,
                                                                                         TraktExtendedInfo extendedInfo = null,
                                                                                         int? page = null, int? limitPerPage = null)
        {
            var requestHandler = new TraktRequestHandler(Client);

            return await requestHandler.ExecutePagedRequestAsync(new TraktSearchIdLookupRequest
            {
                IdType = searchIdType,
                LookupId = lookupId,
                ResultTypes = searchResultTypes,
                ExtendedInfo = extendedInfo,
                Page = page,
                Limit = limitPerPage
            });
        }
    }
}
