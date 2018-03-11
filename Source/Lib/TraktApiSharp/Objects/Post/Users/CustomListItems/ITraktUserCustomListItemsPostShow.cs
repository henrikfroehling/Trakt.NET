namespace TraktApiSharp.Objects.Post.Users.CustomListItems
{
    using Get.Shows;
    using System.Collections.Generic;

    public interface ITraktUserCustomListItemsPostShow
    {
        ITraktShowIds Ids { get; set; }

        IEnumerable<ITraktUserCustomListItemsPostShowSeason> Seasons { get; set; }
    }
}
