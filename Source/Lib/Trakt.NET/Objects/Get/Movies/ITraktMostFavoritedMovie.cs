namespace TraktNet.Objects.Get.Movies
{
    /// <summary>A favorited Trakt movie.</summary>
    public interface ITraktMostFavoritedMovie : ITraktMovie
    {
        /// <summary>Gets or sets the user count for the <see cref="Movie" />.</summary>
        int? UserCount { get; set; }

        /// <summary>Gets or sets the Trakt movie. See also <seealso cref="ITraktMovie" />.<para>Nullable</para></summary>
        ITraktMovie Movie { get; set; }
    }
}
