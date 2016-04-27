namespace TraktApiSharp.Objects.Get.People.Credits
{
    using Newtonsoft.Json;
    using System.Collections.Generic;

    public class TraktPersonShowCredits
    {
        [JsonProperty(PropertyName = "cast")]
        public IEnumerable<TraktPersonShowCreditsCastItem> Cast { get; set; }

        [JsonProperty(PropertyName = "crew")]
        public TraktPersonShowCreditsCrew Crew { get; set; }
    }
}
