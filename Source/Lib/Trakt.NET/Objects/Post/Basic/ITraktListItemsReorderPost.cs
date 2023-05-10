namespace TraktNet.Objects.Post.Basic
{
    using Requests.Interfaces;
    using System.Collections.Generic;

    public interface ITraktListItemsReorderPost : IRequestBody
    {
        IList<uint> Rank { get; set; }
    }
}
