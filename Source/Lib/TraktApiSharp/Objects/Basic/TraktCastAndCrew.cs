namespace TraktApiSharp.Objects.Basic
{
    using Attributes;
    using Newtonsoft.Json;
    using System.Collections.Generic;

    /// <summary>Represents a collection of cast- and crew-members.</summary>
    public class TraktCastAndCrew
    {
        /// <summary>Gets or sets a list of cast members. See also <seealso cref="TraktCastMember" />.<para>Nullable</para></summary>
        [JsonProperty(PropertyName = "cast")]
        [Nullable]
        public IEnumerable<TraktCastMember> Cast { get; set; }

        /// <summary>Gets or sets the crew members. See also <seealso cref="TraktCrew" />.<para>Nullable</para></summary>
        [JsonProperty(PropertyName = "crew")]
        [Nullable]
        public TraktCrew Crew { get; set; }
    }
}
