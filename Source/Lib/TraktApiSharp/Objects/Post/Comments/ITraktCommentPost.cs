namespace TraktApiSharp.Objects.Post.Comments
{
    using Basic;
    using Requests.Interfaces;

    public interface ITraktCommentPost : IRequestBody
    {
        string Comment { get; set; }

        bool? Spoiler { get; set; }

        ITraktSharing Sharing { get; set; }
    }
}
