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

        public async Task<TraktMovie> GetMovieAsync(string id, TraktExtendedOption extended = null)
        {
            Validate(id);

            return await QueryAsync(new TraktMovieSummaryRequest(Client)
            {
                Id = id,
                ExtendedOption = extended ?? new TraktExtendedOption()
            });
        }

        public async Task<TraktListResult<TraktMovie>> GetMoviesAsync(string[] ids, TraktExtendedOption extended = null)
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
            Validate(id);

            return await QueryAsync(new TraktMovieAliasesRequest(Client) { Id = id });
        }

        public async Task<TraktListResult<TraktMovieRelease>> GetMovieReleasesAsync(string id)
        {
            Validate(id);

            return await QueryAsync(new TraktMovieReleasesRequest(Client) { Id = id });
        }

        public async Task<TraktMovieRelease> GetMovieSingleReleaseAsync(string id, string countryCode)
        {
            Validate(id, countryCode);

            return await QueryAsync(new TraktMovieSingleReleaseRequest(Client)
            {
                Id = id,
                LanguageCode = countryCode
            });
        }

        public async Task<TraktListResult<TraktMovieTranslation>> GetMovieTranslationsAsync(string id)
        {
            Validate(id);

            return await QueryAsync(new TraktMovieTranslationsRequest(Client) { Id = id });
        }

        public async Task<TraktMovieTranslation> GetMovieSingleTranslationAsync(string id, string languageCode)
        {
            Validate(id, languageCode);

            return await QueryAsync(new TraktMovieSingleTranslationRequest(Client)
            {
                Id = id,
                LanguageCode = languageCode
            });
        }

        public async Task<TraktPaginationListResult<TraktMovieComment>> GetMovieCommentsAsync(string id,
                                                                                              TraktCommentSortOrder? sorting = null,
                                                                                              int? page = null, int? limit = null)
        {
            Validate(id);

            return await QueryAsync(new TraktMovieCommentsRequest(Client)
            {
                Id = id,
                Sorting = sorting,
                PaginationOptions = new TraktPaginationOptions(page, limit)
            });
        }

        public async Task<TraktMoviePeople> GetMoviePeopleAsync(string id, TraktExtendedOption extended = null)
        {
            Validate(id);

            return await QueryAsync(new TraktMoviePeopleRequest(Client) { Id = id, ExtendedOption = extended ?? new TraktExtendedOption() });
        }

        public async Task<TraktMovieRating> GetMovieRatingsAsync(string id)
        {
            Validate(id);

            return await QueryAsync(new TraktMovieRatingsRequest(Client) { Id = id });
        }

        public async Task<TraktPaginationListResult<TraktMovie>> GetMovieRelatedMoviesAsync(string id, TraktExtendedOption extended = null,
                                                                                            int? page = null, int? limit = null)
        {
            Validate(id);

            return await QueryAsync(new TraktMovieRelatedMoviesRequest(Client)
            {
                Id = id,
                ExtendedOption = extended ?? new TraktExtendedOption(),
                PaginationOptions = new TraktPaginationOptions(page, limit)
            });
        }

        public async Task<TraktMovieStatistics> GetMovieStatisticsAsync(string id)
        {
            Validate(id);

            return await QueryAsync(new TraktMovieStatisticsRequest(Client) { Id = id });
        }

        public async Task<TraktListResult<TraktMovieWatchingUser>> GetMovieWatchingUsersAsync(string id, TraktExtendedOption extended = null)
        {
            Validate(id);

            return await QueryAsync(new TraktMovieWatchingUsersRequest(Client) { Id = id, ExtendedOption = extended ?? new TraktExtendedOption() });
        }

        public async Task<TraktPaginationListResult<TraktTrendingMovie>> GetTrendingMoviesAsync(TraktExtendedOption extended = null,
                                                                                                int? page = null, int? limit = null)
        {
            return await QueryAsync(new TraktMoviesTrendingRequest(Client)
            {
                ExtendedOption = extended ?? new TraktExtendedOption(),
                PaginationOptions = new TraktPaginationOptions(page, limit)
            });
        }

        public async Task<TraktPaginationListResult<TraktPopularMovie>> GetPopularMoviesAsync(TraktExtendedOption extended = null,
                                                                                              int? page = null, int? limit = null)
        {
            return await QueryAsync(new TraktMoviesPopularRequest(Client)
            {
                ExtendedOption = extended ?? new TraktExtendedOption(),
                PaginationOptions = new TraktPaginationOptions(page, limit)
            });
        }

        public async Task<TraktPaginationListResult<TraktMostPlayedMovie>> GetMostPlayedMoviesAsync(TraktPeriod? period = null,
                                                                                                    TraktExtendedOption extended = null,
                                                                                                    int? page = null, int? limit = null)
        {
            return await QueryAsync(new TraktMoviesMostPlayedRequest(Client)
            {
                Period = period,
                ExtendedOption = extended ?? new TraktExtendedOption(),
                PaginationOptions = new TraktPaginationOptions(page, limit)
            });
        }

        public async Task<TraktPaginationListResult<TraktMostWatchedMovie>> GetMostWatchedMoviesAsync(TraktPeriod? period = null,
                                                                                                      TraktExtendedOption extended = null,
                                                                                                      int? page = null, int? limit = null)
        {
            return await QueryAsync(new TraktMoviesMostWatchedRequest(Client)
            {
                Period = period,
                ExtendedOption = extended ?? new TraktExtendedOption(),
                PaginationOptions = new TraktPaginationOptions(page, limit)
            });
        }

        public async Task<TraktPaginationListResult<TraktMostCollectedMovie>> GetMostCollectedMoviesAsync(TraktPeriod? period = null,
                                                                                                          TraktExtendedOption extended = null,
                                                                                                          int? page = null, int? limit = null)
        {
            return await QueryAsync(new TraktMoviesMostCollectedRequest(Client)
            {
                Period = period,
                ExtendedOption = extended ?? new TraktExtendedOption(),
                PaginationOptions = new TraktPaginationOptions(page, limit)
            });
        }

        public async Task<TraktPaginationListResult<TraktMostAnticipatedMovie>> GetMostAnticipatedMoviesAsync(TraktExtendedOption extended = null,
                                                                                                              int? page = null, int? limit = null)
        {
            return await QueryAsync(new TraktMoviesMostAnticipatedRequest(Client)
            {
                ExtendedOption = extended ?? new TraktExtendedOption(),
                PaginationOptions = new TraktPaginationOptions(page, limit)
            });
        }

        public async Task<TraktListResult<TraktBoxOfficeMovie>> GetBoxOfficeMoviesAsync(TraktExtendedOption extended = null)
        {
            return await QueryAsync(new TraktMoviesBoxOfficeRequest(Client)
            {
                ExtendedOption = extended ?? new TraktExtendedOption()
            });
        }

        public async Task<TraktPaginationListResult<TraktRecentlyUpdatedMovie>> GetRecentlyUpdatedMoviesAsync(DateTime? startDate,
                                                                                                              TraktExtendedOption extended = null,
                                                                                                              int? page = null, int? limit = null)
        {
            return await QueryAsync(new TraktMoviesRecentlyUpdatedRequest(Client)
            {
                StartDate = startDate,
                ExtendedOption = extended ?? new TraktExtendedOption(),
                PaginationOptions = new TraktPaginationOptions(page, limit)
            });
        }

        private void Validate(string id)
        {
            if (string.IsNullOrEmpty(id))
                throw new ArgumentException("movie id not valid", "id");
        }

        private void Validate(string id, string languageCode)
        {
            Validate(id);

            if (string.IsNullOrEmpty(languageCode) || languageCode.Length != 2)
                throw new ArgumentException("movie language code not valid", "languageCode");
        }
    }
}
