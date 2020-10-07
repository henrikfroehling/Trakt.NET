namespace TraktNet.Objects.Post.Builder.Interfaces
{
    using Capabilities;
    using Post.Users.HiddenItems;

    public interface ITraktUserHiddenItemsPostBuilder
        : ITraktPostBuilder<ITraktUserHiddenItemsPost>,
          ITraktPostBuilderWithMovie<ITraktUserHiddenItemsPostBuilder, ITraktUserHiddenItemsPost>,
          ITraktPostBuilderAddShowWithSeasons<ITraktUserHiddenItemsPostBuilder, ITraktUserHiddenItemsPost>,
          ITraktPostBuilderWithShows<ITraktUserHiddenItemsPostBuilder, ITraktUserHiddenItemsPost>,
          ITraktPostBuilderWithSeason<ITraktUserHiddenItemsPostBuilder, ITraktUserHiddenItemsPost>
    {
    }
}
