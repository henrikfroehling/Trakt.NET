namespace TraktApiSharp.Objects.Get.People.Credits
{
    using Attributes;
    using Newtonsoft.Json;
    using System.Collections.Generic;

    public class TraktPersonShowCreditsCrew
    {
        [JsonProperty(PropertyName = "production")]
        [Nullable]
        public IEnumerable<TraktPersonShowCreditsCrewItem> Production { get; set; }

        [JsonProperty(PropertyName = "art")]
        [Nullable]
        public IEnumerable<TraktPersonShowCreditsCrewItem> Art { get; set; }

        [JsonProperty(PropertyName = "crew")]
        [Nullable]
        public IEnumerable<TraktPersonShowCreditsCrewItem> Crew { get; set; }

        [JsonProperty(PropertyName = "costume & make-up")]
        [Nullable]
        public IEnumerable<TraktPersonShowCreditsCrewItem> CostumeAndMakeup { get; set; }

        [JsonProperty(PropertyName = "directing")]
        [Nullable]
        public IEnumerable<TraktPersonShowCreditsCrewItem> Directing { get; set; }

        [JsonProperty(PropertyName = "writing")]
        [Nullable]
        public IEnumerable<TraktPersonShowCreditsCrewItem> Writing { get; set; }

        [JsonProperty(PropertyName = "sound")]
        [Nullable]
        public IEnumerable<TraktPersonShowCreditsCrewItem> Sound { get; set; }

        [JsonProperty(PropertyName = "camera")]
        [Nullable]
        public IEnumerable<TraktPersonShowCreditsCrewItem> Camera { get; set; }

        [JsonProperty(PropertyName = "lighting")]
        [Nullable]
        public IEnumerable<TraktPersonShowCreditsCrewItem> Lighting { get; set; }

        [JsonProperty(PropertyName = "visual effects")]
        [Nullable]
        public IEnumerable<TraktPersonShowCreditsCrewItem> VisualEffects { get; set; }

        [JsonProperty(PropertyName = "editing")]
        [Nullable]
        public IEnumerable<TraktPersonShowCreditsCrewItem> Editing { get; set; }
    }
}
