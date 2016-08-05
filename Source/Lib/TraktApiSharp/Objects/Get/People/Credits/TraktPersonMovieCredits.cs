namespace TraktApiSharp.Objects.Get.People.Credits
{
    using Attributes;
    using Newtonsoft.Json;
    using System.Collections.Generic;

    public class TraktPersonMovieCredits
    {
        [JsonProperty(PropertyName = "cast")]
        [Nullable]
        public IEnumerable<TraktPersonMovieCreditsCastItem> Cast { get; set; }

        [JsonProperty(PropertyName = "crew")]
        [Nullable]
        public TraktPersonMovieCreditsCrew Crew { get; set; }
    }
}
