namespace TraktNet.PostBuilder
{
    using System.Collections.Generic;
    using TraktNet.Objects.Get.Users;
    using TraktNet.Objects.Post.Users.HiddenItems;

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
        ITraktUserHiddenItemsPostBuilder WithUser(ITraktUser user);

        ITraktUserHiddenItemsPostBuilder WithUsers(IEnumerable<ITraktUser> users);
    }
}
