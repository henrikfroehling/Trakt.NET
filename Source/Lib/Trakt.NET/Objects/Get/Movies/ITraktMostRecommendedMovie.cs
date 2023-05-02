namespace TraktNet.Objects.Get.Movies
{
    /// <summary>A recommended Trakt movie.</summary>
    public interface ITraktMostRecommendedMovie : ITraktMovie
    {
        /// <summary>Gets or sets the user count for the <see cref="Movie" />.</summary>
        int? UserCount { get; set; }

        /// <summary>Gets or sets the Trakt movie. See also <seealso cref="ITraktMovie" />.<para>Nullable</para></summary>
        ITraktMovie Movie { get; set; }
    }
}
