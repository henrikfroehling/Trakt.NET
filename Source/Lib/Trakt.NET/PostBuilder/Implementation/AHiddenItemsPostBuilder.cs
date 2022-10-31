namespace TraktNet.PostBuilder
{
    using System;
    using System.Collections.Generic;
    using TraktNet.Objects.Get.Movies;
    using TraktNet.Objects.Get.Seasons;
    using TraktNet.Objects.Get.Shows;
    using TraktNet.Objects.Get.Users;

    internal abstract class AHiddenItemsPostBuilder<TPostBuilder, TPostObject> : ITraktHiddenItemsPostBuilder<TPostBuilder, TPostObject>
        where TPostBuilder : ITraktHiddenItemsPostBuilder<TPostBuilder, TPostObject>
    {
        protected readonly Lazy<List<ITraktMovie>> _movies;
        protected readonly Lazy<List<ITraktMovieIds>> _movieIds;
        protected readonly Lazy<List<ITraktShow>> _shows;
        protected readonly Lazy<List<ITraktShowIds>> _showIds;
        protected readonly Lazy<List<HiddenShowWithSeasons>> _showsWithSeasons;
        protected readonly Lazy<List<HiddenShowIdsWithSeasons>> _showIdsWithSeasons;
        protected readonly Lazy<List<ITraktSeason>> _seasons;
        protected readonly Lazy<List<ITraktSeasonIds>> _seasonIds;
        protected readonly Lazy<List<ITraktUser>> _users;
        protected readonly Lazy<List<ITraktUserIds>> _userIds;

        protected AHiddenItemsPostBuilder()
        {
            _movies = new Lazy<List<ITraktMovie>>();
            _movieIds = new Lazy<List<ITraktMovieIds>>();
            _shows = new Lazy<List<ITraktShow>>();
            _showIds = new Lazy<List<ITraktShowIds>>();
            _showsWithSeasons = new Lazy<List<HiddenShowWithSeasons>>();
            _showIdsWithSeasons = new Lazy<List<HiddenShowIdsWithSeasons>>();
            _seasons = new Lazy<List<ITraktSeason>>();
            _seasonIds = new Lazy<List<ITraktSeasonIds>>();
            _users = new Lazy<List<ITraktUser>>();
            _userIds = new Lazy<List<ITraktUserIds>>();
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

        public TPostBuilder WithShowAndSeasons(ITraktShow show, IEnumerable<int> seasons)
        {
            if (show == null)
                throw new ArgumentNullException(nameof(show));

            if (seasons == null)
                throw new ArgumentNullException(nameof(seasons));

            return WithShowAndSeasons(new HiddenShowWithSeasons(show, seasons));
        }

        public TPostBuilder WithShowAndSeasons(ITraktShow show, int season, params int[] seasons)
        {
            if (show == null)
                throw new ArgumentNullException(nameof(show));

            return WithShowAndSeasons(new HiddenShowWithSeasons(show, season, seasons));
        }

        public TPostBuilder WithShowAndSeasons(HiddenShowWithSeasons showWithSeasons)
        {
            if (showWithSeasons == null)
                throw new ArgumentNullException(nameof(showWithSeasons));

            _showsWithSeasons.Value.Add(showWithSeasons);
            return GetBuilder();
        }

        public TPostBuilder WithShowAndSeasons(ITraktShowIds showIds, IEnumerable<int> seasons)
        {
            if (showIds == null)
                throw new ArgumentNullException(nameof(showIds));

            if (seasons == null)
                throw new ArgumentNullException(nameof(seasons));

            return WithShowAndSeasons(new HiddenShowIdsWithSeasons(showIds, seasons));
        }

        public TPostBuilder WithShowAndSeasons(ITraktShowIds showIds, int season, params int[] seasons)
        {
            if (showIds == null)
                throw new ArgumentNullException(nameof(showIds));

            return WithShowAndSeasons(new HiddenShowIdsWithSeasons(showIds, season, seasons));
        }

        public TPostBuilder WithShowAndSeasons(HiddenShowIdsWithSeasons showIdsWithSeasons)
        {
            if (showIdsWithSeasons == null)
                throw new ArgumentNullException(nameof(showIdsWithSeasons));

            _showIdsWithSeasons.Value.Add(showIdsWithSeasons);
            return GetBuilder();
        }

        public TPostBuilder WithShowsAndSeasons(IEnumerable<HiddenShowWithSeasons> showsWithSeasons)
        {
            if (showsWithSeasons == null)
                throw new ArgumentNullException(nameof(showsWithSeasons));

            foreach (HiddenShowWithSeasons showWithSeasons in showsWithSeasons)
            {
                if (showWithSeasons != null)
                    _showsWithSeasons.Value.Add(showWithSeasons);
            }

            return GetBuilder();
        }

        public TPostBuilder WithShowsAndSeasons(IEnumerable<HiddenShowIdsWithSeasons> showIdsWithSeasons)
        {
            if (showIdsWithSeasons == null)
                throw new ArgumentNullException(nameof(showIdsWithSeasons));

            foreach (HiddenShowIdsWithSeasons showIdWithSeasons in showIdsWithSeasons)
            {
                if (showIdWithSeasons != null)
                    _showIdsWithSeasons.Value.Add(showIdWithSeasons);
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

        public TPostBuilder WithUser(ITraktUser user)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));

            _users.Value.Add(user);
            return GetBuilder();
        }

        public TPostBuilder WithUser(ITraktUserIds userIds)
        {
            if (userIds == null)
                throw new ArgumentNullException(nameof(userIds));

            _userIds.Value.Add(userIds);
            return GetBuilder();
        }

        public TPostBuilder WithUsers(IEnumerable<ITraktUser> users)
        {
            if (users == null)
                throw new ArgumentNullException(nameof(users));

            foreach (ITraktUser user in users)
            {
                if (user != null)
                    _users.Value.Add(user);
            }

            return GetBuilder();
        }

        public TPostBuilder WithUsers(IEnumerable<ITraktUserIds> userIds)
        {
            if (userIds == null)
                throw new ArgumentNullException(nameof(userIds));

            foreach (ITraktUserIds userId in userIds)
            {
                if (userId != null)
                    _userIds.Value.Add(userId);
            }

            return GetBuilder();
        }

        public abstract TPostObject Build();

        protected abstract TPostBuilder GetBuilder();
    }
}
