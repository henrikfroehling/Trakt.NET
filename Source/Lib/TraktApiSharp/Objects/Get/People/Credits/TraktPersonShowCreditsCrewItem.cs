namespace TraktApiSharp.Objects.Get.People.Credits
{
    using Attributes;
    using Newtonsoft.Json;
    using Shows;

    public class TraktPersonShowCreditsCrewItem
    {
        [JsonProperty(PropertyName = "job")]
        [Nullable]
        public string Job { get; set; }

        [JsonProperty(PropertyName = "show")]
        [Nullable]
        public TraktShow Show { get; set; }
    }
}
