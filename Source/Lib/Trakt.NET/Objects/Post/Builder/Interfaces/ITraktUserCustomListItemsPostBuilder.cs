namespace TraktNet.Objects.Post
{
    using Capabilities;
    using Post.Users.CustomListItems;

    public interface ITraktUserCustomListItemsPostBuilder
        : ITraktPostBuilder<ITraktUserCustomListItemsPost>,
          ITraktPostBuilderWithMovie<ITraktUserCustomListItemsPostBuilder, ITraktUserCustomListItemsPost>,
          ITraktPostBuilderWithMovies<ITraktUserCustomListItemsPostBuilder, ITraktUserCustomListItemsPost>,
          ITraktPostBuilderWithPerson<ITraktUserCustomListItemsPostBuilder, ITraktUserCustomListItemsPost>,
          ITraktPostBuilderWithPersons<ITraktUserCustomListItemsPostBuilder, ITraktUserCustomListItemsPost>,
          ITraktPostBuilderWithShow<ITraktUserCustomListItemsPostBuilder, ITraktUserCustomListItemsPost>,
          ITraktPostBuilderWithShows<ITraktUserCustomListItemsPostBuilder, ITraktUserCustomListItemsPost>,
          ITraktPostBuilderShowWithSeasons<ITraktUserCustomListItemsPostBuilder, ITraktUserCustomListItemsPost>,
          ITraktPostBuilderShowWithSeasonsCollection<ITraktUserCustomListItemsPostBuilder, ITraktUserCustomListItemsPost, PostSeasons>
    {
    }
}
