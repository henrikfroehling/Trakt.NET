namespace TraktApiSharp.Objects.Post.Comments.Implementations
{
    using System.Net.Http;

    /// <summary>A comment update post.</summary>
    public class TraktCommentUpdatePost : ITraktCommentUpdatePost
    {
        /// <summary>Gets or sets the required comment's content.</summary>
        public string Comment { get; set; }

        /// <summary>Gets or sets, whether the comment contains spoiler.</summary>
        public bool? Spoiler { get; set; }

        public virtual string HttpContentAsString => throw new System.NotImplementedException();

        public virtual HttpContent ToHttpContent() => throw new System.NotImplementedException();

        public virtual void Validate() => throw new System.NotImplementedException();
    }
}
