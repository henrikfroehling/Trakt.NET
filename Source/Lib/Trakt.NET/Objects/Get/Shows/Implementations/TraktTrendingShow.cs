namespace TraktNet.Objects.Get.Shows
{
    using Enums;
    using Seasons;
    using System;
    using System.Collections.Generic;

    /// <summary>A trending Trakt show.</summary>
    public class TraktTrendingShow : ITraktTrendingShow
    {
        /// <summary>Gets or sets the watcher count for the <see cref="Show" />.</summary>
        public int? Watchers { get; set; }

        /// <summary>Gets or sets the Trakt show. See also <seealso cref="ITraktShow" />.<para>Nullable</para></summary>
        public ITraktShow Show { get; set; }

        /// <summary>Gets or sets the show title.<para>Nullable</para></summary>
        public string Title
        {
            get { return Show?.Title; }

            set
            {
                if (Show != null)
                    Show.Title = value;
            }
        }

        /// <summary>Gets or sets the show release year (first episode of the first season).</summary>
        public int? Year
        {
            get { return Show?.Year; }

            set
            {
                if (Show != null)
                    Show.Year = value;
            }
        }

        /// <summary>
        /// Gets or sets the collection of ids for the show for various web services.
        /// See also <seealso cref="ITraktShowIds" />.
        /// <para>Nullable</para>
        /// </summary>
        public ITraktShowIds Ids
        {
            get { return Show?.Ids; }

            set
            {
                if (Show != null)
                    Show.Ids = value;
            }
        }

        /// <summary>Gets or sets the synopsis of the show.<para>Nullable</para></summary>
        public string Overview
        {
            get { return Show?.Overview; }

            set
            {
                if (Show != null)
                    Show.Overview = value;
            }
        }

        /// <summary>Gets or sets the UTC datetime when the first episode of the first season of the show was aired.</summary>
        public DateTime? FirstAired
        {
            get { return Show?.FirstAired; }

            set
            {
                if (Show != null)
                    Show.FirstAired = value;
            }
        }

        /// <summary>Gets or sets the air time of the show. See also <seealso cref="ITraktShowAirs" />.<para>Nullable</para></summary>
        public ITraktShowAirs Airs
        {
            get { return Show?.Airs; }

            set
            {
                if (Show != null)
                    Show.Airs = value;
            }
        }

        /// <summary>Gets or sets the runtime for the show's episodes, in minutes.</summary>
        public int? Runtime
        {
            get { return Show?.Runtime; }

            set
            {
                if (Show != null)
                    Show.Runtime = value;
            }
        }

        /// <summary>Gets or sets the content certification of the show.<para>Nullable</para></summary>
        public string Certification
        {
            get { return Show?.Certification; }

            set
            {
                if (Show != null)
                    Show.Certification = value;
            }
        }

        /// <summary>Gets or sets the producing network name of the show.<para>Nullable</para></summary>
        public string Network
        {
            get { return Show?.Network; }

            set
            {
                if (Show != null)
                    Show.Network = value;
            }
        }

        /// <summary>Gets or sets the two letter language code for the country in which the show is produced.<para>Nullable</para></summary>
        public string CountryCode
        {
            get { return Show?.CountryCode; }

            set
            {
                if (Show != null)
                    Show.CountryCode = value;
            }
        }

        /// <summary>Gets or sets the web address of a trailer for the show.<para>Nullable</para></summary>
        public string Trailer
        {
            get { return Show?.Trailer; }

            set
            {
                if (Show != null)
                    Show.Trailer = value;
            }
        }

        /// <summary>Gets or sets the web address of the homepage of the show.<para>Nullable</para></summary>
        public string Homepage
        {
            get { return Show?.Homepage; }

            set
            {
                if (Show != null)
                    Show.Homepage = value;
            }
        }

        /// <summary>Gets or sets the show's current status. See also <seealso cref="TraktShowStatus" />.<para>Nullable</para></summary>
        public TraktShowStatus Status
        {
            get { return Show?.Status; }

            set
            {
                if (Show != null)
                    Show.Status = value;
            }
        }

        /// <summary>Gets or sets the average user rating of the show.</summary>
        public float? Rating
        {
            get { return Show?.Rating; }

            set
            {
                if (Show != null)
                    Show.Rating = value;
            }
        }

        /// <summary>Gets or sets the number of votes for the show.</summary>
        public int? Votes
        {
            get { return Show?.Votes; }

            set
            {
                if (Show != null)
                    Show.Votes = value;
            }
        }

        /// <summary>Gets or sets the UTC datetime when the show was last updated.</summary>
        public DateTime? UpdatedAt
        {
            get { return Show?.UpdatedAt; }

            set
            {
                if (Show != null)
                    Show.UpdatedAt = value;
            }
        }

        /// <summary>Gets or sets the two letter language code of the show.<para>Nullable</para></summary>
        public string LanguageCode
        {
            get { return Show?.LanguageCode; }

            set
            {
                if (Show != null)
                    Show.LanguageCode = value;
            }
        }

        /// <summary>Gets or sets the list of translation language codes (two letters) for the show.<para>Nullable</para></summary>
        public IEnumerable<string> AvailableTranslationLanguageCodes
        {
            get { return Show?.AvailableTranslationLanguageCodes; }

            set
            {
                if (Show != null)
                    Show.AvailableTranslationLanguageCodes = value;
            }
        }

        /// <summary>Gets or sets the collection of Trakt genre slugs for the show.<para>Nullable</para></summary>
        public IEnumerable<string> Genres
        {
            get { return Show?.Genres; }

            set
            {
                if (Show != null)
                    Show.Genres = value;
            }
        }

        /// <summary>Gets or sets the absolute number of already aired episodes in all seasons of the show.</summary>
        public int? AiredEpisodes
        {
            get { return Show?.AiredEpisodes; }

            set
            {
                if (Show != null)
                    Show.AiredEpisodes = value;
            }
        }

        /// <summary>Gets or sets the collection of Trakt seasons for the show. See also <seealso cref="ITraktSeason" />.<para>Nullable</para></summary>
        public IEnumerable<ITraktSeason> Seasons
        {
            get { return Show?.Seasons; }

            set
            {
                if (Show != null)
                    Show.Seasons = value;
            }
        }

        /// <summary>Gets or sets the comment count of the show.<para>Nullable</para></summary>
        public int? CommentCount
        {
            get { return Show?.CommentCount; }

            set
            {
                if (Show != null)
                    Show.CommentCount = value;
            }
        }
    }
}
