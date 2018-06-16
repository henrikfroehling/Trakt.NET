namespace TraktApiSharp.Objects.Post.Users
{
    using Enums;
    using Requests.Interfaces;

    public interface ITraktUserCustomListPost : IRequestBody
    {
        string Name { get; set; }

        string Description { get; set; }

        TraktAccessScope Privacy { get; set; }

        bool? DisplayNumbers { get; set; }

        bool? AllowComments { get; set; }

        string SortBy { get; set; }

        string SortHow { get; set; }
    }
}
