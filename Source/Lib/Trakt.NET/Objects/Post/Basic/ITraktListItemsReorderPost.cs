namespace TraktNet.Objects.Post.Basic
{
    using Requests.Interfaces;
    using System.Collections.Generic;

    public interface ITraktListItemsReorderPost : IRequestBody
    {
        IEnumerable<uint> Rank { get; set; }
    }
}
