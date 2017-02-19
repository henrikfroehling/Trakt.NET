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
        public TraktEpisode Episode { get; set; }

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

        [JsonIgnore]
        public int? SeasonNumber
        {
            get { return Episode?.SeasonNumber; }

            set
            {
                if (Episode != null)
                    Episode.SeasonNumber = value;
            }
        }

        [JsonIgnore]
        public int? EpisodeNumber
        {
            get { return Episode?.Number; }

            set
            {
                if (Episode != null)
                    Episode.Number = value;
            }
        }

        [JsonIgnore]
        public string EpisodeTitle
        {
            get { return Episode?.Title; }

            set
            {
                if (Episode != null)
                    Episode.Title = value;
            }
        }

        [JsonIgnore]
        public TraktEpisodeIds EpisodeIds
        {
            get { return Episode?.Ids; }

            set
            {
                if (Episode != null)
                    Episode.Ids = value;
            }
        }

        [JsonIgnore]
        public int? AbsoluteEpisodeNumber
        {
            get { return Episode?.NumberAbsolute; }

            set
            {
                if (Episode != null)
                    Episode.NumberAbsolute = value;
            }
        }

        [JsonIgnore]
        public string EpisodeOverview
        {
            get { return Episode?.Overview; }

            set
            {
                if (Episode != null)
                    Episode.Overview = value;
            }
        }

        [JsonIgnore]
        public int? EpisodeRuntime
        {
            get { return Episode?.Runtime; }

            set
            {
                if (Episode != null)
                    Episode.Runtime = value;
            }
        }

        [JsonIgnore]
        public float? EpisodeRating
        {
            get { return Episode?.Rating; }

            set
            {
                if (Episode != null)
                    Episode.Rating = value;
            }
        }

        [JsonIgnore]
        public int? EpisodeVotes
        {
            get { return Episode?.Votes; }

            set
            {
                if (Episode != null)
                    Episode.Votes = value;
            }
        }

        [JsonIgnore]
        public DateTime? EpisodeAiredFirstAt
        {
            get { return Episode?.FirstAired; }

            set
            {
                if (Episode != null)
                    Episode.FirstAired = value;
            }
        }

        [JsonIgnore]
        public DateTime? EpisodeUpdatedAt
        {
            get { return Episode?.UpdatedAt; }

            set
            {
                if (Episode != null)
                    Episode.UpdatedAt = value;
            }
        }

        [JsonIgnore]
        public IEnumerable<string> AvailableEpisodeTranslationLanguageCodes
        {
            get { return Episode?.AvailableTranslationLanguageCodes; }

            set
            {
                if (Episode != null)
                    Episode.AvailableTranslationLanguageCodes = value;
            }
        }

        [JsonIgnore]
        public IEnumerable<TraktEpisodeTranslation> EpisodeTranslations
        {
            get { return Episode?.Translations; }

            set
            {
                if (Episode != null)
                    Episode.Translations = value;
            }
        }
    }
}
