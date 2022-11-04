namespace TraktNet.Parameters
{
    using System.Collections.Generic;

    public interface ITraktShowAndMovieFilterBuilder<TFilter, TFilterBuilder> : ITraktFilterBuilder<TFilter, TFilterBuilder>
        where TFilter : ITraktFilter
        where TFilterBuilder : ITraktFilterBuilder<TFilter, TFilterBuilder>
    {
        TFilterBuilder WithCertifications(string certification, params string[] certifications);

        TFilterBuilder WithCertifications(IEnumerable<string> certifications);
    }
}
