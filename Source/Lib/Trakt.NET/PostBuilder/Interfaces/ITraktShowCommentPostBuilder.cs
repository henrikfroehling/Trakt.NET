namespace TraktNet.PostBuilder
{
    using Objects.Get.Shows;
    using Objects.Post.Comments;
    using System;

    public interface ITraktShowCommentPostBuilder : ITraktCommentPostBuilder<ITraktShowCommentPostBuilder, ITraktShowCommentPost>
    {
        /// <summary>Adds the given <paramref name="show"/> to the builder.</summary>
        /// <param name="show">The <see cref="ITraktShow"/> which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktShowCommentPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="show"/> is null.</exception>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="show"/>s ids are null.</exception>
        /// <exception cref="ArgumentException">Thrown, if the given <paramref name="show"/>s ids are not valid.</exception>
        /// <remarks>Overrides values already set by <see cref="WithShow(ITraktShowIds)"/>.</remarks>
        ITraktShowCommentPostBuilder WithShow(ITraktShow show);

        /// <summary>Adds the given <paramref name="showIds"/> to the builder.</summary>
        /// <param name="showIds">The <see cref="ITraktShow"/> which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktShowCommentPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="showIds"/> is null.</exception>
        /// <exception cref="ArgumentException">Thrown, if the given <paramref name="showIds"/>s are not valid.</exception>
        /// <remarks>Overrides values already set by <see cref="WithShow(ITraktShow)"/>.</remarks>
        ITraktShowCommentPostBuilder WithShow(ITraktShowIds showIds);
    }
}
