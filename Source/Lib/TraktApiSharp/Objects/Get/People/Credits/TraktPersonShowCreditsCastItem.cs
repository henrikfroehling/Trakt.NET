namespace TraktApiSharp.Objects.Get.People.Credits
{
    using Attributes;
    using Newtonsoft.Json;
    using Shows;

    public class TraktPersonShowCreditsCastItem
    {
        [JsonProperty(PropertyName = "character")]
        [Nullable]
        public string Character { get; set; }

        [JsonProperty(PropertyName = "show")]
        [Nullable]
        public TraktShow Show { get; set; }
    }
}
