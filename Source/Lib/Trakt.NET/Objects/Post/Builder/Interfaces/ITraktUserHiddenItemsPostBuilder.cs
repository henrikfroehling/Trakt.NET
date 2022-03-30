namespace TraktNet.Objects.Post
{
    using Capabilities;
    using Post.Users.HiddenItems;

    public interface ITraktUserHiddenItemsPostBuilder
        : ITraktPostBuilder<ITraktUserHiddenItemsPost>,
          ITraktPostBuilderWithMovie<ITraktUserHiddenItemsPostBuilder, ITraktUserHiddenItemsPost>,
          ITraktPostBuilderWithMovies<ITraktUserHiddenItemsPostBuilder, ITraktUserHiddenItemsPost>,
          ITraktPostBuilderWithShow<ITraktUserHiddenItemsPostBuilder, ITraktUserHiddenItemsPost>,
          ITraktPostBuilderWithShows<ITraktUserHiddenItemsPostBuilder, ITraktUserHiddenItemsPost>,
          ITraktPostBuilderShowWithSeasons<ITraktUserHiddenItemsPostBuilder, ITraktUserHiddenItemsPost>,
          ITraktPostBuilderWithSeason<ITraktUserHiddenItemsPostBuilder, ITraktUserHiddenItemsPost>,
          ITraktPostBuilderWithSeasons<ITraktUserHiddenItemsPostBuilder, ITraktUserHiddenItemsPost>
    {
    }
}
