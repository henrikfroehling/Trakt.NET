namespace TraktNet.Objects.Post.Syncs.Ratings
{
    using Get.Movies;
    using System;

    /// <summary>
    /// A Trakt ratings post movie, containing the required movie ids,
    /// an optional rating and an optional datetime, when the movie was rated.
    /// </summary>
    public interface ITraktSyncRatingsPostMovie
    {
        /// <summary>Gets or sets the optional UTC datetime, when the Trakt movie was rated.</summary>
        DateTime? RatedAt { get; set; }

        /// <summary>Gets or sets an optional rating for the movie.</summary>
        int? Rating { get; set; }

        /// <summary>Gets or sets the optional title of the Trakt movie.<para>Nullable</para></summary>
        string Title { get; set; }

        /// <summary>Gets or sets the optional year of the Trakt movie.</summary>
        int? Year { get; set; }

        /// <summary>Gets or sets the required movie ids. See also <seealso cref="ITraktMovieIds" />.</summary>
        ITraktMovieIds Ids { get; set; }
    }
}
