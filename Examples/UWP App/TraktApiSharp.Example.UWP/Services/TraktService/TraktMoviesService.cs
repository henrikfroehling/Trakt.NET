namespace TraktApiSharp.Example.UWP.Services.TraktService
{
    using Enums;
    using Models;
    using Models.ModelConverter;
    using Models.Movies;
    using Objects.Get.Movies;
    using Requests.Params;
    using System;
    using System.Collections.ObjectModel;
    using System.Threading.Tasks;

    public class TraktMoviesService
    {
        private TraktClient Client { get; }

        private TraktMoviesService()
        {
            Client = TraktServiceProvider.Instance.Client;
        }

        public static TraktMoviesService Instance { get; } = new TraktMoviesService();

        // -------------------------------------------------------------
        // Single Movie

        public async Task<Movie> GetMovieAsync(string movieId, TraktExtendedInfo extendedInfo = null,
                                               bool withAdditionalContent = false)
        {
            var movie = await Client.Movies.GetMovieAsync(movieId, extendedInfo) as Movie;

            if (withAdditionalContent)
            {
                var aliases = await Client.Movies.GetMovieAliasesAsync(movieId);
                movie.Aliases = new ObservableCollection<TraktMovieAlias>(aliases);

                var releases = await Client.Movies.GetMovieReleasesAsync(movieId);
                movie.Releases = new ObservableCollection<TraktMovieRelease>(releases);

                var translations = await Client.Movies.GetMovieTranslationsAsync(movieId);
                movie.Translations = new ObservableCollection<TraktMovieTranslation>(translations);

                movie.MovieRating = await Client.Movies.GetMovieRatingsAsync(movieId);
                movie.Statistics = await Client.Movies.GetMovieStatisticsAsync(movieId);
            }

            return movie;
        }

        // -------------------------------------------------------------
        // Trending Movies

        public async Task<PaginationList<TrendingMovie>> GetTrendingMoviesAsync(TraktExtendedInfo extendedInfo = null,
                                                                                TraktMovieFilter movieFilter = null,
                                                                                int? whichPage = null, int? limitPerPage = null)
        {
            var traktResults = await Client.Movies.GetTrendingMoviesAsync(extendedInfo, movieFilter, whichPage, limitPerPage);

            var results = new PaginationList<TrendingMovie>
            {
                CurrentPage = traktResults.Page,
                TotalPages = traktResults.PageCount,
                LimitPerPage = traktResults.Limit,
                TotalItemCount = traktResults.ItemCount,
                TotalUserCount = traktResults.UserCount
            };

            results.Items = new ObservableCollection<TrendingMovie>();

            foreach (var traktTrendingMovie in traktResults)
            {
                var trendingMovie = MovieModelConverter.Convert<TrendingMovie>(traktTrendingMovie.Movie);

                if (trendingMovie != null)
                {
                    trendingMovie.Watchers = traktTrendingMovie.Watchers.GetValueOrDefault();
                    results.Items.Add(trendingMovie);
                }
            }

            return results;
        }

        // -------------------------------------------------------------
        // Popular Movies

        public async Task<PaginationList<Movie>> GetPopularMoviesAsync(TraktExtendedInfo extendedInfo = null,
                                                                       TraktMovieFilter movieFilter = null,
                                                                       int? whichPage = null, int? limitPerPage = null)
        {
            var traktResults = await Client.Movies.GetPopularMoviesAsync(extendedInfo, movieFilter, whichPage, limitPerPage);

            var results = new PaginationList<Movie>
            {
                CurrentPage = traktResults.Page,
                TotalPages = traktResults.PageCount,
                LimitPerPage = traktResults.Limit,
                TotalItemCount = traktResults.ItemCount,
                TotalUserCount = traktResults.UserCount
            };

            results.Items = new ObservableCollection<Movie>();

            foreach (var traktPopularMovie in traktResults)
            {
                var popularMovie = MovieModelConverter.Convert<Movie>(traktPopularMovie);

                if (popularMovie != null)
                    results.Items.Add(popularMovie);
            }

            return results;
        }

        // -------------------------------------------------------------
        // Most Played Movies

        public async Task<PaginationList<MostPWCMovie>> GetMostPlayedMoviesAsync(TraktExtendedInfo extendedInfo = null,
                                                                                 TraktMovieFilter movieFilter = null,
                                                                                 TraktTimePeriod period = null,
                                                                                 int? whichPage = null, int? limitPerPage = null)
        {
            var traktResults = await Client.Movies.GetMostPlayedMoviesAsync(period, extendedInfo, movieFilter, whichPage, limitPerPage);

            var results = new PaginationList<MostPWCMovie>
            {
                CurrentPage = traktResults.Page,
                TotalPages = traktResults.PageCount,
                LimitPerPage = traktResults.Limit,
                TotalItemCount = traktResults.ItemCount,
                TotalUserCount = traktResults.UserCount
            };

            results.Items = new ObservableCollection<MostPWCMovie>();

            foreach (var traktMostPlayedMovie in traktResults)
            {
                var mostPlayedMovie = MovieModelConverter.Convert<MostPWCMovie>(traktMostPlayedMovie.Movie);

                if (mostPlayedMovie != null)
                {
                    mostPlayedMovie.WatcherCount = traktMostPlayedMovie.WatcherCount.GetValueOrDefault();
                    mostPlayedMovie.PlayCount = traktMostPlayedMovie.PlayCount.GetValueOrDefault();
                    mostPlayedMovie.CollectedCount = traktMostPlayedMovie.CollectedCount.GetValueOrDefault();

                    results.Items.Add(mostPlayedMovie);
                }
            }

            return results;
        }

        // -------------------------------------------------------------
        // Most Watched Movies

        public async Task<PaginationList<MostPWCMovie>> GetMostWatchedMoviesAsync(TraktExtendedInfo extendedInfo = null,
                                                                                  TraktMovieFilter movieFilter = null,
                                                                                  TraktTimePeriod period = null,
                                                                                  int? whichPage = null, int? limitPerPage = null)
        {
            var traktResults = await Client.Movies.GetMostWatchedMoviesAsync(period, extendedInfo, movieFilter, whichPage, limitPerPage);

            var results = new PaginationList<MostPWCMovie>
            {
                CurrentPage = traktResults.Page,
                TotalPages = traktResults.PageCount,
                LimitPerPage = traktResults.Limit,
                TotalItemCount = traktResults.ItemCount,
                TotalUserCount = traktResults.UserCount
            };

            results.Items = new ObservableCollection<MostPWCMovie>();

            foreach (var traktMostWatchedMovie in traktResults)
            {
                var mostWatchedMovie = MovieModelConverter.Convert<MostPWCMovie>(traktMostWatchedMovie.Movie);

                if (mostWatchedMovie != null)
                {
                    mostWatchedMovie.WatcherCount = traktMostWatchedMovie.WatcherCount.GetValueOrDefault();
                    mostWatchedMovie.PlayCount = traktMostWatchedMovie.PlayCount.GetValueOrDefault();
                    mostWatchedMovie.CollectedCount = traktMostWatchedMovie.CollectedCount.GetValueOrDefault();

                    results.Items.Add(mostWatchedMovie);
                }
            }

            return results;
        }

        // -------------------------------------------------------------
        // Most Collected Movies

        public async Task<PaginationList<MostPWCMovie>> GetMostCollectedMoviesAsync(TraktExtendedInfo extendedInfo = null,
                                                                                    TraktMovieFilter movieFilter = null,
                                                                                    TraktTimePeriod period = null,
                                                                                    int? whichPage = null, int? limitPerPage = null)
        {
            var traktResults = await Client.Movies.GetMostCollectedMoviesAsync(period, extendedInfo, movieFilter, whichPage, limitPerPage);

            var results = new PaginationList<MostPWCMovie>
            {
                CurrentPage = traktResults.Page,
                TotalPages = traktResults.PageCount,
                LimitPerPage = traktResults.Limit,
                TotalItemCount = traktResults.ItemCount,
                TotalUserCount = traktResults.UserCount
            };

            results.Items = new ObservableCollection<MostPWCMovie>();

            foreach (var traktMostCollectedMovie in traktResults)
            {
                var mostCollectedMovie = MovieModelConverter.Convert<MostPWCMovie>(traktMostCollectedMovie.Movie);

                if (mostCollectedMovie != null)
                {
                    mostCollectedMovie.WatcherCount = traktMostCollectedMovie.WatcherCount.GetValueOrDefault();
                    mostCollectedMovie.PlayCount = traktMostCollectedMovie.PlayCount.GetValueOrDefault();
                    mostCollectedMovie.CollectedCount = traktMostCollectedMovie.CollectedCount.GetValueOrDefault();

                    results.Items.Add(mostCollectedMovie);
                }
            }

            return results;
        }

        // -------------------------------------------------------------
        // Most Anticipated Movies

        public async Task<PaginationList<AnticipatedMovie>> GetMostAnticipatedMoviesAsync(TraktExtendedInfo extendedInfo = null,
                                                                                          TraktMovieFilter movieFilter = null,
                                                                                          int? whichPage = null, int? limitPerPage = null)
        {
            var traktResults = await Client.Movies.GetMostAnticipatedMoviesAsync(extendedInfo, movieFilter, whichPage, limitPerPage);

            var results = new PaginationList<AnticipatedMovie>
            {
                CurrentPage = traktResults.Page,
                TotalPages = traktResults.PageCount,
                LimitPerPage = traktResults.Limit,
                TotalItemCount = traktResults.ItemCount,
                TotalUserCount = traktResults.UserCount
            };

            results.Items = new ObservableCollection<AnticipatedMovie>();

            foreach (var traktAnticipatedMovie in traktResults)
            {
                var anticipatedMovie = MovieModelConverter.Convert<AnticipatedMovie>(traktAnticipatedMovie.Movie);

                if (anticipatedMovie != null)
                {
                    anticipatedMovie.ListCount = traktAnticipatedMovie.ListCount.GetValueOrDefault();
                    results.Items.Add(anticipatedMovie);
                }
            }

            return results;
        }

        // -------------------------------------------------------------
        // Box Office Movies

        public async Task<ObservableCollection<BoxOfficeMovie>> GetBoxOfficeMoviesAsync(TraktExtendedInfo extendedInfo = null)
        {
            var traktResults = await Client.Movies.GetBoxOfficeMoviesAsync(extendedInfo);

            var results = new ObservableCollection<BoxOfficeMovie>();

            foreach (var traktBoxOfficeMovie in traktResults)
            {
                var boxOfficeMovie = MovieModelConverter.Convert<BoxOfficeMovie>(traktBoxOfficeMovie.Movie);

                if (boxOfficeMovie != null)
                {
                    boxOfficeMovie.Revenue = traktBoxOfficeMovie.Revenue.GetValueOrDefault();
                    results.Add(boxOfficeMovie);
                }
            }

            return results;
        }

        // -------------------------------------------------------------
        // Recently Updated Movies

        public async Task<PaginationList<RecentlyUpdatedMovie>> GetRecentlyUpdatedMoviesAsync(DateTime? startDate = null,
                                                                                              TraktExtendedInfo extendedInfo = null,
                                                                                              int? whichPage = null, int? limitPerPage = null)
        {
            var traktResults = await Client.Movies.GetRecentlyUpdatedMoviesAsync(startDate, extendedInfo, whichPage, limitPerPage);

            var results = new PaginationList<RecentlyUpdatedMovie>
            {
                CurrentPage = traktResults.Page,
                TotalPages = traktResults.PageCount,
                LimitPerPage = traktResults.Limit,
                TotalItemCount = traktResults.ItemCount,
                TotalUserCount = traktResults.UserCount
            };

            results.Items = new ObservableCollection<RecentlyUpdatedMovie>();

            foreach (var traktRecentlyUpdatedMovie in traktResults)
            {
                var recentlyUpdatedMovie = MovieModelConverter.Convert<RecentlyUpdatedMovie>(traktRecentlyUpdatedMovie.Movie);

                if (recentlyUpdatedMovie != null)
                {
                    var updatedAt = traktRecentlyUpdatedMovie.UpdatedAt;
                    recentlyUpdatedMovie.MovieUpdatedAt = updatedAt.HasValue ? updatedAt.ToString() : string.Empty;
                    results.Items.Add(recentlyUpdatedMovie);
                }
            }

            return results;
        }
    }
}
