﻿namespace TraktNet.Objects.Basic
{
    using System.Collections.Generic;

    /// <summary>Represents a collection of Trakt certifications.</summary>
    public class TraktCertifications : ITraktCertifications
    {
        /// <summary>
        /// Gets or sets the certifications for the country code "us". See also <seealso cref="ITraktCertification" />.
        /// <para>Nullable</para>
        /// </summary>
        public IList<ITraktCertification> US { get; set; }
    }
}
