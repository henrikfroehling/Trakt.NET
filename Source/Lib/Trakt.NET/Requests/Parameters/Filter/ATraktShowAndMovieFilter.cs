namespace TraktNet.Requests.Parameters.Filter
{
    using System.Collections.Generic;

    public abstract class ATraktShowAndMovieFilter : ATraktFilter, ITraktShowAndMovieFilter
    {
        public string[] Certifications { get; internal set; }

        public override bool HasValues => base.HasValues || HasCertificationsSet;

        public override IDictionary<string, object> GetParameters()
        {
            var parameters = base.GetParameters();

            if (HasCertificationsSet)
                parameters.Add("certifications", string.Join(",", Certifications));

            return parameters;
        }

        protected bool HasCertificationsSet => Certifications != null && Certifications.Length > 0;
    }
}
