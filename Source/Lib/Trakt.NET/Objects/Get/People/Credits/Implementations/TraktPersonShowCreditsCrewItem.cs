namespace TraktNet.Objects.Get.People.Credits
{
    using Shows;
    using System.Collections.Generic;

    /// <summary>Contains information about a Trakt person's crew position.</summary>
    public class TraktPersonShowCreditsCrewItem : ITraktPersonShowCreditsCrewItem
    {
        /// <summary>Gets or sets the jobs collection of the crew position.<para>Nullable</para></summary>
        public IEnumerable<string> Jobs { get; set; }

        /// <summary>Gets or sets the episode count of the crew position.<para>Nullable</para></summary>
        public int? EpisodeCount { get; set; }

        /// <summary>
        /// Gets or sets the show of the crew position. See also <seealso cref="ITraktShow" />.
        /// <para>Nullable</para>
        /// </summary>
        public ITraktShow Show { get; set; }
    }
}
