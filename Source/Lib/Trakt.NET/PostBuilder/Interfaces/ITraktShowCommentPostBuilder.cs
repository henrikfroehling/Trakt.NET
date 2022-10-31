namespace TraktNet.PostBuilder
{
    using System;
    using TraktNet.Objects.Get.Shows;
    using TraktNet.Objects.Post.Comments;

    public interface ITraktShowCommentPostBuilder : ITraktCommentPostBuilder<ITraktShowCommentPostBuilder, ITraktShowCommentPost>
    {
        /// <summary>Adds the given <paramref name="show"/> to the builder.</summary>
        /// <param name="show">The <see cref="ITraktShow"/> which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktShowCommentPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="show"/> is null.</exception>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="show"/>s ids are null.</exception>
        /// <exception cref="ArgumentException">Thrown, if the given <paramref name="show"/>s ids are not valid.</exception>
        ITraktShowCommentPostBuilder WithShow(ITraktShow show);
    }
}
