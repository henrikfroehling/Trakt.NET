namespace TraktNet.Parameters
{
    using System;
    using System.Collections.Generic;

    public interface ITraktShowAndMovieFilterBuilder<TFilter, TFilterBuilder> : ITraktFilterBuilder<TFilter, TFilterBuilder>
        where TFilter : ITraktFilter
        where TFilterBuilder : ITraktFilterBuilder<TFilter, TFilterBuilder>
    {
        /// <summary>
        /// Adds the given <paramref name="certification"/> and optional list of <paramref name="certifications"/> to the builder.
        /// <para>Empty values will be ignored.</para>
        /// </summary>
        /// <param name="certification">A US content certification which will be added to the builder.</param>
        /// <param name="certifications">An optional list of US content certifications which will be added to the builder.</param>
        /// <returns>Returns a reference to itself. See also <typeparamref name="TFilterBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="certification"/> is null.</exception>
        TFilterBuilder WithCertifications(string certification, params string[] certifications);

        /// <summary>
        /// Adds the given <paramref name="certifications"/> to the builder.
        /// <para>Empty values will be ignored.</para>
        /// </summary>
        /// <param name="certifications">A list of US content certifications which will be added to the builder.</param>
        /// <returns>Returns a reference to itself. See also <typeparamref name="TFilterBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="certifications"/> is null.</exception>
        TFilterBuilder WithCertifications(IEnumerable<string> certifications);
    }
}
