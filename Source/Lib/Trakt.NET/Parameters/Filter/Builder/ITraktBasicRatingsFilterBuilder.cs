namespace TraktNet.Parameters
{
    public interface ITraktBasicRatingsFilterBuilder<TFilter, TFilterBuilder>
        where TFilter : ITraktFilter
        where TFilterBuilder : ITraktFilterBuilder<TFilter, TFilterBuilder>
    {
        TFilterBuilder WithRatings(uint start, uint end);

        TFilterBuilder WithVotes(uint start, uint end);
    }
}
