namespace TraktApiSharp.Objects.Get.People.Credits
{
    using Newtonsoft.Json;
    using Shows;

    public class TraktPersonShowCreditsCrewItem
    {
        [JsonProperty(PropertyName = "job")]
        public string Job { get; set; }

        [JsonProperty(PropertyName = "show")]
        public TraktShow Show { get; set; }
    }
}
