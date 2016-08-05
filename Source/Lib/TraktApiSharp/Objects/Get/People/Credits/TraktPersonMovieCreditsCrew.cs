namespace TraktApiSharp.Objects.Get.People.Credits
{
    using Attributes;
    using Newtonsoft.Json;
    using System.Collections.Generic;

    public class TraktPersonMovieCreditsCrew
    {
        [JsonProperty(PropertyName = "production")]
        [Nullable]
        public IEnumerable<TraktPersonMovieCreditsCrewItem> Production { get; set; }

        [JsonProperty(PropertyName = "art")]
        [Nullable]
        public IEnumerable<TraktPersonMovieCreditsCrewItem> Art { get; set; }

        [JsonProperty(PropertyName = "crew")]
        [Nullable]
        public IEnumerable<TraktPersonMovieCreditsCrewItem> Crew { get; set; }

        [JsonProperty(PropertyName = "costume & make-up")]
        [Nullable]
        public IEnumerable<TraktPersonMovieCreditsCrewItem> CostumeAndMakeup { get; set; }

        [JsonProperty(PropertyName = "directing")]
        [Nullable]
        public IEnumerable<TraktPersonMovieCreditsCrewItem> Directing { get; set; }

        [JsonProperty(PropertyName = "writing")]
        [Nullable]
        public IEnumerable<TraktPersonMovieCreditsCrewItem> Writing { get; set; }

        [JsonProperty(PropertyName = "sound")]
        [Nullable]
        public IEnumerable<TraktPersonMovieCreditsCrewItem> Sound { get; set; }

        [JsonProperty(PropertyName = "camera")]
        [Nullable]
        public IEnumerable<TraktPersonMovieCreditsCrewItem> Camera { get; set; }

        [JsonProperty(PropertyName = "lighting")]
        [Nullable]
        public IEnumerable<TraktPersonMovieCreditsCrewItem> Lighting { get; set; }

        [JsonProperty(PropertyName = "visual effects")]
        [Nullable]
        public IEnumerable<TraktPersonMovieCreditsCrewItem> VisualEffects { get; set; }

        [JsonProperty(PropertyName = "editing")]
        [Nullable]
        public IEnumerable<TraktPersonMovieCreditsCrewItem> Editing { get; set; }
    }
}
