namespace TraktApiSharp.Objects.Get.People.Credits
{
    using Newtonsoft.Json;
    using System.Collections.Generic;

    public class TraktPersonMovieCredits
    {
        [JsonProperty(PropertyName = "cast")]
        public IEnumerable<TraktPersonMovieCreditsCastItem> Cast { get; set; }

        [JsonProperty(PropertyName = "crew")]
        public TraktPersonMovieCreditsCrew Crew { get; set; }
    }
}
