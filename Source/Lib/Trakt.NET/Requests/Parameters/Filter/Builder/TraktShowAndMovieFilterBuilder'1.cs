namespace TraktNet.Requests.Parameters.Filter.Builder
{
    using System.Collections.Generic;

    public abstract class TraktShowAndMovieFilterBuilder<T, U> : TraktFilterBuilder<TraktShowAndMovieFilterBuilder<T, U>, U> where T : TraktShowAndMovieFilterBuilder<T, U> where U : ATraktShowAndMovieFilter
    {
        protected TraktShowAndMovieFilterBuilder(U filter) : base(filter)
        {
        }

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
            _filter.Certifications = null;
            return (T)this;
        }

        protected override void ClearAll()
        {
            base.ClearAll();
            ClearCertifications();
        }

        private void AddCertifications(bool keepExisting, string certification, params string[] certifications)
        {
            if (string.IsNullOrEmpty(certification) && (certifications == null || certifications.Length <= 0))
            {
                if (!keepExisting)
                    _filter.Certifications = null;

                return;
            }

            var certificationsList = new List<string>();

            if (keepExisting && _filter.Certifications != null && _filter.Certifications.Length > 0)
                certificationsList.AddRange(_filter.Certifications);

            if (!string.IsNullOrEmpty(certification))
                certificationsList.Add(certification);

            if (certifications != null && certifications.Length > 0)
                certificationsList.AddRange(certifications);

            _filter.Certifications = certificationsList.ToArray();
        }
    }
}
