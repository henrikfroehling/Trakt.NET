namespace TraktNet.Objects.Get.Recommendations
{
    using Enums;
    using Seasons;
    using Shows;
    using System;
    using System.Collections.Generic;

    /// <summary>A Trakt recommended show.</summary>
    public class TraktRecommendedShow : ATraktRecommendedObject, ITraktRecommendedShow
    {
        /// <summary>Gets or sets the recommended show title.<para>Nullable</para></summary>
        public string Title { get; set; }

        /// <summary>Gets or sets the recommended show release year (first episode of the first season).</summary>
        public int? Year { get; set; }

        /// <summary>
        /// Gets or sets the collection of ids for the recommended show for various web services.
        /// See also <seealso cref="ITraktShowIds" />.
        /// <para>Nullable</para>
        /// </summary>
        public ITraktShowIds Ids { get; set; }

        /// <summary>Gets or sets the synopsis of the recommended show.<para>Nullable</para></summary>
        public string Overview { get; set; }

        /// <summary>Gets or sets the UTC datetime when the first episode of the first season of the recommended show was aired.</summary>
        public DateTime? FirstAired { get; set; }

        /// <summary>Gets or sets the air time of the recommended show. See also <seealso cref="ITraktShowAirs" />.<para>Nullable</para></summary>
        public ITraktShowAirs Airs { get; set; }

        /// <summary>Gets or sets the runtime for the recommended show's episodes, in minutes.</summary>
        public int? Runtime { get; set; }

        /// <summary>Gets or sets the content certification of the recommended show.<para>Nullable</para></summary>
        public string Certification { get; set; }

        /// <summary>Gets or sets the producing network name of the recommended show.<para>Nullable</para></summary>
        public string Network { get; set; }

        /// <summary>Gets or sets the two letter language code for the country in which the recommended show is produced.<para>Nullable</para></summary>
        public string CountryCode { get; set; }

        /// <summary>Gets or sets the web address of a trailer for the recommended show.<para>Nullable</para></summary>
        public string Trailer { get; set; }

        /// <summary>Gets or sets the web address of the homepage of the recommended show.<para>Nullable</para></summary>
        public string Homepage { get; set; }

        /// <summary>Gets or sets the recommended show's current status. See also <seealso cref="TraktShowStatus" />.<para>Nullable</para></summary>
        public TraktShowStatus Status { get; set; }

        /// <summary>Gets or sets the average user rating of the recommended show.</summary>
        public float? Rating { get; set; }

        /// <summary>Gets or sets the number of votes for the recommended show.</summary>
        public int? Votes { get; set; }

        /// <summary>Gets or sets the UTC datetime when the recommended show was last updated.</summary>
        public DateTime? UpdatedAt { get; set; }

        /// <summary>Gets or sets the two letter language code of the recommended show.<para>Nullable</para></summary>
        public string LanguageCode { get; set; }

        /// <summary>Gets or sets the list of translation language codes (two letters) for the recommended show.<para>Nullable</para></summary>
        public IEnumerable<string> AvailableTranslationLanguageCodes { get; set; }

        /// <summary>Gets or sets the collection of Trakt genre slugs for the recommended show.<para>Nullable</para></summary>
        public IEnumerable<string> Genres { get; set; }

        /// <summary>Gets or sets the absolute number of already aired episodes in all seasons of the recommended show.</summary>
        public int? AiredEpisodes { get; set; }

        /// <summary>Gets or sets the collection of Trakt seasons for the recommended show. See also <seealso cref="ITraktSeason" />.<para>Nullable</para></summary>
        public IEnumerable<ITraktSeason> Seasons { get; set; }

        /// <summary>Gets or sets the comment count of the recommended show.<para>Nullable</para></summary>
        public int? CommentCount { get; set; }
    }
}
