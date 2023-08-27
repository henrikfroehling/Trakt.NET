namespace TraktNet.PostBuilder
{
    using Objects.Get.Lists;
    using Objects.Post.Comments;
    using System;

    public interface ITraktListCommentPostBuilder : ITraktCommentPostBuilder<ITraktListCommentPostBuilder, ITraktListCommentPost>
    {
        /// <summary>Adds the given <paramref name="list"/> to the builder.</summary>
        /// <param name="list">The <see cref="ITraktList"/> which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktListCommentPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="list"/> is null.</exception>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="list"/>s ids are null.</exception>
        /// <exception cref="ArgumentException">Thrown, if the given <paramref name="list"/>s ids are not valid.</exception>
        /// <remarks>Overrides values already set by <see cref="WithList(ITraktListIds)"/>.</remarks>
        ITraktListCommentPostBuilder WithList(ITraktList list);

        /// <summary>Adds the given <paramref name="listIds"/> to the builder.</summary>
        /// <param name="listIds">The <see cref="ITraktListIds"/> which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktListCommentPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="listIds"/> is null.</exception>
        /// <exception cref="ArgumentException">Thrown, if the given <paramref name="listIds"/>s are not valid.</exception>
        /// <remarks>Overrides values already set by <see cref="WithList(ITraktList)"/>.</remarks>
        ITraktListCommentPostBuilder WithList(ITraktListIds listIds);
    }
}
