namespace TraktApiSharp.Objects.Basic
{
    using Get.People;
    using Newtonsoft.Json;

    public class TraktCrewMember
    {
        [JsonProperty(PropertyName = "job")]
        public string Job { get; set; }

        [JsonProperty(PropertyName = "person")]
        public TraktPerson Person { get; set; }
    }
}
