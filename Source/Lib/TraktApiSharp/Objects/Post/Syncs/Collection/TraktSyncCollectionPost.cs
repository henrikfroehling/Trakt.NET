namespace TraktApiSharp.Objects.Post.Syncs.Collection
{
    using Basic;
    using Get.Movies;
    using Get.Shows;
    using Get.Shows.Episodes;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class TraktSyncCollectionPost
    {
        [JsonProperty(PropertyName = "movies")]
        public IEnumerable<TraktSyncCollectionPostMovie> Movies { get; set; }

        [JsonProperty(PropertyName = "shows")]
        public IEnumerable<TraktSyncCollectionPostShow> Shows { get; set; }

        [JsonProperty(PropertyName = "episodes")]
        public IEnumerable<TraktSyncCollectionPostEpisode> Episodes { get; set; }

        public static TraktSyncCollectionPostBuilder Builder() => new TraktSyncCollectionPostBuilder();
    }

    public class TraktSyncCollectionPostBuilder
    {
        private TraktSyncCollectionPost _collectionPost;

        public TraktSyncCollectionPostBuilder()
        {
            _collectionPost = new TraktSyncCollectionPost();
        }

        public TraktSyncCollectionPostBuilder AddMovie(TraktMovie movie)
        {
            ValidateMovie(movie);
            EnsureMoviesListExists();

            return AddMovieOrIgnore(movie);
        }

        public TraktSyncCollectionPostBuilder AddMovie(TraktMovie movie, DateTime collectedAt)
        {
            ValidateMovie(movie);
            EnsureMoviesListExists();

            return AddMovieOrIgnore(movie, null, collectedAt);
        }

        public TraktSyncCollectionPostBuilder AddMovie(TraktMovie movie, TraktMetadata metadata)
        {
            ValidateMovie(movie);
            EnsureMoviesListExists();

            return AddMovieOrIgnore(movie, metadata);
        }

        public TraktSyncCollectionPostBuilder AddMovie(TraktMovie movie, TraktMetadata metadata, DateTime collectedAt)
        {
            ValidateMovie(movie);
            EnsureMoviesListExists();

            return AddMovieOrIgnore(movie, metadata, collectedAt);
        }

        public TraktSyncCollectionPostBuilder AddShow(TraktShow show)
        {
            ValidateShow(show);
            EnsureShowsListExists();

            return AddShowOrIgnore(show);
        }

        public TraktSyncCollectionPostBuilder AddShow(TraktShow show, DateTime collectedAt)
        {
            ValidateShow(show);
            EnsureShowsListExists();

            return AddShowOrIgnore(show, null, collectedAt);
        }

        public TraktSyncCollectionPostBuilder AddShow(TraktShow show, TraktMetadata metadata)
        {
            ValidateShow(show);
            EnsureShowsListExists();

            return AddShowOrIgnore(show, metadata);
        }

        public TraktSyncCollectionPostBuilder AddShow(TraktShow show, TraktMetadata metadata, DateTime collectedAt)
        {
            ValidateShow(show);
            EnsureShowsListExists();

            return AddShowOrIgnore(show, metadata, collectedAt);
        }

        public TraktSyncCollectionPostBuilder AddShow(TraktShow show, int season, params int[] seasons)
        {
            ValidateShow(show);
            EnsureShowsListExists();

            var showSeasons = CreateShowSeasons(season, seasons);
            CreateOrSetShow(show, showSeasons);

            return this;
        }

        public TraktSyncCollectionPostBuilder AddShow(TraktShow show, DateTime collectedAt, int season, params int[] seasons)
        {
            ValidateShow(show);
            EnsureShowsListExists();

            var showSeasons = CreateShowSeasons(season, seasons);
            CreateOrSetShow(show, showSeasons, null, collectedAt);

            return this;
        }

        public TraktSyncCollectionPostBuilder AddShow(TraktShow show, TraktMetadata metadata, int season, params int[] seasons)
        {
            ValidateShow(show);
            EnsureShowsListExists();

            var showSeasons = CreateShowSeasons(season, seasons);
            CreateOrSetShow(show, showSeasons, metadata);

            return this;
        }

        public TraktSyncCollectionPostBuilder AddShow(TraktShow show, TraktMetadata metadata, DateTime collectedAt, int season, params int[] seasons)
        {
            ValidateShow(show);
            EnsureShowsListExists();

            var showSeasons = CreateShowSeasons(season, seasons);
            CreateOrSetShow(show, showSeasons, metadata, collectedAt);

            return this;
        }

        public TraktSyncCollectionPostBuilder AddShow(TraktShow show, PostSeasons seasons)
        {
            ValidateShow(show);

            if (seasons == null)
                throw new ArgumentNullException(nameof(seasons));

            EnsureShowsListExists();

            var showSeasons = CreateShowSeasons(seasons);
            CreateOrSetShow(show, showSeasons);

            return this;
        }

        public TraktSyncCollectionPostBuilder AddShow(TraktShow show, DateTime collectedAt, PostSeasons seasons)
        {
            ValidateShow(show);

            if (seasons == null)
                throw new ArgumentNullException(nameof(seasons));

            EnsureShowsListExists();

            var showSeasons = CreateShowSeasons(seasons);
            CreateOrSetShow(show, showSeasons, null, collectedAt);

            return this;
        }

        public TraktSyncCollectionPostBuilder AddShow(TraktShow show, TraktMetadata metadata, PostSeasons seasons)
        {
            ValidateShow(show);

            if (seasons == null)
                throw new ArgumentNullException(nameof(seasons));

            EnsureShowsListExists();

            var showSeasons = CreateShowSeasons(seasons);
            CreateOrSetShow(show, showSeasons, metadata);

            return this;
        }

        public TraktSyncCollectionPostBuilder AddShow(TraktShow show, TraktMetadata metadata, DateTime collectedAt, PostSeasons seasons)
        {
            ValidateShow(show);

            if (seasons == null)
                throw new ArgumentNullException(nameof(seasons));

            EnsureShowsListExists();

            var showSeasons = CreateShowSeasons(seasons);
            CreateOrSetShow(show, showSeasons, metadata, collectedAt);

            return this;
        }

        public TraktSyncCollectionPostBuilder AddEpisode(TraktEpisode episode)
        {
            ValidateEpisode(episode);
            EnsureEpisodesListExists();

            return AddEpisodeOrIgnore(episode);
        }

        public TraktSyncCollectionPostBuilder AddEpisode(TraktEpisode episode, DateTime collectedAt)
        {
            ValidateEpisode(episode);
            EnsureEpisodesListExists();

            return AddEpisodeOrIgnore(episode, null, collectedAt);
        }

        public TraktSyncCollectionPostBuilder AddEpisode(TraktEpisode episode, TraktMetadata metadata)
        {
            ValidateEpisode(episode);
            EnsureEpisodesListExists();

            return AddEpisodeOrIgnore(episode, metadata);
        }

        public TraktSyncCollectionPostBuilder AddEpisode(TraktEpisode episode, TraktMetadata metadata, DateTime collectedAt)
        {
            ValidateEpisode(episode);
            EnsureEpisodesListExists();

            return AddEpisodeOrIgnore(episode, metadata, collectedAt);
        }

        public TraktSyncCollectionPost Build()
        {
            var movies = _collectionPost.Movies;
            var shows = _collectionPost.Shows;
            var episodes = _collectionPost.Episodes;

            var bHasNoMovies = movies == null || !movies.Any();
            var bHasNoShows = shows == null || !shows.Any();
            var bHasNoEpisodes = episodes == null || !episodes.Any();

            if (bHasNoMovies && bHasNoShows && bHasNoEpisodes)
                throw new ArgumentException("no collection items set");

            return _collectionPost;
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

        private bool ContainsMovie(TraktMovie movie)
        {
            return _collectionPost.Movies.Where(m => m.Ids == movie.Ids).FirstOrDefault() != null;
        }

        private void EnsureMoviesListExists()
        {
            if (_collectionPost.Movies == null)
                _collectionPost.Movies = new List<TraktSyncCollectionPostMovie>();
        }

        private bool ContainsShow(TraktShow show)
        {
            return _collectionPost.Shows.Where(s => s.Ids == show.Ids).FirstOrDefault() != null;
        }

        private void EnsureShowsListExists()
        {
            if (_collectionPost.Shows == null)
                _collectionPost.Shows = new List<TraktSyncCollectionPostShow>();
        }

        private bool ContainsEpisode(TraktEpisode episode)
        {
            return _collectionPost.Episodes.Where(e => e.Ids == episode.Ids).FirstOrDefault() != null;
        }

        private void EnsureEpisodesListExists()
        {
            if (_collectionPost.Episodes == null)
                _collectionPost.Episodes = new List<TraktSyncCollectionPostEpisode>();
        }

        private TraktSyncCollectionPostBuilder AddMovieOrIgnore(TraktMovie movie, TraktMetadata metadata = null,
                                                                DateTime? collectedAt = null)
        {
            if (ContainsMovie(movie))
                return this;

            var collectionMovie = new TraktSyncCollectionPostMovie();
            collectionMovie.Ids = movie.Ids;
            collectionMovie.Title = movie.Title;
            collectionMovie.Year = movie.Year;

            if (metadata != null)
                collectionMovie.Metadata = metadata;

            if (collectedAt.HasValue)
                collectionMovie.CollectedAt = collectedAt.Value.ToUniversalTime();

            (_collectionPost.Movies as List<TraktSyncCollectionPostMovie>).Add(collectionMovie);

            return this;
        }

        private TraktSyncCollectionPostBuilder AddShowOrIgnore(TraktShow show, TraktMetadata metadata = null,
                                                               DateTime? collectedAt = null)
        {
            if (ContainsShow(show))
                return this;

            var collectionShow = new TraktSyncCollectionPostShow();
            collectionShow.Ids = show.Ids;
            collectionShow.Title = show.Title;
            collectionShow.Year = show.Year;

            if (metadata != null)
                collectionShow.Metadata = metadata;

            if (collectedAt.HasValue)
                collectionShow.CollectedAt = collectedAt.Value.ToUniversalTime();

            (_collectionPost.Shows as List<TraktSyncCollectionPostShow>).Add(collectionShow);

            return this;
        }

        private TraktSyncCollectionPostBuilder AddEpisodeOrIgnore(TraktEpisode episode, TraktMetadata metadata = null,
                                                                  DateTime? collectedAt = null)
        {
            if (ContainsEpisode(episode))
                return this;

            var collectionEpisode = new TraktSyncCollectionPostEpisode();
            collectionEpisode.Ids = episode.Ids;

            if (metadata != null)
                collectionEpisode.Metadata = metadata;

            if (collectedAt.HasValue)
                collectionEpisode.CollectedAt = collectedAt.Value.ToUniversalTime();

            (_collectionPost.Episodes as List<TraktSyncCollectionPostEpisode>).Add(collectionEpisode);

            return this;
        }

        private void CreateOrSetShow(TraktShow show, IEnumerable<TraktSyncCollectionPostShowSeason> showSeasons,
                                     TraktMetadata metadata = null, DateTime? collectedAt = null)
        {
            var existingShow = _collectionPost.Shows.Where(s => s.Ids == show.Ids).FirstOrDefault();

            if (existingShow != null)
                existingShow.Seasons = showSeasons;
            else
            {
                var collectionShow = new TraktSyncCollectionPostShow();
                collectionShow.Ids = show.Ids;
                collectionShow.Title = show.Title;
                collectionShow.Year = show.Year;

                if (metadata != null)
                    collectionShow.Metadata = metadata;

                if (collectedAt.HasValue)
                    collectionShow.CollectedAt = collectedAt.Value.ToUniversalTime();

                collectionShow.Seasons = showSeasons;
                (_collectionPost.Shows as List<TraktSyncCollectionPostShow>).Add(collectionShow);
            }
        }

        private IEnumerable<TraktSyncCollectionPostShowSeason> CreateShowSeasons(int season, params int[] seasons)
        {
            var seasonsToAdd = new int[seasons.Length + 1];
            seasonsToAdd[0] = season;
            seasons.CopyTo(seasonsToAdd, 1);

            var showSeasons = new List<TraktSyncCollectionPostShowSeason>();

            for (int i = 0; i < seasonsToAdd.Length; i++)
            {
                if (seasonsToAdd[i] < 0)
                    throw new ArgumentOutOfRangeException("at least one season number not valid");

                showSeasons.Add(new TraktSyncCollectionPostShowSeason { Number = seasonsToAdd[i] });
            }

            return showSeasons;
        }

        private IEnumerable<TraktSyncCollectionPostShowSeason> CreateShowSeasons(PostSeasons seasons)
        {
            var showSeasons = new List<TraktSyncCollectionPostShowSeason>();

            foreach (var season in seasons)
            {
                if (season.Number < 0)
                    throw new ArgumentOutOfRangeException("at least one season number not valid", nameof(season));

                var showSingleSeason = new TraktSyncCollectionPostShowSeason { Number = season.Number };

                if (season.Episodes != null && season.Episodes.Count() > 0)
                {
                    var showEpisodes = new List<TraktSyncCollectionPostShowEpisode>();

                    foreach (var episode in season.Episodes)
                    {
                        if (episode < 0)
                            throw new ArgumentOutOfRangeException("at least one season number not valid", nameof(seasons));

                        showEpisodes.Add(new TraktSyncCollectionPostShowEpisode { Number = episode });
                    }

                    showSingleSeason.Episodes = showEpisodes;
                }

                showSeasons.Add(showSingleSeason);
            }

            return showSeasons;
        }
    }
}
