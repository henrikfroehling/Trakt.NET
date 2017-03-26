namespace TraktApiSharp.Objects.Get.People.Credits.Implementations
{
    using Newtonsoft.Json;
    using Shows;
    using TraktApiSharp.Objects.Get.Shows.Implementations;

    /// <summary>Contains information about a Trakt person's crew position.</summary>
    public class TraktPersonShowCreditsCrewItem : ITraktPersonShowCreditsCrewItem
    {
        /// <summary>Gets or sets the job name of the crew position.<para>Nullable</para></summary>
        [JsonProperty(PropertyName = "job")]
        public string Job { get; set; }

        /// <summary>
        /// Gets or sets the show of the crew position. See also <seealso cref="ITraktShow" />.
        /// <para>Nullable</para>
        /// </summary>
        [JsonProperty(PropertyName = "show")]
        public ITraktShow Show { get; set; }
    }
}
