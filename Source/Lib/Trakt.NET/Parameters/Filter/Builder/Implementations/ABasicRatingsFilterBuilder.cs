namespace TraktNet.Parameters
{
    using System;
    using TraktNet.Utils;

    internal abstract class ABasicRatingsFilterBuilder<TFilter, TFilterBuilder> : ITraktBasicRatingsFilterBuilder<TFilter, TFilterBuilder>
        where TFilter : ITraktFilter
        where TFilterBuilder : ITraktFilterBuilder<TFilter, TFilterBuilder>
    {
        protected readonly TFilterBuilder _filterBuilder;
        
        internal Range<uint>? Ratings { get; private set; }
        
        internal Range<uint>? Votes { get; private set; }

        protected ABasicRatingsFilterBuilder(TFilterBuilder filterBuilder)
        {
            _filterBuilder = filterBuilder;
            Ratings = null;
            Votes = null;
        }

        public TFilterBuilder WithRatings(uint start, uint end)
        {
            if (start > 100)
                throw new ArgumentOutOfRangeException(nameof(start), "start should have maximum value of 100");

            if (end > 100)
                throw new ArgumentOutOfRangeException(nameof(start), "end should have maximum value of 100");

            if (end < start)
                throw new ArgumentOutOfRangeException(nameof(start), "start should be less than end");

            Ratings = new Range<uint>(start, end);
            return _filterBuilder;
        }

        public TFilterBuilder WithVotes(uint start, uint end)
        {
            if (start > 100000)
                throw new ArgumentOutOfRangeException(nameof(start), "start should have maximum value of 100000");

            if (end > 100000)
                throw new ArgumentOutOfRangeException(nameof(start), "end should have maximum value of 100000");

            if (end < start)
                throw new ArgumentOutOfRangeException(nameof(start), "start should be less than end");

            Votes = new Range<uint>(start, end);
            return _filterBuilder;
        }
    }
}
