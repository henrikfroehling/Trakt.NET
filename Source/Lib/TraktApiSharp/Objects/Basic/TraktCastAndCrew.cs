namespace TraktApiSharp.Objects.Basic
{
    using Newtonsoft.Json;
    using System.Collections.Generic;

    public class TraktCastAndCrew
    {
        [JsonProperty(PropertyName = "cast")]
        public IEnumerable<TraktCastMember> Cast { get; set; }

        [JsonProperty(PropertyName = "crew")]
        public TraktCrew Crew { get; set; }
    }
}
