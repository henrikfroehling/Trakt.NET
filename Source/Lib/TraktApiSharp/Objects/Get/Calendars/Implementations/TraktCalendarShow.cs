namespace TraktApiSharp.Objects.Get.Calendars
{
    using Enums;
    using Episodes;
    using Seasons;
    using Shows;
    using System;
    using System.Collections.Generic;

    /// <summary>A Trakt calendar show, containing episode and show information.</summary>
    public class TraktCalendarShow : ITraktCalendarShow
    {
        /// <summary>Gets or sets the UTC datetime, when the <see cref="Episode" /> first aired.</summary>
        public DateTime? FirstAiredInCalendar { get; set; }

        /// <summary>Gets or sets the Trakt show. See also <seealso cref="ITraktShow" />.<para>Nullable</para></summary>
        public ITraktShow Show { get; set; }

        /// <summary>Gets or sets the Trakt episode. See also <seealso cref="ITraktEpisode" />.<para>Nullable</para></summary>
        public ITraktEpisode Episode { get; set; }

        public string Title
        {
            get { return Show?.Title; }

            set
            {
                if (Show != null)
                    Show.Title = value;
            }
        }

        public int? Year
        {
            get { return Show?.Year; }

            set
            {
                if (Show != null)
                    Show.Year = value;
            }
        }

        public ITraktShowIds Ids
        {
            get { return Show?.Ids; }

            set
            {
                if (Show != null)
                    Show.Ids = value;
            }
        }

        public string Overview
        {
            get { return Show?.Overview; }

            set
            {
                if (Show != null)
                    Show.Overview = value;
            }
        }

        public DateTime? FirstAired
        {
            get { return Show?.FirstAired; }

            set
            {
                if (Show != null)
                    Show.FirstAired = value;
            }
        }

        public ITraktShowAirs Airs
        {
            get { return Show?.Airs; }

            set
            {
                if (Show != null)
                    Show.Airs = value;
            }
        }

        public int? Runtime
        {
            get { return Show?.Runtime; }

            set
            {
                if (Show != null)
                    Show.Runtime = value;
            }
        }

        public string Certification
        {
            get { return Show?.Certification; }

            set
            {
                if (Show != null)
                    Show.Certification = value;
            }
        }

        public string Network
        {
            get { return Show?.Network; }

            set
            {
                if (Show != null)
                    Show.Network = value;
            }
        }

        public string CountryCode
        {
            get { return Show?.CountryCode; }

            set
            {
                if (Show != null)
                    Show.CountryCode = value;
            }
        }

        public string Trailer
        {
            get { return Show?.Trailer; }

            set
            {
                if (Show != null)
                    Show.Trailer = value;
            }
        }

        public string Homepage
        {
            get { return Show?.Homepage; }

            set
            {
                if (Show != null)
                    Show.Homepage = value;
            }
        }

        public TraktShowStatus Status
        {
            get { return Show?.Status; }

            set
            {
                if (Show != null)
                    Show.Status = value;
            }
        }

        public float? Rating
        {
            get { return Show?.Rating; }

            set
            {
                if (Show != null)
                    Show.Rating = value;
            }
        }

        public int? Votes
        {
            get { return Show?.Votes; }

            set
            {
                if (Show != null)
                    Show.Votes = value;
            }
        }

        public DateTime? UpdatedAt
        {
            get { return Show?.UpdatedAt; }

            set
            {
                if (Show != null)
                    Show.UpdatedAt = value;
            }
        }

        public string LanguageCode
        {
            get { return Show?.LanguageCode; }

            set
            {
                if (Show != null)
                    Show.LanguageCode = value;
            }
        }

        public IEnumerable<string> AvailableTranslationLanguageCodes
        {
            get { return Show?.AvailableTranslationLanguageCodes; }

            set
            {
                if (Show != null)
                    Show.AvailableTranslationLanguageCodes = value;
            }
        }

        public IEnumerable<string> Genres
        {
            get { return Show?.Genres; }

            set
            {
                if (Show != null)
                    Show.Genres = value;
            }
        }

        public int? AiredEpisodes
        {
            get { return Show?.AiredEpisodes; }

            set
            {
                if (Show != null)
                    Show.AiredEpisodes = value;
            }
        }

        public IEnumerable<ITraktSeason> Seasons
        {
            get { return Show?.Seasons; }

            set
            {
                if (Show != null)
                    Show.Seasons = value;
            }
        }

        public int? CommentCount
        {
            get { return Show?.CommentCount; }

            set
            {
                if (Show != null)
                    Show.CommentCount = value;
            }
        }

        public int? SeasonNumber
        {
            get { return Episode?.SeasonNumber; }

            set
            {
                if (Episode != null)
                    Episode.SeasonNumber = value;
            }
        }

        public int? EpisodeNumber
        {
            get { return Episode?.Number; }

            set
            {
                if (Episode != null)
                    Episode.Number = value;
            }
        }

        public string EpisodeTitle
        {
            get { return Episode?.Title; }

            set
            {
                if (Episode != null)
                    Episode.Title = value;
            }
        }

        public ITraktEpisodeIds EpisodeIds
        {
            get { return Episode?.Ids; }

            set
            {
                if (Episode != null)
                    Episode.Ids = value;
            }
        }

        public int? AbsoluteEpisodeNumber
        {
            get { return Episode?.NumberAbsolute; }

            set
            {
                if (Episode != null)
                    Episode.NumberAbsolute = value;
            }
        }

        public string EpisodeOverview
        {
            get { return Episode?.Overview; }

            set
            {
                if (Episode != null)
                    Episode.Overview = value;
            }
        }

        public int? EpisodeRuntime
        {
            get { return Episode?.Runtime; }

            set
            {
                if (Episode != null)
                    Episode.Runtime = value;
            }
        }

        public float? EpisodeRating
        {
            get { return Episode?.Rating; }

            set
            {
                if (Episode != null)
                    Episode.Rating = value;
            }
        }

        public int? EpisodeVotes
        {
            get { return Episode?.Votes; }

            set
            {
                if (Episode != null)
                    Episode.Votes = value;
            }
        }

        public DateTime? EpisodeAiredFirstAt
        {
            get { return Episode?.FirstAired; }

            set
            {
                if (Episode != null)
                    Episode.FirstAired = value;
            }
        }

        public DateTime? EpisodeUpdatedAt
        {
            get { return Episode?.UpdatedAt; }

            set
            {
                if (Episode != null)
                    Episode.UpdatedAt = value;
            }
        }

        public IEnumerable<string> AvailableEpisodeTranslationLanguageCodes
        {
            get { return Episode?.AvailableTranslationLanguageCodes; }

            set
            {
                if (Episode != null)
                    Episode.AvailableTranslationLanguageCodes = value;
            }
        }

        public IEnumerable<ITraktEpisodeTranslation> EpisodeTranslations
        {
            get { return Episode?.Translations; }

            set
            {
                if (Episode != null)
                    Episode.Translations = value;
            }
        }

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
