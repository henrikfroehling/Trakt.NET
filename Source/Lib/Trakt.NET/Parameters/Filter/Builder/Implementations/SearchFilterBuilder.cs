namespace TraktNet.Parameters
{
    using System.Linq;

    internal sealed class SearchFilterBuilder : AShowAndMovieFilterBuilder<ITraktSearchFilter, ITraktSearchFilterBuilder>, ITraktSearchFilterBuilder
    {
        private readonly SearchRatingsFilterBuilder _searchRatingsFilterBuilder;

        internal SearchFilterBuilder() => _searchRatingsFilterBuilder = new SearchRatingsFilterBuilder(this);

        public ITraktSearchFilterBuilder WithRatings(uint start, uint end)
            => _searchRatingsFilterBuilder.WithRatings(start, end);

        public ITraktSearchFilterBuilder WithVotes(uint start, uint end)
            => _searchRatingsFilterBuilder.WithVotes(start, end);

        public ITraktSearchFilterBuilder WithTMDBRatings(float start, float end)
            => _searchRatingsFilterBuilder.WithTMDBRatings(start, end);

        public ITraktSearchFilterBuilder WithTMDBVotes(uint start, uint end)
            => _searchRatingsFilterBuilder.WithTMDBVotes(start, end);

        public ITraktSearchFilterBuilder WithIMDBRatings(float start, float end)
            => _searchRatingsFilterBuilder.WithIMDBRatings(start, end);

        public ITraktSearchFilterBuilder WithIMDBVotes(uint start, uint end)
            => _searchRatingsFilterBuilder.WithIMDBVotes(start, end);

        public override ITraktSearchFilter Build()
        {
            ITraktSearchFilter filter = new TraktSearchFilter
            {
                Query = _query,
                Year = _year,
                Years = _years,
                Runtimes = _runtimes,
                Ratings = _searchRatingsFilterBuilder.Ratings,
                Votes = _searchRatingsFilterBuilder.Votes,
                TMDBRatings = _searchRatingsFilterBuilder.TMBDRatings,
                TMDBVotes = _searchRatingsFilterBuilder.TMDBVotes,
                IMDBRatings = _searchRatingsFilterBuilder.IMDBRatings,
                IMDBVotes = _searchRatingsFilterBuilder.IMDBVotes
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

        protected override ITraktSearchFilterBuilder GetBuilder() => this;
    }
}
