namespace TraktNet.Objects.Post
{
    using Capabilities;
    using Get.Episodes;
    using Get.Movies;
    using Get.Shows;
    using Helper;
    using Post.Syncs.Watchlist;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal sealed class SyncWatchlistPostBuilder : ITraktSyncWatchlistPostBuilder
    {
        private readonly List<ITraktMovie> _movies;
        private readonly List<PostBuilderObjectWithNotes<ITraktMovie>> _moviesWithNotes;
        private readonly List<ITraktShow> _shows;
        private readonly List<PostBuilderObjectWithNotes<ITraktShow>> _showsWithNotes;
        private readonly List<ITraktEpisode> _episodes;
        private readonly List<PostBuilderObjectWithNotes<ITraktEpisode>> _episodesWithNotes;
        private readonly PostBuilderShowAddedSeasons<ITraktSyncWatchlistPostBuilder, ITraktSyncWatchlistPost> _showsWithSeasons;
        private readonly PostBuilderShowAddedSeasonsCollection<ITraktSyncWatchlistPostBuilder, ITraktSyncWatchlistPost, PostSeasons> _showsWithSeasonsCollection;

        internal SyncWatchlistPostBuilder()
        {
            _movies = new List<ITraktMovie>();
            _moviesWithNotes = new List<PostBuilderObjectWithNotes<ITraktMovie>>();
            _shows = new List<ITraktShow>();
            _showsWithNotes = new List<PostBuilderObjectWithNotes<ITraktShow>>();
            _episodes = new List<ITraktEpisode>();
            _episodesWithNotes = new List<PostBuilderObjectWithNotes<ITraktEpisode>>();
            _showsWithSeasons = new PostBuilderShowAddedSeasons<ITraktSyncWatchlistPostBuilder, ITraktSyncWatchlistPost>(this);
            _showsWithSeasonsCollection = new PostBuilderShowAddedSeasonsCollection<ITraktSyncWatchlistPostBuilder, ITraktSyncWatchlistPost, PostSeasons>(this);
        }

        public ITraktSyncWatchlistPostBuilder WithMovie(ITraktMovie movie)
        {
            if (movie == null)
                throw new ArgumentNullException(nameof(movie));

            _movies.Add(movie);
            return this;
        }

        public ITraktSyncWatchlistPostBuilder WithMovieWithNotes(ITraktMovie movie, string notes)
        {
            if (movie == null)
                throw new ArgumentNullException(nameof(movie));

            if (notes == null)
                throw new ArgumentNullException(nameof(notes));

            if (notes.Length > 255)
                throw new ArgumentOutOfRangeException(nameof(notes), "notes cannot be longer than 255 characters");

            _moviesWithNotes.Add(new PostBuilderObjectWithNotes<ITraktMovie>
            {
                Object = movie,
                Notes = notes
            });

            return this;
        }

        public ITraktSyncWatchlistPostBuilder WithMovies(IEnumerable<ITraktMovie> movies)
        {
            if (movies == null)
                throw new ArgumentNullException(nameof(movies));

            _movies.AddRange(movies);
            return this;
        }

        public ITraktSyncWatchlistPostBuilder WithMoviesWithNotes(IEnumerable<Tuple<ITraktMovie, string>> movies)
        {
            if (movies == null)
                throw new ArgumentNullException(nameof(movies));

            foreach (Tuple<ITraktMovie, string> tuple in movies)
            {
                if (tuple.Item2?.Length > 255)
                    throw new ArgumentOutOfRangeException($"movies[{movies.ToList().IndexOf(tuple)}].Notes", "notes cannot be longer than 255 characters");

                _moviesWithNotes.Add(new PostBuilderObjectWithNotes<ITraktMovie>
                {
                    Object = tuple.Item1,
                    Notes = tuple.Item2
                });
            }

            return this;
        }

        public ITraktSyncWatchlistPostBuilder WithShow(ITraktShow show)
        {
            if (show == null)
                throw new ArgumentNullException(nameof(show));

            _shows.Add(show);
            return this;
        }

        public ITraktSyncWatchlistPostBuilder WithShowWithNotes(ITraktShow show, string notes)
        {
            if (show == null)
                throw new ArgumentNullException(nameof(show));

            if (notes == null)
                throw new ArgumentNullException(nameof(notes));

            if (notes.Length > 255)
                throw new ArgumentOutOfRangeException(nameof(notes), "notes cannot be longer than 255 characters");

            _showsWithNotes.Add(new PostBuilderObjectWithNotes<ITraktShow>
            {
                Object = show,
                Notes = notes
            });

            return this;
        }

        public ITraktSyncWatchlistPostBuilder WithShows(IEnumerable<ITraktShow> shows)
        {
            if (shows == null)
                throw new ArgumentNullException(nameof(shows));

            _shows.AddRange(shows);
            return this;
        }

        public ITraktSyncWatchlistPostBuilder WithShowsWithNotes(IEnumerable<Tuple<ITraktShow, string>> shows)
        {
            if (shows == null)
                throw new ArgumentNullException(nameof(shows));

            foreach (Tuple<ITraktShow, string> tuple in shows)
            {
                if (tuple.Item2?.Length > 255)
                    throw new ArgumentOutOfRangeException($"shows[{shows.ToList().IndexOf(tuple)}].Notes", "notes cannot be longer than 255 characters");

                _showsWithNotes.Add(new PostBuilderObjectWithNotes<ITraktShow>
                {
                    Object = tuple.Item1,
                    Notes = tuple.Item2
                });
            }

            return this;
        }

        public ITraktPostBuilderShowAddedSeasons<ITraktSyncWatchlistPostBuilder, ITraktSyncWatchlistPost> WithShowAndSeasons(ITraktShow show)
        {
            if (show == null)
                throw new ArgumentNullException(nameof(show));

            _showsWithSeasons.SetCurrentShow(show);
            return _showsWithSeasons;
        }

        public ITraktPostBuilderShowAddedSeasonsCollection<ITraktSyncWatchlistPostBuilder, ITraktSyncWatchlistPost, PostSeasons> WithShowAndSeasonsCollection(ITraktShow show)
        {
            if (show == null)
                throw new ArgumentNullException(nameof(show));

            _showsWithSeasonsCollection.SetCurrentShow(show);
            return _showsWithSeasonsCollection;
        }

        public ITraktSyncWatchlistPostBuilder WithEpisode(ITraktEpisode episode)
        {
            if (episode == null)
                throw new ArgumentNullException(nameof(episode));

            _episodes.Add(episode);
            return this;
        }

        public ITraktSyncWatchlistPostBuilder WithEpisodeWithNotes(ITraktEpisode episode, string notes)
        {
            if (episode == null)
                throw new ArgumentNullException(nameof(episode));

            if (notes == null)
                throw new ArgumentNullException(nameof(notes));

            if (notes.Length > 255)
                throw new ArgumentOutOfRangeException(nameof(notes), "notes cannot be longer than 255 characters");

            _episodesWithNotes.Add(new PostBuilderObjectWithNotes<ITraktEpisode>
            {
                Object = episode,
                Notes = notes
            });

            return this;
        }

        public ITraktSyncWatchlistPostBuilder WithEpisodes(IEnumerable<ITraktEpisode> episodes)
        {
            if (episodes == null)
                throw new ArgumentNullException(nameof(episodes));

            _episodes.AddRange(episodes);
            return this;
        }

        public ITraktSyncWatchlistPostBuilder WithEpisodesWithNotes(IEnumerable<Tuple<ITraktEpisode, string>> episodes)
        {
            if (episodes == null)
                throw new ArgumentNullException(nameof(episodes));

            foreach (Tuple<ITraktEpisode, string> tuple in episodes)
            {
                if (tuple.Item2?.Length > 255)
                    throw new ArgumentOutOfRangeException($"episodes[{episodes.ToList().IndexOf(tuple)}].Notes", "notes cannot be longer than 255 characters");

                _episodesWithNotes.Add(new PostBuilderObjectWithNotes<ITraktEpisode>
                {
                    Object = tuple.Item1,
                    Notes = tuple.Item2
                });
            }

            return this;
        }

        public ITraktSyncWatchlistPost Build()
        {
            ITraktSyncWatchlistPost syncWatchlistPost = new TraktSyncWatchlistPost();
            AddMovies(syncWatchlistPost);
            AddShows(syncWatchlistPost);
            AddEpisodes(syncWatchlistPost);
            return syncWatchlistPost;
        }

        private void AddMovies(ITraktSyncWatchlistPost syncWatchlistPost)
        {
            syncWatchlistPost.Movies ??= new List<ITraktSyncWatchlistPostMovie>();

            foreach (ITraktMovie movie in _movies)
                (syncWatchlistPost.Movies as List<ITraktSyncWatchlistPostMovie>).Add(CreateSyncWatchlistPostMovie(movie));

            foreach (PostBuilderObjectWithNotes<ITraktMovie> movieWithNotes in _moviesWithNotes)
                (syncWatchlistPost.Movies as List<ITraktSyncWatchlistPostMovie>).Add(CreateSyncWatchlistPostMovie(movieWithNotes.Object, movieWithNotes.Notes));
        }

        private void AddShows(ITraktSyncWatchlistPost syncWatchlistPost)
        {
            syncWatchlistPost.Shows ??= new List<ITraktSyncWatchlistPostShow>();

            foreach (ITraktShow show in _shows)
                (syncWatchlistPost.Shows as List<ITraktSyncWatchlistPostShow>).Add(CreateSyncWatchlistPostShow(show));

            foreach (PostBuilderObjectWithSeasons<ITraktShow, IEnumerable<int>> showEntry in _showsWithSeasons.ShowsWithSeasons)
                (syncWatchlistPost.Shows as List<ITraktSyncWatchlistPostShow>).Add(CreateSyncWatchlistPostShowWithSeasons(showEntry.Object, showEntry.Seasons));

            foreach (PostBuilderObjectWithSeasons<ITraktShow, PostSeasons> showEntry in _showsWithSeasonsCollection.ShowsWithSeasonsCollection)
                (syncWatchlistPost.Shows as List<ITraktSyncWatchlistPostShow>).Add(CreateSyncWatchlistPostShowWithSeasonsCollection(showEntry.Object, showEntry.Seasons));

            foreach (PostBuilderObjectWithNotes<ITraktShow> showWithNotes in _showsWithNotes)
                (syncWatchlistPost.Shows as List<ITraktSyncWatchlistPostShow>).Add(CreateSyncWatchlistPostShow(showWithNotes.Object, showWithNotes.Notes));
        }

        private void AddEpisodes(ITraktSyncWatchlistPost syncWatchlistPost)
        {
            syncWatchlistPost.Episodes ??= new List<ITraktSyncWatchlistPostEpisode>();

            foreach (ITraktEpisode episode in _episodes)
                (syncWatchlistPost.Episodes as List<ITraktSyncWatchlistPostEpisode>).Add(CreateSyncWatchlistPostEpisode(episode));

            foreach (PostBuilderObjectWithNotes<ITraktEpisode> episodeWithNotes in _episodesWithNotes)
                (syncWatchlistPost.Episodes as List<ITraktSyncWatchlistPostEpisode>).Add(CreateSyncWatchlistPostEpisode(episodeWithNotes.Object, episodeWithNotes.Notes));
        }

        private ITraktSyncWatchlistPostMovie CreateSyncWatchlistPostMovie(ITraktMovie movie, string notes = null)
        {
            var syncWatchlistPostMovie = new TraktSyncWatchlistPostMovie
            {
                Ids = movie.Ids,
                Title = movie.Title,
                Year = movie.Year
            };

            if (!string.IsNullOrEmpty(notes))
                syncWatchlistPostMovie.Notes = notes;

            return syncWatchlistPostMovie;
        }

        private ITraktSyncWatchlistPostShow CreateSyncWatchlistPostShow(ITraktShow show, string notes = null)
        {
            var syncWatchlistPostShow = new TraktSyncWatchlistPostShow
            {
                Ids = show.Ids,
                Title = show.Title,
                Year = show.Year
            };

            if (!string.IsNullOrEmpty(notes))
                syncWatchlistPostShow.Notes = notes;

            return syncWatchlistPostShow;
        }

        private ITraktSyncWatchlistPostShow CreateSyncWatchlistPostShowWithSeasons(ITraktShow show, IEnumerable<int> seasons)
        {
            var syncWatchlistPostShow = CreateSyncWatchlistPostShow(show);

            if (seasons != null)
                syncWatchlistPostShow.Seasons = CreateSyncWatchlistPostShowSeasons(seasons);

            return syncWatchlistPostShow;
        }

        private ITraktSyncWatchlistPostShow CreateSyncWatchlistPostShowWithSeasonsCollection(ITraktShow show, PostSeasons seasons)
        {
            var syncWatchlistPostShow = CreateSyncWatchlistPostShow(show);

            if (seasons != null)
                syncWatchlistPostShow.Seasons = CreateSyncWatchlistPostShowSeasons(seasons);

            return syncWatchlistPostShow;
        }

        private IEnumerable<ITraktSyncWatchlistPostShowSeason> CreateSyncWatchlistPostShowSeasons(IEnumerable<int> seasons)
        {
            var syncWatchlistPostShowSeasons = new List<ITraktSyncWatchlistPostShowSeason>();

            foreach (int season in seasons)
            {
                syncWatchlistPostShowSeasons.Add(new TraktSyncWatchlistPostShowSeason
                {
                    Number = season
                });
            }

            return syncWatchlistPostShowSeasons;
        }

        private IEnumerable<ITraktSyncWatchlistPostShowSeason> CreateSyncWatchlistPostShowSeasons(PostSeasons seasons)
        {
            var syncWatchlistPostShowSeasons = new List<ITraktSyncWatchlistPostShowSeason>();

            foreach (PostSeason season in seasons)
            {
                var syncWatchlistPostShowSeason = new TraktSyncWatchlistPostShowSeason
                {
                    Number = season.Number
                };

                if (season.Episodes?.Count() > 0)
                {
                    var syncWatchlistPostShowEpisodes = new List<ITraktSyncWatchlistPostShowEpisode>();

                    foreach (PostEpisode episode in season.Episodes)
                    {
                        syncWatchlistPostShowEpisodes.Add(new TraktSyncWatchlistPostShowEpisode
                        {
                            Number = episode.Number
                        });
                    }

                    syncWatchlistPostShowSeason.Episodes = syncWatchlistPostShowEpisodes;
                }

                syncWatchlistPostShowSeasons.Add(syncWatchlistPostShowSeason);
            }

            return syncWatchlistPostShowSeasons;
        }

        private ITraktSyncWatchlistPostEpisode CreateSyncWatchlistPostEpisode(ITraktEpisode episode, string notes = null)
        {
            var syncWatchlistPostEpisode = new TraktSyncWatchlistPostEpisode
            {
                Ids = episode.Ids
            };

            if (!string.IsNullOrEmpty(notes))
                syncWatchlistPostEpisode.Notes = notes;

            return syncWatchlistPostEpisode;
        }
    }
}
