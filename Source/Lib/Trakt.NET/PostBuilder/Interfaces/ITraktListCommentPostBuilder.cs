namespace TraktNet.PostBuilder
{
    using System;
    using TraktNet.Objects.Get.Lists;
    using TraktNet.Objects.Post.Comments;

    public interface ITraktListCommentPostBuilder : ITraktCommentPostBuilder<ITraktListCommentPostBuilder, ITraktListCommentPost>
    {
        /// <summary>Adds the given <paramref name="list"/> to the builder.</summary>
        /// <param name="list">The <see cref="ITraktList"/> which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktListCommentPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="list"/> is null.</exception>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="list"/>s ids are null.</exception>
        /// <exception cref="ArgumentException">Thrown, if the given <paramref name="list"/>s ids are not valid.</exception>
        ITraktListCommentPostBuilder WithList(ITraktList list);
    }
}
