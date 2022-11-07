namespace TraktNet.Objects.Get.Seasons
{
    using Episodes;
    using Modules;
    using Requests.Parameters;
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using TraktNet.Parameters;

    /// <summary>A Trakt season of a Trakt show.</summary>
    public interface ITraktSeason
    {
        /// <summary>Gets or sets the season number.</summary>
        int? Number { get; set; }

        /// <summary>
        /// Gets or sets the title of the season.
        /// <para>Nullable</para>
        /// </summary>
        string Title { get; set; }

        /// <summary>
        /// Gets or sets the collection of ids for the season for various web services.
        /// See also <seealso cref="ITraktSeasonIds" />.
        /// <para>Nullable</para>
        /// </summary>
        ITraktSeasonIds Ids { get; set; }

        /// <summary>Gets or sets the average user rating of the season.</summary>
        float? Rating { get; set; }

        /// <summary>Gets or sets the number of votes for the season.</summary>
        int? Votes { get; set; }

        /// <summary>Gets or sets the number of episodes in the season.</summary>
        int? TotalEpisodesCount { get; set; }

        /// <summary>Gets or sets the number of aired episodes in the season.</summary>
        int? AiredEpisodesCount { get; set; }

        /// <summary>Gets or sets the synopsis of the season.<para>Nullable</para></summary>
        string Overview { get; set; }

        /// <summary>Gets or sets the UTC datetime when the season was first aired.</summary>
        DateTime? FirstAired { get; set; }

        /// <summary>Gets or sets the UTC datetime when the season was last updated.</summary>
        DateTime? UpdatedAt { get; set; }

        /// <summary>Gets or sets the network on which the season airs.</summary>
        string Network { get; set; }

        /// <summary>Gets or sets the collection of Trakt episodes in the season. See also <seealso cref="ITraktEpisode" />.<para>Nullable</para></summary>
        /// <remarks>
        /// This property is set automatically if this season is in a collection
        /// of seasons and this collection was returned by
        /// <see cref="TraktSeasonsModule.GetAllSeasonsAsync(string, TraktExtendedInfo, string, CancellationToken)" />
        /// and the optional <see cref="TraktExtendedInfo" /> has
        /// <see cref="TraktExtendedInfo.Episodes" /> set to true.
        /// </remarks>
        IEnumerable<ITraktEpisode> Episodes { get; set; }

        /// <summary>Gets or sets the comment count of the season.<para>Nullable</para></summary>
        int? CommentCount { get; set; }
    }
}
