namespace TraktNet.Objects.Get.Episodes
{
    using Get.Seasons;
    using Modules;
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using TraktNet.Parameters;

    /// <summary>A Trakt episode of a Trakt season.</summary>
    public interface ITraktEpisode
    {
        /// <summary>Gets or sets the season number in which the episode was aired.</summary>
        int? SeasonNumber { get; set; }

        /// <summary>Gets or sets the episode number within the season to which it belongs.</summary>
        int? Number { get; set; }

        /// <summary>Gets or sets the episode title.<para>Nullable</para></summary>
        string Title { get; set; }

        /// <summary>
        /// Gets or sets the collection of ids for the episode for various web services.
        /// See also <seealso cref="ITraktEpisodeIds" />.
        /// <para>Nullable</para>
        /// </summary>
        ITraktEpisodeIds Ids { get; set; }

        /// <summary>Gets or sets the absolute episode number of all episodes in all seasons.</summary>
        int? NumberAbsolute { get; set; }

        /// <summary>Gets or sets the synopsis of the episode.<para>Nullable</para></summary>
        string Overview { get; set; }

        /// <summary>Gets or sets the runtime of the episode.</summary>
        int? Runtime { get; set; }

        /// <summary>Gets or sets the average user rating of the episode.</summary>
        float? Rating { get; set; }

        /// <summary>Gets or sets the number of votes for the episode.</summary>
        int? Votes { get; set; }

        /// <summary>Gets or sets the UTC datetime when the episode was first aired.</summary>
        DateTime? FirstAired { get; set; }

        /// <summary>Gets or sets the UTC datetime when the episode was last updated.</summary>
        DateTime? UpdatedAt { get; set; }

        /// <summary>Gets or sets the list of translation language codes (two letters) for the episode.<para>Nullable</para></summary>
        IEnumerable<string> AvailableTranslationLanguageCodes { get; set; }

        /// <summary>Gets or sets the list of <see cref="ITraktEpisodeTranslation" />s for the episode.<para>Nullable</para></summary>
        /// <seealso cref="ITraktSeason.Episodes" />
        /// <remarks>
        /// This property is set automatically if this episode is in a
        /// <see cref="ITraktSeason.Episodes" /> collection and the episode's season
        /// is in a collection of seasons returned by
        /// <see cref="TraktSeasonsModule.GetAllSeasonsAsync(string, TraktExtendedInfo, string, CancellationToken)" />
        /// and a translation language code was specified.
        /// This property is also set automatically if this episode is in
        /// a collection returned by <see cref="TraktSeasonsModule.GetSeasonAsync(string, uint, TraktExtendedInfo, string, CancellationToken)" />
        /// and a translation language code was specified.
        /// </remarks>
        IEnumerable<ITraktEpisodeTranslation> Translations { get; set; }

        /// <summary>Gets or sets the comment count of the episode.<para>Nullable</para></summary>
        int? CommentCount { get; set; }
    }
}
