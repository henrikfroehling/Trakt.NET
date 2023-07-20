namespace TraktNet.Objects.Post.Basic
{
    using Requests.Interfaces;

    public interface ITraktListItemUpdatePost : IRequestBody
    {
        string Notes { get; set; }
    }
}
