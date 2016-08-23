namespace TraktApiSharp.Objects.Post.Syncs.Responses
{
    using Newtonsoft.Json;

    /// <summary>A collection containing the number of movies, shows, seasons and episodes.</summary>
    public class TraktSyncPostResponseGroup
    {
        /// <summary>Gets or sets the number of movies.</summary>
        [JsonProperty(PropertyName = "movies")]
        public int? Movies { get; set; }

        /// <summary>Gets or sets the number of shows.</summary>
        [JsonProperty(PropertyName = "shows")]
        public int? Shows { get; set; }

        /// <summary>Gets or sets the number of seasons.</summary>
        [JsonProperty(PropertyName = "seasons")]
        public int? Seasons { get; set; }

        /// <summary>Gets or sets the number of episodes.</summary>
        [JsonProperty(PropertyName = "episodes")]
        public int? Episodes { get; set; }
    }
}
