namespace TraktNet.Objects.Post.Builder.Implementation
{
    using Interfaces;
    using Objects.Get.Movies;
    using Objects.Get.People;
    using Objects.Get.Shows;
    using Objects.Post.Builder.Interfaces.Capabilities;
    using Objects.Post.Users.CustomListItems;
    using System.Collections.Generic;

    public class TraktUserCustomListItemsPostBuilder : ITraktUserCustomListItemsPostBuilder
    {
        internal TraktUserCustomListItemsPostBuilder()
        {
        }

        public ITraktPostBuilderShowAddedSeasonsCollection<ITraktPostBuilderAddShowWithSeasonsCollection<ITraktUserCustomListItemsPostBuilder, ITraktUserCustomListItemsPost, PostSeasons>, ITraktUserCustomListItemsPost, PostSeasons> AddShow(ITraktShow show)
        {
            throw new System.NotImplementedException();
        }

        public ITraktUserCustomListItemsPost Build()
        {
            throw new System.NotImplementedException();
        }

        public ITraktUserCustomListItemsPostBuilder WithMovie(ITraktMovie movie)
        {
            throw new System.NotImplementedException();
        }

        public ITraktUserCustomListItemsPostBuilder WithMovies(IEnumerable<ITraktMovie> movies)
        {
            throw new System.NotImplementedException();
        }

        public ITraktUserCustomListItemsPostBuilder WithPerson(ITraktPerson person)
        {
            throw new System.NotImplementedException();
        }

        public ITraktUserCustomListItemsPostBuilder WithPersons(IEnumerable<ITraktPerson> persons)
        {
            throw new System.NotImplementedException();
        }

        public ITraktPostBuilderAddShowWithSeasonsCollection<ITraktUserCustomListItemsPostBuilder, ITraktUserCustomListItemsPost, PostSeasons> WithShow(ITraktShow show)
        {
            throw new System.NotImplementedException();
        }

        public ITraktUserCustomListItemsPostBuilder WithShows(IEnumerable<ITraktShow> shows)
        {
            throw new System.NotImplementedException();
        }

        ITraktUserCustomListItemsPostBuilder ITraktPostBuilderWithShow<ITraktUserCustomListItemsPostBuilder, ITraktUserCustomListItemsPost>.WithShow(ITraktShow show)
        {
            throw new System.NotImplementedException();
        }
    }
}
