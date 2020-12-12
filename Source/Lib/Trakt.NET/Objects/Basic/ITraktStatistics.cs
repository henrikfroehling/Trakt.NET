namespace TraktNet.Objects.Basic
{
    /// <summary>Represents Trakt statistics.</summary>
    public interface ITraktStatistics
    {
        /// <summary>Gets or sets the number of watchers.</summary>
        int? Watchers { get; set; }

        /// <summary>Gets or sets the number of playes.</summary>
        int? Plays { get; set; }

        /// <summary>Gets or sets the number of collectors.</summary>
        int? Collectors { get; set; }

        /// <summary>Gets or sets the number of collected episodes.</summary>
        int? CollectedEpisodes { get; set; }

        /// <summary>Gets or sets the number of comments.</summary>
        int? Comments { get; set; }

        /// <summary>Gets or sets the number of lists.</summary>
        int? Lists { get; set; }

        /// <summary>Gets or sets the number of votes.</summary>
        int? Votes { get; set; }

        /// <summary>Gets or sets the number of recommendations.</summary>
        int? Recommended { get; set; }
    }
}
