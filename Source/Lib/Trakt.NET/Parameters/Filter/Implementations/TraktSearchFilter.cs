namespace TraktNet.Parameters
{
    using System.Collections.Generic;
    using TraktNet.Utils;

    public sealed class TraktSearchFilter : ATraktShowAndMovieFilter, ITraktSearchFilter
    {
        private readonly ITraktCommonRatingsFilter _ratingsFilter;

        public Range<int>? Ratings
        {
            get => _ratingsFilter.Ratings;
            set => _ratingsFilter.Ratings = value;
        }

        public Range<int>? Votes
        {
            get => _ratingsFilter.Votes;
            set => _ratingsFilter.Votes = value;
        }

        public Range<float>? TMDBRatings
        {
            get => _ratingsFilter.TMDBRatings;
            set => _ratingsFilter.TMDBRatings = value;
        }
        
        public Range<int>? TMDBVotes
        {
            get => _ratingsFilter.TMDBVotes;
            set => _ratingsFilter.TMDBVotes = value;
        }
        
        public Range<float>? IMDBRatings
        {
            get => _ratingsFilter.IMDBRatings;
            set => _ratingsFilter.IMDBRatings = value;
        }
        
        public Range<int>? IMDBVotes
        {
            get => _ratingsFilter.IMDBVotes;
            set => _ratingsFilter.IMDBVotes = value;
        }

        public override bool HasValues => base.HasValues || _ratingsFilter.HasValues;

        public TraktSearchFilter() => _ratingsFilter = new TraktCommonRatingsFilter();

        public override IDictionary<string, object> GetParameters()
        {
            IDictionary<string, object> parameters = base.GetParameters();
            IDictionary<string, object> ratingsParameters = _ratingsFilter.GetParameters();

            foreach (KeyValuePair<string, object> parameter in ratingsParameters)
                parameters.Add(parameter.Key, parameter.Value);

            return parameters;
        }
    }
}
