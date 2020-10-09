namespace TraktNet.Objects.Post.Builder.Interfaces
{
    using Capabilities;
    using Post.Users.HiddenItems;

    public interface ITraktUserHiddenItemsPostBuilder
        : ITraktPostBuilder<ITraktUserHiddenItemsPost>,
          ITraktPostBuilderWithMovie<ITraktUserHiddenItemsPostBuilder, ITraktUserHiddenItemsPost>,
          ITraktPostBuilderWithMovies<ITraktUserHiddenItemsPostBuilder, ITraktUserHiddenItemsPost>,
          ITraktPostBuilderWithShow<ITraktUserHiddenItemsPostBuilder, ITraktUserHiddenItemsPost>,
          ITraktPostBuilderWithShows<ITraktUserHiddenItemsPostBuilder, ITraktUserHiddenItemsPost>,
          ITraktPostBuilderAddShowWithSeasons<ITraktUserHiddenItemsPostBuilder, ITraktUserHiddenItemsPost>,
          ITraktPostBuilderWithSeason<ITraktUserHiddenItemsPostBuilder, ITraktUserHiddenItemsPost>,
          ITraktPostBuilderWithSeasons<ITraktUserHiddenItemsPostBuilder, ITraktUserHiddenItemsPost>
    {
    }
}
