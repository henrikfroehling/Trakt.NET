namespace TraktNet.Objects.Post.Builder.Implementation
{
    using Helper;
    using Interfaces;
    using Interfaces.Capabilities;
    using Objects.Get.Movies;
    using Objects.Get.People;
    using Objects.Get.Shows;
    using Objects.Post.Users.CustomListItems;
    using System.Collections.Generic;

    public class TraktUserCustomListItemsPostBuilder : ITraktUserCustomListItemsPostBuilder
    {
        private readonly List<ITraktMovie> _movies;
        private readonly List<ITraktShow> _shows;
        private readonly List<ITraktPerson> _persons;
        private readonly ITraktPostBuilderShowAddedSeasons<ITraktUserCustomListItemsPostBuilder, ITraktUserCustomListItemsPost> _showsWithSeasons;
        private readonly ITraktPostBuilderShowAddedSeasonsCollection<ITraktUserCustomListItemsPostBuilder, ITraktUserCustomListItemsPost, PostSeasons> _showsWithSeasonsCollection;

        internal TraktUserCustomListItemsPostBuilder()
        {
            _movies = new List<ITraktMovie>();
            _shows = new List<ITraktShow>();
            _persons = new List<ITraktPerson>();
            _showsWithSeasons = new PostBuilderShowAddedSeasons<ITraktUserCustomListItemsPostBuilder, ITraktUserCustomListItemsPost>(this);
            _showsWithSeasonsCollection = new PostBuilderShowAddedSeasonsCollection<ITraktUserCustomListItemsPostBuilder, ITraktUserCustomListItemsPost, PostSeasons>(this);
        }

        public ITraktUserCustomListItemsPostBuilder WithMovie(ITraktMovie movie)
        {
            _movies.Add(movie);
            return this;
        }

        public ITraktUserCustomListItemsPostBuilder WithMovies(IEnumerable<ITraktMovie> movies)
        {
            _movies.AddRange(movies);
            return this;
        }

        public ITraktUserCustomListItemsPostBuilder WithShow(ITraktShow show)
        {
            _shows.Add(show);
            return this;
        }

        public ITraktUserCustomListItemsPostBuilder WithShows(IEnumerable<ITraktShow> shows)
        {
            _shows.AddRange(shows);
            return this;
        }

        public ITraktPostBuilderShowAddedSeasons<ITraktUserCustomListItemsPostBuilder, ITraktUserCustomListItemsPost> AddShowAndSeasons(ITraktShow show)
        {
            _showsWithSeasons.SetCurrentShow(show);
            return _showsWithSeasons;
        }

        public ITraktPostBuilderShowAddedSeasonsCollection<ITraktUserCustomListItemsPostBuilder, ITraktUserCustomListItemsPost, PostSeasons> AddShowAndSeasonsCollection(ITraktShow show)
        {
            _showsWithSeasonsCollection.SetCurrentShow(show);
            return _showsWithSeasonsCollection;
        }

        public ITraktUserCustomListItemsPostBuilder WithPerson(ITraktPerson person)
        {
            _persons.Add(person);
            return this;
        }

        public ITraktUserCustomListItemsPostBuilder WithPersons(IEnumerable<ITraktPerson> persons)
        {
            _persons.AddRange(persons);
            return this;
        }

        public ITraktUserCustomListItemsPost Build()
        {
            return new TraktUserCustomListItemsPost();
        }
    }
}
