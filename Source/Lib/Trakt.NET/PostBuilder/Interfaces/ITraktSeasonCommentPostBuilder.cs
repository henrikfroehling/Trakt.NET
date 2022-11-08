namespace TraktNet.PostBuilder
{
    using System;
    using TraktNet.Objects.Get.Seasons;
    using TraktNet.Objects.Post.Comments;

    public interface ITraktSeasonCommentPostBuilder : ITraktCommentPostBuilder<ITraktSeasonCommentPostBuilder, ITraktSeasonCommentPost>
    {
        /// <summary>Adds the given <paramref name="season"/> to the builder.</summary>
        /// <param name="season">The <see cref="ITraktSeason"/> which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktSeasonCommentPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="season"/> is null.</exception>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="season"/>s ids are null.</exception>
        /// <exception cref="ArgumentException">Thrown, if the given <paramref name="season"/>s ids are not valid.</exception>
        ITraktSeasonCommentPostBuilder WithSeason(ITraktSeason season);
    }
}
