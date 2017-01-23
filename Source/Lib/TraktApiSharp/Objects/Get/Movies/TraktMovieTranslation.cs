namespace TraktApiSharp.Objects.Get.Movies
{
    using Attributes;
    using Newtonsoft.Json;
    using Objects.Basic;

    /// <summary>A translation for a Trakt movie.</summary>
    public class TraktMovieTranslation : TraktTranslation
    {
        /// <summary>Gets or sets the tagline for the release.<para>Nullable</para></summary>
        [JsonProperty(PropertyName = "tagline")]
        [Nullable]
        public string Tagline { get; set; }
    }
}
