namespace TraktNet.Objects.Get.Shows
{
    using Enums;
    using Seasons;
    using System;
    using System.Collections.Generic;

    /// <summary>A Trakt show.</summary>
    public interface ITraktShow
    {
        /// <summary>Gets or sets the show title.<para>Nullable</para></summary>
        string Title { get; set; }

        /// <summary>Gets or sets the show release year (first episode of the first season).</summary>
        int? Year { get; set; }

        /// <summary>
        /// Gets or sets the collection of ids for the show for various web services.
        /// See also <seealso cref="ITraktShowIds" />.
        /// <para>Nullable</para>
        /// </summary>
        ITraktShowIds Ids { get; set; }

        /// <summary>Gets or sets the synopsis of the show.<para>Nullable</para></summary>
        string Overview { get; set; }

        /// <summary>Gets or sets the UTC datetime when the first episode of the first season of the show was aired.</summary>
        DateTime? FirstAired { get; set; }

        /// <summary>Gets or sets the air time of the show. See also <seealso cref="ITraktShowAirs" />.<para>Nullable</para></summary>
        ITraktShowAirs Airs { get; set; }

        /// <summary>Gets or sets the runtime for the show's episodes, in minutes.</summary>
        int? Runtime { get; set; }

        /// <summary>Gets or sets the content certification of the show.<para>Nullable</para></summary>
        string Certification { get; set; }

        /// <summary>Gets or sets the producing network name of the show.<para>Nullable</para></summary>
        string Network { get; set; }

        /// <summary>Gets or sets the two letter language code for the country in which the show is produced.<para>Nullable</para></summary>
        string CountryCode { get; set; }

        /// <summary>Gets or sets the web address of a trailer for the show.<para>Nullable</para></summary>
        string Trailer { get; set; }

        /// <summary>Gets or sets the web address of the homepage of the show.<para>Nullable</para></summary>
        string Homepage { get; set; }

        /// <summary>Gets or sets the show's current status. See also <seealso cref="TraktShowStatus" />.<para>Nullable</para></summary>
        TraktShowStatus Status { get; set; }

        /// <summary>Gets or sets the average user rating of the show.</summary>
        float? Rating { get; set; }

        /// <summary>Gets or sets the number of votes for the show.</summary>
        int? Votes { get; set; }

        /// <summary>Gets or sets the UTC datetime when the show was last updated.</summary>
        DateTime? UpdatedAt { get; set; }

        /// <summary>Gets or sets the two letter language code of the show.<para>Nullable</para></summary>
        string LanguageCode { get; set; }

        /// <summary>Gets or sets the list of translation language codes (two letters) for the show.<para>Nullable</para></summary>
        IEnumerable<string> AvailableTranslationLanguageCodes { get; set; }

        /// <summary>Gets or sets the collection of Trakt genre slugs for the show.<para>Nullable</para></summary>
        IEnumerable<string> Genres { get; set; }

        /// <summary>Gets or sets the absolute number of already aired episodes in all seasons of the show.</summary>
        int? AiredEpisodes { get; set; }

        /// <summary>Gets or sets the collection of Trakt seasons for the show. See also <seealso cref="ITraktSeason" />.<para>Nullable</para></summary>
        IEnumerable<ITraktSeason> Seasons { get; set; }

        /// <summary>Gets or sets the comment count of the show.<para>Nullable</para></summary>
        int? CommentCount { get; set; }
    }
}
