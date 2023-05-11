namespace TraktNet.Objects.Get.Calendars
{
    using Enums;
    using Episodes;
    using Modules;
    using Seasons;
    using Shows;
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using TraktNet.Parameters;

    /// <summary>A Trakt calendar show, containing episode and show information.</summary>
    public class TraktCalendarShow : ITraktCalendarShow
    {
        /// <summary>Gets or sets the UTC datetime, when the <see cref="Episode" /> first aired.</summary>
        public DateTime? FirstAiredInCalendar { get; set; }

        /// <summary>Gets or sets the Trakt show. See also <seealso cref="ITraktShow" />.<para>Nullable</para></summary>
        public ITraktShow Show { get; set; }

        /// <summary>Gets or sets the Trakt episode. See also <seealso cref="ITraktEpisode" />.<para>Nullable</para></summary>
        public ITraktEpisode Episode { get; set; }

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
        public IList<string> AvailableTranslationLanguageCodes
        {
            get { return Show?.AvailableTranslationLanguageCodes; }

            set
            {
                if (Show != null)
                    Show.AvailableTranslationLanguageCodes = value;
            }
        }

        /// <summary>Gets or sets the collection of Trakt genre slugs for the show.<para>Nullable</para></summary>
        public IList<string> Genres
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
        public IList<ITraktSeason> Seasons
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

        /// <summary>Gets or sets the season number in which the episode was aired.</summary>
        public int? SeasonNumber
        {
            get { return Episode?.SeasonNumber; }

            set
            {
                if (Episode != null)
                    Episode.SeasonNumber = value;
            }
        }

        /// <summary>Gets or sets the episode number within the season to which it belongs.</summary>
        public int? EpisodeNumber
        {
            get { return Episode?.Number; }

            set
            {
                if (Episode != null)
                    Episode.Number = value;
            }
        }

        /// <summary>Gets or sets the episode title.<para>Nullable</para></summary>
        public string EpisodeTitle
        {
            get { return Episode?.Title; }

            set
            {
                if (Episode != null)
                    Episode.Title = value;
            }
        }

        /// <summary>
        /// Gets or sets the collection of ids for the episode for various web services.
        /// See also <seealso cref="ITraktEpisodeIds" />.
        /// <para>Nullable</para>
        /// </summary>
        public ITraktEpisodeIds EpisodeIds
        {
            get { return Episode?.Ids; }

            set
            {
                if (Episode != null)
                    Episode.Ids = value;
            }
        }

        /// <summary>Gets or sets the absolute episode number of all episodes in all seasons.</summary>
        public int? AbsoluteEpisodeNumber
        {
            get { return Episode?.NumberAbsolute; }

            set
            {
                if (Episode != null)
                    Episode.NumberAbsolute = value;
            }
        }

        /// <summary>Gets or sets the synopsis of the episode.<para>Nullable</para></summary>
        public string EpisodeOverview
        {
            get { return Episode?.Overview; }

            set
            {
                if (Episode != null)
                    Episode.Overview = value;
            }
        }

        /// <summary>Gets or sets the runtime of the episode.</summary>
        public int? EpisodeRuntime
        {
            get { return Episode?.Runtime; }

            set
            {
                if (Episode != null)
                    Episode.Runtime = value;
            }
        }

        /// <summary>Gets or sets the average user rating of the episode.</summary>
        public float? EpisodeRating
        {
            get { return Episode?.Rating; }

            set
            {
                if (Episode != null)
                    Episode.Rating = value;
            }
        }

        /// <summary>Gets or sets the number of votes for the episode.</summary>
        public int? EpisodeVotes
        {
            get { return Episode?.Votes; }

            set
            {
                if (Episode != null)
                    Episode.Votes = value;
            }
        }

        /// <summary>Gets or sets the UTC datetime when the episode was first aired.</summary>
        public DateTime? EpisodeAiredFirstAt
        {
            get { return Episode?.FirstAired; }

            set
            {
                if (Episode != null)
                    Episode.FirstAired = value;
            }
        }

        /// <summary>Gets or sets the UTC datetime when the episode was last updated.</summary>
        public DateTime? EpisodeUpdatedAt
        {
            get { return Episode?.UpdatedAt; }

            set
            {
                if (Episode != null)
                    Episode.UpdatedAt = value;
            }
        }

        /// <summary>Gets or sets the list of translation language codes (two letters) for the episode.<para>Nullable</para></summary>
        public IList<string> AvailableEpisodeTranslationLanguageCodes
        {
            get { return Episode?.AvailableTranslationLanguageCodes; }

            set
            {
                if (Episode != null)
                    Episode.AvailableTranslationLanguageCodes = value;
            }
        }

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
        public IList<ITraktEpisodeTranslation> EpisodeTranslations
        {
            get { return Episode?.Translations; }

            set
            {
                if (Episode != null)
                    Episode.Translations = value;
            }
        }

        /// <summary>Gets or sets the comment count of the episode.<para>Nullable</para></summary>
        public int? EpisodeCommentCount
        {
            get { return Episode?.CommentCount; }

            set
            {
                if (Episode != null)
                    Episode.CommentCount = value;
            }
        }
    }
}
