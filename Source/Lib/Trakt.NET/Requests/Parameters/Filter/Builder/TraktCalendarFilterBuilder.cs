namespace TraktNet.Requests.Parameters.Filter.Builder
{
    public sealed class TraktCalendarFilterBuilder : TraktFilterBuilder<TraktCalendarFilterBuilder, TraktCalendarFilter>
    {
        public TraktCalendarFilterBuilder() : base(new TraktCalendarFilter())
        {
        }
    }
}
