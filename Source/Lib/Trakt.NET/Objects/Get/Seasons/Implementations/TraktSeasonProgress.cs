﻿namespace TraktNet.Objects.Get.Seasons
{
    /// <summary>Represents the progress of a Trakt season.</summary>
    public abstract class TraktSeasonProgress : ITraktSeasonProgress
    {
        /// <summary>Gets or sets the number of the collected or watched season.</summary>
        public int? Number { get; set; }

        /// <summary>
        /// Gets or sets the title of the season.
        /// <para>Nullable</para>
        /// </summary>
        public string Title { get; set; }

        /// <summary>Gets or sets the number of episodes in the season, which already aired.</summary>
        public int? Aired { get; set; }

        /// <summary>Gets or sets the number of episodes in the season already collected or watched.</summary>
        public int? Completed { get; set; }
    }
}
