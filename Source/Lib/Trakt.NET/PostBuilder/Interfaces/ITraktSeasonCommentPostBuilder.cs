namespace TraktNet.PostBuilder
{
    using Objects.Get.Seasons;
    using Objects.Post.Comments;
    using System;

    public interface ITraktSeasonCommentPostBuilder : ITraktCommentPostBuilder<ITraktSeasonCommentPostBuilder, ITraktSeasonCommentPost>
    {
        /// <summary>Adds the given <paramref name="season"/> to the builder.</summary>
        /// <param name="season">The <see cref="ITraktSeason"/> which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktSeasonCommentPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="season"/> is null.</exception>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="season"/>s ids are null.</exception>
        /// <exception cref="ArgumentException">Thrown, if the given <paramref name="season"/>s ids are not valid.</exception>
        /// <remarks>Overrides values already set by <see cref="WithSeason(ITraktSeasonIds)"/>.</remarks>
        ITraktSeasonCommentPostBuilder WithSeason(ITraktSeason season);

        /// <summary>Adds the given <paramref name="seasonIds"/> to the builder.</summary>
        /// <param name="seasonIds">The <see cref="ITraktSeason"/> which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktSeasonCommentPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="seasonIds"/> is null.</exception>
        /// <exception cref="ArgumentException">Thrown, if the given <paramref name="seasonIds"/>s are not valid.</exception>
        /// <remarks>Overrides values already set by <see cref="WithSeason(ITraktSeason)"/>.</remarks>
        ITraktSeasonCommentPostBuilder WithSeason(ITraktSeasonIds seasonIds);
    }
}
