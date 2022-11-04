namespace TraktNet.Parameters
{
    using System;
    using TraktNet.Utils;

    internal abstract class ACommonRatingsFilterBuilder<TFilter, TFilterBuilder>
        : ABasicRatingsFilterBuilder<TFilter, TFilterBuilder>, ITraktCommonRatingsFilterBuilder<TFilter, TFilterBuilder>
          where TFilter : ITraktFilter
          where TFilterBuilder : ITraktFilterBuilder<TFilter, TFilterBuilder>
    {
        internal Range<float>? TMBDRatings { get; private set; }
        
        internal Range<uint>? TMDBVotes { get; private set; }
        
        internal Range<float>? IMDBRatings { get; private set; }
        
        internal Range<uint>? IMDBVotes { get; private set; }

        protected ACommonRatingsFilterBuilder(TFilterBuilder filterBuilder) : base(filterBuilder)
        {
            TMBDRatings = null;
            TMDBVotes = null;
            IMDBRatings = null;
            IMDBVotes = null;
        }

        public TFilterBuilder WithTMDBRatings(float start, float end)
        {
            if (end < start)
                throw new ArgumentOutOfRangeException(nameof(start), "start should be less than end");

            TMBDRatings = new Range<float>(start, end);
            return _filterBuilder;
        }

        public TFilterBuilder WithTMDBVotes(uint start, uint end)
        {
            if (end < start)
                throw new ArgumentOutOfRangeException(nameof(start), "start should be less than end");

            TMDBVotes = new Range<uint>(start, end);
            return _filterBuilder;
        }

        public TFilterBuilder WithIMDBRatings(float start, float end)
        {
            if (end < start)
                throw new ArgumentOutOfRangeException(nameof(start), "start should be less than end");

            IMDBRatings = new Range<float>(start, end);
            return _filterBuilder;
        }

        public TFilterBuilder WithIMDBVotes(uint start, uint end)
        {
            if (end < start)
                throw new ArgumentOutOfRangeException(nameof(start), "start should be less than end");

            IMDBVotes = new Range<uint>(start, end);
            return _filterBuilder;
        }
    }
}
