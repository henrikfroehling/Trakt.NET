namespace TraktApiSharp.Requests.Base
{
    using System.Collections.Generic;

    public class TraktMovieFilter : TraktFilter
    {
        public string[] Certifications { get; private set; }

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

            if (Certifications != null && Certifications.Length > 0)
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
