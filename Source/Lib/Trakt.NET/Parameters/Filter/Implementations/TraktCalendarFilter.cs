namespace TraktNet.Parameters
{
    using System.Collections.Generic;
    using TraktNet.Utils;

    public sealed class TraktCalendarFilter : ATraktFilter, ITraktCalendarFilter
    {
        private readonly ITraktCalendarRatingsFilter _calendarRatingsFilter;

        public Range<uint>? Ratings
        {
            get => _calendarRatingsFilter.Ratings;
            set => _calendarRatingsFilter.Ratings = value;
        }
        
        public Range<uint>? Votes
        {
            get => _calendarRatingsFilter.Votes;
            set => _calendarRatingsFilter.Votes = value;
        }

        public override bool HasValues => base.HasValues || _calendarRatingsFilter.HasRatingsValues;

        public bool HasRatingsValues => _calendarRatingsFilter.HasRatingsValues;

        public TraktCalendarFilter() => _calendarRatingsFilter = new TraktCalendarRatingsFilter();

        public override IDictionary<string, object> GetParameters()
        {
            IDictionary<string, object> parameters = base.GetParameters();
            IDictionary<string, object> ratingsParameters = _calendarRatingsFilter.GetRatingsParameters();

            foreach (KeyValuePair<string, object> parameter in ratingsParameters)
                parameters.Add(parameter.Key, parameter.Value);

            return parameters;
        }

        public IDictionary<string, object> GetRatingsParameters() => _calendarRatingsFilter.GetRatingsParameters();

        public string RatingsToString() => _calendarRatingsFilter.RatingsToString();
    }
}
