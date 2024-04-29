namespace TraktNet.Objects.Get.People.Credits
{
    using Shows;
    using System.Collections.Generic;

    /// <summary>Contains information about a Trakt person's cast position.</summary>
    public class TraktPersonShowCreditsCastItem : ITraktPersonShowCreditsCastItem
    {
        /// <summary>Gets or sets the characters collection of the cast position.<para>Nullable</para></summary>
        public IList<string> Characters { get; set; }

        /// <summary>Gets or sets the episode count of the cast position.<para>Nullable</para></summary>
        public int? EpisodeCount { get; set; }

        /// <summary>Gets or sets the series regular value of the cast position.<para>Nullable</para></summary>
        public bool? SeriesRegular { get; set; }

        /// <summary>
        /// Gets or sets the show of the cast position. See also <seealso cref="ITraktShow" />.
        /// <para>Nullable</para>
        /// </summary>
        public ITraktShow Show { get; set; }
    }
}
