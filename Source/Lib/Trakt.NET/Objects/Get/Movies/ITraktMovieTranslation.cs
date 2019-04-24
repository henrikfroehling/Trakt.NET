namespace TraktNet.Objects.Get.Movies
{
    using Basic;

    /// <summary>A translation for a Trakt movie.</summary>
    public interface ITraktMovieTranslation : ITraktTranslation
    {
        /// <summary>Gets or sets the tagline for the release.<para>Nullable</para></summary>
        string Tagline { get; set; }
    }
}
