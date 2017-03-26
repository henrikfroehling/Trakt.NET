namespace TraktApiSharp.Objects.Get.Movies.Implementations
{
    using Basic.Implementations;
    using Newtonsoft.Json;

    /// <summary>A translation for a Trakt movie.</summary>
    public class TraktMovieTranslation : TraktTranslation, ITraktMovieTranslation
    {
        /// <summary>Gets or sets the tagline for the release.<para>Nullable</para></summary>
        [JsonProperty(PropertyName = "tagline")]
        public string Tagline { get; set; }
    }
}
