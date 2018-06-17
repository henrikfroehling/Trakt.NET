namespace TraktApiSharp.Objects.Post.Users.HiddenItems
{
    using Get.Shows;
    using System.Collections.Generic;

    public class TraktUserHiddenItemsPostShow : ITraktUserHiddenItemsPostShow
    {
        public string Title { get; set; }

        public int? Year { get; set; }

        public ITraktShowIds Ids { get; set; }

        public IEnumerable<ITraktUserHiddenItemsPostShowSeason> Seasons { get; set; }
    }
}
