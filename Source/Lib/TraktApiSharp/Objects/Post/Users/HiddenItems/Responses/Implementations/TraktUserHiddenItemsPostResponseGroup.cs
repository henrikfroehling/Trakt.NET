namespace TraktNet.Objects.Post.Users.HiddenItems.Responses
{
    public class TraktUserHiddenItemsPostResponseGroup : ITraktUserHiddenItemsPostResponseGroup
    {
        public int? Movies { get; set; }

        public int? Shows { get; set; }

        public int? Seasons { get; set; }
    }
}
