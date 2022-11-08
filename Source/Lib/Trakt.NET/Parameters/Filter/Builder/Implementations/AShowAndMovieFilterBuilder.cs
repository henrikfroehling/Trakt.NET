namespace TraktNet.Parameters
{
    using System;
    using System.Collections.Generic;

    internal abstract class AShowAndMovieFilterBuilder<TFilter, TFilterBuilder>
        : AFilterBuilder<TFilter, TFilterBuilder>, ITraktShowAndMovieFilterBuilder<TFilter, TFilterBuilder>
          where TFilter : ITraktFilter
          where TFilterBuilder : ITraktFilterBuilder<TFilter, TFilterBuilder>
    {
        protected Lazy<List<string>> _certifications;

        protected AShowAndMovieFilterBuilder() => _certifications = new Lazy<List<string>>();

        public TFilterBuilder WithCertifications(string certification, params string[] certifications)
        {
            if (certification == null)
                throw new ArgumentNullException(nameof(certification));

            if (certification.Length > 0)
                _certifications.Value.Add(certification);

            if (certifications?.Length > 0)
            {
                foreach (string value in certifications)
                {
                    if (!string.IsNullOrEmpty(value))
                        _certifications.Value.Add(value);
                }
            }

            return GetBuilder();
        }

        public TFilterBuilder WithCertifications(IEnumerable<string> certifications)
        {
            if (certifications == null)
                throw new ArgumentNullException(nameof(certifications));

            foreach (string certification in certifications)
            {
                if (!string.IsNullOrEmpty(certification))
                    _certifications.Value.Add(certification);
            }

            return GetBuilder();
        }
    }
}
