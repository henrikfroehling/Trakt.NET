namespace TraktNet.Objects.Post
{
    using Capabilities;
    using Get.Users;
    using Post.Users.HiddenItems;
    using System.Collections.Generic;

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
