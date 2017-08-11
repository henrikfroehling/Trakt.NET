namespace TraktApiSharp.Objects.Get.Movies.Implementations
{
    using Basic.Implementations;

    /// <summary>A translation for a Trakt movie.</summary>
    public class TraktMovieTranslation : TraktTranslation, ITraktMovieTranslation
    {
        /// <summary>Gets or sets the tagline for the release.<para>Nullable</para></summary>
        public string Tagline { get; set; }
    }
}
