namespace TraktApiSharp.Objects.Basic.Implementations
{
    using Newtonsoft.Json;
    using System.Collections.Generic;

    /// <summary>Represents a collection of cast- and crew-members.</summary>
    public class TraktCastAndCrew : ITraktCastAndCrew
    {
        /// <summary>Gets or sets a list of cast members. See also <seealso cref="ITraktCastMember" />.<para>Nullable</para></summary>
        [JsonProperty(PropertyName = "cast")]
        public IEnumerable<ITraktCastMember> Cast { get; set; }

        /// <summary>Gets or sets the crew members. See also <seealso cref="ITraktCrew" />.<para>Nullable</para></summary>
        [JsonProperty(PropertyName = "crew")]
        public ITraktCrew Crew { get; set; }
    }
}
