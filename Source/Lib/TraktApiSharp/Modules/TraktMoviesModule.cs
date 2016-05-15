namespace TraktApiSharp.Modules
{
    using Enums;
    using Objects.Basic;
    using Objects.Get.Movies;
    using Objects.Get.Movies.Common;
    using Requests;
    using Requests.WithoutOAuth.Movies;
    using Requests.WithoutOAuth.Movies.Common;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class TraktMoviesModule : TraktBaseModule
    {
        public TraktMoviesModule(TraktClient client) : base(client) { }

        public async Task<TraktMovie> GetMovieAsync(string id, TraktExtendedOption extended = TraktExtendedOption.Unspecified)
        {
            return await QueryAsync(new TraktMovieSummaryRequest(Client)
            {
                Id = id,
                ExtendedOption = extended
            });
        }

        public async Task<TraktListResult<TraktMovie>> GetMoviesAsync(string[] ids, TraktExtendedOption extended = TraktExtendedOption.Unspecified)
        {
            if (ids == null || ids.Length <= 0)
                return null;

            var movies = new List<TraktMovie>();

            foreach (var id in ids)
            {
                var movie = await GetMovieAsync(id, extended);

                if (movie != null)
                    movies.Add(movie);
            }

            return new TraktListResult<TraktMovie> { Items = movies };
        }

        public async Task<TraktListResult<TraktMovieAlias>> GetMovieAliasesAsync(string id)
        {
            return await QueryAsync(new TraktMovieAliasesRequest(Client)
            {
                Id = id
            });
        }

        public async Task<TraktListResult<TraktMovieRelease>> GetMovieReleasesAsync(string id)
        {
            return await QueryAsync(new TraktMovieReleasesRequest(Client)
            {
                Id = id
            });
        }

        public async Task<TraktMovieRelease> GetMovieSingleReleaseAsync(string id, string languageCode)
        {
            return await QueryAsync(new TraktMovieSingleReleaseRequest(Client)
            {
                Id = id,
                LanguageCode = languageCode
            });
        }

        public async Task<TraktListResult<TraktMovieTranslation>> GetMovieTranslationsAsync(string id)
        {
            return await QueryAsync(new TraktMovieTranslationsRequest(Client)
            {
                Id = id
            });
        }

        public async Task<TraktMovieTranslation> GetMovieSingleTranslationAsync(string id, string languageCode)
        {
            return await QueryAsync(new TraktMovieSingleTranslationRequest(Client)
            {
                Id = id,
                LanguageCode = languageCode
            });
        }

        public async Task<TraktPaginationListResult<TraktMovieComment>> GetMovieCommentsAsync(string id,
                                                                                              TraktCommentSortOrder sorting = TraktCommentSortOrder.Unspecified,
                                                                                              int? page = null, int? limit = null)
        {
            return await QueryAsync(new TraktMovieCommentsRequest(Client)
            {
                Id = id,
                Sorting = sorting,
                PaginationOptions = new TraktPaginationOptions(page, limit)
            });
        }

        public async Task<TraktMoviePeople> GetMoviePeopleAsync(string id)
        {
            return await QueryAsync(new TraktMoviePeopleRequest(Client)
            {
                Id = id
            });
        }

        public async Task<TraktMovieRating> GetMovieRatingsAsync(string id)
        {
            return await QueryAsync(new TraktMovieRatingsRequest(Client)
            {
                Id = id
            });
        }

        public async Task<TraktPaginationListResult<TraktMovie>> GetMovieRelatedMoviesAsync(string id, int? page = null, int? limit = null)
        {
            return await QueryAsync(new TraktMovieRelatedMoviesRequest(Client)
            {
                Id = id,
                PaginationOptions = new TraktPaginationOptions(page, limit)
            });
        }

        public async Task<TraktMovieStatistics> GetMovieStatisticsAsync(string id)
        {
            return await QueryAsync(new TraktMovieStatisticsRequest(Client)
            {
                Id = id
            });
        }

        public async Task<TraktListResult<TraktMovieWatchingUser>> GetMovieWatchingUsersAsync(string id)
        {
            return await QueryAsync(new TraktMovieWatchingUsersRequest(Client)
            {
                Id = id
            });
        }

        public async Task<TraktPaginationListResult<TraktTrendingMovie>> GetTrendingMoviesAsync(TraktExtendedOption extended = TraktExtendedOption.Unspecified,
                                                                                                     int? page = null, int? limit = null)
        {
            return await QueryAsync(new TraktMoviesTrendingRequest(Client)
            {
                ExtendedOption = extended,
                PaginationOptions = new TraktPaginationOptions(page, limit)
            });
        }

        public async Task<TraktPaginationListResult<TraktMoviesPopularItem>> GetPopularMoviesAsync(TraktExtendedOption extended = TraktExtendedOption.Unspecified,
                                                                                                   int? page = null, int? limit = null)
        {
            return await QueryAsync(new TraktMoviesPopularRequest(Client)
            {
                ExtendedOption = extended,
                PaginationOptions = new TraktPaginationOptions(page, limit)
            });
        }

        public async Task<TraktPaginationListResult<TraktMoviesMostPlayedItem>> GetMostPlayedMoviesAsync(TraktPeriod period = TraktPeriod.Weekly,
                                                                                                         TraktExtendedOption extended = TraktExtendedOption.Unspecified,
                                                                                                         int? page = null, int? limit = null)
        {
            return await QueryAsync(new TraktMoviesMostPlayedRequest(Client)
            {
                Period = period,
                ExtendedOption = extended,
                PaginationOptions = new TraktPaginationOptions(page, limit)
            });
        }

        public async Task<TraktPaginationListResult<TraktMoviesMostWatchedItem>> GetMostWatchedMoviesAsync(TraktPeriod period = TraktPeriod.Weekly,
                                                                                                           TraktExtendedOption extended = TraktExtendedOption.Unspecified,
                                                                                                           int? page = null, int? limit = null)
        {
            return await QueryAsync(new TraktMoviesMostWatchedRequest(Client)
            {
                Period = period,
                ExtendedOption = extended,
                PaginationOptions = new TraktPaginationOptions(page, limit)
            });
        }

        public async Task<TraktPaginationListResult<TraktMoviesMostCollectedItem>> GetMostCollectedMoviesAsync(TraktPeriod period = TraktPeriod.Weekly,
                                                                                                               TraktExtendedOption extended = TraktExtendedOption.Unspecified,
                                                                                                               int? page = null, int? limit = null)
        {
            return await QueryAsync(new TraktMoviesMostCollectedRequest(Client)
            {
                Period = period,
                ExtendedOption = extended,
                PaginationOptions = new TraktPaginationOptions(page, limit)
            });
        }

        public async Task<TraktPaginationListResult<TraktMoviesMostAnticipatedItem>> GetMostAnticipatedMoviesAsync(TraktExtendedOption extended = TraktExtendedOption.Unspecified,
                                                                                                                   int? page = null, int? limit = null)
        {
            return await QueryAsync(new TraktMoviesMostAnticipatedRequest(Client)
            {
                ExtendedOption = extended,
                PaginationOptions = new TraktPaginationOptions(page, limit)
            });
        }

        public async Task<TraktListResult<TraktMoviesBoxOfficeItem>> GetBoxOfficeMoviesAsync(TraktExtendedOption extended = TraktExtendedOption.Unspecified)
        {
            return await QueryAsync(new TraktMoviesBoxOfficeRequest(Client)
            {
                ExtendedOption = extended
            });
        }

        public async Task<TraktPaginationListResult<TraktMoviesRecentlyUpdatedItem>> GetRecentlyUpdatedMoviesAsync(DateTime? startDate,
                                                                                                                   TraktExtendedOption extended = TraktExtendedOption.Unspecified,
                                                                                                                   int? page = null, int? limit = null)
        {
            return await QueryAsync(new TraktMoviesRecentlyUpdatedRequest(Client)
            {
                StartDate = startDate,
                ExtendedOption = extended,
                PaginationOptions = new TraktPaginationOptions(page, limit)
            });
        }
    }
}
