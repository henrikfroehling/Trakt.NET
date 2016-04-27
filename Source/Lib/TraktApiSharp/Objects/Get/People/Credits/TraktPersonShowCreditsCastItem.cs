namespace TraktApiSharp.Objects.Get.People.Credits
{
    using Newtonsoft.Json;
    using Shows;

    public class TraktPersonShowCreditsCastItem
    {
        [JsonProperty(PropertyName = "character")]
        public string Character { get; set; }

        [JsonProperty(PropertyName = "show")]
        public TraktShow Show { get; set; }
    }
}
