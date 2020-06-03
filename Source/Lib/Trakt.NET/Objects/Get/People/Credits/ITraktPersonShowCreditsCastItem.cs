namespace TraktNet.Objects.Get.People.Credits
{
    using Shows;
    using System.Collections.Generic;

    /// <summary>Contains information about a Trakt person's cast position.</summary>
    public interface ITraktPersonShowCreditsCastItem
    {
        /// <summary>Gets or sets the character name of the cast position.<para>Nullable</para></summary>
        string Character { get; set; }

        /// <summary>Gets or sets the characters collection of the cast position.<para>Nullable</para></summary>
        IEnumerable<string> Characters { get; set; }

        /// <summary>Gets or sets the episode count of the cast position.<para>Nullable</para></summary>
        int? EpisodeCount { get; set; }

        /// <summary>Gets or sets the series regular value of the cast position.<para>Nullable</para></summary>
        bool? SeriesRegular { get; set; }

        /// <summary>
        /// Gets or sets the show of the cast position. See also <seealso cref="ITraktShow" />.
        /// <para>Nullable</para>
        /// </summary>
        ITraktShow Show { get; set; }
    }
}
