namespace TraktNet.Parameters
{
    using System.Collections.Generic;
    using TraktNet.Utils;

    public sealed class TraktSearchFilter : ATraktShowAndMovieFilter, ITraktSearchFilter
    {
        private readonly ITraktCommonRatingsFilter _searchRatingsFilter;

        public Range<uint>? Ratings
        {
            get => _searchRatingsFilter.Ratings;
            set => _searchRatingsFilter.Ratings = value;
        }

        public Range<uint>? Votes
        {
            get => _searchRatingsFilter.Votes;
            set => _searchRatingsFilter.Votes = value;
        }

        public Range<float>? TMDBRatings
        {
            get => _searchRatingsFilter.TMDBRatings;
            set => _searchRatingsFilter.TMDBRatings = value;
        }
        
        public Range<uint>? TMDBVotes
        {
            get => _searchRatingsFilter.TMDBVotes;
            set => _searchRatingsFilter.TMDBVotes = value;
        }
        
        public Range<float>? IMDBRatings
        {
            get => _searchRatingsFilter.IMDBRatings;
            set => _searchRatingsFilter.IMDBRatings = value;
        }
        
        public Range<uint>? IMDBVotes
        {
            get => _searchRatingsFilter.IMDBVotes;
            set => _searchRatingsFilter.IMDBVotes = value;
        }

        public override bool HasValues => base.HasValues || _searchRatingsFilter.HasRatingsValues;

        public bool HasRatingsValues => _searchRatingsFilter.HasRatingsValues;

        public TraktSearchFilter() => _searchRatingsFilter = new TraktCommonRatingsFilter();

        public override IDictionary<string, object> GetParameters()
        {
            IDictionary<string, object> parameters = base.GetParameters();
            IDictionary<string, object> ratingsParameters = _searchRatingsFilter.GetRatingsParameters();

            foreach (KeyValuePair<string, object> parameter in ratingsParameters)
                parameters.Add(parameter.Key, parameter.Value);

            return parameters;
        }

        public IDictionary<string, object> GetRatingsParameters() => _searchRatingsFilter.GetRatingsParameters();

        public string RatingsToString() => _searchRatingsFilter.RatingsToString();
    }
}
