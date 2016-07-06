namespace TraktApiSharp.Requests.WithoutOAuth.Movies
{
    using Base;
    using System.Collections.Generic;

    public class TraktMovieFilter : TraktFilter
    {
        public TraktMovieFilter() { }

        public TraktMovieFilter(string query, int years, string[] genres = null, string[] languages = null,
                                string[] countries = null, Range<int> runtimes = null, Range<int> ratings = null,
                                string[] certifications = null) : base(query, years, genres, languages, countries, runtimes, ratings)
        {
            WithCertifications(null, certifications);
        }

        public string[] Certifications { get; private set; }

        public bool HasCertificationsSet => Certifications != null && Certifications.Length > 0;

        public override bool HasValues => base.HasValues || HasCertificationsSet;

        public TraktMovieFilter AddCertifications(string certification, params string[] certifications)
        {
            return AddCertifications(true, certification, certifications);
        }

        public TraktMovieFilter WithCertifications(string certification, params string[] certifications)
        {
            return AddCertifications(false, certification, certifications);
        }

        public override void Clear()
        {
            base.Clear();
            Certifications = null;
        }

        public override string ToString()
        {
            var parameters = new List<string>();

            parameters.Add(base.ToString());

            if (HasCertificationsSet)
                parameters.Add($"certifications={string.Join(",", Certifications)}");

            return parameters.Count > 0 ? string.Join("&", parameters) : string.Empty;
        }

        private TraktMovieFilter AddCertifications(bool keepExisting, string certification, params string[] certifications)
        {
            var certificationsList = new List<string>();

            if (keepExisting && this.Certifications != null && this.Certifications.Length > 0)
                certificationsList.AddRange(this.Certifications);

            if (!string.IsNullOrEmpty(certification))
                certificationsList.Add(certification);

            if (certifications != null && certifications.Length > 0)
                certificationsList.AddRange(certifications);

            this.Certifications = certificationsList.ToArray();

            return this;
        }
    }
}
