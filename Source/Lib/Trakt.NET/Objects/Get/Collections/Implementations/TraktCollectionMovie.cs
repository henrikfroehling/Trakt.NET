namespace TraktNet.Objects.Get.Collections
{
    using Basic;
    using Movies;
    using System;
    using System.Collections.Generic;

    /// <summary>Contains information about a collected Trakt movie.</summary>
    public class TraktCollectionMovie : ITraktCollectionMovie
    {
        /// <summary>Gets or sets the UTC datetime, when the movie was collected.</summary>
        public DateTime? CollectedAt { get; set; }

        /// <summary>
        /// Gets or sets the collected Trakt movie. See also <seealso cref="ITraktMovie" />.
        /// <para>Nullable</para>
        /// </summary>
        public ITraktMovie Movie { get; set; }

        /// <summary>
        /// Gets or sets metadata about the collected movie. See also <seealso cref="ITraktMetadata" />.
        /// <para>Nullable</para>
        /// </summary>
        public ITraktMetadata Metadata { get; set; }

        public string Title
        {
            get { return Movie?.Title; }

            set
            {
                if (Movie != null)
                    Movie.Title = value;
            }
        }

        public int? Year
        {
            get { return Movie?.Year; }

            set
            {
                if (Movie != null)
                    Movie.Year = value;
            }
        }

        public ITraktMovieIds Ids
        {
            get { return Movie?.Ids; }

            set
            {
                if (Movie != null)
                    Movie.Ids = value;
            }
        }

        public string Tagline
        {
            get { return Movie?.Tagline; }

            set
            {
                if (Movie != null)
                    Movie.Tagline = value;
            }
        }

        public string Overview
        {
            get { return Movie?.Overview; }

            set
            {
                if (Movie != null)
                    Movie.Overview = value;
            }
        }

        public DateTime? Released
        {
            get { return Movie?.Released; }

            set
            {
                if (Movie != null)
                    Movie.Released = value;
            }
        }

        public int? Runtime
        {
            get { return Movie?.Runtime; }

            set
            {
                if (Movie != null)
                    Movie.Runtime = value;
            }
        }

        public string Trailer
        {
            get { return Movie?.Trailer; }

            set
            {
                if (Movie != null)
                    Movie.Trailer = value;
            }
        }

        public string Homepage
        {
            get { return Movie?.Homepage; }

            set
            {
                if (Movie != null)
                    Movie.Homepage = value;
            }
        }

        public float? Rating
        {
            get { return Movie?.Rating; }

            set
            {
                if (Movie != null)
                    Movie.Rating = value;
            }
        }

        public int? Votes
        {
            get { return Movie?.Votes; }

            set
            {
                if (Movie != null)
                    Movie.Votes = value;
            }
        }

        public DateTime? UpdatedAt
        {
            get { return Movie?.UpdatedAt; }

            set
            {
                if (Movie != null)
                    Movie.UpdatedAt = value;
            }
        }

        public string LanguageCode
        {
            get { return Movie?.LanguageCode; }

            set
            {
                if (Movie != null)
                    Movie.LanguageCode = value;
            }
        }

        public IEnumerable<string> AvailableTranslationLanguageCodes
        {
            get { return Movie?.AvailableTranslationLanguageCodes; }

            set
            {
                if (Movie != null)
                    Movie.AvailableTranslationLanguageCodes = value;
            }
        }

        public IEnumerable<string> Genres
        {
            get { return Movie?.Genres; }

            set
            {
                if (Movie != null)
                    Movie.Genres = value;
            }
        }

        public string Certification
        {
            get { return Movie?.Certification; }

            set
            {
                if (Movie != null)
                    Movie.Certification = value;
            }
        }

        public string CountryCode
        {
            get { return Movie?.CountryCode; }

            set
            {
                if (Movie != null)
                    Movie.CountryCode = value;
            }
        }

        public int? CommentCount
        {
            get { return Movie?.CommentCount; }

            set
            {
                if (Movie != null)
                    Movie.CommentCount = value;
            }
        }
    }
}
