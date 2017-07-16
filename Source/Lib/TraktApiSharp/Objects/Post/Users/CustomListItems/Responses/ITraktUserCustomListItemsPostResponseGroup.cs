namespace TraktApiSharp.Objects.Post.Users.CustomListItems.Responses
{
    public interface ITraktUserCustomListItemsPostResponseGroup
    {
        int? Movies { get; set; }

        int? Shows { get; set; }

        int? Seasons { get; set; }

        int? Episodes { get; set; }

        int? People { get; set; }
    }
}
