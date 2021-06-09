namespace TraktNet.Objects.Post
{
    using Capabilities;
    using Get.Movies;
    using Get.People;
    using Get.Shows;
    using Helper;
    using Post.Users.CustomListItems;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class UserCustomListItemsPostBuilder : ITraktUserCustomListItemsPostBuilder
    {
        private readonly List<ITraktMovie> _movies;
        private readonly List<ITraktShow> _shows;
        private readonly List<ITraktPerson> _persons;
        private readonly PostBuilderShowAddedSeasons<ITraktUserCustomListItemsPostBuilder, ITraktUserCustomListItemsPost> _showsWithSeasons;
        private readonly PostBuilderShowAddedSeasonsCollection<ITraktUserCustomListItemsPostBuilder, ITraktUserCustomListItemsPost, PostSeasons> _showsWithSeasonsCollection;

        internal UserCustomListItemsPostBuilder()
        {
            _movies = new List<ITraktMovie>();
            _shows = new List<ITraktShow>();
            _persons = new List<ITraktPerson>();
            _showsWithSeasons = new PostBuilderShowAddedSeasons<ITraktUserCustomListItemsPostBuilder, ITraktUserCustomListItemsPost>(this);
            _showsWithSeasonsCollection = new PostBuilderShowAddedSeasonsCollection<ITraktUserCustomListItemsPostBuilder, ITraktUserCustomListItemsPost, PostSeasons>(this);
        }

        public ITraktUserCustomListItemsPostBuilder WithMovie(ITraktMovie movie)
        {
            if (movie == null)
                throw new ArgumentNullException(nameof(movie));

            _movies.Add(movie);
            return this;
        }

        public ITraktUserCustomListItemsPostBuilder WithMovies(IEnumerable<ITraktMovie> movies)
        {
            if (movies == null)
                throw new ArgumentNullException(nameof(movies));

            _movies.AddRange(movies);
            return this;
        }

        public ITraktUserCustomListItemsPostBuilder WithShow(ITraktShow show)
        {
            if (show == null)
                throw new ArgumentNullException(nameof(show));

            _shows.Add(show);
            return this;
        }

        public ITraktUserCustomListItemsPostBuilder WithShows(IEnumerable<ITraktShow> shows)
        {
            if (shows == null)
                throw new ArgumentNullException(nameof(shows));

            _shows.AddRange(shows);
            return this;
        }

        public ITraktPostBuilderShowAddedSeasons<ITraktUserCustomListItemsPostBuilder, ITraktUserCustomListItemsPost> AddShowAndSeasons(ITraktShow show)
        {
            if (show == null)
                throw new ArgumentNullException(nameof(show));

            _showsWithSeasons.SetCurrentShow(show);
            return _showsWithSeasons;
        }

        public ITraktPostBuilderShowAddedSeasonsCollection<ITraktUserCustomListItemsPostBuilder, ITraktUserCustomListItemsPost, PostSeasons> AddShowAndSeasonsCollection(ITraktShow show)
        {
            if (show == null)
                throw new ArgumentNullException(nameof(show));

            _showsWithSeasonsCollection.SetCurrentShow(show);
            return _showsWithSeasonsCollection;
        }

        public ITraktUserCustomListItemsPostBuilder WithPerson(ITraktPerson person)
        {
            if (person == null)
                throw new ArgumentNullException(nameof(person));

            _persons.Add(person);
            return this;
        }

        public ITraktUserCustomListItemsPostBuilder WithPersons(IEnumerable<ITraktPerson> persons)
        {
            if (persons == null)
                throw new ArgumentNullException(nameof(persons));

            _persons.AddRange(persons);
            return this;
        }

        public ITraktUserCustomListItemsPost Build()
        {
            ITraktUserCustomListItemsPost userCustomListItemsPost = new TraktUserCustomListItemsPost();
            AddMovies(userCustomListItemsPost);
            AddShows(userCustomListItemsPost);
            AddPersons(userCustomListItemsPost);
            return userCustomListItemsPost;
        }

        private void AddMovies(ITraktUserCustomListItemsPost userCustomListItemsPost)
        {
            if (userCustomListItemsPost.Movies == null)
                userCustomListItemsPost.Movies = new List<ITraktUserCustomListItemsPostMovie>();

            foreach (ITraktMovie movie in _movies)
                (userCustomListItemsPost.Movies as List<ITraktUserCustomListItemsPostMovie>).Add(CreateUserCustomListItemsPostMovie(movie));
        }

        private void AddShows(ITraktUserCustomListItemsPost userCustomListItemsPost)
        {
            if (userCustomListItemsPost.Shows == null)
                userCustomListItemsPost.Shows = new List<ITraktUserCustomListItemsPostShow>();

            foreach (ITraktShow show in _shows)
                (userCustomListItemsPost.Shows as List<ITraktUserCustomListItemsPostShow>).Add(CreateUserCustomListItemsPostShow(show));

            foreach (PostBuilderObjectWithSeasons<ITraktShow, IEnumerable<int>> showEntry in _showsWithSeasons.ShowsWithSeasons)
                (userCustomListItemsPost.Shows as List<ITraktUserCustomListItemsPostShow>).Add(CreateUserCustomListItemsPostShowWithSeasons(showEntry.Object, showEntry.Seasons));

            foreach (PostBuilderObjectWithSeasons<ITraktShow, PostSeasons> showEntry in _showsWithSeasonsCollection.ShowsWithSeasonsCollection)
                (userCustomListItemsPost.Shows as List<ITraktUserCustomListItemsPostShow>).Add(CreateUserCustomListItemsPostShowWithSeasonsCollection(showEntry.Object, showEntry.Seasons));
        }

        private void AddPersons(ITraktUserCustomListItemsPost userCustomListItemsPost)
        {
            if (userCustomListItemsPost.People == null)
                userCustomListItemsPost.People = new List<ITraktPerson>();

            foreach (ITraktPerson episode in _persons)
                (userCustomListItemsPost.People as List<ITraktPerson>).Add(CreateUserCustomListItemsPostPerson(episode));
        }

        private ITraktUserCustomListItemsPostMovie CreateUserCustomListItemsPostMovie(ITraktMovie movie)
        {
            return new TraktUserCustomListItemsPostMovie
            {
                Ids = movie.Ids
            };
        }

        private ITraktUserCustomListItemsPostShow CreateUserCustomListItemsPostShow(ITraktShow show)
        {
            return new TraktUserCustomListItemsPostShow
            {
                Ids = show.Ids
            };
        }

        private ITraktUserCustomListItemsPostShow CreateUserCustomListItemsPostShowWithSeasons(ITraktShow show, IEnumerable<int> seasons)
        {
            var userCustomListItemsPostShow = CreateUserCustomListItemsPostShow(show);

            if (seasons != null)
                userCustomListItemsPostShow.Seasons = CreateUserCustomListItemsPostShowSeasons(seasons);

            return userCustomListItemsPostShow;
        }

        private ITraktUserCustomListItemsPostShow CreateUserCustomListItemsPostShowWithSeasonsCollection(ITraktShow show, PostSeasons seasons)
        {
            var userCustomListItemsPostShow = CreateUserCustomListItemsPostShow(show);

            if (seasons != null)
                userCustomListItemsPostShow.Seasons = CreateUserCustomListItemsPostShowSeasons(seasons);

            return userCustomListItemsPostShow;
        }

        private IEnumerable<ITraktUserCustomListItemsPostShowSeason> CreateUserCustomListItemsPostShowSeasons(IEnumerable<int> seasons)
        {
            var userCustomListItemsPostShowSeasons = new List<ITraktUserCustomListItemsPostShowSeason>();

            foreach (int season in seasons)
            {
                userCustomListItemsPostShowSeasons.Add(new TraktUserCustomListItemsPostShowSeason
                {
                    Number = season
                });
            }

            return userCustomListItemsPostShowSeasons;
        }

        private IEnumerable<ITraktUserCustomListItemsPostShowSeason> CreateUserCustomListItemsPostShowSeasons(PostSeasons seasons)
        {
            var userCustomListItemsPostShowSeasons = new List<ITraktUserCustomListItemsPostShowSeason>();

            foreach (PostSeason season in seasons)
            {
                var userCustomListItemsPostShowSeason = new TraktUserCustomListItemsPostShowSeason
                {
                    Number = season.Number
                };

                if (season.Episodes?.Count() > 0)
                {
                    var userCustomListItemsPostShowEpisodes = new List<ITraktUserCustomListItemsPostShowEpisode>();

                    foreach (PostEpisode episode in season.Episodes)
                    {
                        userCustomListItemsPostShowEpisodes.Add(new TraktUserCustomListItemsPostShowEpisode
                        {
                            Number = episode.Number
                        });
                    }

                    userCustomListItemsPostShowSeason.Episodes = userCustomListItemsPostShowEpisodes;
                }

                userCustomListItemsPostShowSeasons.Add(userCustomListItemsPostShowSeason);
            }

            return userCustomListItemsPostShowSeasons;
        }

        private ITraktPerson CreateUserCustomListItemsPostPerson(ITraktPerson person)
        {
            return new TraktPerson
            {
                Ids = person.Ids
            };
        }
    }
}
