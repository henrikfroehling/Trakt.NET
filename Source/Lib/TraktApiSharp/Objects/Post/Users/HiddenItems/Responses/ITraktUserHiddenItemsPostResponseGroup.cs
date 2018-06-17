namespace TraktApiSharp.Objects.Post.Users.HiddenItems.Responses
{
    public interface ITraktUserHiddenItemsPostResponseGroup
    {
        int? Movies { get; set; }

        int? Shows { get; set; }

        int? Seasons { get; set; }
    }
}
