namespace TraktApiSharp.Objects.Basic
{
    using Get.People;
    using Newtonsoft.Json;

    public class TraktCastMember
    {
        [JsonProperty(PropertyName = "character")]
        public string Character { get; set; }

        [JsonProperty(PropertyName = "person")]
        public TraktPerson Person { get; set; }
    }
}
