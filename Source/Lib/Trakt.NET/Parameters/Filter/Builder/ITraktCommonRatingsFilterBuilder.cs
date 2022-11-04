namespace TraktNet.Parameters
{
    public interface ITraktCommonRatingsFilterBuilder<TFilter, TFilterBuilder> : ITraktBasicRatingsFilterBuilder<TFilter, TFilterBuilder>
        where TFilter : ITraktFilter
        where TFilterBuilder : ITraktFilterBuilder<TFilter, TFilterBuilder>
    {
        TFilterBuilder WithTMDBRatings(float start, float end);

        TFilterBuilder WithTMDBVotes(uint start, uint end);

        TFilterBuilder WithIMDBRatings(float start, float end);

        TFilterBuilder WithIMDBVotes(uint start, uint end);
    }
}
