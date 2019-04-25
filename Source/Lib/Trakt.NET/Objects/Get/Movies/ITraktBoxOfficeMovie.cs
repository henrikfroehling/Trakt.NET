namespace TraktNet.Objects.Get.Movies
{
    /// <summary>A Trakt box office movie.</summary>
    public interface ITraktBoxOfficeMovie : ITraktMovie
    {
        /// <summary>Gets or sets the revenue of the <see cref="Movie" />.</summary>
        int? Revenue { get; set; }

        /// <summary>Gets or sets the Trakt movie. See also <seealso cref="ITraktMovie" />.<para>Nullable</para></summary>
        ITraktMovie Movie { get; set; }
    }
}
