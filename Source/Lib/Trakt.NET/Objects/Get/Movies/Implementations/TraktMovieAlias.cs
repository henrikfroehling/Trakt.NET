namespace TraktNet.Objects.Get.Movies
{
    /// <summary>An alias for a Trakt movie.</summary>
    public class TraktMovieAlias : ITraktMovieAlias
    {
        /// <summary>Gets or sets the title of the movie alias.<para>Nullable</para></summary>
        public string Title { get; set; }

        /// <summary>Gets or sets the two letter country code for the movie alias.<para>Nullable</para></summary>
        public string CountryCode { get; set; }
    }
}
