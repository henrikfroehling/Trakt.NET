namespace TraktNet.Parameters
{
    using System.Collections.Generic;
    using TraktNet.Enums;
    using TraktNet.Utils;

    internal class TraktShowFilter : ATraktShowAndMovieFilter, ITraktShowFilter
    {
        private readonly ITraktShowRatingsFilter _showRatingsFilter;

        public string[] Networks { get; set; }

        public TraktShowStatus[] States { get; set; }

        public Range<uint>? Ratings
        {
            get => _showRatingsFilter.Ratings;
            set => _showRatingsFilter.Ratings = value;
        }

        public Range<uint>? Votes
        {
            get => _showRatingsFilter.Votes;
            set => _showRatingsFilter.Votes = value;
        }

        public Range<float>? TMDBRatings
        {
            get => _showRatingsFilter.TMDBRatings;
            set => _showRatingsFilter.TMDBRatings = value;
        }

        public Range<uint>? TMDBVotes
        {
            get => _showRatingsFilter.TMDBVotes;
            set => _showRatingsFilter.TMDBVotes = value;
        }

        public Range<float>? IMDBRatings
        {
            get => _showRatingsFilter.IMDBRatings;
            set => _showRatingsFilter.IMDBRatings = value;
        }

        public Range<uint>? IMDBVotes
        {
            get => _showRatingsFilter.IMDBVotes;
            set => _showRatingsFilter.IMDBVotes = value;
        }

        public override bool HasValues => base.HasValues || HasNetworksSet || HasStatesSet || _showRatingsFilter.HasRatingsValues;

        public bool HasRatingsValues => _showRatingsFilter.HasRatingsValues;

        public TraktShowFilter() => _showRatingsFilter = new TraktShowRatingsFilter();

        public override IDictionary<string, object> GetParameters()
        {
            IDictionary<string, object> parameters = base.GetParameters();

            if (HasNetworksSet)
                parameters.Add("networks", string.Join(",", Networks));

            if (HasStatesSet)
            {
                var statesAsString = new string[States.Length];

                for (int i = 0; i < States.Length; i++)
                    statesAsString[i] = States[i].UriName;

                parameters.Add("status", string.Join(",", statesAsString));
            }

            IDictionary<string, object> ratingsParameters = _showRatingsFilter.GetRatingsParameters();

            foreach (KeyValuePair<string, object> parameter in ratingsParameters)
                parameters.Add(parameter.Key, parameter.Value);

            return parameters;
        }

        public IDictionary<string, object> GetRatingsParameters() => _showRatingsFilter.GetRatingsParameters();

        public string RatingsToString() => _showRatingsFilter.RatingsToString();

        private bool HasNetworksSet => Networks != null && Networks.Length > 0;

        private bool HasStatesSet => States != null && States.Length > 0;
    }
}
