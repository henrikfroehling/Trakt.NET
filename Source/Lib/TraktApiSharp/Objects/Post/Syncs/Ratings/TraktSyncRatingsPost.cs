namespace TraktApiSharp.Objects.Post.Syncs.Ratings
{
    using Get.Movies;
    using Get.Shows;
    using Get.Shows.Episodes;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class TraktSyncRatingsPost
    {
        [JsonProperty(PropertyName = "movies")]
        public IEnumerable<TraktSyncRatingsPostMovie> Movies { get; set; }

        [JsonProperty(PropertyName = "shows")]
        public IEnumerable<TraktSyncRatingsPostShow> Shows { get; set; }

        [JsonProperty(PropertyName = "episodes")]
        public IEnumerable<TraktSyncRatingsPostEpisode> Episodes { get; set; }

        public static TraktSyncRatingsPostBuilder Builder() => new TraktSyncRatingsPostBuilder();
    }

    public class TraktSyncRatingsPostBuilder
    {
        private TraktSyncRatingsPost _ratingsPost;

        public TraktSyncRatingsPostBuilder()
        {
            _ratingsPost = new TraktSyncRatingsPost();
        }

        public TraktSyncRatingsPostBuilder AddMovie(TraktMovie movie)
        {
            ValidateMovie(movie);
            EnsureMoviesListExists();

            return AddMovieOrIgnore(movie);
        }

        public TraktSyncRatingsPostBuilder AddMovie(TraktMovie movie, int rating)
        {
            ValidateMovie(movie);
            ValidateRating(rating);
            EnsureMoviesListExists();

            return AddMovieOrIgnore(movie, rating);
        }

        public TraktSyncRatingsPostBuilder AddMovie(TraktMovie movie, int rating, DateTime ratedAt)
        {
            ValidateMovie(movie);
            ValidateRating(rating);
            EnsureMoviesListExists();

            return AddMovieOrIgnore(movie, rating, ratedAt);
        }

        public TraktSyncRatingsPostBuilder AddShow(TraktShow show)
        {
            ValidateShow(show);
            EnsureShowsListExists();

            return AddShowOrIgnore(show);
        }

        public TraktSyncRatingsPostBuilder AddShow(TraktShow show, int season, params int[] seasons)
        {
            ValidateShow(show);
            EnsureShowsListExists();

            var showSeasons = CreateShowSeasons(season, seasons);
            CreateOrSetShow(show, showSeasons);

            return this;
        }

        public TraktSyncRatingsPostBuilder AddShow(TraktShow show, PostRatingsSeasons seasons)
        {
            ValidateShow(show);

            if (seasons == null)
                throw new ArgumentNullException(nameof(seasons));

            EnsureShowsListExists();

            var showSeasons = CreateShowSeasons(seasons);
            CreateOrSetShow(show, showSeasons);

            return this;
        }

        public TraktSyncRatingsPostBuilder AddShowWithRating(TraktShow show, int rating)
        {
            ValidateShow(show);
            ValidateRating(rating);
            EnsureShowsListExists();

            return AddShowOrIgnore(show, rating);
        }

        public TraktSyncRatingsPostBuilder AddShowWithRating(TraktShow show, int rating, int season, params int[] seasons)
        {
            ValidateShow(show);
            ValidateRating(rating);
            EnsureShowsListExists();

            var showSeasons = CreateShowSeasons(season, seasons);
            CreateOrSetShow(show, showSeasons, rating);

            return this;
        }

        public TraktSyncRatingsPostBuilder AddShowWithRating(TraktShow show, int rating, PostRatingsSeasons seasons)
        {
            ValidateShow(show);
            ValidateRating(rating);

            if (seasons == null)
                throw new ArgumentNullException(nameof(seasons));

            EnsureShowsListExists();

            var showSeasons = CreateShowSeasons(seasons);
            CreateOrSetShow(show, showSeasons, rating);

            return this;
        }

        public TraktSyncRatingsPostBuilder AddShowWithRating(TraktShow show, int rating, DateTime ratedAt)
        {
            ValidateShow(show);
            ValidateRating(rating);
            EnsureShowsListExists();

            return AddShowOrIgnore(show, rating, ratedAt);
        }

        public TraktSyncRatingsPostBuilder AddShowWithRating(TraktShow show, int rating, DateTime ratedAt,
                                                             int season, params int[] seasons)
        {
            ValidateShow(show);
            ValidateRating(rating);
            EnsureShowsListExists();

            var showSeasons = CreateShowSeasons(season, seasons);
            CreateOrSetShow(show, showSeasons, rating, ratedAt);

            return this;
        }

        public TraktSyncRatingsPostBuilder AddShowWithRating(TraktShow show, int rating, DateTime ratedAt,
                                                             PostRatingsSeasons seasons)
        {
            ValidateShow(show);
            ValidateRating(rating);

            if (seasons == null)
                throw new ArgumentNullException(nameof(seasons));

            EnsureShowsListExists();

            var showSeasons = CreateShowSeasons(seasons);
            CreateOrSetShow(show, showSeasons, rating, ratedAt);

            return this;
        }

        public TraktSyncRatingsPostBuilder AddEpisode(TraktEpisode episode)
        {
            ValidateEpisode(episode);
            EnsureEpisodesListExists();

            return AddEpisodeOrIgnore(episode);
        }

        public TraktSyncRatingsPostBuilder AddEpisode(TraktEpisode episode, int rating)
        {
            ValidateEpisode(episode);
            ValidateRating(rating);
            EnsureEpisodesListExists();

            return AddEpisodeOrIgnore(episode, rating);
        }

        public TraktSyncRatingsPostBuilder AddEpisode(TraktEpisode episode, int rating, DateTime ratedAt)
        {
            ValidateEpisode(episode);
            ValidateRating(rating);
            EnsureEpisodesListExists();

            return AddEpisodeOrIgnore(episode, rating, ratedAt);
        }

        public TraktSyncRatingsPost Build()
        {
            return _ratingsPost;
        }

        private void ValidateMovie(TraktMovie movie)
        {
            if (movie == null)
                throw new ArgumentNullException(nameof(movie));

            if (movie.Ids == null)
                throw new ArgumentNullException(nameof(movie.Ids));

            if (!movie.Ids.HasAnyId)
                throw new ArgumentException("no movie ids set or valid", nameof(movie.Ids));

            if (movie.Year.HasValue && movie.Year.Value.ToString().Length != 4)
                throw new ArgumentException("movie year not valid", nameof(movie.Year));
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

        private void ValidateEpisode(TraktEpisode episode)
        {
            if (episode == null)
                throw new ArgumentNullException(nameof(episode));

            if (episode.Ids == null)
                throw new ArgumentNullException(nameof(episode.Ids));

            if (!episode.Ids.HasAnyId)
                throw new ArgumentException("no episode ids set or valid", nameof(episode.Ids));
        }

        private void ValidateRating(int rating)
        {
            if (rating < 1 || rating > 10)
                throw new ArgumentOutOfRangeException(nameof(rating));
        }

        private bool ContainsMovie(TraktMovie movie)
        {
            return _ratingsPost.Movies.Where(m => m.Ids == movie.Ids).FirstOrDefault() != null;
        }

        private void EnsureMoviesListExists()
        {
            if (_ratingsPost.Movies == null)
                _ratingsPost.Movies = new List<TraktSyncRatingsPostMovie>();
        }

        private bool ContainsShow(TraktShow show)
        {
            return _ratingsPost.Shows.Where(s => s.Ids == show.Ids).FirstOrDefault() != null;
        }

        private void EnsureShowsListExists()
        {
            if (_ratingsPost.Shows == null)
                _ratingsPost.Shows = new List<TraktSyncRatingsPostShow>();
        }

        private bool ContainsEpisode(TraktEpisode episode)
        {
            return _ratingsPost.Episodes.Where(e => e.Ids == episode.Ids).FirstOrDefault() != null;
        }

        private void EnsureEpisodesListExists()
        {
            if (_ratingsPost.Episodes == null)
                _ratingsPost.Episodes = new List<TraktSyncRatingsPostEpisode>();
        }

        private TraktSyncRatingsPostBuilder AddMovieOrIgnore(TraktMovie movie, int? rating = null, DateTime? ratedAt = null)
        {
            if (ContainsMovie(movie))
                return this;

            var ratingsMovie = new TraktSyncRatingsPostMovie();
            ratingsMovie.Ids = movie.Ids;
            ratingsMovie.Title = movie.Title;
            ratingsMovie.Year = movie.Year;

            if (rating.HasValue)
                ratingsMovie.Rating = rating;

            if (ratedAt.HasValue)
                ratingsMovie.RatedAt = ratedAt.Value.ToUniversalTime();

            (_ratingsPost.Movies as List<TraktSyncRatingsPostMovie>).Add(ratingsMovie);

            return this;
        }

        private TraktSyncRatingsPostBuilder AddShowOrIgnore(TraktShow show, int? rating = null, DateTime? ratedAt = null)
        {
            if (ContainsShow(show))
                return this;

            var ratingsShow = new TraktSyncRatingsPostShow();
            ratingsShow.Ids = show.Ids;
            ratingsShow.Title = show.Title;
            ratingsShow.Year = show.Year;

            if (rating.HasValue)
                ratingsShow.Rating = rating;

            if (ratedAt.HasValue)
                ratingsShow.RatedAt = ratedAt.Value.ToUniversalTime();

            (_ratingsPost.Shows as List<TraktSyncRatingsPostShow>).Add(ratingsShow);

            return this;
        }

        private TraktSyncRatingsPostBuilder AddEpisodeOrIgnore(TraktEpisode episode, int? rating = null, DateTime? ratedAt = null)
        {
            if (ContainsEpisode(episode))
                return this;

            var ratingsEpisode = new TraktSyncRatingsPostEpisode();
            ratingsEpisode.Ids = episode.Ids;

            if (rating.HasValue)
                ratingsEpisode.Rating = rating;

            if (ratedAt.HasValue)
                ratingsEpisode.RatedAt = ratedAt.Value.ToUniversalTime();

            (_ratingsPost.Episodes as List<TraktSyncRatingsPostEpisode>).Add(ratingsEpisode);

            return this;
        }

        private void CreateOrSetShow(TraktShow show, IEnumerable<TraktSyncRatingsPostShowSeason> showSeasons,
                                     int? rating = null, DateTime? ratedAt = null)
        {
            var existingShow = _ratingsPost.Shows.Where(s => s.Ids == show.Ids).FirstOrDefault();

            if (existingShow != null)
                existingShow.Seasons = showSeasons;
            else
            {
                var ratingsShow = new TraktSyncRatingsPostShow();
                ratingsShow.Ids = show.Ids;
                ratingsShow.Title = show.Title;
                ratingsShow.Year = show.Year;

                if (rating.HasValue)
                    ratingsShow.Rating = rating;

                if (ratedAt.HasValue)
                    ratingsShow.RatedAt = ratedAt.Value.ToUniversalTime();

                ratingsShow.Seasons = showSeasons;
                (_ratingsPost.Shows as List<TraktSyncRatingsPostShow>).Add(ratingsShow);
            }
        }

        private IEnumerable<TraktSyncRatingsPostShowSeason> CreateShowSeasons(int season, params int[] seasons)
        {
            var seasonsToAdd = new int[seasons.Length + 1];
            seasonsToAdd[0] = season;
            seasons.CopyTo(seasonsToAdd, 1);

            var showSeasons = new List<TraktSyncRatingsPostShowSeason>();

            for (int i = 0; i < seasonsToAdd.Length; i++)
            {
                if (seasonsToAdd[i] < 0)
                    throw new ArgumentOutOfRangeException("at least one season number not valid");

                showSeasons.Add(new TraktSyncRatingsPostShowSeason { Number = seasonsToAdd[i] });
            }

            return showSeasons;
        }

        private IEnumerable<TraktSyncRatingsPostShowSeason> CreateShowSeasons(PostRatingsSeasons seasons)
        {
            var showSeasons = new List<TraktSyncRatingsPostShowSeason>();

            foreach (var season in seasons)
            {
                if (season.Number < 0)
                    throw new ArgumentOutOfRangeException("at least one season number not valid", nameof(season));

                var showSingleSeason = new TraktSyncRatingsPostShowSeason { Number = season.Number };

                if (season.Rating.HasValue)
                    showSingleSeason.Rating = season.Rating;

                if (season.RatedAt.HasValue)
                    showSingleSeason.RatedAt = season.RatedAt.Value.ToUniversalTime();

                if (season.Episodes != null && season.Episodes.Count() > 0)
                {
                    var showEpisodes = new List<TraktSyncRatingsPostShowEpisode>();

                    foreach (var episode in season.Episodes)
                    {
                        if (episode.Number < 0)
                            throw new ArgumentOutOfRangeException("at least one episode number not valid", nameof(seasons));

                        var showEpisode = new TraktSyncRatingsPostShowEpisode { Number = episode.Number };

                        if (episode.Rating.HasValue)
                            showEpisode.Rating = episode.Rating;

                        if (episode.RatedAt.HasValue)
                            showEpisode.RatedAt = episode.RatedAt.Value.ToUniversalTime();

                        showEpisodes.Add(showEpisode);
                    }

                    showSingleSeason.Episodes = showEpisodes;
                }

                showSeasons.Add(showSingleSeason);
            }

            return showSeasons;
        }
    }
}
