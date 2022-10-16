namespace TraktNet.PostBuilder
{
    using System;
    using System.Collections.Generic;
    using TraktNet.Objects.Get.Episodes;
    using TraktNet.Objects.Get.Movies;
    using TraktNet.Objects.Get.Seasons;
    using TraktNet.Objects.Get.Shows;

    internal abstract class ATraktRemovePostBuilder<TPostBuilder, TPostObject> : ITraktRemovePostBuilder<TPostBuilder, TPostObject>
        where TPostBuilder : ITraktRemovePostBuilder<TPostBuilder, TPostObject>
    {
        protected readonly Lazy<List<ITraktMovie>> _movies;
        protected readonly Lazy<List<ITraktMovieIds>> _movieIds;
        protected readonly Lazy<List<ITraktShow>> _shows;
        protected readonly Lazy<List<ITraktShowIds>> _showIds;
        protected readonly Lazy<List<ShowAndSeasons>> _showsAndSeasons;
        protected readonly Lazy<List<ShowIdsAndSeasons>> _showIdsAndSeasons;
        protected readonly Lazy<List<ITraktSeason>> _seasons;
        protected readonly Lazy<List<ITraktSeasonIds>> _seasonIds;
        protected readonly Lazy<List<ITraktEpisode>> _episodes;
        protected readonly Lazy<List<ITraktEpisodeIds>> _episodeIds;

        protected ATraktRemovePostBuilder()
        {
            _movies = new Lazy<List<ITraktMovie>>();
            _movieIds = new Lazy<List<ITraktMovieIds>>();
            _shows = new Lazy<List<ITraktShow>>();
            _showIds = new Lazy<List<ITraktShowIds>>();
            _showsAndSeasons = new Lazy<List<ShowAndSeasons>>();
            _showIdsAndSeasons = new Lazy<List<ShowIdsAndSeasons>>();
            _seasons = new Lazy<List<ITraktSeason>>();
            _seasonIds = new Lazy<List<ITraktSeasonIds>>();
            _episodes = new Lazy<List<ITraktEpisode>>();
            _episodeIds = new Lazy<List<ITraktEpisodeIds>>();
        }

        public TPostBuilder WithMovie(ITraktMovie movie)
        {
            if (movie == null)
                throw new ArgumentNullException(nameof(movie));

            _movies.Value.Add(movie);
            return GetBuilder();
        }

        public TPostBuilder WithMovie(ITraktMovieIds movieIds)
        {
            if (movieIds == null)
                throw new ArgumentNullException(nameof(movieIds));

            _movieIds.Value.Add(movieIds);
            return GetBuilder();
        }

        public TPostBuilder WithMovies(IEnumerable<ITraktMovie> movies)
        {
            if (movies == null)
                throw new ArgumentNullException(nameof(movies));

            foreach (ITraktMovie movie in movies)
            {
                if (movie != null)
                    _movies.Value.Add(movie);
            }

            return GetBuilder();
        }

        public TPostBuilder WithMovies(IEnumerable<ITraktMovieIds> movieIds)
        {
            if (movieIds == null)
                throw new ArgumentNullException(nameof(movieIds));

            foreach (ITraktMovieIds movieId in movieIds)
            {
                if (movieId != null)
                    _movieIds.Value.Add(movieId);
            }

            return GetBuilder();
        }

        public TPostBuilder WithShow(ITraktShow show)
        {
            if (show == null)
                throw new ArgumentNullException(nameof(show));

            _shows.Value.Add(show);
            return GetBuilder();
        }

        public TPostBuilder WithShow(ITraktShowIds showIds)
        {
            if (showIds == null)
                throw new ArgumentNullException(nameof(showIds));

            _showIds.Value.Add(showIds);
            return GetBuilder();
        }

        public TPostBuilder WithShows(IEnumerable<ITraktShow> shows)
        {
            if (shows == null)
                throw new ArgumentNullException(nameof(shows));

            foreach (ITraktShow show in shows)
            {
                if (show != null)
                    _shows.Value.Add(show);
            }

            return GetBuilder();
        }

        public TPostBuilder WithShows(IEnumerable<ITraktShowIds> showIds)
        {
            if (showIds == null)
                throw new ArgumentNullException(nameof(showIds));

            foreach (ITraktShowIds showId in showIds)
            {
                if (showId != null)
                    _showIds.Value.Add(showId);
            }

            return GetBuilder();
        }

        public TPostBuilder WithShowAndSeasons(ITraktShow show, PostSeasons seasons)
        {
            if (show == null)
                throw new ArgumentNullException(nameof(show));

            if (seasons == null)
                throw new ArgumentNullException(nameof(seasons));

            return WithShowAndSeasons(new ShowAndSeasons(show, seasons));
        }

        public TPostBuilder WithShowAndSeasons(ShowAndSeasons showAndSeasons)
        {
            if (showAndSeasons == null)
                throw new ArgumentNullException(nameof(showAndSeasons));

            _showsAndSeasons.Value.Add(showAndSeasons);
            return GetBuilder();
        }

        public TPostBuilder WithShowAndSeasons(ITraktShowIds showIds, PostSeasons seasons)
        {
            if (showIds == null)
                throw new ArgumentNullException(nameof(showIds));

            if (seasons == null)
                throw new ArgumentNullException(nameof(seasons));

            return WithShowAndSeasons(new ShowIdsAndSeasons(showIds, seasons));
        }

        public TPostBuilder WithShowAndSeasons(ShowIdsAndSeasons showIdsAndSeasons)
        {
            if (showIdsAndSeasons == null)
                throw new ArgumentNullException(nameof(showIdsAndSeasons));

            _showIdsAndSeasons.Value.Add(showIdsAndSeasons);
            return GetBuilder();
        }

        public TPostBuilder WithShowsAndSeasons(IEnumerable<ShowAndSeasons> showsAndSeasons)
        {
            if (showsAndSeasons == null)
                throw new ArgumentNullException(nameof(showsAndSeasons));

            foreach (ShowAndSeasons showAndSeasons in showsAndSeasons)
            {
                if (showAndSeasons != null)
                    _showsAndSeasons.Value.Add(showAndSeasons);
            }

            return GetBuilder();
        }

        public TPostBuilder WithShowsAndSeasons(IEnumerable<ShowIdsAndSeasons> showIdsAndSeasons)
        {
            if (showIdsAndSeasons == null)
                throw new ArgumentNullException(nameof(showIdsAndSeasons));

            foreach (ShowIdsAndSeasons showIdAndSeasons in showIdsAndSeasons)
            {
                if (showIdAndSeasons != null)
                    _showIdsAndSeasons.Value.Add(showIdAndSeasons);
            }

            return GetBuilder();
        }

        public TPostBuilder WithSeason(ITraktSeason season)
        {
            if (season == null)
                throw new ArgumentNullException(nameof(season));

            _seasons.Value.Add(season);
            return GetBuilder();
        }

        public TPostBuilder WithSeason(ITraktSeasonIds seasonIds)
        {
            if (seasonIds == null)
                throw new ArgumentNullException(nameof(seasonIds));

            _seasonIds.Value.Add(seasonIds);
            return GetBuilder();
        }

        public TPostBuilder WithSeasons(IEnumerable<ITraktSeason> seasons)
        {
            if (seasons == null)
                throw new ArgumentNullException(nameof(seasons));

            foreach (ITraktSeason season in seasons)
            {
                if (season != null)
                    _seasons.Value.Add(season);
            }

            return GetBuilder();
        }

        public TPostBuilder WithSeasons(IEnumerable<ITraktSeasonIds> seasonIds)
        {
            if (seasonIds == null)
                throw new ArgumentNullException(nameof(seasonIds));

            foreach (ITraktSeasonIds seasonId in seasonIds)
            {
                if (seasonId != null)
                    _seasonIds.Value.Add(seasonId);
            }

            return GetBuilder();
        }

        public TPostBuilder WithEpisode(ITraktEpisode episode)
        {
            if (episode == null)
                throw new ArgumentNullException(nameof(episode));

            _episodes.Value.Add(episode);
            return GetBuilder();
        }

        public TPostBuilder WithEpisode(ITraktEpisodeIds episodeIds)
        {
            if (episodeIds == null)
                throw new ArgumentNullException(nameof(episodeIds));

            _episodeIds.Value.Add(episodeIds);
            return GetBuilder();
        }

        public TPostBuilder WithEpisodes(IEnumerable<ITraktEpisode> episodes)
        {
            if (episodes == null)
                throw new ArgumentNullException(nameof(episodes));

            foreach (ITraktEpisode episode in episodes)
            {
                if (episode != null)
                    _episodes.Value.Add(episode);
            }

            return GetBuilder();
        }

        public TPostBuilder WithEpisodes(IEnumerable<ITraktEpisodeIds> episodeIds)
        {
            if (episodeIds == null)
                throw new ArgumentNullException(nameof(episodeIds));

            foreach (ITraktEpisodeIds episodeId in episodeIds)
            {
                if (episodeId != null)
                    _episodeIds.Value.Add(episodeId);
            }

            return GetBuilder();
        }

        public abstract TPostObject Build();

        protected abstract TPostBuilder GetBuilder();
    }
}
