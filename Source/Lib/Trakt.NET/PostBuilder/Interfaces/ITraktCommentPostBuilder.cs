namespace TraktNet.PostBuilder
{
    using Exceptions;
    using Objects.Basic;
    using Objects.Post.Comments;
    using System;

    public interface ITraktCommentPostBuilder<TPostBuilder, out TPostObject>
        where TPostBuilder : ITraktCommentPostBuilder<TPostBuilder, TPostObject>
        where TPostObject : ITraktCommentPost
    {
        /// <summary>Adds the given <paramref name="comment"/> to the builder.</summary>
        /// <param name="comment">The comment which will be added.</param>
        /// <returns>Returns a reference to itself. See also <typeparamref name="TPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="comment"/> is null.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown, if the given <paramref name="comment"/> is too short.</exception>
        TPostBuilder WithComment(string comment);

        /// <summary>Sets whether a comment has spoilers.</summary>
        /// <param name="hasSpoiler">True, if a comment contains spoilers, false otherwise.</param>
        /// <returns>Returns a reference to itself. See also <typeparamref name="TPostBuilder"/>.</returns>
        TPostBuilder WithSpoiler(bool hasSpoiler = true);

        /// <summary>Adds the given <paramref name="sharing"/> to the builder.</summary>
        /// <param name="sharing">The <see cref="ITraktConnections"/> which will be added.</param>
        /// <returns>Returns a reference to itself. See also <typeparamref name="TPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="sharing"/> is null.</exception>
        TPostBuilder WithSharing(ITraktConnections sharing);

        /// <summary>Creates a new <typeparamref name="TPostObject"/> instance.</summary>
        /// <returns>A new <typeparamref name="TPostObject"/> instance.</returns>
        /// <exception cref="TraktPostValidationException">Thrown, if the post object is empty.</exception>
        TPostObject Build();
    }
}
