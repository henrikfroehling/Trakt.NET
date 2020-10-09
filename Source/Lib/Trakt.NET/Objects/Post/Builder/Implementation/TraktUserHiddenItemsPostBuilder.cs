namespace TraktNet.Objects.Post.Builder.Implementation
{
    using Interfaces;
    using Objects.Get.Movies;
    using Objects.Get.Seasons;
    using Objects.Get.Shows;
    using Objects.Post.Builder.Interfaces.Capabilities;
    using Objects.Post.Users.HiddenItems;
    using System.Collections.Generic;

    public class TraktUserHiddenItemsPostBuilder : ITraktUserHiddenItemsPostBuilder
    {
        internal TraktUserHiddenItemsPostBuilder()
        {
        }

        public ITraktPostBuilderShowAddedSeasons<ITraktUserHiddenItemsPostBuilder, ITraktUserHiddenItemsPost> AddShowAndSeasons(ITraktShow show)
        {
            throw new System.NotImplementedException();
        }

        public ITraktUserHiddenItemsPost Build()
        {
            throw new System.NotImplementedException();
        }

        public ITraktUserHiddenItemsPostBuilder WithMovie(ITraktMovie movie)
        {
            throw new System.NotImplementedException();
        }

        public ITraktUserHiddenItemsPostBuilder WithMovies(IEnumerable<ITraktMovie> movies)
        {
            throw new System.NotImplementedException();
        }

        public ITraktUserHiddenItemsPostBuilder WithSeason(ITraktSeason season)
        {
            throw new System.NotImplementedException();
        }

        public ITraktUserHiddenItemsPostBuilder WithSeasons(IEnumerable<ITraktSeason> seasons)
        {
            throw new System.NotImplementedException();
        }

        public ITraktUserHiddenItemsPostBuilder WithShow(ITraktShow show)
        {
            throw new System.NotImplementedException();
        }

        public ITraktUserHiddenItemsPostBuilder WithShows(IEnumerable<ITraktShow> shows)
        {
            throw new System.NotImplementedException();
        }
    }
}
