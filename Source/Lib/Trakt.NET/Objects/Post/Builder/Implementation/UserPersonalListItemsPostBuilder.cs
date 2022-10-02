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
        private readonly List<PostBuilderObjectWithNotes<ITraktMovie>> _moviesWithNotes;
        private readonly List<ITraktShow> _shows;
        private readonly List<PostBuilderObjectWithNotes<ITraktShow>> _showsWithNotes;
        private readonly List<ITraktPerson> _persons;
        private readonly PostBuilderShowAddedSeasons<ITraktUserPersonalListItemsPostBuilder, ITraktUserPersonalListItemsPost> _showsWithSeasons;
        private readonly PostBuilderShowAddedSeasonsCollection<ITraktUserPersonalListItemsPostBuilder, ITraktUserPersonalListItemsPost, PostSeasonsOld> _showsWithSeasonsCollection;

        internal UserPersonalListItemsPostBuilder()
        {
            _movies = new List<ITraktMovie>();
            _moviesWithNotes = new List<PostBuilderObjectWithNotes<ITraktMovie>>();
            _shows = new List<ITraktShow>();
            _showsWithNotes = new List<PostBuilderObjectWithNotes<ITraktShow>>();
            _persons = new List<ITraktPerson>();
            _showsWithSeasons = new PostBuilderShowAddedSeasons<ITraktUserPersonalListItemsPostBuilder, ITraktUserPersonalListItemsPost>(this);
            _showsWithSeasonsCollection = new PostBuilderShowAddedSeasonsCollection<ITraktUserPersonalListItemsPostBuilder, ITraktUserPersonalListItemsPost, PostSeasonsOld>(this);
        }

        public ITraktUserPersonalListItemsPostBuilder WithMovie(ITraktMovie movie)
        {
            if (movie == null)
                throw new ArgumentNullException(nameof(movie));

            _movies.Add(movie);
            return this;
        }

        public ITraktUserPersonalListItemsPostBuilder WithMovieWithNotes(ITraktMovie movie, string notes)
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

        public ITraktUserPersonalListItemsPostBuilder WithMovies(IEnumerable<ITraktMovie> movies)
        {
            if (movies == null)
                throw new ArgumentNullException(nameof(movies));

            _movies.AddRange(movies);
            return this;
        }

        public ITraktUserPersonalListItemsPostBuilder WithMoviesWithNotes(IEnumerable<Tuple<ITraktMovie, string>> movies)
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

        public ITraktUserPersonalListItemsPostBuilder WithShow(ITraktShow show)
        {
            if (show == null)
                throw new ArgumentNullException(nameof(show));

            _shows.Add(show);
            return this;
        }

        public ITraktUserPersonalListItemsPostBuilder WithShowWithNotes(ITraktShow show, string notes)
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

        public ITraktUserPersonalListItemsPostBuilder WithShows(IEnumerable<ITraktShow> shows)
        {
            if (shows == null)
                throw new ArgumentNullException(nameof(shows));

            _shows.AddRange(shows);
            return this;
        }

        public ITraktUserPersonalListItemsPostBuilder WithShowsWithNotes(IEnumerable<Tuple<ITraktShow, string>> shows)
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

        public ITraktPostBuilderShowAddedSeasons<ITraktUserPersonalListItemsPostBuilder, ITraktUserPersonalListItemsPost> WithShowAndSeasons(ITraktShow show)
        {
            if (show == null)
                throw new ArgumentNullException(nameof(show));

            _showsWithSeasons.SetCurrentShow(show);
            return _showsWithSeasons;
        }

        public ITraktPostBuilderShowAddedSeasonsCollection<ITraktUserPersonalListItemsPostBuilder, ITraktUserPersonalListItemsPost, PostSeasonsOld> WithShowAndSeasonsCollection(ITraktShow show)
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
            userPersonalListItemsPost.Validate();
            return userPersonalListItemsPost;
        }

        private void AddMovies(ITraktUserPersonalListItemsPost userPersonalListItemsPost)
        {
            userPersonalListItemsPost.Movies ??= new List<ITraktUserPersonalListItemsPostMovie>();

            foreach (ITraktMovie movie in _movies)
                (userPersonalListItemsPost.Movies as List<ITraktUserPersonalListItemsPostMovie>).Add(CreateUserPersonalListItemsPostMovie(movie));

            foreach (PostBuilderObjectWithNotes<ITraktMovie> movieWithNotes in _moviesWithNotes)
                (userPersonalListItemsPost.Movies as List<ITraktUserPersonalListItemsPostMovie>).Add(CreateUserPersonalListItemsPostMovie(movieWithNotes.Object, movieWithNotes.Notes));
        }

        private void AddShows(ITraktUserPersonalListItemsPost userPersonalListItemsPost)
        {
            userPersonalListItemsPost.Shows ??= new List<ITraktUserPersonalListItemsPostShow>();

            foreach (ITraktShow show in _shows)
                (userPersonalListItemsPost.Shows as List<ITraktUserPersonalListItemsPostShow>).Add(CreateUserPersonalListItemsPostShow(show));

            foreach (PostBuilderObjectWithSeasons<ITraktShow, IEnumerable<int>> showEntry in _showsWithSeasons.ShowsWithSeasons)
                (userPersonalListItemsPost.Shows as List<ITraktUserPersonalListItemsPostShow>).Add(CreateUserPersonalListItemsPostShowWithSeasons(showEntry.Object, showEntry.Seasons));

            foreach (PostBuilderObjectWithSeasons<ITraktShow, PostSeasonsOld> showEntry in _showsWithSeasonsCollection.ShowsWithSeasonsCollection)
                (userPersonalListItemsPost.Shows as List<ITraktUserPersonalListItemsPostShow>).Add(CreateUserPersonalListItemsPostShowWithSeasonsCollection(showEntry.Object, showEntry.Seasons));

            foreach (PostBuilderObjectWithNotes<ITraktShow> showWithNotes in _showsWithNotes)
                (userPersonalListItemsPost.Shows as List<ITraktUserPersonalListItemsPostShow>).Add(CreateUserPersonalListItemsPostShow(showWithNotes.Object, showWithNotes.Notes));
        }

        private void AddPersons(ITraktUserPersonalListItemsPost userPersonalListItemsPost)
        {
            userPersonalListItemsPost.People ??= new List<ITraktPerson>();

            foreach (ITraktPerson episode in _persons)
                (userPersonalListItemsPost.People as List<ITraktPerson>).Add(CreateUserPersonalListItemsPostPerson(episode));
        }

        private ITraktUserPersonalListItemsPostMovie CreateUserPersonalListItemsPostMovie(ITraktMovie movie, string notes = null)
        {
            var userPersonalListItemsPostMovie = new TraktUserPersonalListItemsPostMovie
            {
                Ids = movie.Ids
            };

            if (!string.IsNullOrWhiteSpace(notes))
                userPersonalListItemsPostMovie.Notes = notes;

            return userPersonalListItemsPostMovie;
        }

        private ITraktUserPersonalListItemsPostShow CreateUserPersonalListItemsPostShow(ITraktShow show, string notes = null)
        {
            var userPersonalListItemsPostShow = new TraktUserPersonalListItemsPostShow
            {
                Ids = show.Ids
            };

            if (!string.IsNullOrWhiteSpace(notes))
                userPersonalListItemsPostShow.Notes = notes;

            return userPersonalListItemsPostShow;
        }

        private ITraktUserPersonalListItemsPostShow CreateUserPersonalListItemsPostShowWithSeasons(ITraktShow show, IEnumerable<int> seasons)
        {
            var userPersonalListItemsPostShow = CreateUserPersonalListItemsPostShow(show);

            if (seasons != null)
                userPersonalListItemsPostShow.Seasons = CreateUserPersonalListItemsPostShowSeasons(seasons);

            return userPersonalListItemsPostShow;
        }

        private ITraktUserPersonalListItemsPostShow CreateUserPersonalListItemsPostShowWithSeasonsCollection(ITraktShow show, PostSeasonsOld seasons)
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

        private IEnumerable<ITraktUserPersonalListItemsPostShowSeason> CreateUserPersonalListItemsPostShowSeasons(PostSeasonsOld seasons)
        {
            var userPersonalListItemsPostShowSeasons = new List<ITraktUserPersonalListItemsPostShowSeason>();

            foreach (PostSeasonOld season in seasons)
            {
                var userPersonalListItemsPostShowSeason = new TraktUserPersonalListItemsPostShowSeason
                {
                    Number = season.Number
                };

                if (season.Episodes?.Count() > 0)
                {
                    var userPersonalListItemsPostShowEpisodes = new List<ITraktUserPersonalListItemsPostShowEpisode>();

                    foreach (PostEpisodeOld episode in season.Episodes)
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
