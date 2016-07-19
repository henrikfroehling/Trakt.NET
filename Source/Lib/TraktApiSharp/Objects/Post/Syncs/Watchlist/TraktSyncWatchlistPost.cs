namespace TraktApiSharp.Objects.Post.Syncs.Watchlist
{
    using Get.Movies;
    using Get.Shows;
    using Get.Shows.Episodes;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class TraktSyncWatchlistPost
    {
        [JsonProperty(PropertyName = "movies")]
        public IEnumerable<TraktSyncWatchlistPostMovie> Movies { get; set; }

        [JsonProperty(PropertyName = "shows")]
        public IEnumerable<TraktSyncWatchlistPostShow> Shows { get; set; }

        [JsonProperty(PropertyName = "episodes")]
        public IEnumerable<TraktSyncWatchlistPostEpisode> Episodes { get; set; }

        public static TraktSyncWatchlistPostBuilder Builder() => new TraktSyncWatchlistPostBuilder();
    }

    public class TraktSyncWatchlistPostBuilder
    {
        private TraktSyncWatchlistPost _watchlistPost;

        public TraktSyncWatchlistPostBuilder()
        {
            _watchlistPost = new TraktSyncWatchlistPost();
        }

        public TraktSyncWatchlistPostBuilder AddMovie(TraktMovie movie)
        {
            if (movie == null)
                throw new ArgumentNullException(nameof(movie));

            if (movie.Ids == null)
                throw new ArgumentNullException(nameof(movie.Ids));

            if (!movie.Ids.HasAnyId)
                throw new ArgumentException("no movie ids set or valid", nameof(movie.Ids));

            if (movie.Year.HasValue && movie.Year.Value.ToString().Length != 4)
                throw new ArgumentException("movie year not valid", nameof(movie.Year));

            if (_watchlistPost.Movies == null)
                _watchlistPost.Movies = new List<TraktSyncWatchlistPostMovie>();

            var existingMovie = _watchlistPost.Movies.Where(m => m.Ids == movie.Ids).FirstOrDefault();

            if (existingMovie != null)
                return this;

            (_watchlistPost.Movies as List<TraktSyncWatchlistPostMovie>).Add(
                new TraktSyncWatchlistPostMovie
                {
                    Ids = movie.Ids,
                    Title = movie.Title,
                    Year = movie.Year
                });

            return this;
        }

        public TraktSyncWatchlistPostBuilder AddShow(TraktShow show)
        {
            ValidateShow(show);

            if (_watchlistPost.Shows == null)
                _watchlistPost.Shows = new List<TraktSyncWatchlistPostShow>();

            var existingShow = _watchlistPost.Shows.Where(s => s.Ids == show.Ids).FirstOrDefault();

            if (existingShow != null)
                return this;

            (_watchlistPost.Shows as List<TraktSyncWatchlistPostShow>).Add(
                new TraktSyncWatchlistPostShow
                {
                    Ids = show.Ids,
                    Title = show.Title,
                    Year = show.Year
                });

            return this;
        }

        public TraktSyncWatchlistPostBuilder AddShow(TraktShow show, int season, params int[] seasons)
        {
            ValidateShow(show);
            ValidateSeasons(season, seasons);

            if (_watchlistPost.Shows == null)
                _watchlistPost.Shows = new List<TraktSyncWatchlistPostShow>();

            var seasonsToAdd = new int[seasons.Length + 1];
            seasonsToAdd[0] = season;
            seasons.CopyTo(seasonsToAdd, 1);

            var showSeasons = new List<TraktSyncWatchlistPostShowSeason>();

            for (int i = 0; i < seasonsToAdd.Length; i++)
                showSeasons.Add(new TraktSyncWatchlistPostShowSeason { Number = seasonsToAdd[i] });

            var existingShow = _watchlistPost.Shows.Where(s => s.Ids == show.Ids).FirstOrDefault();

            if (existingShow != null)
                existingShow.Seasons = showSeasons;
            else
            {
                var watchlistShow = new TraktSyncWatchlistPostShow();
                watchlistShow.Ids = show.Ids;
                watchlistShow.Title = show.Title;
                watchlistShow.Year = show.Year;

                watchlistShow.Seasons = showSeasons;
                (_watchlistPost.Shows as List<TraktSyncWatchlistPostShow>).Add(watchlistShow);
            }

            return this;
        }

        public TraktSyncWatchlistPostBuilder AddShow(TraktShow show, PostSeasons seasons)
        {
            ValidateShow(show);

            if (seasons == null)
                throw new ArgumentNullException(nameof(seasons));

            ValidateSeasons(seasons);

            if (_watchlistPost.Shows == null)
                _watchlistPost.Shows = new List<TraktSyncWatchlistPostShow>();

            List<TraktSyncWatchlistPostShowSeason> showSeasons = null;

            if (seasons.Count() > 0)
            {
                showSeasons = new List<TraktSyncWatchlistPostShowSeason>();

                foreach (var season in seasons)
                {
                    var showSingleSeason = new TraktSyncWatchlistPostShowSeason { Number = season.Season };

                    if (season.Episodes != null && season.Episodes.Count() > 0)
                    {
                        var showEpisodes = new List<TraktSyncWatchlistPostShowEpisode>();

                        foreach (var episode in season.Episodes)
                            showEpisodes.Add(new TraktSyncWatchlistPostShowEpisode { Number = episode });

                        showSingleSeason.Episodes = showEpisodes;
                    }

                    showSeasons.Add(showSingleSeason);
                }
            }

            var existingShow = _watchlistPost.Shows.Where(s => s.Ids == show.Ids).FirstOrDefault();

            if (existingShow != null)
                existingShow.Seasons = showSeasons;
            else
            {
                var watchlistShow = new TraktSyncWatchlistPostShow();
                watchlistShow.Ids = show.Ids;
                watchlistShow.Title = show.Title;
                watchlistShow.Year = show.Year;

                watchlistShow.Seasons = showSeasons;
                (_watchlistPost.Shows as List<TraktSyncWatchlistPostShow>).Add(watchlistShow);
            }

            return this;
        }

        public TraktSyncWatchlistPostBuilder AddEpisode(TraktEpisode episode)
        {
            if (episode == null)
                throw new ArgumentNullException(nameof(episode));

            if (episode.Ids == null)
                throw new ArgumentNullException(nameof(episode.Ids));

            if (!episode.Ids.HasAnyId)
                throw new ArgumentException("no episode ids set or valid", nameof(episode.Ids));

            if (_watchlistPost.Episodes == null)
                _watchlistPost.Episodes = new List<TraktSyncWatchlistPostEpisode>();

            var existingEpisode = _watchlistPost.Episodes.Where(e => e.Ids == episode.Ids).FirstOrDefault();

            if (existingEpisode != null)
                return this;

            (_watchlistPost.Episodes as List<TraktSyncWatchlistPostEpisode>).Add(
                new TraktSyncWatchlistPostEpisode
                {
                    Ids = episode.Ids
                });

            return this;
        }

        public TraktSyncWatchlistPost Build()
        {
            var movies = _watchlistPost.Movies;
            var shows = _watchlistPost.Shows;
            var episodes = _watchlistPost.Episodes;

            var bHasNoMovies = movies == null || !movies.Any();
            var bHasNoShows = shows == null || !shows.Any();
            var bHasNoEpisodes = episodes == null || !episodes.Any();

            if (bHasNoMovies && bHasNoShows && bHasNoEpisodes)
                throw new ArgumentException("no items set");

            return _watchlistPost;
        }

        private void ValidateShow(TraktShow show)
        {
            if (show == null)
                throw new ArgumentNullException(nameof(show));

            if (show.Ids == null)
                throw new ArgumentNullException(nameof(show.Ids));

            if (!show.Ids.HasAnyId)
                throw new ArgumentException("no show ids set or valid", nameof(show.Ids));

            if (show.Year.HasValue && show.Year.Value.ToString().Length != 4)
                throw new ArgumentException("show year not valid", nameof(show.Year));
        }

        private void ValidateSeasons(int season, params int[] seasons)
        {
            if (season < 0)
                throw new ArgumentException("season number not valid", nameof(season));

            if (seasons != null)
            {
                for (int i = 0; i < seasons.Length; i++)
                {
                    if (seasons[i] < 0)
                        throw new ArgumentException("at least one season number not valid", nameof(seasons));
                }
            }
        }

        private void ValidateSeasons(PostSeasons seasons)
        {
            foreach (var season in seasons)
            {
                if (season.Season < 0)
                    throw new ArgumentException("at least one season number not valid", nameof(seasons));

                if (season.Episodes != null)
                {
                    foreach (var episode in season.Episodes)
                    {
                        if (episode < 0)
                            throw new ArgumentException("at least one episode number not valid", nameof(seasons));
                    }
                }
            }
        }
    }
}
