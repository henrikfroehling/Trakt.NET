namespace TraktNet.Parameters
{
    using System.Linq;

    internal sealed class CalendarFilterBuilder : AFilterBuilder<ITraktCalendarFilter, ITraktCalendarFilterBuilder>, ITraktCalendarFilterBuilder
    {
        private readonly CalendarRatingsFilterBuilder _calendarRatingsFilterBuilder;

        internal CalendarFilterBuilder() => _calendarRatingsFilterBuilder = new CalendarRatingsFilterBuilder(this);

        public ITraktCalendarFilterBuilder WithRatings(uint start, uint end)
            => _calendarRatingsFilterBuilder.WithRatings(start, end);

        public ITraktCalendarFilterBuilder WithVotes(uint start, uint end)
            => _calendarRatingsFilterBuilder.WithVotes(start, end);

        public override ITraktCalendarFilter Build()
        {
            ITraktCalendarFilter filter =  new TraktCalendarFilter
            {
                Query = _query,
                Year = _year,
                Years = _years,
                Runtimes = _runtimes,
                Ratings = _calendarRatingsFilterBuilder.Ratings,
                Votes = _calendarRatingsFilterBuilder.Votes
            };

            if (_genres.IsValueCreated && _genres.Value.Any())
                filter.Genres = _genres.Value.ToArray();

            if (_languages.IsValueCreated && _languages.Value.Any())
                filter.Languages = _languages.Value.ToArray();

            if (_countries.IsValueCreated && _countries.Value.Any())
                filter.Countries = _countries.Value.ToArray();

            if (_studios.IsValueCreated && _studios.Value.Any())
                filter.Studios = _studios.Value.ToArray();

            return filter;
        }

        protected override ITraktCalendarFilterBuilder GetBuilder() => this;
    }
}
