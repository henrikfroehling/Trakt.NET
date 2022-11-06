namespace TraktNet.Parameters
{
    internal sealed class SearchRatingsFilterBuilder
        : ACommonRatingsFilterBuilder<ITraktSearchFilter, ITraktSearchFilterBuilder>, ITraktSearchRatingsFilterBuilder
    {
        internal SearchRatingsFilterBuilder(ITraktSearchFilterBuilder filterBuilder) : base(filterBuilder)
        {
        }
    }
}
