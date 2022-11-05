namespace TraktNet.Parameters
{
    using System.Collections.Generic;
    using TraktNet.Utils;

    public sealed class TraktMovieFilter : ATraktShowAndMovieFilter, ITraktMovieFilter
    {
        private readonly ITraktMovieRatingsFilter _movieRatingsFilter;

        public Range<uint>? Ratings
        {
            get => _movieRatingsFilter.Ratings;
            set => _movieRatingsFilter.Ratings = value;
        }

        public Range<uint>? Votes
        {
            get => _movieRatingsFilter.Votes;
            set => _movieRatingsFilter.Votes = value;
        }

        public Range<float>? TMDBRatings
        {
            get => _movieRatingsFilter.TMDBRatings;
            set => _movieRatingsFilter.TMDBRatings = value;
        }

        public Range<uint>? TMDBVotes
        {
            get => _movieRatingsFilter.TMDBVotes;
            set => _movieRatingsFilter.TMDBVotes = value;
        }

        public Range<float>? IMDBRatings
        {
            get => _movieRatingsFilter.IMDBRatings;
            set => _movieRatingsFilter.IMDBRatings = value;
        }

        public Range<uint>? IMDBVotes
        {
            get => _movieRatingsFilter.IMDBVotes;
            set => _movieRatingsFilter.IMDBVotes = value;
        }

        public Range<float>? RottenTomatousMeter
        {
            get => _movieRatingsFilter.RottenTomatousMeter;
            set => _movieRatingsFilter.RottenTomatousMeter = value;
        }

        public Range<float>? Metascores
        {
            get => _movieRatingsFilter.Metascores;
            set => _movieRatingsFilter.Metascores = value;
        }

        public override bool HasValues => base.HasValues || _movieRatingsFilter.HasRatingsValues;

        public bool HasRatingsValues => _movieRatingsFilter.HasRatingsValues;

        public TraktMovieFilter() => _movieRatingsFilter = new TraktMovieRatingsFilter();

        public override IDictionary<string, object> GetParameters()
        {
            IDictionary<string, object> parameters = base.GetParameters();
            IDictionary<string, object> ratingsParameters = _movieRatingsFilter.GetRatingsParameters();

            foreach (KeyValuePair<string, object> parameter in ratingsParameters)
                parameters.Add(parameter.Key, parameter.Value);

            return parameters;
        }
    }
}
