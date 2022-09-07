namespace TraktNet.Objects.Post
{
    using Capabilities;
    using Get.Movies;
    using Get.People;
    using Get.Shows;
    using Helper;
    using Post.Users.PersonalListItems;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal sealed class UserPersonalListItemsPostBuilder : ITraktUserPersonalListItemsPostBuilder
    {
        private readonly List<ITraktMovie> _movies;
        private readonly List<ITraktShow> _shows;
        private readonly List<ITraktPerson> _persons;
        private readonly PostBuilderShowAddedSeasons<ITraktUserPersonalListItemsPostBuilder, ITraktUserPersonalListItemsPost> _showsWithSeasons;
        private readonly PostBuilderShowAddedSeasonsCollection<ITraktUserPersonalListItemsPostBuilder, ITraktUserPersonalListItemsPost, PostSeasons> _showsWithSeasonsCollection;

        internal UserPersonalListItemsPostBuilder()
        {
            _movies = new List<ITraktMovie>();
            _shows = new List<ITraktShow>();
            _persons = new List<ITraktPerson>();
            _showsWithSeasons = new PostBuilderShowAddedSeasons<ITraktUserPersonalListItemsPostBuilder, ITraktUserPersonalListItemsPost>(this);
            _showsWithSeasonsCollection = new PostBuilderShowAddedSeasonsCollection<ITraktUserPersonalListItemsPostBuilder, ITraktUserPersonalListItemsPost, PostSeasons>(this);
        }

        public ITraktUserPersonalListItemsPostBuilder WithMovie(ITraktMovie movie)
        {
            if (movie == null)
                throw new ArgumentNullException(nameof(movie));

            _movies.Add(movie);
            return this;
        }

        public ITraktUserPersonalListItemsPostBuilder WithMovies(IEnumerable<ITraktMovie> movies)
        {
            if (movies == null)
                throw new ArgumentNullException(nameof(movies));

            _movies.AddRange(movies);
            return this;
        }

        public ITraktUserPersonalListItemsPostBuilder WithShow(ITraktShow show)
        {
            if (show == null)
                throw new ArgumentNullException(nameof(show));

            _shows.Add(show);
            return this;
        }

        public ITraktUserPersonalListItemsPostBuilder WithShows(IEnumerable<ITraktShow> shows)
        {
            if (shows == null)
                throw new ArgumentNullException(nameof(shows));

            _shows.AddRange(shows);
            return this;
        }

        public ITraktPostBuilderShowAddedSeasons<ITraktUserPersonalListItemsPostBuilder, ITraktUserPersonalListItemsPost> WithShowAndSeasons(ITraktShow show)
        {
            if (show == null)
                throw new ArgumentNullException(nameof(show));

            _showsWithSeasons.SetCurrentShow(show);
            return _showsWithSeasons;
        }

        public ITraktPostBuilderShowAddedSeasonsCollection<ITraktUserPersonalListItemsPostBuilder, ITraktUserPersonalListItemsPost, PostSeasons> WithShowAndSeasonsCollection(ITraktShow show)
        {
            if (show == null)
                throw new ArgumentNullException(nameof(show));

            _showsWithSeasonsCollection.SetCurrentShow(show);
            return _showsWithSeasonsCollection;
        }

        public ITraktUserPersonalListItemsPostBuilder WithPerson(ITraktPerson person)
        {
            if (person == null)
                throw new ArgumentNullException(nameof(person));

            _persons.Add(person);
            return this;
        }

        public ITraktUserPersonalListItemsPostBuilder WithPersons(IEnumerable<ITraktPerson> persons)
        {
            if (persons == null)
                throw new ArgumentNullException(nameof(persons));

            _persons.AddRange(persons);
            return this;
        }

        public ITraktUserPersonalListItemsPost Build()
        {
            ITraktUserPersonalListItemsPost userPersonalListItemsPost = new TraktUserPersonalListItemsPost();
            AddMovies(userPersonalListItemsPost);
            AddShows(userPersonalListItemsPost);
            AddPersons(userPersonalListItemsPost);
            return userPersonalListItemsPost;
        }

        private void AddMovies(ITraktUserPersonalListItemsPost userPersonalListItemsPost)
        {
            if (userPersonalListItemsPost.Movies == null)
                userPersonalListItemsPost.Movies = new List<ITraktUserPersonalListItemsPostMovie>();

            foreach (ITraktMovie movie in _movies)
                (userPersonalListItemsPost.Movies as List<ITraktUserPersonalListItemsPostMovie>).Add(CreateUserPersonalListItemsPostMovie(movie));
        }

        private void AddShows(ITraktUserPersonalListItemsPost userPersonalListItemsPost)
        {
            if (userPersonalListItemsPost.Shows == null)
                userPersonalListItemsPost.Shows = new List<ITraktUserPersonalListItemsPostShow>();

            foreach (ITraktShow show in _shows)
                (userPersonalListItemsPost.Shows as List<ITraktUserPersonalListItemsPostShow>).Add(CreateUserPersonalListItemsPostShow(show));

            foreach (PostBuilderObjectWithSeasons<ITraktShow, IEnumerable<int>> showEntry in _showsWithSeasons.ShowsWithSeasons)
                (userPersonalListItemsPost.Shows as List<ITraktUserPersonalListItemsPostShow>).Add(CreateUserPersonalListItemsPostShowWithSeasons(showEntry.Object, showEntry.Seasons));

            foreach (PostBuilderObjectWithSeasons<ITraktShow, PostSeasons> showEntry in _showsWithSeasonsCollection.ShowsWithSeasonsCollection)
                (userPersonalListItemsPost.Shows as List<ITraktUserPersonalListItemsPostShow>).Add(CreateUserPersonalListItemsPostShowWithSeasonsCollection(showEntry.Object, showEntry.Seasons));
        }

        private void AddPersons(ITraktUserPersonalListItemsPost userPersonalListItemsPost)
        {
            if (userPersonalListItemsPost.People == null)
                userPersonalListItemsPost.People = new List<ITraktPerson>();

            foreach (ITraktPerson episode in _persons)
                (userPersonalListItemsPost.People as List<ITraktPerson>).Add(CreateUserPersonalListItemsPostPerson(episode));
        }

        private ITraktUserPersonalListItemsPostMovie CreateUserPersonalListItemsPostMovie(ITraktMovie movie)
        {
            return new TraktUserPersonalListItemsPostMovie
            {
                Ids = movie.Ids
            };
        }

        private ITraktUserPersonalListItemsPostShow CreateUserPersonalListItemsPostShow(ITraktShow show)
        {
            return new TraktUserPersonalListItemsPostShow
            {
                Ids = show.Ids
            };
        }

        private ITraktUserPersonalListItemsPostShow CreateUserPersonalListItemsPostShowWithSeasons(ITraktShow show, IEnumerable<int> seasons)
        {
            var userPersonalListItemsPostShow = CreateUserPersonalListItemsPostShow(show);

            if (seasons != null)
                userPersonalListItemsPostShow.Seasons = CreateUserPersonalListItemsPostShowSeasons(seasons);

            return userPersonalListItemsPostShow;
        }

        private ITraktUserPersonalListItemsPostShow CreateUserPersonalListItemsPostShowWithSeasonsCollection(ITraktShow show, PostSeasons seasons)
        {
            var userPersonalListItemsPostShow = CreateUserPersonalListItemsPostShow(show);

            if (seasons != null)
                userPersonalListItemsPostShow.Seasons = CreateUserPersonalListItemsPostShowSeasons(seasons);

            return userPersonalListItemsPostShow;
        }

        private IEnumerable<ITraktUserPersonalListItemsPostShowSeason> CreateUserPersonalListItemsPostShowSeasons(IEnumerable<int> seasons)
        {
            var userPersonalListItemsPostShowSeasons = new List<ITraktUserPersonalListItemsPostShowSeason>();

            foreach (int season in seasons)
            {
                userPersonalListItemsPostShowSeasons.Add(new TraktUserPersonalListItemsPostShowSeason
                {
                    Number = season
                });
            }

            return userPersonalListItemsPostShowSeasons;
        }

        private IEnumerable<ITraktUserPersonalListItemsPostShowSeason> CreateUserPersonalListItemsPostShowSeasons(PostSeasons seasons)
        {
            var userPersonalListItemsPostShowSeasons = new List<ITraktUserPersonalListItemsPostShowSeason>();

            foreach (PostSeason season in seasons)
            {
                var userPersonalListItemsPostShowSeason = new TraktUserPersonalListItemsPostShowSeason
                {
                    Number = season.Number
                };

                if (season.Episodes?.Count() > 0)
                {
                    var userPersonalListItemsPostShowEpisodes = new List<ITraktUserPersonalListItemsPostShowEpisode>();

                    foreach (PostEpisode episode in season.Episodes)
                    {
                        userPersonalListItemsPostShowEpisodes.Add(new TraktUserPersonalListItemsPostShowEpisode
                        {
                            Number = episode.Number
                        });
                    }

                    userPersonalListItemsPostShowSeason.Episodes = userPersonalListItemsPostShowEpisodes;
                }

                userPersonalListItemsPostShowSeasons.Add(userPersonalListItemsPostShowSeason);
            }

            return userPersonalListItemsPostShowSeasons;
        }

        private ITraktPerson CreateUserPersonalListItemsPostPerson(ITraktPerson person)
        {
            return new TraktPerson
            {
                Ids = person.Ids
            };
        }
    }
}
