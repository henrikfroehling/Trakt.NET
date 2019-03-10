namespace TraktNet.Requests.Parameters.Filter.Builder
{
    public sealed class TraktSearchFilterBuilder : TraktShowFilterBuilder<TraktSearchFilterBuilder, TraktSearchFilter>
    {
        public TraktSearchFilterBuilder() : base(new TraktSearchFilter())
        {
        }
    }
}
