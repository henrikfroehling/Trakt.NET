namespace TraktNet.Objects.Post.Users
{
    using Requests.Interfaces;
    using System.Collections.Generic;

    public interface ITraktUserCustomListsReorderPost : IRequestBody
    {
        IEnumerable<uint> Rank { get; set; }
    }
}
