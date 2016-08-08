namespace TraktApiSharp.Example.UWP.Services.TraktService
{
    using Enums;
    using Models;
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

        public async Task<Movie> GetMovieAsync(string movieId, TraktExtendedOption extendedInfo = null,
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

        public async Task<PaginationList<TrendingMovie>> GetTrendingMoviesAsync(TraktExtendedOption extendedInfo = null,
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
                var trendingMovie = traktTrendingMovie.Movie as TrendingMovie;
                trendingMovie.Watchers = traktTrendingMovie.Watchers;
                results.Items.Add(trendingMovie);
            }

            return results;
        }

        // -------------------------------------------------------------
        // Popular Movies

        public async Task<PaginationList<Movie>> GetPopularMoviesAsync(TraktExtendedOption extendedInfo = null,
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
                results.Items.Add(traktPopularMovie as Movie);

            return results;
        }

        // -------------------------------------------------------------
        // Most Played Movies

        public async Task<PaginationList<MostPWCMovie>> GetMostPlayedMoviesAsync(TraktExtendedOption extendedInfo = null,
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
                var mostPlayedMovie = traktMostPlayedMovie.Movie as MostPWCMovie;

                mostPlayedMovie.CollectedCount = traktMostPlayedMovie.CollectedCount;
                mostPlayedMovie.PlayCount = traktMostPlayedMovie.PlayCount;
                mostPlayedMovie.WatcherCount = traktMostPlayedMovie.WatcherCount;

                results.Items.Add(mostPlayedMovie);
            }

            return results;
        }

        // -------------------------------------------------------------
        // Most Watched Movies

        public async Task<PaginationList<MostPWCMovie>> GetMostWatchedMoviesAsync(TraktExtendedOption extendedInfo = null,
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
                var mostWatchedMovie = traktMostWatchedMovie.Movie as MostPWCMovie;

                mostWatchedMovie.CollectedCount = traktMostWatchedMovie.CollectedCount;
                mostWatchedMovie.PlayCount = traktMostWatchedMovie.PlayCount;
                mostWatchedMovie.WatcherCount = traktMostWatchedMovie.WatcherCount;

                results.Items.Add(mostWatchedMovie);
            }

            return results;
        }

        // -------------------------------------------------------------
        // Most Collected Movies

        public async Task<PaginationList<MostPWCMovie>> GetMostCollectedMoviesAsync(TraktExtendedOption extendedInfo = null,
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
                var mostCollectedMovie = traktMostCollectedMovie.Movie as MostPWCMovie;

                mostCollectedMovie.CollectedCount = traktMostCollectedMovie.CollectedCount;
                mostCollectedMovie.PlayCount = traktMostCollectedMovie.PlayCount;
                mostCollectedMovie.WatcherCount = traktMostCollectedMovie.WatcherCount;

                results.Items.Add(mostCollectedMovie);
            }

            return results;
        }

        // -------------------------------------------------------------
        // Most Anticipated Movies

        public async Task<PaginationList<AnticipatedMovie>> GetMostAnticipatedMoviesAsync(TraktExtendedOption extendedInfo = null,
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
                var anticipatedMovie = traktAnticipatedMovie.Movie as AnticipatedMovie;
                anticipatedMovie.ListCount = traktAnticipatedMovie.ListCount;
                results.Items.Add(anticipatedMovie);
            }

            return results;
        }

        // -------------------------------------------------------------
        // Box Office Movies

        public async Task<ObservableCollection<BoxOfficeMovie>> GetBoxOfficeMoviesAsync(TraktExtendedOption extendedInfo = null)
        {
            var traktResults = await Client.Movies.GetBoxOfficeMoviesAsync(extendedInfo);

            var results = new ObservableCollection<BoxOfficeMovie>();

            foreach (var traktBoxOfficeMovie in traktResults)
            {
                var boxOfficeMovie = traktBoxOfficeMovie.Movie as BoxOfficeMovie;
                boxOfficeMovie.Revenue = traktBoxOfficeMovie.Revenue;
                results.Add(boxOfficeMovie);
            }

            return results;
        }

        // -------------------------------------------------------------
        // Recently Updated Movies

        public async Task<PaginationList<RecentlyUpdatedMovie>> GetRecentlyUpdatedMoviesAsync(DateTime? startDate = null,
                                                                                              TraktExtendedOption extendedInfo = null,
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
                var recentlyUpdatedMovie = traktRecentlyUpdatedMovie.Movie as RecentlyUpdatedMovie;
                recentlyUpdatedMovie.MovieUpdatedAt = traktRecentlyUpdatedMovie.UpdatedAt;
                results.Items.Add(recentlyUpdatedMovie);
            }

            return results;
        }
    }
}
