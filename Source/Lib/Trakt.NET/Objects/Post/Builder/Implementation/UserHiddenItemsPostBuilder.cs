namespace TraktNet.Objects.Post
{
    using Capabilities;
    using Get.Movies;
    using Get.Seasons;
    using Get.Shows;
    using Helper;
    using Post.Users.HiddenItems;
    using System;
    using System.Collections.Generic;

    internal sealed class UserHiddenItemsPostBuilder : ITraktUserHiddenItemsPostBuilder
    {
        private readonly List<ITraktMovie> _movies;
        private readonly List<ITraktShow> _shows;
        private readonly List<ITraktSeason> _seasons;
        private readonly PostBuilderShowAddedSeasons<ITraktUserHiddenItemsPostBuilder, ITraktUserHiddenItemsPost> _showsWithSeasons;

        internal UserHiddenItemsPostBuilder()
        {
            _movies = new List<ITraktMovie>();
            _shows = new List<ITraktShow>();
            _seasons = new List<ITraktSeason>();
            _showsWithSeasons = new PostBuilderShowAddedSeasons<ITraktUserHiddenItemsPostBuilder, ITraktUserHiddenItemsPost>(this);
        }

        public ITraktUserHiddenItemsPostBuilder WithMovie(ITraktMovie movie)
        {
            if (movie == null)
                throw new ArgumentNullException(nameof(movie));

            _movies.Add(movie);
            return this;
        }

        public ITraktUserHiddenItemsPostBuilder WithMovies(IEnumerable<ITraktMovie> movies)
        {
            if (movies == null)
                throw new ArgumentNullException(nameof(movies));

            _movies.AddRange(movies);
            return this;
        }

        public ITraktUserHiddenItemsPostBuilder WithShow(ITraktShow show)
        {
            if (show == null)
                throw new ArgumentNullException(nameof(show));

            _shows.Add(show);
            return this;
        }

        public ITraktUserHiddenItemsPostBuilder WithShows(IEnumerable<ITraktShow> shows)
        {
            if (shows == null)
                throw new ArgumentNullException(nameof(shows));

            _shows.AddRange(shows);
            return this;
        }

        public ITraktPostBuilderShowAddedSeasons<ITraktUserHiddenItemsPostBuilder, ITraktUserHiddenItemsPost> WithShowAndSeasons(ITraktShow show)
        {
            if (show == null)
                throw new ArgumentNullException(nameof(show));

            _showsWithSeasons.SetCurrentShow(show);
            return _showsWithSeasons;
        }

        public ITraktUserHiddenItemsPostBuilder WithSeason(ITraktSeason season)
        {
            if (season == null)
                throw new ArgumentNullException(nameof(season));

            _seasons.Add(season);
            return this;
        }

        public ITraktUserHiddenItemsPostBuilder WithSeasons(IEnumerable<ITraktSeason> seasons)
        {
            if (seasons == null)
                throw new ArgumentNullException(nameof(seasons));

            _seasons.AddRange(seasons);
            return this;
        }

        public ITraktUserHiddenItemsPost Build()
        {
            ITraktUserHiddenItemsPost userHiddenItemsPost = new TraktUserHiddenItemsPost();
            AddMovies(userHiddenItemsPost);
            AddShows(userHiddenItemsPost);
            AddSeasons(userHiddenItemsPost);
            return userHiddenItemsPost;
        }

        private void AddMovies(ITraktUserHiddenItemsPost userHiddenItemsPost)
        {
            if (userHiddenItemsPost.Movies == null)
                userHiddenItemsPost.Movies = new List<ITraktUserHiddenItemsPostMovie>();

            foreach (ITraktMovie movie in _movies)
                (userHiddenItemsPost.Movies as List<ITraktUserHiddenItemsPostMovie>).Add(CreateUserHiddenItemsPostMovie(movie));
        }

        private void AddShows(ITraktUserHiddenItemsPost userHiddenItemsPost)
        {
            if (userHiddenItemsPost.Shows == null)
                userHiddenItemsPost.Shows = new List<ITraktUserHiddenItemsPostShow>();

            foreach (ITraktShow show in _shows)
                (userHiddenItemsPost.Shows as List<ITraktUserHiddenItemsPostShow>).Add(CreateUserHiddenItemsPostShow(show));

            foreach (PostBuilderObjectWithSeasons<ITraktShow, IEnumerable<int>> showEntry in _showsWithSeasons.ShowsWithSeasons)
                (userHiddenItemsPost.Shows as List<ITraktUserHiddenItemsPostShow>).Add(CreateUserHiddenItemsPostShowWithSeasons(showEntry.Object, showEntry.Seasons));
        }

        private void AddSeasons(ITraktUserHiddenItemsPost userHiddenItemsPost)
        {
            if (userHiddenItemsPost.Seasons == null)
                userHiddenItemsPost.Seasons = new List<ITraktUserHiddenItemsPostSeason>();

            foreach (ITraktSeason season in _seasons)
                (userHiddenItemsPost.Seasons as List<ITraktUserHiddenItemsPostSeason>).Add(CreateUserHiddenItemsPostSeason(season));
        }

        private ITraktUserHiddenItemsPostMovie CreateUserHiddenItemsPostMovie(ITraktMovie movie)
        {
            return new TraktUserHiddenItemsPostMovie
            {
                Ids = movie.Ids,
                Title = movie.Title,
                Year = movie.Year
            };
        }

        private ITraktUserHiddenItemsPostShow CreateUserHiddenItemsPostShow(ITraktShow show)
        {
            return new TraktUserHiddenItemsPostShow
            {
                Ids = show.Ids,
                Title = show.Title,
                Year = show.Year
            };
        }

        private ITraktUserHiddenItemsPostShow CreateUserHiddenItemsPostShowWithSeasons(ITraktShow show, IEnumerable<int> seasons)
        {
            var userHiddenItemsPostShow = CreateUserHiddenItemsPostShow(show);

            if (seasons != null)
                userHiddenItemsPostShow.Seasons = CreateUserHiddenItemsPostShowSeasons(seasons);

            return userHiddenItemsPostShow;
        }

        private IEnumerable<ITraktUserHiddenItemsPostShowSeason> CreateUserHiddenItemsPostShowSeasons(IEnumerable<int> seasons)
        {
            var userHiddenItemsPostShowSeasons = new List<ITraktUserHiddenItemsPostShowSeason>();

            foreach (int season in seasons)
            {
                userHiddenItemsPostShowSeasons.Add(new TraktUserHiddenItemsPostShowSeason
                {
                    Number = season
                });
            }

            return userHiddenItemsPostShowSeasons;
        }

        private ITraktUserHiddenItemsPostSeason CreateUserHiddenItemsPostSeason(ITraktSeason season)
        {
            return new TraktUserHiddenItemsPostSeason
            {
                Ids = season.Ids
            };
        }
    }
}
