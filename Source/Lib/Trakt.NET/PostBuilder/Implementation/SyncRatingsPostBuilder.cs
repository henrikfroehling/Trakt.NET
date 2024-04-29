namespace TraktNet.PostBuilder
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using TraktNet.Objects.Get.Episodes;
    using TraktNet.Objects.Get.Movies;
    using TraktNet.Objects.Get.Seasons;
    using TraktNet.Objects.Get.Shows;
    using TraktNet.Objects.Post.Syncs.Ratings;

    internal sealed class SyncRatingsPostBuilder : ITraktSyncRatingsPostBuilder
    {
        private readonly Lazy<List<RatingsMovie>> _moviesWithRating;
        private readonly Lazy<List<RatingsMovieIds>> _movieIdsWithRating;
        private readonly Lazy<List<RatingsMovieRatedAt>> _moviesWithRatingRatedAt;
        private readonly Lazy<List<RatingsMovieIdsRatedAt>> _movieIdsWithRatingRatedAt;
        private readonly Lazy<List<RatingsShow>> _showsWithRating;
        private readonly Lazy<List<RatingsShowIds>> _showIdsWithRating;
        private readonly Lazy<List<RatingsShowRatedAt>> _showsWithRatingRatedAt;
        private readonly Lazy<List<RatingsShowIdsRatedAt>> _showIdsWithRatingRatedAt;
        private readonly Lazy<List<RatingsShowAndSeasons>> _showsAndSeasons;
        private readonly Lazy<List<RatingsShowIdsAndSeasons>> _showIdsAndSeasons;
        private readonly Lazy<List<RatingsSeason>> _seasonsWithRating;
        private readonly Lazy<List<RatingsSeasonIds>> _seasonIdsWithRating;
        private readonly Lazy<List<RatingsSeasonRatedAt>> _seasonsWithRatingRatedAt;
        private readonly Lazy<List<RatingsSeasonIdsRatedAt>> _seasonIdsWithRatingRatedAt;
        private readonly Lazy<List<RatingsEpisode>> _episodesWithRating;
        private readonly Lazy<List<RatingsEpisodeIds>> _episodeIdsWithRating;
        private readonly Lazy<List<RatingsEpisodeRatedAt>> _episodesWithRatingRatedAt;
        private readonly Lazy<List<RatingsEpisodeIdsRatedAt>> _episodeIdsWithRatingRatedAt;

        internal SyncRatingsPostBuilder()
        {
            _moviesWithRating = new Lazy<List<RatingsMovie>>();
            _movieIdsWithRating = new Lazy<List<RatingsMovieIds>>();
            _moviesWithRatingRatedAt = new Lazy<List<RatingsMovieRatedAt>>();
            _movieIdsWithRatingRatedAt = new Lazy<List<RatingsMovieIdsRatedAt>>();
            _showsWithRating = new Lazy<List<RatingsShow>>();
            _showIdsWithRating = new Lazy<List<RatingsShowIds>>();
            _showsWithRatingRatedAt = new Lazy<List<RatingsShowRatedAt>>();
            _showIdsWithRatingRatedAt = new Lazy<List<RatingsShowIdsRatedAt>>();
            _showsAndSeasons = new Lazy<List<RatingsShowAndSeasons>>();
            _showIdsAndSeasons = new Lazy<List<RatingsShowIdsAndSeasons>>();
            _seasonsWithRating = new Lazy<List<RatingsSeason>>();
            _seasonIdsWithRating = new Lazy<List<RatingsSeasonIds>>();
            _seasonsWithRatingRatedAt = new Lazy<List<RatingsSeasonRatedAt>>();
            _seasonIdsWithRatingRatedAt = new Lazy<List<RatingsSeasonIdsRatedAt>>();
            _episodesWithRating = new Lazy<List<RatingsEpisode>>();
            _episodeIdsWithRating = new Lazy<List<RatingsEpisodeIds>>();
            _episodesWithRatingRatedAt = new Lazy<List<RatingsEpisodeRatedAt>>();
            _episodeIdsWithRatingRatedAt = new Lazy<List<RatingsEpisodeIdsRatedAt>>();
        }

        public ITraktSyncRatingsPostBuilder WithMovie(ITraktMovie movie, TraktPostRating rating)
        {
            if (movie == null)
                throw new ArgumentNullException(nameof(movie));

            return WithMovie(new RatingsMovie(movie, rating));
        }

        public ITraktSyncRatingsPostBuilder WithMovie(RatingsMovie movieWithRating)
        {
            if (movieWithRating == null)
                throw new ArgumentNullException(nameof(movieWithRating));

            _moviesWithRating.Value.Add(movieWithRating);
            return this;
        }

        public ITraktSyncRatingsPostBuilder WithMovie(ITraktMovieIds movieIds, TraktPostRating rating)
        {
            if (movieIds == null)
                throw new ArgumentNullException(nameof(movieIds));

            return WithMovie(new RatingsMovieIds(movieIds, rating));
        }

        public ITraktSyncRatingsPostBuilder WithMovie(RatingsMovieIds movieIdsWithRating)
        {
            if (movieIdsWithRating == null)
                throw new ArgumentNullException(nameof(movieIdsWithRating));

            _movieIdsWithRating.Value.Add(movieIdsWithRating);
            return this;
        }

        public ITraktSyncRatingsPostBuilder WithMovieRatedAt(ITraktMovie movie, TraktPostRating rating, DateTime ratedAt)
        {
            if (movie == null)
                throw new ArgumentNullException(nameof(movie));

            return WithMovieRatedAt(new RatingsMovieRatedAt(movie, rating, ratedAt));
        }

        public ITraktSyncRatingsPostBuilder WithMovieRatedAt(RatingsMovieRatedAt movieWithRatingRatedAt)
        {
            if (movieWithRatingRatedAt == null)
                throw new ArgumentNullException(nameof(movieWithRatingRatedAt));

            _moviesWithRatingRatedAt.Value.Add(movieWithRatingRatedAt);
            return this;
        }

        public ITraktSyncRatingsPostBuilder WithMovieRatedAt(ITraktMovieIds movieIds, TraktPostRating rating, DateTime ratedAt)
        {
            if (movieIds == null)
                throw new ArgumentNullException(nameof(movieIds));

            return WithMovieRatedAt(new RatingsMovieIdsRatedAt(movieIds, rating, ratedAt));
        }

        public ITraktSyncRatingsPostBuilder WithMovieRatedAt(RatingsMovieIdsRatedAt movieIdsWithRatingsRatedAt)
        {
            if (movieIdsWithRatingsRatedAt == null)
                throw new ArgumentNullException(nameof(movieIdsWithRatingsRatedAt));

            _movieIdsWithRatingRatedAt.Value.Add(movieIdsWithRatingsRatedAt);
            return this;
        }

        public ITraktSyncRatingsPostBuilder WithMovies(IEnumerable<RatingsMovie> moviesWithRating)
        {
            if (moviesWithRating == null)
                throw new ArgumentNullException(nameof(moviesWithRating));

            foreach (RatingsMovie movieWithRating in moviesWithRating)
            {
                if (movieWithRating != null)
                    _moviesWithRating.Value.Add(movieWithRating);
            }

            return this;
        }

        public ITraktSyncRatingsPostBuilder WithMovies(IEnumerable<RatingsMovieIds> movieIdsWithRating)
        {
            if (movieIdsWithRating == null)
                throw new ArgumentNullException(nameof(movieIdsWithRating));

            foreach (RatingsMovieIds movieIdWithRating in movieIdsWithRating)
            {
                if (movieIdWithRating != null)
                    _movieIdsWithRating.Value.Add(movieIdWithRating);
            }

            return this;
        }

        public ITraktSyncRatingsPostBuilder WithMoviesRatedAt(IEnumerable<RatingsMovieRatedAt> moviesWithRatingRatedAt)
        {
            if (moviesWithRatingRatedAt == null)
                throw new ArgumentNullException(nameof(moviesWithRatingRatedAt));

            foreach (RatingsMovieRatedAt movieWithRatingRatedAt in moviesWithRatingRatedAt)
            {
                if (movieWithRatingRatedAt != null)
                    _moviesWithRatingRatedAt.Value.Add(movieWithRatingRatedAt);
            }

            return this;
        }

        public ITraktSyncRatingsPostBuilder WithMoviesRatedAt(IEnumerable<RatingsMovieIdsRatedAt> movieIdsWithRatingRatedAt)
        {
            if (movieIdsWithRatingRatedAt == null)
                throw new ArgumentNullException(nameof(movieIdsWithRatingRatedAt));

            foreach (RatingsMovieIdsRatedAt movieIdWithRatingRatedAt in movieIdsWithRatingRatedAt)
            {
                if (movieIdWithRatingRatedAt != null)
                    _movieIdsWithRatingRatedAt.Value.Add(movieIdWithRatingRatedAt);
            }

            return this;
        }

        public ITraktSyncRatingsPostBuilder WithShow(ITraktShow show, TraktPostRating rating)
        {
            if (show == null)
                throw new ArgumentNullException(nameof(show));

            return WithShow(new RatingsShow(show, rating));
        }

        public ITraktSyncRatingsPostBuilder WithShow(RatingsShow showWitRating)
        {
            if (showWitRating == null)
                throw new ArgumentNullException(nameof(showWitRating));

            _showsWithRating.Value.Add(showWitRating);
            return this;
        }

        public ITraktSyncRatingsPostBuilder WithShow(ITraktShowIds showIds, TraktPostRating rating)
        {
            if (showIds == null)
                throw new ArgumentNullException(nameof(showIds));

            return WithShow(new RatingsShowIds(showIds, rating));
        }

        public ITraktSyncRatingsPostBuilder WithShow(RatingsShowIds showIdsWithRating)
        {
            if (showIdsWithRating == null)
                throw new ArgumentNullException(nameof(showIdsWithRating));

            _showIdsWithRating.Value.Add(showIdsWithRating);
            return this;
        }

        public ITraktSyncRatingsPostBuilder WithShowRatedAt(ITraktShow show, TraktPostRating rating, DateTime ratedAt)
        {
            if (show == null)
                throw new ArgumentNullException(nameof(show));

            return WithShowRatedAt(new RatingsShowRatedAt(show, rating, ratedAt));
        }

        public ITraktSyncRatingsPostBuilder WithShowRatedAt(RatingsShowRatedAt showWithRatingRatedAt)
        {
            if (showWithRatingRatedAt == null)
                throw new ArgumentNullException(nameof(showWithRatingRatedAt));

            _showsWithRatingRatedAt.Value.Add(showWithRatingRatedAt);
            return this;
        }

        public ITraktSyncRatingsPostBuilder WithShowRatedAt(ITraktShowIds showIds, TraktPostRating rating, DateTime ratedAt)
        {
            if (showIds == null)
                throw new ArgumentNullException(nameof(showIds));

            return WithShowRatedAt(new RatingsShowIdsRatedAt(showIds, rating, ratedAt));
        }

        public ITraktSyncRatingsPostBuilder WithShowRatedAt(RatingsShowIdsRatedAt showIdsWithRatingRatedAt)
        {
            if (showIdsWithRatingRatedAt == null)
                throw new ArgumentNullException(nameof(showIdsWithRatingRatedAt));

            _showIdsWithRatingRatedAt.Value.Add(showIdsWithRatingRatedAt);
            return this;
        }

        public ITraktSyncRatingsPostBuilder WithShows(IEnumerable<RatingsShow> showsWithRating)
        {
            if (showsWithRating == null)
                throw new ArgumentNullException(nameof(showsWithRating));

            foreach (RatingsShow showWithRating in showsWithRating)
            {
                if (showWithRating != null)
                    _showsWithRating.Value.Add(showWithRating);
            }

            return this;
        }

        public ITraktSyncRatingsPostBuilder WithShows(IEnumerable<RatingsShowIds> showIdsWithRating)
        {
            if (showIdsWithRating == null)
                throw new ArgumentNullException(nameof(showIdsWithRating));

            foreach (RatingsShowIds showIdWithRating in showIdsWithRating)
            {
                if (showIdWithRating != null)
                    _showIdsWithRating.Value.Add(showIdWithRating);
            }

            return this;
        }

        public ITraktSyncRatingsPostBuilder WithShowsRatedAt(IEnumerable<RatingsShowRatedAt> showsWithRatingRatedAt)
        {
            if (showsWithRatingRatedAt == null)
                throw new ArgumentNullException(nameof(showsWithRatingRatedAt));

            foreach (RatingsShowRatedAt showWithRatingRatedAt in showsWithRatingRatedAt)
            {
                if (showWithRatingRatedAt != null)
                    _showsWithRatingRatedAt.Value.Add(showWithRatingRatedAt);
            }

            return this;
        }

        public ITraktSyncRatingsPostBuilder WithShowsRatedAt(IEnumerable<RatingsShowIdsRatedAt> showIdsWithRatingRatedAt)
        {
            if (showIdsWithRatingRatedAt == null)
                throw new ArgumentNullException(nameof(showIdsWithRatingRatedAt));

            foreach (RatingsShowIdsRatedAt showIdWithRatingRatedAt in showIdsWithRatingRatedAt)
            {
                if (showIdWithRatingRatedAt != null)
                    _showIdsWithRatingRatedAt.Value.Add(showIdWithRatingRatedAt);
            }

            return this;
        }

        public ITraktSyncRatingsPostBuilder WithShowAndSeasons(ITraktShow show, PostRatingsSeasons seasons)
        {
            if (show == null)
                throw new ArgumentNullException(nameof(show));

            if (seasons == null)
                throw new ArgumentNullException(nameof(seasons));

            return WithShowAndSeasons(new RatingsShowAndSeasons(show, seasons));
        }

        public ITraktSyncRatingsPostBuilder WithShowAndSeasons(RatingsShowAndSeasons showAndSeasons)
        {
            if (showAndSeasons == null)
                throw new ArgumentNullException(nameof(showAndSeasons));

            _showsAndSeasons.Value.Add(showAndSeasons);
            return this;
        }

        public ITraktSyncRatingsPostBuilder WithShowAndSeasons(ITraktShowIds showIds, PostRatingsSeasons seasons)
        {
            if (showIds == null)
                throw new ArgumentNullException(nameof(showIds));

            if (seasons == null)
                throw new ArgumentNullException(nameof(seasons));

            return WithShowAndSeasons(new RatingsShowIdsAndSeasons(showIds, seasons));
        }

        public ITraktSyncRatingsPostBuilder WithShowAndSeasons(RatingsShowIdsAndSeasons showIdsAndSeasons)
        {
            if (showIdsAndSeasons == null)
                throw new ArgumentNullException(nameof(showIdsAndSeasons));

            _showIdsAndSeasons.Value.Add(showIdsAndSeasons);
            return this;
        }

        public ITraktSyncRatingsPostBuilder WithShowsAndSeasons(IEnumerable<RatingsShowAndSeasons> showsAndSeasons)
        {
            if (showsAndSeasons == null)
                throw new ArgumentNullException(nameof(showsAndSeasons));

            foreach (RatingsShowAndSeasons showAndSeasons in showsAndSeasons)
            {
                if (showAndSeasons != null)
                    _showsAndSeasons.Value.Add(showAndSeasons);
            }

            return this;
        }

        public ITraktSyncRatingsPostBuilder WithShowsAndSeasons(IEnumerable<RatingsShowIdsAndSeasons> showIdsAndSeasons)
        {
            if (showIdsAndSeasons == null)
                throw new ArgumentNullException(nameof(showIdsAndSeasons));

            foreach (RatingsShowIdsAndSeasons showIdAndSeasons in showIdsAndSeasons)
            {
                if (showIdAndSeasons != null)
                    _showIdsAndSeasons.Value.Add(showIdAndSeasons);
            }

            return this;
        }

        public ITraktSyncRatingsPostBuilder WithSeason(ITraktSeason season, TraktPostRating rating)
        {
            if (season == null)
                throw new ArgumentNullException(nameof(season));

            return WithSeason(new RatingsSeason(season, rating));
        }

        public ITraktSyncRatingsPostBuilder WithSeason(RatingsSeason seasonWithRating)
        {
            if (seasonWithRating == null)
                throw new ArgumentNullException(nameof(seasonWithRating));

            _seasonsWithRating.Value.Add(seasonWithRating);
            return this;
        }

        public ITraktSyncRatingsPostBuilder WithSeason(ITraktSeasonIds seasonIds, TraktPostRating rating)
        {
            if (seasonIds == null)
                throw new ArgumentNullException(nameof(seasonIds));

            return WithSeason(new RatingsSeasonIds(seasonIds, rating));
        }

        public ITraktSyncRatingsPostBuilder WithSeason(RatingsSeasonIds seasonIdsWithRating)
        {
            if (seasonIdsWithRating == null)
                throw new ArgumentNullException(nameof(seasonIdsWithRating));

            _seasonIdsWithRating.Value.Add(seasonIdsWithRating);
            return this;
        }

        public ITraktSyncRatingsPostBuilder WithSeasonRatedAt(ITraktSeason season, TraktPostRating rating, DateTime ratedAt)
        {
            if (season == null)
                throw new ArgumentNullException(nameof(season));

            return WithSeasonRatedAt(new RatingsSeasonRatedAt(season, rating, ratedAt));
        }

        public ITraktSyncRatingsPostBuilder WithSeasonRatedAt(RatingsSeasonRatedAt seasonWithRatingRatedAt)
        {
            if (seasonWithRatingRatedAt == null)
                throw new ArgumentNullException(nameof(seasonWithRatingRatedAt));

            _seasonsWithRatingRatedAt.Value.Add(seasonWithRatingRatedAt);
            return this;
        }

        public ITraktSyncRatingsPostBuilder WithSeasonRatedAt(ITraktSeasonIds seasonIds, TraktPostRating rating, DateTime ratedAt)
        {
            if (seasonIds == null)
                throw new ArgumentNullException(nameof(seasonIds));

            return WithSeasonRatedAt(new RatingsSeasonIdsRatedAt(seasonIds, rating, ratedAt));
        }

        public ITraktSyncRatingsPostBuilder WithSeasonRatedAt(RatingsSeasonIdsRatedAt seasonIdsWithRatingRatedAt)
        {
            if (seasonIdsWithRatingRatedAt == null)
                throw new ArgumentNullException(nameof(seasonIdsWithRatingRatedAt));

            _seasonIdsWithRatingRatedAt.Value.Add(seasonIdsWithRatingRatedAt);
            return this;
        }

        public ITraktSyncRatingsPostBuilder WithSeasons(IEnumerable<RatingsSeason> seasonsWithRating)
        {
            if (seasonsWithRating == null)
                throw new ArgumentNullException(nameof(seasonsWithRating));

            foreach (RatingsSeason seasonWithRating in seasonsWithRating)
            {
                if (seasonWithRating != null)
                    _seasonsWithRating.Value.Add(seasonWithRating);
            }

            return this;
        }

        public ITraktSyncRatingsPostBuilder WithSeasons(IEnumerable<RatingsSeasonIds> seasonIdsWithRating)
        {
            if (seasonIdsWithRating == null)
                throw new ArgumentNullException(nameof(seasonIdsWithRating));

            foreach (RatingsSeasonIds seasonIdWithRating in seasonIdsWithRating)
            {
                if (seasonIdWithRating != null)
                    _seasonIdsWithRating.Value.Add(seasonIdWithRating);
            }

            return this;
        }

        public ITraktSyncRatingsPostBuilder WithSeasonsRatedAt(IEnumerable<RatingsSeasonRatedAt> seasonsWithRatingRatedAt)
        {
            if (seasonsWithRatingRatedAt == null)
                throw new ArgumentNullException(nameof(seasonsWithRatingRatedAt));

            foreach (RatingsSeasonRatedAt seasonWithRatingRatedAt in seasonsWithRatingRatedAt)
            {
                if (seasonWithRatingRatedAt != null)
                    _seasonsWithRatingRatedAt.Value.Add(seasonWithRatingRatedAt);
            }

            return this;
        }

        public ITraktSyncRatingsPostBuilder WithSeasonsRatedAt(IEnumerable<RatingsSeasonIdsRatedAt> seasonIdsWithRatingRatedAt)
        {
            if (seasonIdsWithRatingRatedAt == null)
                throw new ArgumentNullException(nameof(seasonIdsWithRatingRatedAt));

            foreach (RatingsSeasonIdsRatedAt seasonIdWithRatingRatedAt in seasonIdsWithRatingRatedAt)
            {
                if (seasonIdWithRatingRatedAt != null)
                    _seasonIdsWithRatingRatedAt.Value.Add(seasonIdWithRatingRatedAt);
            }

            return this;
        }

        public ITraktSyncRatingsPostBuilder WithEpisode(ITraktEpisode episode, TraktPostRating rating)
        {
            if (episode == null)
                throw new ArgumentNullException(nameof(episode));

            return WithEpisode(new RatingsEpisode(episode, rating));
        }

        public ITraktSyncRatingsPostBuilder WithEpisode(RatingsEpisode episodeWithRating)
        {
            if (episodeWithRating == null)
                throw new ArgumentNullException(nameof(episodeWithRating));

            _episodesWithRating.Value.Add(episodeWithRating);
            return this;
        }

        public ITraktSyncRatingsPostBuilder WithEpisode(ITraktEpisodeIds episodeIds, TraktPostRating rating)
        {
            if (episodeIds == null)
                throw new ArgumentNullException(nameof(episodeIds));

            return WithEpisode(new RatingsEpisodeIds(episodeIds, rating));
        }

        public ITraktSyncRatingsPostBuilder WithEpisode(RatingsEpisodeIds episodeIdsWithRating)
        {
            if (episodeIdsWithRating == null)
                throw new ArgumentNullException(nameof(episodeIdsWithRating));

            _episodeIdsWithRating.Value.Add(episodeIdsWithRating);
            return this;
        }

        public ITraktSyncRatingsPostBuilder WithEpisodeRatedAt(ITraktEpisode episode, TraktPostRating rating, DateTime ratedAt)
        {
            if (episode == null)
                throw new ArgumentNullException(nameof(episode));

            return WithEpisodeRatedAt(new RatingsEpisodeRatedAt(episode, rating, ratedAt));
        }

        public ITraktSyncRatingsPostBuilder WithEpisodeRatedAt(RatingsEpisodeRatedAt episodeWithRatingRatedAt)
        {
            if (episodeWithRatingRatedAt == null)
                throw new ArgumentNullException(nameof(episodeWithRatingRatedAt));

            _episodesWithRatingRatedAt.Value.Add(episodeWithRatingRatedAt);
            return this;
        }

        public ITraktSyncRatingsPostBuilder WithEpisodeRatedAt(ITraktEpisodeIds episodeIds, TraktPostRating rating, DateTime ratedAt)
        {
            if (episodeIds == null)
                throw new ArgumentNullException(nameof(episodeIds));

            return WithEpisodeRatedAt(new RatingsEpisodeIdsRatedAt(episodeIds, rating, ratedAt));
        }

        public ITraktSyncRatingsPostBuilder WithEpisodeRatedAt(RatingsEpisodeIdsRatedAt episodeIdsWithRatingRatedAt)
        {
            if (episodeIdsWithRatingRatedAt == null)
                throw new ArgumentNullException(nameof(episodeIdsWithRatingRatedAt));

            _episodeIdsWithRatingRatedAt.Value.Add(episodeIdsWithRatingRatedAt);
            return this;
        }

        public ITraktSyncRatingsPostBuilder WithEpisodes(IEnumerable<RatingsEpisode> episodesWithRating)
        {
            if (episodesWithRating == null)
                throw new ArgumentNullException(nameof(episodesWithRating));

            foreach (RatingsEpisode episodeWithRating in episodesWithRating)
            {
                if (episodeWithRating != null)
                    _episodesWithRating.Value.Add(episodeWithRating);
            }

            return this;
        }

        public ITraktSyncRatingsPostBuilder WithEpisodes(IEnumerable<RatingsEpisodeIds> episodeIdsWithRating)
        {
            if (episodeIdsWithRating == null)
                throw new ArgumentNullException(nameof(episodeIdsWithRating));

            foreach (RatingsEpisodeIds episodeIdWithRating in episodeIdsWithRating)
            {
                if (episodeIdWithRating != null)
                    _episodeIdsWithRating.Value.Add(episodeIdWithRating);
            }

            return this;
        }

        public ITraktSyncRatingsPostBuilder WithEpisodesRatedAt(IEnumerable<RatingsEpisodeRatedAt> episodesWithRatingRatedAt)
        {
            if (episodesWithRatingRatedAt == null)
                throw new ArgumentNullException(nameof(episodesWithRatingRatedAt));

            foreach (RatingsEpisodeRatedAt episodeWithRatingRatedAt in episodesWithRatingRatedAt)
            {
                if (episodeWithRatingRatedAt != null)
                    _episodesWithRatingRatedAt.Value.Add(episodeWithRatingRatedAt);
            }

            return this;
        }

        public ITraktSyncRatingsPostBuilder WithEpisodesRatedAt(IEnumerable<RatingsEpisodeIdsRatedAt> episodeIdsWithRatingRatedAt)
        {
            if (episodeIdsWithRatingRatedAt == null)
                throw new ArgumentNullException(nameof(episodeIdsWithRatingRatedAt));

            foreach (RatingsEpisodeIdsRatedAt episodeIdWithRatingRatedAt in episodeIdsWithRatingRatedAt)
            {
                if (episodeIdWithRatingRatedAt != null)
                    _episodeIdsWithRatingRatedAt.Value.Add(episodeIdWithRatingRatedAt);
            }

            return this;
        }

        public ITraktSyncRatingsPost Build()
        {
            ITraktSyncRatingsPost syncRatingsPost = new TraktSyncRatingsPost();
            AddMovies(syncRatingsPost);
            AddShows(syncRatingsPost);
            AddSeasons(syncRatingsPost);
            AddEpisodes(syncRatingsPost);
            syncRatingsPost.Validate();
            return syncRatingsPost;
        }

        private void AddMovies(ITraktSyncRatingsPost syncRatingsPost)
        {
            if (!_moviesWithRating.IsValueCreated && !_movieIdsWithRating.IsValueCreated
                && !_moviesWithRatingRatedAt.IsValueCreated && !_movieIdsWithRatingRatedAt.IsValueCreated)
            {
                return;
            }

            syncRatingsPost.Movies ??= new List<ITraktSyncRatingsPostMovie>();

            if (_moviesWithRating.IsValueCreated && _moviesWithRating.Value.Any())
            {
                foreach (RatingsMovie ratingsMovie in _moviesWithRating.Value)
                    syncRatingsPost.Movies.Add(CreateRatingsPostMovie(ratingsMovie.Object, ratingsMovie.Rating));
            }

            if (_movieIdsWithRating.IsValueCreated && _movieIdsWithRating.Value.Any())
            {
                foreach (RatingsMovieIds ratingsMovieIds in _movieIdsWithRating.Value)
                    syncRatingsPost.Movies.Add(CreateRatingsPostMovie(ratingsMovieIds.Object, ratingsMovieIds.Rating));
            }

            if (_moviesWithRatingRatedAt.IsValueCreated && _moviesWithRatingRatedAt.Value.Any())
            {
                foreach (RatingsMovieRatedAt ratingsMovieRatedAt in _moviesWithRatingRatedAt.Value)
                {
                    syncRatingsPost.Movies
                        .Add(CreateRatingsPostMovie(ratingsMovieRatedAt.Object, ratingsMovieRatedAt.Rating, ratingsMovieRatedAt.RatedAt));
                }
            }

            if (_movieIdsWithRatingRatedAt.IsValueCreated && _movieIdsWithRatingRatedAt.Value.Any())
            {
                foreach (RatingsMovieIdsRatedAt ratingsMovieIdsRatedAt in _movieIdsWithRatingRatedAt.Value)
                {
                    syncRatingsPost.Movies
                        .Add(CreateRatingsPostMovie(ratingsMovieIdsRatedAt.Object, ratingsMovieIdsRatedAt.Rating, ratingsMovieIdsRatedAt.RatedAt));
                }
            }
        }

        private void AddShows(ITraktSyncRatingsPost syncRatingsPost)
        {
            if (!_showsWithRating.IsValueCreated && !_showIdsWithRating.IsValueCreated && !_showsWithRatingRatedAt.IsValueCreated
                && !_showIdsWithRatingRatedAt.IsValueCreated && !_showsAndSeasons.IsValueCreated && !_showIdsAndSeasons.IsValueCreated)
            {
                return;
            }

            syncRatingsPost.Shows ??= new List<ITraktSyncRatingsPostShow>();

            if (_showsWithRating.IsValueCreated && _showsWithRating.Value.Any())
            {
                foreach (RatingsShow ratingsShow in _showsWithRating.Value)
                    syncRatingsPost.Shows.Add(CreateRatingsPostShow(ratingsShow.Object, ratingsShow.Rating));
            }

            if (_showIdsWithRating.IsValueCreated && _showIdsWithRating.Value.Any())
            {
                foreach (RatingsShowIds ratingsShowIds in _showIdsWithRating.Value)
                    syncRatingsPost.Shows.Add(CreateRatingsPostShow(ratingsShowIds.Object, ratingsShowIds.Rating));
            }

            if (_showsWithRatingRatedAt.IsValueCreated && _showsWithRatingRatedAt.Value.Any())
            {
                foreach (RatingsShowRatedAt ratingsShowRatedAt in _showsWithRatingRatedAt.Value)
                {
                    syncRatingsPost.Shows
                        .Add(CreateRatingsPostShow(ratingsShowRatedAt.Object, ratingsShowRatedAt.Rating, ratingsShowRatedAt.RatedAt));
                }
            }

            if (_showIdsWithRatingRatedAt.IsValueCreated && _showIdsWithRatingRatedAt.Value.Any())
            {
                foreach (RatingsShowIdsRatedAt ratingsShowIdsRatedAt in _showIdsWithRatingRatedAt.Value)
                {
                    syncRatingsPost.Shows
                        .Add(CreateRatingsPostShow(ratingsShowIdsRatedAt.Object, ratingsShowIdsRatedAt.Rating, ratingsShowIdsRatedAt.RatedAt));
                }
            }

            if (_showsAndSeasons.IsValueCreated && _showsAndSeasons.Value.Any())
                CreateRatingsPostShowAndSeasons(syncRatingsPost, _showsAndSeasons.Value);

            if (_showIdsAndSeasons.IsValueCreated && _showIdsAndSeasons.Value.Any())
                CreateRatingsPostShowIdsAndSeasons(syncRatingsPost, _showIdsAndSeasons.Value);
        }

        private void AddSeasons(ITraktSyncRatingsPost syncRatingsPost)
        {
            if (!_seasonsWithRating.IsValueCreated && !_seasonIdsWithRating.IsValueCreated
                && !_seasonsWithRatingRatedAt.IsValueCreated && !_seasonIdsWithRatingRatedAt.IsValueCreated)
            {
                return;
            }

            syncRatingsPost.Seasons ??= new List<ITraktSyncRatingsPostSeason>();

            if (_seasonsWithRating.IsValueCreated && _seasonsWithRating.Value.Any())
            {
                foreach (RatingsSeason ratingsSeason in _seasonsWithRating.Value)
                    syncRatingsPost.Seasons.Add(CreateRatingsPostSeason(ratingsSeason.Object, ratingsSeason.Rating));
            }

            if (_seasonIdsWithRating.IsValueCreated && _seasonIdsWithRating.Value.Any())
            {
                foreach (RatingsSeasonIds ratingsSeasonIds in _seasonIdsWithRating.Value)
                    syncRatingsPost.Seasons.Add(CreateRatingsPostSeason(ratingsSeasonIds.Object, ratingsSeasonIds.Rating));
            }

            if (_seasonsWithRatingRatedAt.IsValueCreated && _seasonsWithRatingRatedAt.Value.Any())
            {
                foreach (RatingsSeasonRatedAt ratingsSeasonatedAt in _seasonsWithRatingRatedAt.Value)
                {
                    syncRatingsPost.Seasons
                        .Add(CreateRatingsPostSeason(ratingsSeasonatedAt.Object, ratingsSeasonatedAt.Rating, ratingsSeasonatedAt.RatedAt));
                }
            }

            if (_seasonIdsWithRatingRatedAt.IsValueCreated && _seasonIdsWithRatingRatedAt.Value.Any())
            {
                foreach (RatingsSeasonIdsRatedAt ratingsSeasonIdsRatedAt in _seasonIdsWithRatingRatedAt.Value)
                {
                    syncRatingsPost.Seasons
                        .Add(CreateRatingsPostSeason(ratingsSeasonIdsRatedAt.Object, ratingsSeasonIdsRatedAt.Rating, ratingsSeasonIdsRatedAt.RatedAt));
                }
            }
        }

        private void AddEpisodes(ITraktSyncRatingsPost syncRatingsPost)
        {
            if (!_episodesWithRating.IsValueCreated && !_episodeIdsWithRating.IsValueCreated
                && !_episodesWithRatingRatedAt.IsValueCreated && !_episodeIdsWithRatingRatedAt.IsValueCreated)
            {
                return;
            }

            syncRatingsPost.Episodes ??= new List<ITraktSyncRatingsPostEpisode>();

            if (_episodesWithRating.IsValueCreated && _episodesWithRating.Value.Any())
            {
                foreach (RatingsEpisode ratingsEpisode in _episodesWithRating.Value)
                    syncRatingsPost.Episodes.Add(CreateRatingsPostEpisode(ratingsEpisode.Object, ratingsEpisode.Rating));
            }

            if (_episodeIdsWithRating.IsValueCreated && _episodeIdsWithRating.Value.Any())
            {
                foreach (RatingsEpisodeIds ratingsEpisodeIds in _episodeIdsWithRating.Value)
                    syncRatingsPost.Episodes.Add(CreateRatingsPostEpisode(ratingsEpisodeIds.Object, ratingsEpisodeIds.Rating));
            }

            if (_episodesWithRatingRatedAt.IsValueCreated && _episodesWithRatingRatedAt.Value.Any())
            {
                foreach (RatingsEpisodeRatedAt ratingsEpisodeRatedAt in _episodesWithRatingRatedAt.Value)
                {
                    syncRatingsPost.Episodes
                        .Add(CreateRatingsPostEpisode(ratingsEpisodeRatedAt.Object, ratingsEpisodeRatedAt.Rating, ratingsEpisodeRatedAt.RatedAt));
                }
            }

            if (_episodeIdsWithRatingRatedAt.IsValueCreated && _episodeIdsWithRatingRatedAt.Value.Any())
            {
                foreach (RatingsEpisodeIdsRatedAt ratingsEpisodeIdsRatedAt in _episodeIdsWithRatingRatedAt.Value)
                {
                    syncRatingsPost.Episodes
                        .Add(CreateRatingsPostEpisode(ratingsEpisodeIdsRatedAt.Object, ratingsEpisodeIdsRatedAt.Rating, ratingsEpisodeIdsRatedAt.RatedAt));
                }
            }
        }

        private static ITraktSyncRatingsPostMovie CreateRatingsPostMovie(ITraktMovie movie, TraktPostRating rating, DateTime? ratedAt = null)
        {
            ITraktSyncRatingsPostMovie syncRatingsPostMovie = new TraktSyncRatingsPostMovie
            {
                Ids = movie.Ids,
                Title = movie.Title,
                Year = movie.Year,
                Rating = (int)rating
            };

            if (ratedAt.HasValue)
                syncRatingsPostMovie.RatedAt = ratedAt.Value;

            return syncRatingsPostMovie;
        }

        private static ITraktSyncRatingsPostMovie CreateRatingsPostMovie(ITraktMovieIds movieIds, TraktPostRating rating, DateTime? ratedAt = null)
        {
            ITraktSyncRatingsPostMovie syncRatingsPostMovie = new TraktSyncRatingsPostMovie
            {
                Ids = movieIds,
                Rating = (int)rating
            };

            if (ratedAt.HasValue)
                syncRatingsPostMovie.RatedAt = ratedAt.Value;

            return syncRatingsPostMovie;
        }

        private static ITraktSyncRatingsPostShow CreateRatingsPostShow(ITraktShow show, TraktPostRating? rating = null, DateTime? ratedAt = null)
        {
            ITraktSyncRatingsPostShow syncRatingsPostShow = new TraktSyncRatingsPostShow
            {
                Ids = show.Ids,
                Title = show.Title,
                Year = show.Year
            };

            if (rating.HasValue)
                syncRatingsPostShow.Rating = (int)rating.Value;

            if (ratedAt.HasValue)
                syncRatingsPostShow.RatedAt = ratedAt.Value;

            return syncRatingsPostShow;
        }

        private static ITraktSyncRatingsPostShow CreateRatingsPostShow(ITraktShowIds showIds, TraktPostRating? rating = null, DateTime? ratedAt = null)
        {
            ITraktSyncRatingsPostShow syncRatingsPostShow = new TraktSyncRatingsPostShow
            {
                Ids = showIds
            };

            if (rating.HasValue)
                syncRatingsPostShow.Rating = (int)rating.Value;

            if (ratedAt.HasValue)
                syncRatingsPostShow.RatedAt = ratedAt.Value;

            return syncRatingsPostShow;
        }

        private static void CreateRatingsPostShowAndSeasons(ITraktSyncRatingsPost syncRatingsPost, List<RatingsShowAndSeasons> showsAndSeasons)
        {
            foreach (RatingsShowAndSeasons showAndSeasons in showsAndSeasons)
            {
                ITraktSyncRatingsPostShow syncRatingsPostShow = CreateRatingsPostShow(showAndSeasons.Object);
                CreateRatingsPostShowSeasons(syncRatingsPost, showAndSeasons.Seasons, syncRatingsPostShow);
            }
        }

        private static void CreateRatingsPostShowIdsAndSeasons(ITraktSyncRatingsPost syncRatingsPost, List<RatingsShowIdsAndSeasons> showIdsAndSeasons)
        {
            foreach (RatingsShowIdsAndSeasons showIdAndSeasons in showIdsAndSeasons)
            {
                ITraktSyncRatingsPostShow syncRatingsPostShow = CreateRatingsPostShow(showIdAndSeasons.Object);
                CreateRatingsPostShowSeasons(syncRatingsPost, showIdAndSeasons.Seasons, syncRatingsPostShow);
            }
        }

        private static void CreateRatingsPostShowSeasons(ITraktSyncRatingsPost syncRatingsPost, PostRatingsSeasons seasons, ITraktSyncRatingsPostShow syncRatingsPostShow)
        {
            if (seasons.Any())
            {
                syncRatingsPostShow.Seasons = new List<ITraktSyncRatingsPostShowSeason>();

                foreach (PostRatingsSeason season in seasons)
                {
                    ITraktSyncRatingsPostShowSeason syncRatingsPostShowSeason = CreateRatingsPostShowSeason(season);

                    if (season.Episodes != null && season.Episodes.Any())
                    {
                        syncRatingsPostShowSeason.Episodes = new List<ITraktSyncRatingsPostShowEpisode>();

                        foreach (PostRatingsEpisode episode in season.Episodes)
                            syncRatingsPostShowSeason.Episodes.Add(CreateRatingsPostShowEpisode(episode));
                    }

                    syncRatingsPostShow.Seasons.Add(syncRatingsPostShowSeason);
                }
            }

            syncRatingsPost.Shows.Add(syncRatingsPostShow);
        }

        private static ITraktSyncRatingsPostShowSeason CreateRatingsPostShowSeason(PostRatingsSeason season)
        {
            ITraktSyncRatingsPostShowSeason syncRatingsPostShowSeason = new TraktSyncRatingsPostShowSeason
            {
                Number = season.Number
            };

            if (season.Rating.HasValue)
                syncRatingsPostShowSeason.Rating = (int?)season.Rating.Value;

            if (season.RatedAt.HasValue)
                syncRatingsPostShowSeason.RatedAt = season.RatedAt.Value;

            return syncRatingsPostShowSeason;
        }

        private static ITraktSyncRatingsPostShowEpisode CreateRatingsPostShowEpisode(PostRatingsEpisode episode)
        {
            var syncRatingsPostShowEpisode = new TraktSyncRatingsPostShowEpisode
            {
                Number = episode.Number,
                Rating = (int)episode.Rating
            };

            if (episode.RatedAt.HasValue)
                syncRatingsPostShowEpisode.RatedAt = episode.RatedAt.Value;

            return syncRatingsPostShowEpisode;
        }

        private static ITraktSyncRatingsPostSeason CreateRatingsPostSeason(ITraktSeason season, TraktPostRating rating, DateTime? ratedAt = null)
        {
            ITraktSyncRatingsPostSeason syncRatingsPostSeason = new TraktSyncRatingsPostSeason
            {
                Ids = season.Ids,
                Rating = (int)rating
            };

            if (ratedAt.HasValue)
                syncRatingsPostSeason.RatedAt = ratedAt.Value;

            return syncRatingsPostSeason;
        }

        private static ITraktSyncRatingsPostSeason CreateRatingsPostSeason(ITraktSeasonIds seasonIds, TraktPostRating rating, DateTime? ratedAt = null)
        {
            ITraktSyncRatingsPostSeason syncRatingsPostSeason = new TraktSyncRatingsPostSeason
            {
                Ids = seasonIds,
                Rating = (int)rating
            };

            if (ratedAt.HasValue)
                syncRatingsPostSeason.RatedAt = ratedAt.Value;

            return syncRatingsPostSeason;
        }

        private static ITraktSyncRatingsPostEpisode CreateRatingsPostEpisode(ITraktEpisode episode, TraktPostRating rating, DateTime? ratedAt = null)
        {
            ITraktSyncRatingsPostEpisode syncRatingsPostEpisode = new TraktSyncRatingsPostEpisode
            {
                Ids = episode.Ids,
                Rating = (int)rating
            };

            if (ratedAt.HasValue)
                syncRatingsPostEpisode.RatedAt = ratedAt.Value;

            return syncRatingsPostEpisode;
        }

        private static ITraktSyncRatingsPostEpisode CreateRatingsPostEpisode(ITraktEpisodeIds episodeIds, TraktPostRating rating, DateTime? ratedAt = null)
        {
            ITraktSyncRatingsPostEpisode syncRatingsPostEpisode = new TraktSyncRatingsPostEpisode
            {
                Ids = episodeIds,
                Rating = (int)rating
            };

            if (ratedAt.HasValue)
                syncRatingsPostEpisode.RatedAt = ratedAt.Value;

            return syncRatingsPostEpisode;
        }
    }
}
