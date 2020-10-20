namespace TraktNet.Objects.Post.Builder
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
          ITraktPostBuilderAddShowWithSeasons<ITraktUserCustomListItemsPostBuilder, ITraktUserCustomListItemsPost>,
          ITraktPostBuilderAddShowWithSeasonsCollection<ITraktUserCustomListItemsPostBuilder, ITraktUserCustomListItemsPost, PostSeasons>
    {
    }
}
