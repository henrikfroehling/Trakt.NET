namespace TraktNet.Objects.Post.Builder.Interfaces
{
    using Capabilities;
    using Post.Users.CustomListItems;

    public interface ITraktUserCustomListItemsPostBuilder
        : ITraktPostBuilder<ITraktUserCustomListItemsPost>,
          ITraktPostBuilderWithMovie<ITraktUserCustomListItemsPostBuilder, ITraktUserCustomListItemsPost>,
          ITraktPostBuilderWithPerson<ITraktUserCustomListItemsPostBuilder, ITraktUserCustomListItemsPost>,
          ITraktPostBuilderAddShowWithSeasonsCollection<ITraktUserCustomListItemsPostBuilder, ITraktUserCustomListItemsPost, PostSeasons>,
          ITraktPostBuilderWithShows<ITraktUserCustomListItemsPostBuilder, ITraktUserCustomListItemsPost>
    {
    }
}
