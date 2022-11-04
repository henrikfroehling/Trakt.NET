namespace TraktNet.Parameters
{
    using System.Linq;

    internal sealed class MovieFilterBuilder : AShowAndMovieFilterBuilder<ITraktMovieFilter, ITraktMovieFilterBuilder>, ITraktMovieFilterBuilder
    {
        private readonly MovieRatingsFilterBuilder _movieRatingsFilterBuilder;

        internal MovieFilterBuilder() => _movieRatingsFilterBuilder = new MovieRatingsFilterBuilder(this);

        public ITraktMovieFilterBuilder WithRatings(uint start, uint end)
            => _movieRatingsFilterBuilder.WithRatings(start, end);

        public ITraktMovieFilterBuilder WithVotes(uint start, uint end)
            => _movieRatingsFilterBuilder.WithVotes(start, end);

        public ITraktMovieFilterBuilder WithTMDBRatings(float start, float end)
            => _movieRatingsFilterBuilder.WithTMDBRatings(start, end);

        public ITraktMovieFilterBuilder WithTMDBVotes(uint start, uint end)
            => _movieRatingsFilterBuilder.WithTMDBVotes(start, end);

        public ITraktMovieFilterBuilder WithIMDBRatings(float start, float end)
            => _movieRatingsFilterBuilder.WithIMDBRatings(start, end);

        public ITraktMovieFilterBuilder WithIMDBVotes(uint start, uint end)
            => _movieRatingsFilterBuilder.WithIMDBVotes(start, end);

        public ITraktMovieFilterBuilder WithRottenTomatoesMeter(float start, float end)
            => _movieRatingsFilterBuilder.WithRottenTomatoesMeter(start, end);

        public ITraktMovieFilterBuilder WithMetascores(float start, float end)
            => _movieRatingsFilterBuilder.WithMetascores(start, end);

        public override ITraktMovieFilter Build()
        {
            ITraktMovieFilter filter = new TraktMovieFilter
            {
                Query = _query,
                Year = _year,
                Years = _years,
                Runtimes = _runtimes,
                Ratings = _movieRatingsFilterBuilder.Ratings,
                Votes = _movieRatingsFilterBuilder.Votes,
                TMDBRatings = _movieRatingsFilterBuilder.TMBDRatings,
                TMDBVotes = _movieRatingsFilterBuilder.TMDBVotes,
                IMDBRatings = _movieRatingsFilterBuilder.IMDBRatings,
                IMDBVotes = _movieRatingsFilterBuilder.IMDBVotes,
                RottenTomatousMeter = _movieRatingsFilterBuilder.RottenTomatoesMeter,
                Metascores = _movieRatingsFilterBuilder.Metascores
            };

            if (_genres.IsValueCreated && _genres.Value.Any())
                filter.Genres = _genres.Value.ToArray();

            if (_languages.IsValueCreated && _languages.Value.Any())
                filter.Languages = _languages.Value.ToArray();

            if (_countries.IsValueCreated && _countries.Value.Any())
                filter.Countries = _countries.Value.ToArray();

            if (_studios.IsValueCreated && _studios.Value.Any())
                filter.Studios = _studios.Value.ToArray();

            if (_certifications.IsValueCreated && _certifications.Value.Any())
                filter.Certifications = _certifications.Value.ToArray();

            return filter;
        }

        protected override ITraktMovieFilterBuilder GetBuilder() => this;
    }
}
