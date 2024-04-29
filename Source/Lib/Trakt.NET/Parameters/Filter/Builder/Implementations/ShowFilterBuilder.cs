﻿namespace TraktNet.Parameters
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using TraktNet.Enums;

    internal sealed class ShowFilterBuilder : AShowAndMovieFilterBuilder<ITraktShowFilter, ITraktShowFilterBuilder>, ITraktShowFilterBuilder
    {
        private readonly ShowRatingsFilterBuilder _showRatingsFilterBuilder;
        private readonly Lazy<List<uint>> _networks;
        private readonly Lazy<List<TraktShowStatus>> _states;

        internal ShowFilterBuilder()
        {
            _showRatingsFilterBuilder = new ShowRatingsFilterBuilder(this);
            _networks = new Lazy<List<uint>>();
            _states = new Lazy<List<TraktShowStatus>>();
        }

        public ITraktShowFilterBuilder WithNetworkIds(uint networkId, params uint[] networkIds)
        {
            if (networkId > 0)
                _networks.Value.Add(networkId);

            if (networkIds?.Length > 0)
            {
                foreach (uint value in networkIds)
                {
                    if (value > 0)
                        _networks.Value.Add(value);
                }
            }

            return GetBuilder();
        }

        public ITraktShowFilterBuilder WithNetworkIds(IEnumerable<uint> networkIds)
        {
            if (networkIds == null)
                throw new ArgumentNullException(nameof(networkIds));

            foreach (uint networkId in networkIds)
            {
                if (networkId > 0)
                    _networks.Value.Add(networkId);
            }

            return GetBuilder();
        }

        public ITraktShowFilterBuilder WithStates(TraktShowStatus status, params TraktShowStatus[] states)
        {
            if (status == null)
                throw new ArgumentNullException(nameof(status));

            if (status == TraktShowStatus.Unspecified)
                throw new ArgumentException("status must not be unspecified", nameof(status));

            _states.Value.Add(status);

            if (states?.Length > 0)
            {
                foreach (TraktShowStatus value in states)
                {
                    if (value == TraktShowStatus.Unspecified)
                        throw new ArgumentException("status must not be unspecified", nameof(states));

                    _states.Value.Add(value);
                }
            }

            return GetBuilder();
        }

        public ITraktShowFilterBuilder WithStates(IEnumerable<TraktShowStatus> states)
        {
            if (states == null)
                throw new ArgumentNullException(nameof(states));

            foreach (TraktShowStatus status in states)
            {
                if (status == TraktShowStatus.Unspecified)
                    throw new ArgumentException("status must not be unspecified", nameof(states));

                _states.Value.Add(status);
            }

            return GetBuilder();
        }

        public ITraktShowFilterBuilder WithRatings(uint start, uint end)
            => _showRatingsFilterBuilder.WithRatings(start, end);

        public ITraktShowFilterBuilder WithVotes(uint start, uint end)
            => _showRatingsFilterBuilder.WithVotes(start, end);

        public ITraktShowFilterBuilder WithTMDBRatings(float start, float end)
            => _showRatingsFilterBuilder.WithTMDBRatings(start, end);

        public ITraktShowFilterBuilder WithTMDBVotes(uint start, uint end)
            => _showRatingsFilterBuilder.WithTMDBVotes(start, end);

        public ITraktShowFilterBuilder WithIMDBRatings(float start, float end)
            => _showRatingsFilterBuilder.WithIMDBRatings(start, end);

        public ITraktShowFilterBuilder WithIMDBVotes(uint start, uint end)
            => _showRatingsFilterBuilder.WithIMDBVotes(start, end);

        public override ITraktShowFilter Build()
        {
            var filter = new TraktShowFilter
            {
                Query = _query,
                Year = _year,
                Years = _years,
                Runtimes = _runtimes,
                Ratings = _showRatingsFilterBuilder.Ratings,
                Votes = _showRatingsFilterBuilder.Votes,
                TMDBRatings = _showRatingsFilterBuilder.TMBDRatings,
                TMDBVotes = _showRatingsFilterBuilder.TMDBVotes,
                IMDBRatings = _showRatingsFilterBuilder.IMDBRatings,
                IMDBVotes = _showRatingsFilterBuilder.IMDBVotes
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

            if (_networks.IsValueCreated && _networks.Value.Any())
                filter.NetworkIds = _networks.Value.ToArray();

            if (_states.IsValueCreated && _states.Value.Any())
                filter.States = _states.Value.ToArray();

            return filter;
        }

        protected override ITraktShowFilterBuilder GetBuilder() => this;
    }
}
