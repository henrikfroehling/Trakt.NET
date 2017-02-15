namespace TraktApiSharp.Objects.Get.Calendars
{
    using Enums;
    using Episodes;
    using Newtonsoft.Json;
    using Seasons;
    using Shows;
    using System;
    using System.Collections.Generic;

    /// <summary>A Trakt calendar show, containing episode and show information.</summary>
    public class TraktCalendarShow : ITraktCalendarShow
    {
        /// <summary>Gets or sets the UTC datetime, when the <see cref="Episode" /> first aired.</summary>
        [JsonProperty(PropertyName = "first_aired")]
        public DateTime? FirstAiredInCalendar { get; set; }

        /// <summary>Gets or sets the Trakt show. See also <seealso cref="TraktShow" />.<para>Nullable</para></summary>
        [JsonProperty(PropertyName = "show")]
        public ITraktShow Show { get; set; }

        /// <summary>Gets or sets the Trakt episode. See also <seealso cref="TraktEpisode" />.<para>Nullable</para></summary>
        [JsonProperty(PropertyName = "episode")]
        public ITraktEpisode Episode { get; set; }

        [JsonIgnore]
        public string Title
        {
            get { return Show?.Title; }

            set
            {
                if (Show != null)
                    Show.Title = value;
            }
        }

        [JsonIgnore]
        public int? Year
        {
            get { return Show?.Year; }

            set
            {
                if (Show != null)
                    Show.Year = value;
            }
        }

        [JsonIgnore]
        public TraktShowIds Ids
        {
            get { return Show?.Ids; }

            set
            {
                if (Show != null)
                    Show.Ids = value;
            }
        }

        [JsonIgnore]
        public string Overview
        {
            get { return Show?.Overview; }

            set
            {
                if (Show != null)
                    Show.Overview = value;
            }
        }

        [JsonIgnore]
        public DateTime? FirstAired
        {
            get { return Show?.FirstAired; }

            set
            {
                if (Show != null)
                    Show.FirstAired = value;
            }
        }

        [JsonIgnore]
        public TraktShowAirs Airs
        {
            get { return Show?.Airs; }

            set
            {
                if (Show != null)
                    Show.Airs = value;
            }
        }

        [JsonIgnore]
        public int? Runtime
        {
            get { return Show?.Runtime; }

            set
            {
                if (Show != null)
                    Show.Runtime = value;
            }
        }

        [JsonIgnore]
        public string Certification
        {
            get { return Show?.Certification; }

            set
            {
                if (Show != null)
                    Show.Certification = value;
            }
        }

        [JsonIgnore]
        public string Network
        {
            get { return Show?.Network; }

            set
            {
                if (Show != null)
                    Show.Network = value;
            }
        }

        [JsonIgnore]
        public string CountryCode
        {
            get { return Show?.CountryCode; }

            set
            {
                if (Show != null)
                    Show.CountryCode = value;
            }
        }

        [JsonIgnore]
        public string Trailer
        {
            get { return Show?.Trailer; }

            set
            {
                if (Show != null)
                    Show.Trailer = value;
            }
        }

        [JsonIgnore]
        public string Homepage
        {
            get { return Show?.Homepage; }

            set
            {
                if (Show != null)
                    Show.Homepage = value;
            }
        }

        [JsonIgnore]
        public TraktShowStatus Status
        {
            get { return Show?.Status; }

            set
            {
                if (Show != null)
                    Show.Status = value;
            }
        }

        [JsonIgnore]
        public float? Rating
        {
            get { return Show?.Rating; }

            set
            {
                if (Show != null)
                    Show.Rating = value;
            }
        }

        [JsonIgnore]
        public int? Votes
        {
            get { return Show?.Votes; }

            set
            {
                if (Show != null)
                    Show.Votes = value;
            }
        }

        [JsonIgnore]
        public DateTime? UpdatedAt
        {
            get { return Show?.UpdatedAt; }

            set
            {
                if (Show != null)
                    Show.UpdatedAt = value;
            }
        }

        [JsonIgnore]
        public string LanguageCode
        {
            get { return Show?.LanguageCode; }

            set
            {
                if (Show != null)
                    Show.LanguageCode = value;
            }
        }

        [JsonIgnore]
        public IEnumerable<string> AvailableTranslationLanguageCodes
        {
            get { return Show?.AvailableTranslationLanguageCodes; }

            set
            {
                if (Show != null)
                    Show.AvailableTranslationLanguageCodes = value;
            }
        }

        [JsonIgnore]
        public IEnumerable<string> Genres
        {
            get { return Show?.Genres; }

            set
            {
                if (Show != null)
                    Show.Genres = value;
            }
        }

        [JsonIgnore]
        public int? AiredEpisodes
        {
            get { return Show?.AiredEpisodes; }

            set
            {
                if (Show != null)
                    Show.AiredEpisodes = value;
            }
        }

        [JsonIgnore]
        public IEnumerable<TraktSeason> Seasons
        {
            get { return Show?.Seasons; }

            set
            {
                if (Show != null)
                    Show.Seasons = value;
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
            get { return Episode?.EpisodeNumber; }

            set
            {
                if (Episode != null)
                    Episode.EpisodeNumber = value;
            }
        }

        public string EpisodeTitle
        {
            get { return Episode?.EpisodeTitle; }

            set
            {
                if (Episode != null)
                    Episode.EpisodeTitle = value;
            }
        }

        public TraktEpisodeIds EpisodeIds
        {
            get { return Episode?.EpisodeIds; }

            set
            {
                if (Episode != null)
                    Episode.EpisodeIds = value;
            }
        }

        public int? AbsoluteEpisodeNumber
        {
            get { return Episode?.AbsoluteEpisodeNumber; }

            set
            {
                if (Episode != null)
                    Episode.AbsoluteEpisodeNumber = value;
            }
        }

        public string EpisodeOverview
        {
            get { return Episode?.EpisodeOverview; }

            set
            {
                if (Episode != null)
                    Episode.EpisodeOverview = value;
            }
        }

        public int? EpisodeRuntime
        {
            get { return Episode?.EpisodeRuntime; }

            set
            {
                if (Episode != null)
                    Episode.EpisodeRuntime = value;
            }
        }

        public float? EpisodeRating
        {
            get { return Episode?.EpisodeRating; }

            set
            {
                if (Episode != null)
                    Episode.EpisodeRating = value;
            }
        }

        public int? EpisodeVotes
        {
            get { return Episode?.EpisodeVotes; }

            set
            {
                if (Episode != null)
                    Episode.EpisodeVotes = value;
            }
        }

        public DateTime? EpisodeAiredFirstAt
        {
            get { return Episode?.EpisodeAiredFirstAt; }

            set
            {
                if (Episode != null)
                    Episode.EpisodeAiredFirstAt = value;
            }
        }

        public DateTime? EpisodeUpdatedAt
        {
            get { return Episode?.EpisodeUpdatedAt; }

            set
            {
                if (Episode != null)
                    Episode.EpisodeUpdatedAt = value;
            }
        }

        public IEnumerable<string> AvailableEpisodeTranslationLanguageCodes
        {
            get { return Episode?.AvailableEpisodeTranslationLanguageCodes; }

            set
            {
                if (Episode != null)
                    Episode.AvailableEpisodeTranslationLanguageCodes = value;
            }
        }

        public IEnumerable<TraktEpisodeTranslation> EpisodeTranslations
        {
            get { return Episode?.EpisodeTranslations; }

            set
            {
                if (Episode != null)
                    Episode.EpisodeTranslations = value;
            }
        }
    }
}
