namespace TraktNet.Objects.Get.Watched
{
    using Movies;
    using System;

    /// <summary>Contains information about a watched Trakt movie.</summary>
    public interface ITraktWatchedMovie : ITraktMovie
    {
        /// <summary>Gets or sets the number of plays for the watched movie.</summary>
        int? Plays { get; set; }

        /// <summary>Gets or sets the UTC datetime, when the movie was last watched.</summary>
        DateTime? LastWatchedAt { get; set; }

        /// <summary>Gets or sets the Trakt movie. See also <seealso cref="ITraktMovie" />.<para>Nullable</para></summary>
        ITraktMovie Movie { get; set; }
    }
}
