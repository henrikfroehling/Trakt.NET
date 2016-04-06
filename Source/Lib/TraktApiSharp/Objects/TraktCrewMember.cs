namespace TraktApiSharp.Objects
{
    using Newtonsoft.Json;
    using People;

    public class TraktCrewMember
    {
        [JsonProperty(PropertyName = "job")]
        public string Job { get; set; }

        [JsonProperty(PropertyName = "person")]
        public TraktPerson Person { get; set; }
    }
}
