namespace TraktApiSharp.Objects
{
    using Newtonsoft.Json;
    using People;

    public class TraktCastMember
    {
        [JsonProperty(PropertyName = "character")]
        public string Character { get; set; }

        [JsonProperty(PropertyName = "person")]
        public TraktPerson Person { get; set; }
    }
}
