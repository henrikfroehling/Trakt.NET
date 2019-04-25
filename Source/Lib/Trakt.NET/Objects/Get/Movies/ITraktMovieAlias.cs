namespace TraktNet.Objects.Get.Movies
{
    /// <summary>An alias for a Trakt movie.</summary>
    public interface ITraktMovieAlias
    {
        /// <summary>Gets or sets the title of the movie alias.<para>Nullable</para></summary>
        string Title { get; set; }

        /// <summary>Gets or sets the two letter country code for the movie alias.<para>Nullable</para></summary>
        string CountryCode { get; set; }
    }
}
