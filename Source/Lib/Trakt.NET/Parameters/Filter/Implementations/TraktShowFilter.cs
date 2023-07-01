namespace TraktNet.Parameters
{
    using System.Collections.Generic;
    using TraktNet.Enums;
    using TraktNet.Utils;

    internal class TraktShowFilter : ATraktShowAndMovieFilter, ITraktShowFilter
    {
        private readonly TraktShowRatingsFilter _showRatingsFilter;

        public uint[] NetworkIds { get; set; }

        public TraktShowStatus[] States { get; set; }

        public Range<uint>? Ratings
        {
            get => _showRatingsFilter.Ratings;
            internal set => _showRatingsFilter.Ratings = value;
        }

        public Range<uint>? Votes
        {
            get => _showRatingsFilter.Votes;
            internal set => _showRatingsFilter.Votes = value;
        }

        public Range<float>? TMDBRatings
        {
            get => _showRatingsFilter.TMDBRatings;
            internal set => _showRatingsFilter.TMDBRatings = value;
        }

        public Range<uint>? TMDBVotes
        {
            get => _showRatingsFilter.TMDBVotes;
            internal set => _showRatingsFilter.TMDBVotes = value;
        }

        public Range<float>? IMDBRatings
        {
            get => _showRatingsFilter.IMDBRatings;
            internal set => _showRatingsFilter.IMDBRatings = value;
        }

        public Range<uint>? IMDBVotes
        {
            get => _showRatingsFilter.IMDBVotes;
            internal set => _showRatingsFilter.IMDBVotes = value;
        }

        public override bool HasValues => base.HasValues || HasNetworkIdsSet || HasStatesSet || _showRatingsFilter.HasRatingsValues;

        public bool HasRatingsValues => _showRatingsFilter.HasRatingsValues;

        public TraktShowFilter() => _showRatingsFilter = new TraktShowRatingsFilter();

        public override IDictionary<string, object> GetParameters()
        {
            IDictionary<string, object> parameters = base.GetParameters();

            if (HasNetworkIdsSet)
                parameters.Add("network_ids", string.Join(",", NetworkIds));

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

        private bool HasNetworkIdsSet => NetworkIds != null && NetworkIds.Length > 0;

        private bool HasStatesSet => States != null && States.Length > 0;
    }
}
