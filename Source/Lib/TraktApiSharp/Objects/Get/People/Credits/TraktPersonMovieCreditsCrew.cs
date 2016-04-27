namespace TraktApiSharp.Objects.Get.People.Credits
{
    using Newtonsoft.Json;
    using System.Collections.Generic;

    public class TraktPersonMovieCreditsCrew
    {
        [JsonProperty(PropertyName = "production")]
        public IEnumerable<TraktPersonMovieCreditsCrewItem> Production { get; set; }

        [JsonProperty(PropertyName = "art")]
        public IEnumerable<TraktPersonMovieCreditsCrewItem> Art { get; set; }

        [JsonProperty(PropertyName = "crew")]
        public IEnumerable<TraktPersonMovieCreditsCrewItem> Crew { get; set; }

        [JsonProperty(PropertyName = "costume & make-up")]
        public IEnumerable<TraktPersonMovieCreditsCrewItem> CostumeAndMakeup { get; set; }

        [JsonProperty(PropertyName = "directing")]
        public IEnumerable<TraktPersonMovieCreditsCrewItem> Directing { get; set; }

        [JsonProperty(PropertyName = "writing")]
        public IEnumerable<TraktPersonMovieCreditsCrewItem> Writing { get; set; }

        [JsonProperty(PropertyName = "sound")]
        public IEnumerable<TraktPersonMovieCreditsCrewItem> Sound { get; set; }

        [JsonProperty(PropertyName = "camera")]
        public IEnumerable<TraktPersonMovieCreditsCrewItem> Camera { get; set; }

        [JsonProperty(PropertyName = "lighting")]
        public IEnumerable<TraktPersonMovieCreditsCrewItem> Lighting { get; set; }

        [JsonProperty(PropertyName = "visual effects")]
        public IEnumerable<TraktPersonMovieCreditsCrewItem> VisualEffects { get; set; }

        [JsonProperty(PropertyName = "editing")]
        public IEnumerable<TraktPersonMovieCreditsCrewItem> Editing { get; set; }
    }
}
