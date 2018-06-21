namespace TraktNet.Objects.Post.Users.HiddenItems
{
    using Get.Shows;
    using System.Collections.Generic;

    public interface ITraktUserHiddenItemsPostShow
    {
        string Title { get; set; }

        int? Year { get; set; }

        ITraktShowIds Ids { get; set; }

        IEnumerable<ITraktUserHiddenItemsPostShowSeason> Seasons { get; set; }
    }
}
