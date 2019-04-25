namespace TraktNet.Objects.Get.Movies
{
    /// <summary>A anticipated Trakt movie.</summary>
    public interface ITraktMostAnticipatedMovie : ITraktMovie
    {
        /// <summary>Gets or sets the list count for the <see cref="Movie" />.</summary>
        int? ListCount { get; set; }

        /// <summary>Gets or sets the Trakt movie. See also <seealso cref="ITraktMovie" />.<para>Nullable</para></summary>
        ITraktMovie Movie { get; set; }
    }
}
