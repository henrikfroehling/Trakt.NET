namespace TraktNet.PostBuilder
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using TraktNet.Objects.Get.Episodes;
    using TraktNet.Objects.Get.Movies;
    using TraktNet.Objects.Get.Seasons;
    using TraktNet.Objects.Get.Shows;
    using TraktNet.Objects.Post.Syncs.Watchlist;

    internal sealed class SyncWatchlistPostBuilder : ITraktSyncWatchlistPostBuilder
    {
        private readonly Lazy<List<ITraktMovie>> _movies;
        private readonly Lazy<List<ITraktMovieIds>> _movieIds;
        private readonly Lazy<List<MovieWithNotes>> _moviesWithNotes;
        private readonly Lazy<List<MovieIdsWithNotes>> _movieIdsWithNotes;
        private readonly Lazy<List<ITraktShow>> _shows;
        private readonly Lazy<List<ITraktShowIds>> _showIds;
        private readonly Lazy<List<ShowWithNotes>> _showsWithNotes;
        private readonly Lazy<List<ShowIdsWithNotes>> _showIdsWithNotes;
        private readonly Lazy<List<ShowAndSeasons>> _showsAndSeasons;
        private readonly Lazy<List<ShowIdsAndSeasons>> _showIdsAndSeasons;
        private readonly Lazy<List<ShowWithNotesAndSeasons>> _showsWithNotesAndSeasons;
        private readonly Lazy<List<ShowIdsWithNotesAndSeasons>> _showIdsWithNotesAndSeasons;
        private readonly Lazy<List<ITraktSeason>> _seasons;
        private readonly Lazy<List<ITraktSeasonIds>> _seasonIds;
        private readonly Lazy<List<SeasonWithNotes>> _seasonsWithNotes;
        private readonly Lazy<List<SeasonIdsWithNotes>> _seasonIdsWithNotes;
        private readonly Lazy<List<ITraktEpisode>> _episodes;
        private readonly Lazy<List<ITraktEpisodeIds>> _episodeIds;
        private readonly Lazy<List<EpisodeWithNotes>> _episodesWithNotes;
        private readonly Lazy<List<EpisodeIdsWithNotes>> _episodeIdsWithNotes;

        internal SyncWatchlistPostBuilder()
        {
            _movies = new Lazy<List<ITraktMovie>>();
            _movieIds = new Lazy<List<ITraktMovieIds>>();
            _moviesWithNotes = new Lazy<List<MovieWithNotes>>();
            _movieIdsWithNotes = new Lazy<List<MovieIdsWithNotes>>();
            _shows = new Lazy<List<ITraktShow>>();
            _showIds = new Lazy<List<ITraktShowIds>>();
            _showsWithNotes = new Lazy<List<ShowWithNotes>>();
            _showIdsWithNotes = new Lazy<List<ShowIdsWithNotes>>();
            _showsAndSeasons = new Lazy<List<ShowAndSeasons>>();
            _showIdsAndSeasons = new Lazy<List<ShowIdsAndSeasons>>();
            _showsWithNotesAndSeasons = new Lazy<List<ShowWithNotesAndSeasons>>();
            _showIdsWithNotesAndSeasons = new Lazy<List<ShowIdsWithNotesAndSeasons>>();
            _seasons = new Lazy<List<ITraktSeason>>();
            _seasonIds = new Lazy<List<ITraktSeasonIds>>();
            _seasonsWithNotes = new Lazy<List<SeasonWithNotes>>();
            _seasonIdsWithNotes = new Lazy<List<SeasonIdsWithNotes>>();
            _episodes = new Lazy<List<ITraktEpisode>>();
            _episodeIds = new Lazy<List<ITraktEpisodeIds>>();
            _episodesWithNotes = new Lazy<List<EpisodeWithNotes>>();
            _episodeIdsWithNotes = new Lazy<List<EpisodeIdsWithNotes>>();
        }

        public ITraktSyncWatchlistPostBuilder WithMovie(ITraktMovie movie)
        {
            if (movie == null)
                throw new ArgumentNullException(nameof(movie));

            _movies.Value.Add(movie);
            return this;
        }

        public ITraktSyncWatchlistPostBuilder WithMovie(ITraktMovieIds movieIds)
        {
            if (movieIds == null)
                throw new ArgumentNullException(nameof(movieIds));

            _movieIds.Value.Add(movieIds);
            return this;
        }

        public ITraktSyncWatchlistPostBuilder WithMovieWithNotes(ITraktMovie movie, string notes)
        {
            if (movie == null)
                throw new ArgumentNullException(nameof(movie));

            CheckNotes(notes);
            return WithMovieWithNotes(new MovieWithNotes(movie, notes));
        }

        public ITraktSyncWatchlistPostBuilder WithMovieWithNotes(MovieWithNotes movieWithNotes)
        {
            if (movieWithNotes == null)
                throw new ArgumentNullException(nameof(movieWithNotes));

            CheckNotes(movieWithNotes.Notes);
            _moviesWithNotes.Value.Add(movieWithNotes);
            return this;
        }

        public ITraktSyncWatchlistPostBuilder WithMovieWithNotes(ITraktMovieIds movieIds, string notes)
        {
            if (movieIds == null)
                throw new ArgumentNullException(nameof(movieIds));

            CheckNotes(notes);
            return WithMovieWithNotes(new MovieIdsWithNotes(movieIds, notes));
        }

        public ITraktSyncWatchlistPostBuilder WithMovieWithNotes(MovieIdsWithNotes movieIdsWithNotes)
        {
            if (movieIdsWithNotes == null)
                throw new ArgumentNullException(nameof(movieIdsWithNotes));

            CheckNotes(movieIdsWithNotes.Notes);
            _movieIdsWithNotes.Value.Add(movieIdsWithNotes);
            return this;
        }

        public ITraktSyncWatchlistPostBuilder WithMovies(IEnumerable<ITraktMovie> movies)
        {
            if (movies == null)
                throw new ArgumentNullException(nameof(movies));

            foreach (ITraktMovie movie in movies)
            {
                if (movie != null)
                    _movies.Value.Add(movie);
            }

            return this;
        }

        public ITraktSyncWatchlistPostBuilder WithMovies(IEnumerable<ITraktMovieIds> movieIds)
        {
            if (movieIds == null)
                throw new ArgumentNullException(nameof(movieIds));

            foreach (ITraktMovieIds movieId in movieIds)
            {
                if (movieId != null)
                    _movieIds.Value.Add(movieId);
            }

            return this;
        }

        public ITraktSyncWatchlistPostBuilder WithMoviesWithNotes(IEnumerable<MovieWithNotes> moviesWithNotes)
        {
            if (moviesWithNotes == null)
                throw new ArgumentNullException(nameof(moviesWithNotes));

            foreach (MovieWithNotes movieWithNotes in moviesWithNotes)
            {
                if (movieWithNotes != null)
                {
                    CheckNotes(movieWithNotes.Notes);
                    _moviesWithNotes.Value.Add(movieWithNotes);
                }
            }

            return this;
        }

        public ITraktSyncWatchlistPostBuilder WithMoviesWithNotes(IEnumerable<MovieIdsWithNotes> movieIdsWithNotes)
        {
            if (movieIdsWithNotes == null)
                throw new ArgumentNullException(nameof(movieIdsWithNotes));

            foreach (MovieIdsWithNotes movieIdWithNotes in movieIdsWithNotes)
            {
                if (movieIdWithNotes != null)
                {
                    CheckNotes(movieIdWithNotes.Notes);
                    _movieIdsWithNotes.Value.Add(movieIdWithNotes);
                }
            }

            return this;
        }

        public ITraktSyncWatchlistPostBuilder WithShow(ITraktShow show)
        {
            if (show == null)
                throw new ArgumentNullException(nameof(show));

            _shows.Value.Add(show);
            return this;
        }

        public ITraktSyncWatchlistPostBuilder WithShow(ITraktShowIds showIds)
        {
            if (showIds == null)
                throw new ArgumentNullException(nameof(showIds));

            _showIds.Value.Add(showIds);
            return this;
        }

        public ITraktSyncWatchlistPostBuilder WithShowWithNotes(ITraktShow show, string notes)
        {
            if (show == null)
                throw new ArgumentNullException(nameof(show));

            CheckNotes(notes);
            return WithShowWithNotes(new ShowWithNotes(show, notes));
        }

        public ITraktSyncWatchlistPostBuilder WithShowWithNotes(ShowWithNotes showWithNotes)
        {
            if (showWithNotes == null)
                throw new ArgumentNullException(nameof(showWithNotes));

            CheckNotes(showWithNotes.Notes);
            _showsWithNotes.Value.Add(showWithNotes);
            return this;
        }

        public ITraktSyncWatchlistPostBuilder WithShowWithNotes(ITraktShowIds showIds, string notes)
        {
            if (showIds == null)
                throw new ArgumentNullException(nameof(showIds));

            CheckNotes(notes);
            return WithShowWithNotes(new ShowIdsWithNotes(showIds, notes));
        }

        public ITraktSyncWatchlistPostBuilder WithShowWithNotes(ShowIdsWithNotes showIdsWithNotes)
        {
            if (showIdsWithNotes == null)
                throw new ArgumentNullException(nameof(showIdsWithNotes));

            CheckNotes(showIdsWithNotes.Notes);
            _showIdsWithNotes.Value.Add(showIdsWithNotes);
            return this;
        }

        public ITraktSyncWatchlistPostBuilder WithShows(IEnumerable<ITraktShow> shows)
        {
            if (shows == null)
                throw new ArgumentNullException(nameof(shows));

            foreach (ITraktShow show in shows)
            {
                if (show != null)
                    _shows.Value.Add(show);
            }

            return this;
        }

        public ITraktSyncWatchlistPostBuilder WithShows(IEnumerable<ITraktShowIds> showIds)
        {
            if (showIds == null)
                throw new ArgumentNullException(nameof(showIds));

            foreach (ITraktShowIds showId in showIds)
            {
                if (showId != null)
                    _showIds.Value.Add(showId);
            }

            return this;
        }

        public ITraktSyncWatchlistPostBuilder WithShowsWithNotes(IEnumerable<ShowWithNotes> showsWithNotes)
        {
            if (showsWithNotes == null)
                throw new ArgumentNullException(nameof(showsWithNotes));

            foreach (ShowWithNotes showWithNotes in showsWithNotes)
            {
                if (showWithNotes != null)
                {
                    CheckNotes(showWithNotes.Notes);
                    _showsWithNotes.Value.Add(showWithNotes);
                }
            }

            return this;
        }

        public ITraktSyncWatchlistPostBuilder WithShowsWithNotes(IEnumerable<ShowIdsWithNotes> showIdsWithNotes)
        {
            if (showIdsWithNotes == null)
                throw new ArgumentNullException(nameof(showIdsWithNotes));

            foreach (ShowIdsWithNotes showIdWithNotes in showIdsWithNotes)
            {
                if (showIdWithNotes != null)
                {
                    CheckNotes(showIdWithNotes.Notes);
                    _showIdsWithNotes.Value.Add(showIdWithNotes);
                }
            }

            return this;
        }

        public ITraktSyncWatchlistPostBuilder WithShowAndSeasons(ITraktShow show, PostSeasons seasons)
        {
            if (show == null)
                throw new ArgumentNullException(nameof(show));

            if (seasons == null)
                throw new ArgumentNullException(nameof(seasons));

            return WithShowAndSeasons(new ShowAndSeasons(show, seasons));
        }

        public ITraktSyncWatchlistPostBuilder WithShowAndSeasons(ShowAndSeasons showAndSeasons)
        {
            if (showAndSeasons == null)
                throw new ArgumentNullException(nameof(showAndSeasons));

            _showsAndSeasons.Value.Add(showAndSeasons);
            return this;
        }

        public ITraktSyncWatchlistPostBuilder WithShowAndSeasons(ITraktShowIds showIds, PostSeasons seasons)
        {
            if (showIds == null)
                throw new ArgumentNullException(nameof(showIds));

            if (seasons == null)
                throw new ArgumentNullException(nameof(seasons));

            return WithShowAndSeasons(new ShowIdsAndSeasons(showIds, seasons));
        }

        public ITraktSyncWatchlistPostBuilder WithShowAndSeasons(ShowIdsAndSeasons showIdsAndSeasons)
        {
            if (showIdsAndSeasons == null)
                throw new ArgumentNullException(nameof(showIdsAndSeasons));

            _showIdsAndSeasons.Value.Add(showIdsAndSeasons);
            return this;
        }

        public ITraktSyncWatchlistPostBuilder WithShowWithNotesAndSeasons(ShowWithNotesAndSeasons showWithNotesAndSeasons)
        {
            if (showWithNotesAndSeasons == null)
                throw new ArgumentNullException(nameof(showWithNotesAndSeasons));

            CheckNotes(showWithNotesAndSeasons.Object.Notes);
            _showsWithNotesAndSeasons.Value.Add(showWithNotesAndSeasons);
            return this;
        }

        public ITraktSyncWatchlistPostBuilder WithShowWithNotesAndSeasons(ShowIdsWithNotesAndSeasons showIdsWithNotesAndSeasons)
        {
            if (showIdsWithNotesAndSeasons == null)
                throw new ArgumentNullException(nameof(showIdsWithNotesAndSeasons));

            CheckNotes(showIdsWithNotesAndSeasons.Object.Notes);
            _showIdsWithNotesAndSeasons.Value.Add(showIdsWithNotesAndSeasons);
            return this;
        }

        public ITraktSyncWatchlistPostBuilder WithShowsAndSeasons(IEnumerable<ShowAndSeasons> showsAndSeasons)
        {
            if (showsAndSeasons == null)
                throw new ArgumentNullException(nameof(showsAndSeasons));

            foreach (ShowAndSeasons showAndSeasons in showsAndSeasons)
            {
                if (showAndSeasons != null)
                    _showsAndSeasons.Value.Add(showAndSeasons);
            }

            return this;
        }

        public ITraktSyncWatchlistPostBuilder WithShowsAndSeasons(IEnumerable<ShowIdsAndSeasons> showIdsAndSeasons)
        {
            if (showIdsAndSeasons == null)
                throw new ArgumentNullException(nameof(showIdsAndSeasons));

            foreach (ShowIdsAndSeasons showIdAndSeasons in showIdsAndSeasons)
            {
                if (showIdAndSeasons != null)
                    _showIdsAndSeasons.Value.Add(showIdAndSeasons);
            }

            return this;
        }

        public ITraktSyncWatchlistPostBuilder WithShowsWithNotesAndSeasons(IEnumerable<ShowWithNotesAndSeasons> showsWithNotesAndSeasons)
        {
            if (showsWithNotesAndSeasons == null)
                throw new ArgumentNullException(nameof(showsWithNotesAndSeasons));

            foreach (ShowWithNotesAndSeasons showWithNotesAndSeasons in showsWithNotesAndSeasons)
            {
                if (showWithNotesAndSeasons != null)
                {
                    CheckNotes(showWithNotesAndSeasons.Object.Notes);
                    _showsWithNotesAndSeasons.Value.Add(showWithNotesAndSeasons);
                }
            }

            return this;
        }

        public ITraktSyncWatchlistPostBuilder WithShowsWithNotesAndSeasons(IEnumerable<ShowIdsWithNotesAndSeasons> showIdsWithNotesAndSeasons)
        {
            if (showIdsWithNotesAndSeasons == null)
                throw new ArgumentNullException(nameof(showIdsWithNotesAndSeasons));

            foreach (ShowIdsWithNotesAndSeasons showIdWithNotesAndSeasons in showIdsWithNotesAndSeasons)
            {
                if (showIdWithNotesAndSeasons != null)
                {
                    CheckNotes(showIdWithNotesAndSeasons.Object.Notes);
                    _showIdsWithNotesAndSeasons.Value.Add(showIdWithNotesAndSeasons);
                }
            }

            return this;
        }

        public ITraktSyncWatchlistPostBuilder WithSeason(ITraktSeason season)
        {
            if (season == null)
                throw new ArgumentNullException(nameof(season));

            _seasons.Value.Add(season);
            return this;
        }

        public ITraktSyncWatchlistPostBuilder WithSeason(ITraktSeasonIds seasonIds)
        {
            if (seasonIds == null)
                throw new ArgumentNullException(nameof(seasonIds));

            _seasonIds.Value.Add(seasonIds);
            return this;
        }

        public ITraktSyncWatchlistPostBuilder WithSeasonWithNotes(ITraktSeason season, string notes)
        {
            if (season == null)
                throw new ArgumentNullException(nameof(season));

            CheckNotes(notes);
            return WithSeasonWithNotes(new SeasonWithNotes(season, notes));
        }

        public ITraktSyncWatchlistPostBuilder WithSeasonWithNotes(SeasonWithNotes seasonWithNotes)
        {
            if (seasonWithNotes == null)
                throw new ArgumentNullException(nameof(seasonWithNotes));

            CheckNotes(seasonWithNotes.Notes);
            _seasonsWithNotes.Value.Add(seasonWithNotes);
            return this;
        }

        public ITraktSyncWatchlistPostBuilder WithSeasonWithNotes(ITraktSeasonIds seasonIds, string notes)
        {
            if (seasonIds == null)
                throw new ArgumentNullException(nameof(seasonIds));

            CheckNotes(notes);
            return WithSeasonWithNotes(new SeasonIdsWithNotes(seasonIds, notes));
        }

        public ITraktSyncWatchlistPostBuilder WithSeasonWithNotes(SeasonIdsWithNotes seasonIdsWithNotes)
        {
            if (seasonIdsWithNotes == null)
                throw new ArgumentNullException(nameof(seasonIdsWithNotes));

            CheckNotes(seasonIdsWithNotes.Notes);
            _seasonIdsWithNotes.Value.Add(seasonIdsWithNotes);
            return this;
        }

        public ITraktSyncWatchlistPostBuilder WithSeasons(IEnumerable<ITraktSeason> seasons)
        {
            if (seasons == null)
                throw new ArgumentNullException(nameof(seasons));

            foreach (ITraktSeason season in seasons)
            {
                if (season != null)
                    _seasons.Value.Add(season);
            }

            return this;
        }

        public ITraktSyncWatchlistPostBuilder WithSeasons(IEnumerable<ITraktSeasonIds> seasonIds)
        {
            if (seasonIds == null)
                throw new ArgumentNullException(nameof(seasonIds));

            foreach (ITraktSeasonIds seasonId in seasonIds)
            {
                if (seasonId != null)
                    _seasonIds.Value.Add(seasonId);
            }

            return this;
        }

        public ITraktSyncWatchlistPostBuilder WithSeasonsWithNotes(IEnumerable<SeasonWithNotes> seasonsWithNotes)
        {
            if (seasonsWithNotes == null)
                throw new ArgumentNullException(nameof(seasonsWithNotes));

            foreach (SeasonWithNotes seasonWithNotes in seasonsWithNotes)
            {
                if (seasonWithNotes != null)
                {
                    CheckNotes(seasonWithNotes.Notes);
                    _seasonsWithNotes.Value.Add(seasonWithNotes);
                }
            }

            return this;
        }

        public ITraktSyncWatchlistPostBuilder WithSeasonsWithNotes(IEnumerable<SeasonIdsWithNotes> seasonIdsWithNotes)
        {
            if (seasonIdsWithNotes == null)
                throw new ArgumentNullException(nameof(seasonIdsWithNotes));

            foreach (SeasonIdsWithNotes seasonIdWithNotes in seasonIdsWithNotes)
            {
                if (seasonIdWithNotes != null)
                {
                    CheckNotes(seasonIdWithNotes.Notes);
                    _seasonIdsWithNotes.Value.Add(seasonIdWithNotes);
                }
            }

            return this;
        }

        public ITraktSyncWatchlistPostBuilder WithEpisode(ITraktEpisode episode)
        {
            if (episode == null)
                throw new ArgumentNullException(nameof(episode));

            _episodes.Value.Add(episode);
            return this;
        }

        public ITraktSyncWatchlistPostBuilder WithEpisode(ITraktEpisodeIds episodeIds)
        {
            if (episodeIds == null)
                throw new ArgumentNullException(nameof(episodeIds));

            _episodeIds.Value.Add(episodeIds);
            return this;
        }

        public ITraktSyncWatchlistPostBuilder WithEpisodeWithNotes(ITraktEpisode episode, string notes)
        {
            if (episode == null)
                throw new ArgumentNullException(nameof(episode));

            CheckNotes(notes);
            return WithEpisodeWithNotes(new EpisodeWithNotes(episode, notes));
        }

        public ITraktSyncWatchlistPostBuilder WithEpisodeWithNotes(EpisodeWithNotes episodeWithNotes)
        {
            if (episodeWithNotes == null)
                throw new ArgumentNullException(nameof(episodeWithNotes));

            CheckNotes(episodeWithNotes.Notes);
            _episodesWithNotes.Value.Add(episodeWithNotes);
            return this;
        }

        public ITraktSyncWatchlistPostBuilder WithEpisodeWithNotes(ITraktEpisodeIds episodeIds, string notes)
        {
            if (episodeIds == null)
                throw new ArgumentNullException(nameof(episodeIds));

            CheckNotes(notes);
            return WithEpisodeWithNotes(new EpisodeIdsWithNotes(episodeIds, notes));
        }

        public ITraktSyncWatchlistPostBuilder WithEpisodeWithNotes(EpisodeIdsWithNotes episodeIdsWithNotes)
        {
            if (episodeIdsWithNotes == null)
                throw new ArgumentNullException(nameof(episodeIdsWithNotes));

            CheckNotes(episodeIdsWithNotes.Notes);
            _episodeIdsWithNotes.Value.Add(episodeIdsWithNotes);
            return this;
        }

        public ITraktSyncWatchlistPostBuilder WithEpisodes(IEnumerable<ITraktEpisode> episodes)
        {
            if (episodes == null)
                throw new ArgumentNullException(nameof(episodes));

            foreach (ITraktEpisode episode in episodes)
            {
                if (episode != null)
                    _episodes.Value.Add(episode);
            }

            return this;
        }

        public ITraktSyncWatchlistPostBuilder WithEpisodes(IEnumerable<ITraktEpisodeIds> episodeIds)
        {
            if (episodeIds == null)
                throw new ArgumentNullException(nameof(episodeIds));

            foreach (ITraktEpisodeIds episodeId in episodeIds)
            {
                if (episodeId != null)
                    _episodeIds.Value.Add(episodeId);
            }

            return this;
        }

        public ITraktSyncWatchlistPostBuilder WithEpisodesWithNotes(IEnumerable<EpisodeWithNotes> episodesWithNotes)
        {
            if (episodesWithNotes == null)
                throw new ArgumentNullException(nameof(episodesWithNotes));

            foreach (EpisodeWithNotes episodeWithNotes in episodesWithNotes)
            {
                if (episodeWithNotes != null)
                {
                    CheckNotes(episodeWithNotes.Notes);
                    _episodesWithNotes.Value.Add(episodeWithNotes);
                }
            }

            return this;
        }

        public ITraktSyncWatchlistPostBuilder WithEpisodesWithNotes(IEnumerable<EpisodeIdsWithNotes> episodeIdsWithNotes)
        {
            if (episodeIdsWithNotes == null)
                throw new ArgumentNullException(nameof(episodeIdsWithNotes));

            foreach (EpisodeIdsWithNotes episodeIdWithNotes in episodeIdsWithNotes)
            {
                if (episodeIdWithNotes != null)
                {
                    CheckNotes(episodeIdWithNotes.Notes);
                    _episodeIdsWithNotes.Value.Add(episodeIdWithNotes);
                }
            }

            return this;
        }

        public ITraktSyncWatchlistPost Build()
        {
            ITraktSyncWatchlistPost syncWatchlistPost = new TraktSyncWatchlistPost();
            AddMovies(syncWatchlistPost);
            AddShows(syncWatchlistPost);
            AddSeasons(syncWatchlistPost);
            AddEpisodes(syncWatchlistPost);
            syncWatchlistPost.Validate();
            return syncWatchlistPost;
        }

        private void AddMovies(ITraktSyncWatchlistPost syncWatchlistPost)
        {
            if (!_movies.IsValueCreated && !_movieIds.IsValueCreated
                && !_moviesWithNotes.IsValueCreated && !_movieIdsWithNotes.IsValueCreated)
            {
                return;
            }

            syncWatchlistPost.Movies ??= new List<ITraktSyncWatchlistPostMovie>();

            if (_movies.IsValueCreated && _movies.Value.Any())
            {
                foreach (ITraktMovie movie in _movies.Value)
                {
                    (syncWatchlistPost.Movies as List<ITraktSyncWatchlistPostMovie>)
                        .Add(CreateWatchlistPostMovie(movie));
                }
            }

            if (_movieIds.IsValueCreated && _movieIds.Value.Any())
            {
                foreach (ITraktMovieIds movieIds in _movieIds.Value)
                {
                    (syncWatchlistPost.Movies as List<ITraktSyncWatchlistPostMovie>)
                        .Add(CreateWatchlistPostMovie(movieIds));
                }
            }

            if (_moviesWithNotes.IsValueCreated && _moviesWithNotes.Value.Any())
            {
                foreach (MovieWithNotes movieWithNotes in _moviesWithNotes.Value)
                {
                    (syncWatchlistPost.Movies as List<ITraktSyncWatchlistPostMovie>)
                        .Add(CreateWatchlistPostMovie(movieWithNotes.Object, movieWithNotes.Notes));
                }
            }

            if (_movieIdsWithNotes.IsValueCreated && _movieIdsWithNotes.Value.Any())
            {
                foreach (MovieIdsWithNotes movieIdsWithNotes in _movieIdsWithNotes.Value)
                {
                    (syncWatchlistPost.Movies as List<ITraktSyncWatchlistPostMovie>)
                        .Add(CreateWatchlistPostMovie(movieIdsWithNotes.Object, movieIdsWithNotes.Notes));
                }
            }
        }

        private void AddShows(ITraktSyncWatchlistPost syncWatchlistPost)
        {
            if (!_shows.IsValueCreated && !_showIds.IsValueCreated
                && !_showsWithNotes.IsValueCreated && !_showIdsWithNotes.IsValueCreated
                && !_showsAndSeasons.IsValueCreated && !_showIdsAndSeasons.IsValueCreated
                && !_showsWithNotesAndSeasons.IsValueCreated && !_showIdsWithNotesAndSeasons.IsValueCreated)
            {
                return;
            }

            syncWatchlistPost.Shows ??= new List<ITraktSyncWatchlistPostShow>();

            if (_shows.IsValueCreated && _shows.Value.Any())
            {
                foreach (ITraktShow show in _shows.Value)
                {
                    (syncWatchlistPost.Shows as List<ITraktSyncWatchlistPostShow>)
                        .Add(CreateWatchlistPostShow(show));
                }
            }

            if (_showIds.IsValueCreated && _showIds.Value.Any())
            {
                foreach (ITraktShowIds showIds in _showIds.Value)
                {
                    (syncWatchlistPost.Shows as List<ITraktSyncWatchlistPostShow>)
                        .Add(CreateWatchlistPostShow(showIds));
                }
            }

            if (_showsWithNotes.IsValueCreated && _showsWithNotes.Value.Any())
            {
                foreach (ShowWithNotes showWithNotes in _showsWithNotes.Value)
                {
                    (syncWatchlistPost.Shows as List<ITraktSyncWatchlistPostShow>)
                        .Add(CreateWatchlistPostShow(showWithNotes.Object, showWithNotes.Notes));
                }
            }

            if (_showIdsWithNotes.IsValueCreated && _showIdsWithNotes.Value.Any())
            {
                foreach (ShowIdsWithNotes showIdsWithNotes in _showIdsWithNotes.Value)
                {
                    (syncWatchlistPost.Shows as List<ITraktSyncWatchlistPostShow>)
                        .Add(CreateWatchlistPostShow(showIdsWithNotes.Object, showIdsWithNotes.Notes));
                }
            }

            if (_showsAndSeasons.IsValueCreated && _showsAndSeasons.Value.Any())
                CreateWatchlistPostShowAndSeasons(syncWatchlistPost, _showsAndSeasons.Value);

            if (_showIdsAndSeasons.IsValueCreated && _showIdsAndSeasons.Value.Any())
                CreateWatchlistPostShowIdsAndSeasons(syncWatchlistPost, _showIdsAndSeasons.Value);

            if (_showsWithNotesAndSeasons.IsValueCreated && _showsWithNotesAndSeasons.Value.Any())
                CreateWatchlistPostShowAndSeasons(syncWatchlistPost, _showsWithNotesAndSeasons.Value);

            if (_showIdsWithNotesAndSeasons.IsValueCreated && _showIdsWithNotesAndSeasons.Value.Any())
                CreateWatchlistPostShowIdsAndSeasons(syncWatchlistPost, _showIdsWithNotesAndSeasons.Value);
        }

        private void AddSeasons(ITraktSyncWatchlistPost syncWatchlistPost)
        {
            // TODO
        }

        private void AddEpisodes(ITraktSyncWatchlistPost syncWatchlistPost)
        {
            if (!_episodes.IsValueCreated && !_episodeIds.IsValueCreated
                && !_episodesWithNotes.IsValueCreated && !_episodeIdsWithNotes.IsValueCreated)
            {
                return;
            }

            syncWatchlistPost.Episodes ??= new List<ITraktSyncWatchlistPostEpisode>();

            if (_episodes.IsValueCreated && _episodes.Value.Any())
            {
                foreach (ITraktEpisode episode in _episodes.Value)
                {
                    (syncWatchlistPost.Episodes as List<ITraktSyncWatchlistPostEpisode>)
                        .Add(CreateWatchlistPostEpisode(episode));
                }
            }

            if (_episodeIds.IsValueCreated && _episodeIds.Value.Any())
            {
                foreach (ITraktEpisodeIds episodeIds in _episodeIds.Value)
                {
                    (syncWatchlistPost.Episodes as List<ITraktSyncWatchlistPostEpisode>)
                        .Add(CreateWatchlistPostEpisode(episodeIds));
                }
            }

            if (_episodesWithNotes.IsValueCreated && _episodesWithNotes.Value.Any())
            {
                foreach (EpisodeWithNotes episodeWithNotes in _episodesWithNotes.Value)
                {
                    (syncWatchlistPost.Episodes as List<ITraktSyncWatchlistPostEpisode>)
                        .Add(CreateWatchlistPostEpisode(episodeWithNotes.Object, episodeWithNotes.Notes));
                }
            }

            if (_episodeIdsWithNotes.IsValueCreated && _episodeIdsWithNotes.Value.Any())
            {
                foreach (EpisodeIdsWithNotes episodeIdsWithNotes in _episodeIdsWithNotes.Value)
                {
                    (syncWatchlistPost.Episodes as List<ITraktSyncWatchlistPostEpisode>)
                        .Add(CreateWatchlistPostEpisode(episodeIdsWithNotes.Object, episodeIdsWithNotes.Notes));
                }
            }
        }

        private static ITraktSyncWatchlistPostMovie CreateWatchlistPostMovie(ITraktMovie movie, string notes = null)
        {
            ITraktSyncWatchlistPostMovie syncWatchlistPostMovie = new TraktSyncWatchlistPostMovie
            {
                Ids = movie.Ids,
                Title = movie.Title,
                Year = movie.Year
            };

            if (!string.IsNullOrEmpty(notes))
                syncWatchlistPostMovie.Notes = notes;

            return syncWatchlistPostMovie;
        }

        private static ITraktSyncWatchlistPostMovie CreateWatchlistPostMovie(ITraktMovieIds movieIds, string notes = null)
        {
            ITraktSyncWatchlistPostMovie syncWatchlistPostMovie = new TraktSyncWatchlistPostMovie
            {
                Ids = movieIds
            };

            if (!string.IsNullOrEmpty(notes))
                syncWatchlistPostMovie.Notes = notes;

            return syncWatchlistPostMovie;
        }

        private static ITraktSyncWatchlistPostShow CreateWatchlistPostShow(ITraktShow show, string notes = null)
        {
            ITraktSyncWatchlistPostShow syncWatchlistPostShow = new TraktSyncWatchlistPostShow
            {
                Ids = show.Ids,
                Title = show.Title,
                Year = show.Year
            };

            if (!string.IsNullOrEmpty(notes))
                syncWatchlistPostShow.Notes = notes;

            return syncWatchlistPostShow;
        }

        private static ITraktSyncWatchlistPostShow CreateWatchlistPostShow(ITraktShowIds showIds, string notes = null)
        {
            ITraktSyncWatchlistPostShow syncWatchlistPostShow = new TraktSyncWatchlistPostShow
            {
                Ids = showIds
            };

            if (!string.IsNullOrEmpty(notes))
                syncWatchlistPostShow.Notes = notes;

            return syncWatchlistPostShow;
        }

        private static void CreateWatchlistPostShowAndSeasons(ITraktSyncWatchlistPost syncWatchlistPost, List<ShowWithNotesAndSeasons> showsWithNotesAndSeasons)
        {
            foreach (ShowWithNotesAndSeasons showWithNotesAndSeasons in showsWithNotesAndSeasons)
            {
                ITraktSyncWatchlistPostShow syncWatchlistPostShow =
                    CreateWatchlistPostShow(showWithNotesAndSeasons.Object.Object, showWithNotesAndSeasons.Object.Notes);

                CreateWatchlistPostShowSeasons(syncWatchlistPost, showWithNotesAndSeasons.Seasons, syncWatchlistPostShow);
            }
        }

        private static void CreateWatchlistPostShowIdsAndSeasons(ITraktSyncWatchlistPost syncWatchlistPost, List<ShowIdsWithNotesAndSeasons> showIdsWithNotesAndSeasons)
        {
            foreach (ShowIdsWithNotesAndSeasons showIdWithNotesAndSeasons in showIdsWithNotesAndSeasons)
            {
                ITraktSyncWatchlistPostShow syncWatchlistPostShow =
                    CreateWatchlistPostShow(showIdWithNotesAndSeasons.Object.Object, showIdWithNotesAndSeasons.Object.Notes);

                CreateWatchlistPostShowSeasons(syncWatchlistPost, showIdWithNotesAndSeasons.Seasons, syncWatchlistPostShow);
            }
        }

        private static void CreateWatchlistPostShowAndSeasons(ITraktSyncWatchlistPost syncWatchlistPost, List<ShowAndSeasons> showsAndSeasons)
        {
            foreach (ShowAndSeasons showAndSeasons in showsAndSeasons)
            {
                ITraktSyncWatchlistPostShow syncWatchlistPostShow = CreateWatchlistPostShow(showAndSeasons.Object);
                CreateWatchlistPostShowSeasons(syncWatchlistPost, showAndSeasons.Seasons, syncWatchlistPostShow);
            }
        }

        private static void CreateWatchlistPostShowIdsAndSeasons(ITraktSyncWatchlistPost syncWatchlistPost, List<ShowIdsAndSeasons> showIdsAndSeasons)
        {
            foreach (ShowIdsAndSeasons showIdAndSeasons in showIdsAndSeasons)
            {
                ITraktSyncWatchlistPostShow syncWatchlistPostShow = CreateWatchlistPostShow(showIdAndSeasons.Object);
                CreateWatchlistPostShowSeasons(syncWatchlistPost, showIdAndSeasons.Seasons, syncWatchlistPostShow);
            }
        }

        private static void CreateWatchlistPostShowSeasons(ITraktSyncWatchlistPost syncWatchlistPost, PostSeasons seasons, ITraktSyncWatchlistPostShow syncWatchlistPostShow)
        {
            if (seasons.Any())
            {
                syncWatchlistPostShow.Seasons = new List<ITraktSyncWatchlistPostShowSeason>();

                foreach (PostSeason season in seasons)
                {
                    ITraktSyncWatchlistPostShowSeason syncWatchlistPostShowSeason = CreateWatchlistPostShowSeason(season);

                    if (season.Episodes != null && season.Episodes.Any())
                    {
                        syncWatchlistPostShowSeason.Episodes = new List<ITraktSyncWatchlistPostShowEpisode>();

                        foreach (PostEpisode episode in season.Episodes)
                        {
                            (syncWatchlistPostShowSeason.Episodes as List<ITraktSyncWatchlistPostShowEpisode>)
                                .Add(CreateWatchlistPostShowEpisode(episode));
                        }
                    }

                    (syncWatchlistPostShow.Seasons as List<ITraktSyncWatchlistPostShowSeason>).Add(syncWatchlistPostShowSeason);
                }
            }

            (syncWatchlistPost.Shows as List<ITraktSyncWatchlistPostShow>).Add(syncWatchlistPostShow);
        }

        private static ITraktSyncWatchlistPostShowSeason CreateWatchlistPostShowSeason(PostSeason season)
            => new TraktSyncWatchlistPostShowSeason { Number = season.Number };

        private static ITraktSyncWatchlistPostShowEpisode CreateWatchlistPostShowEpisode(PostEpisode episode)
            => new TraktSyncWatchlistPostShowEpisode { Number = episode.Number };

        private static ITraktSyncWatchlistPostEpisode CreateWatchlistPostEpisode(ITraktEpisode episode, string notes = null)
        {
            ITraktSyncWatchlistPostEpisode syncWatchlistPostEpisode = new TraktSyncWatchlistPostEpisode
            {
                Ids = episode.Ids
            };

            if (!string.IsNullOrEmpty(notes))
                syncWatchlistPostEpisode.Notes = notes;

            return syncWatchlistPostEpisode;
        }

        private static ITraktSyncWatchlistPostEpisode CreateWatchlistPostEpisode(ITraktEpisodeIds episodeIds, string notes = null)
        {
            ITraktSyncWatchlistPostEpisode syncWatchlistPostEpisode = new TraktSyncWatchlistPostEpisode
            {
                Ids = episodeIds
            };

            if (!string.IsNullOrEmpty(notes))
                syncWatchlistPostEpisode.Notes = notes;

            return syncWatchlistPostEpisode;
        }

        private static void CheckNotes(string notes)
        {
            if (notes == null)
                throw new ArgumentNullException(nameof(notes));

            if (notes.Length > 255)
                throw new ArgumentOutOfRangeException(nameof(notes));
        }
    }
}
