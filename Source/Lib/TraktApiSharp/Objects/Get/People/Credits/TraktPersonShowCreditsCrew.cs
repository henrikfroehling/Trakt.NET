namespace TraktApiSharp.Objects.Get.People.Credits
{
    using Newtonsoft.Json;
    using System.Collections.Generic;

    public class TraktPersonShowCreditsCrew
    {
        [JsonProperty(PropertyName = "production")]
        public IEnumerable<TraktPersonShowCreditsCrewItem> Production { get; set; }

        [JsonProperty(PropertyName = "art")]
        public IEnumerable<TraktPersonShowCreditsCrewItem> Art { get; set; }

        [JsonProperty(PropertyName = "crew")]
        public IEnumerable<TraktPersonShowCreditsCrewItem> Crew { get; set; }

        [JsonProperty(PropertyName = "costume & make-up")]
        public IEnumerable<TraktPersonShowCreditsCrewItem> CostumeAndMakeup { get; set; }

        [JsonProperty(PropertyName = "directing")]
        public IEnumerable<TraktPersonShowCreditsCrewItem> Directing { get; set; }

        [JsonProperty(PropertyName = "writing")]
        public IEnumerable<TraktPersonShowCreditsCrewItem> Writing { get; set; }

        [JsonProperty(PropertyName = "sound")]
        public IEnumerable<TraktPersonShowCreditsCrewItem> Sound { get; set; }

        [JsonProperty(PropertyName = "camera")]
        public IEnumerable<TraktPersonShowCreditsCrewItem> Camera { get; set; }

        [JsonProperty(PropertyName = "lighting")]
        public IEnumerable<TraktPersonShowCreditsCrewItem> Lighting { get; set; }

        [JsonProperty(PropertyName = "visual effects")]
        public IEnumerable<TraktPersonShowCreditsCrewItem> VisualEffects { get; set; }

        [JsonProperty(PropertyName = "editing")]
        public IEnumerable<TraktPersonShowCreditsCrewItem> Editing { get; set; }
    }
}
