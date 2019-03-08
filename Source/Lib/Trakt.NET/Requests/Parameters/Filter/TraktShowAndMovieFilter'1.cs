namespace TraktNet.Requests.Parameters.Filter
{
    using System.Collections.Generic;

    public abstract class TraktShowAndMovieFilter<T> : TraktFilter<TraktShowAndMovieFilter<T>> where T : TraktShowAndMovieFilter<T>
    {
        public string[] Certifications { get; protected set; }

        public T AddCertifications(string certification, params string[] certifications)
        {
            AddCertifications(true, certification, certifications);
            return (T)this;
        }

        public T WithCertifications(string certification, params string[] certifications)
        {
            AddCertifications(false, certification, certifications);
            return (T)this;
        }

        public T ClearCertifications()
        {
            Certifications = null;
            return (T)this;
        }

        protected override void ClearAll()
        {
            base.ClearAll();
            ClearCertifications();
        }

        protected bool HasCertificationsSet => Certifications != null && Certifications.Length > 0;

        internal override bool HasValues => base.HasValues || HasCertificationsSet;

        internal override IDictionary<string, object> GetParameters()
        {
            var parameters = base.GetParameters();

            if (HasCertificationsSet)
                parameters.Add("certifications", string.Join(",", Certifications));

            return parameters;
        }

        private void AddCertifications(bool keepExisting, string certification, params string[] certifications)
        {
            if (string.IsNullOrEmpty(certification) && (certifications == null || certifications.Length <= 0))
            {
                if (!keepExisting)
                    Certifications = null;

                return;
            }

            var certificationsList = new List<string>();

            if (keepExisting && Certifications != null && Certifications.Length > 0)
                certificationsList.AddRange(Certifications);

            if (!string.IsNullOrEmpty(certification))
                certificationsList.Add(certification);

            if (certifications != null && certifications.Length > 0)
                certificationsList.AddRange(certifications);

            Certifications = certificationsList.ToArray();
        }
    }
}
