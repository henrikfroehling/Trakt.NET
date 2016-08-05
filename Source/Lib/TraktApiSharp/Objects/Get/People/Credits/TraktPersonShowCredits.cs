namespace TraktApiSharp.Objects.Get.People.Credits
{
    using Attributes;
    using Newtonsoft.Json;
    using System.Collections.Generic;

    public class TraktPersonShowCredits
    {
        [JsonProperty(PropertyName = "cast")]
        [Nullable]
        public IEnumerable<TraktPersonShowCreditsCastItem> Cast { get; set; }

        [JsonProperty(PropertyName = "crew")]
        [Nullable]
        public TraktPersonShowCreditsCrew Crew { get; set; }
    }
}
