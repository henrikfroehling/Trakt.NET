namespace TraktNet.Objects.Basic
{
    /// <summary>Represents Trakt statistics.</summary>
    public class TraktStatistics : ITraktStatistics
    {
        /// <summary>Gets or sets the number of watchers.</summary>
        public int? Watchers { get; set; }

        /// <summary>Gets or sets the number of playes.</summary>
        public int? Plays { get; set; }

        /// <summary>Gets or sets the number of collectors.</summary>
        public int? Collectors { get; set; }

        /// <summary>Gets or sets the number of collected episodes.</summary>
        public int? CollectedEpisodes { get; set; }

        /// <summary>Gets or sets the number of comments.</summary>
        public int? Comments { get; set; }

        /// <summary>Gets or sets the number of lists.</summary>
        public int? Lists { get; set; }

        /// <summary>Gets or sets the number of votes.</summary>
        public int? Votes { get; set; }
    }
}
