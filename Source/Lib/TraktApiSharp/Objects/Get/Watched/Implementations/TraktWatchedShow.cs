namespace TraktApiSharp.Objects.Get.Watched
{
    using Enums;
    using Seasons;
    using Shows;
    using System;
    using System.Collections.Generic;

    /// <summary>Contains information about a watched Trakt show.</summary>
    public class TraktWatchedShow : ITraktWatchedShow
    {
        /// <summary>Gets or sets the number of plays for the watched show.</summary>
        public int? Plays { get; set; }

        /// <summary>Gets or sets the UTC datetime, when the show was last watched.</summary>
        public DateTime? LastWatchedAt { get; set; }

        /// <summary>Gets or sets the Trakt show. See also <seealso cref="ITraktShow" />.<para>Nullable</para></summary>
        public ITraktShow Show { get; set; }

        /// <summary>
        /// Gets or sets a list of watched seasons in the watched show.
        /// See also <seealso cref="ITraktWatchedShowSeason" />.
        /// <para>Nullable</para>
        /// </summary>
        public IEnumerable<ITraktWatchedShowSeason> WatchedSeasons { get; set; }

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
    }
}
