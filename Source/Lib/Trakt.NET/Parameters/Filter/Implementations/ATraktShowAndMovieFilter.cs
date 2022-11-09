﻿namespace TraktNet.Parameters
{
    using System.Collections.Generic;

    internal abstract class ATraktShowAndMovieFilter : ATraktFilter, ITraktShowAndMovieFilter
    {
        public string[] Certifications { get; internal set; }

        public override bool HasValues => base.HasValues || HasCertificationsSet;

        public override IDictionary<string, object> GetParameters()
        {
            IDictionary<string, object> parameters = base.GetParameters();

            if (HasCertificationsSet)
                parameters.Add("certifications", string.Join(",", Certifications));

            return parameters;
        }

        protected bool HasCertificationsSet => Certifications != null && Certifications.Length > 0;
    }
}
