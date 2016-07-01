namespace TraktApiSharp.Requests.Base
{
    using System.Collections.Generic;

    public class TraktMovieFilter : TraktFilter
    {
        public string[] Certifications { get; set; }

        public TraktMovieFilter AddCertifications(string certification, params string[] certifications)
        {
            var certificationsList = new List<string>();

            certificationsList.AddRange(this.Certifications);
            certificationsList.Add(certification);
            certificationsList.AddRange(certifications);

            this.Certifications = certificationsList.ToArray();

            return this;
        }

        public TraktMovieFilter WithCertifications(string certification, params string[] certifications)
        {
            this.Certifications = new string[certifications.Length + 1];

            this.Certifications[0] = certification;

            for (int i = 0; i < certifications.Length; i++)
                this.Certifications[i + 1] = certifications[i];

            return this;
        }
    }
}
