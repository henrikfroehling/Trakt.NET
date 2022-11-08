namespace TraktNet.Parameters
{
    internal sealed class ShowRatingsFilterBuilder
        : ACommonRatingsFilterBuilder<ITraktShowFilter, ITraktShowFilterBuilder>, ITraktShowRatingsFilterBuilder
    {
        internal ShowRatingsFilterBuilder(ITraktShowFilterBuilder filterBuilder) : base(filterBuilder)
        {
        }
    }
}
