namespace TraktNet.PostBuilder
{
    using Objects.Get.Episodes;
    using Objects.Post.Comments;
    using System;

    public interface ITraktEpisodeCommentPostBuilder : ITraktCommentPostBuilder<ITraktEpisodeCommentPostBuilder, ITraktEpisodeCommentPost>
    {
        /// <summary>Adds the given <paramref name="episode"/> to the builder.</summary>
        /// <param name="episode">The <see cref="ITraktEpisode"/> which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktEpisodeCommentPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="episode"/> is null.</exception>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="episode"/>s ids are null.</exception>
        /// <exception cref="ArgumentException">Thrown, if the given <paramref name="episode"/>s ids are not valid.</exception>
        /// <remarks>Overrides values already set by <see cref="WithEpisode(ITraktEpisodeIds)"/>.</remarks>
        ITraktEpisodeCommentPostBuilder WithEpisode(ITraktEpisode episode);

        /// <summary>Adds the given <paramref name="episodeIds"/> to the builder.</summary>
        /// <param name="episodeIds">The <see cref="ITraktEpisodeIds"/> which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktEpisodeCommentPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="episodeIds"/> is null.</exception>
        /// <exception cref="ArgumentException">Thrown, if the given <paramref name="episodeIds"/>s are not valid.</exception>
        /// <remarks>Overrides values already set by <see cref="WithEpisode(ITraktEpisode)"/>.</remarks>
        ITraktEpisodeCommentPostBuilder WithEpisode(ITraktEpisodeIds episodeIds);
    }
}
