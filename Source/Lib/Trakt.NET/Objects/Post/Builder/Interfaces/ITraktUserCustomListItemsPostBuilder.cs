namespace TraktNet.Objects.Post.Builder.Interfaces
{
    using Capabilities;
    using Post.Users.CustomListItems;

    public interface ITraktUserCustomListItemsPostBuilder
        : ITraktPostBuilder<ITraktUserCustomListItemsPost>,
          ITraktPostBuilderWithMovie<ITraktUserCustomListItemsPostBuilder, ITraktUserCustomListItemsPost>,
          ITraktPostBuilderWithPerson<ITraktUserCustomListItemsPostBuilder, ITraktUserCustomListItemsPost>,
          ITraktPostBuilderWithShow<ITraktUserCustomListItemsPostBuilder, ITraktUserCustomListItemsPost>,
          ITraktPostBuilderWithShows<ITraktUserCustomListItemsPostBuilder, ITraktUserCustomListItemsPost>
    {
    }
}
