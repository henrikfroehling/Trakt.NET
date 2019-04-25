namespace TraktNet.Objects.Get.Movies
{
    using System;

    /// <summary>An updated Trakt movie.</summary>
    public interface ITraktRecentlyUpdatedMovie : ITraktMovie
    {
        /// <summary>Gets or sets the UTC datetime, when the <see cref="Movie" /> was updated.</summary>
        DateTime? RecentlyUpdatedAt { get; set; }

        /// <summary>Gets or sets the Trakt movie. See also <seealso cref="ITraktMovie" />.<para>Nullable</para></summary>
        ITraktMovie Movie { get; set; }
    }
}
