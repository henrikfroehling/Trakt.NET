namespace TraktNet.Objects.Post.Users.HiddenItems
{
    using Get.Seasons;

    public class TraktUserHiddenItemsPostSeason : ITraktUserHiddenItemsPostSeason
    {
        public ITraktSeasonIds Ids { get; set; }
    }
}
