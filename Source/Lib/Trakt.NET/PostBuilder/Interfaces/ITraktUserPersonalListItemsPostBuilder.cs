namespace TraktNet.PostBuilder
{
    using TraktNet.Objects.Post.Users.PersonalListItems;

    public interface ITraktUserPersonalListItemsPostBuilder
        : ITraktPostBuilder<ITraktUserPersonalListItemsPost>,
          ITraktPostBuilderWithMovie<ITraktUserPersonalListItemsPostBuilder, ITraktUserPersonalListItemsPost>,
          ITraktPostBuilderWithMovies<ITraktUserPersonalListItemsPostBuilder, ITraktUserPersonalListItemsPost>,
          ITraktPostBuilderMovieWithNotes<ITraktUserPersonalListItemsPostBuilder, ITraktUserPersonalListItemsPost>,
          ITraktPostBuilderWithMoviesWithNotes<ITraktUserPersonalListItemsPostBuilder, ITraktUserPersonalListItemsPost>,
          ITraktPostBuilderWithPerson<ITraktUserPersonalListItemsPostBuilder, ITraktUserPersonalListItemsPost>,
          ITraktPostBuilderWithPersons<ITraktUserPersonalListItemsPostBuilder, ITraktUserPersonalListItemsPost>,
          ITraktPostBuilderWithShow<ITraktUserPersonalListItemsPostBuilder, ITraktUserPersonalListItemsPost>,
          ITraktPostBuilderWithShows<ITraktUserPersonalListItemsPostBuilder, ITraktUserPersonalListItemsPost>,
          ITraktPostBuilderShowWithSeasons<ITraktUserPersonalListItemsPostBuilder, ITraktUserPersonalListItemsPost>,
          ITraktPostBuilderShowWithSeasonsCollection<ITraktUserPersonalListItemsPostBuilder, ITraktUserPersonalListItemsPost, PostSeasonsOld>,
          ITraktPostBuilderShowWithNotes<ITraktUserPersonalListItemsPostBuilder, ITraktUserPersonalListItemsPost>,
          ITraktPostBuilderWithShowsWithNotes<ITraktUserPersonalListItemsPostBuilder, ITraktUserPersonalListItemsPost>
    {
    }
}
