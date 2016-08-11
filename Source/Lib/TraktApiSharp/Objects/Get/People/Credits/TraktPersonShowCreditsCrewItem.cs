namespace TraktApiSharp.Objects.Get.People.Credits
{
    using Attributes;
    using Newtonsoft.Json;
    using Shows;

    /// <summary>Contains information about a Trakt person's crew position.</summary>
    public class TraktPersonShowCreditsCrewItem
    {
        /// <summary>Gets or sets the job name of the crew position.<para>Nullable</para></summary>
        [JsonProperty(PropertyName = "job")]
        [Nullable]
        public string Job { get; set; }

        /// <summary>
        /// Gets or sets the show of the crew position. See also <seealso cref="TraktShow" />.
        /// <para>Nullable</para>
        /// </summary>
        [JsonProperty(PropertyName = "show")]
        [Nullable]
        public TraktShow Show { get; set; }
    }
}
