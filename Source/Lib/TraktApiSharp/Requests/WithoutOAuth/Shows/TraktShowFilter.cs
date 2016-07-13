namespace TraktApiSharp.Requests.WithoutOAuth.Shows
{
    using Enums;
    using Params;
    using System;
    using System.Collections.Generic;
    using Utils;

    public class TraktShowFilter : TraktCommonMovieAndShowFilter
    {
        public TraktShowFilter() : base() { }

        public TraktShowFilter(string query, int years, string[] genres = null, string[] languages = null,
                               string[] countries = null, Range<int> runtimes = null, Range<int> ratings = null,
                               string[] certifications = null, string[] networks = null, TraktShowStatus[] states = null)
            : base(query, years, genres, languages, countries, runtimes, ratings, certifications)
        {
            WithNetworks(null, networks);
            WithStates(TraktShowStatus.Unspecified, states);
        }

        public string[] Networks { get; private set; }

        public bool HasNetworksSet => Networks != null && Networks.Length > 0;

        public TraktShowStatus[] States { get; private set; }

        public bool HasStatesSet => States != null && States.Length > 0;

        public override bool HasValues => base.HasValues || HasNetworksSet || HasStatesSet;

        public new TraktShowFilter WithQuery(string query)
        {
            base.WithQuery(query);
            return this;
        }

        public new TraktShowFilter WithYears(int years)
        {
            base.WithYears(years);
            return this;
        }

        public new TraktShowFilter AddGenres(string genre, params string[] genres)
        {
            base.AddGenres(genre, genres);
            return this;
        }

        public new TraktShowFilter WithGenres(string genre, params string[] genres)
        {
            base.WithGenres(genre, genres);
            return this;
        }

        public new TraktShowFilter AddLanguages(string language, params string[] languages)
        {
            base.AddLanguages(language, languages);
            return this;
        }

        public new TraktShowFilter WithLanguages(string language, params string[] languages)
        {
            base.WithLanguages(language, languages);
            return this;
        }

        public new TraktShowFilter AddCountries(string country, params string[] countries)
        {
            base.AddCountries(country, countries);
            return this;
        }

        public new TraktShowFilter WithCountries(string country, params string[] countries)
        {
            base.WithCountries(country, countries);
            return this;
        }

        public new TraktShowFilter WithRuntimes(int begin, int end)
        {
            base.WithRuntimes(begin, end);
            return this;
        }

        public new TraktShowFilter WithRatings(int begin, int end)
        {
            base.WithRatings(begin, end);
            return this;
        }

        public new TraktShowFilter AddCertifications(string certification, params string[] certifications)
        {
            base.AddCertifications(certification, certifications);
            return this;
        }

        public new TraktShowFilter WithCertifications(string certification, params string[] certifications)
        {
            base.WithCertifications(certification, certifications);
            return this;
        }

        public TraktShowFilter AddNetworks(string network, params string[] networks)
        {
            return AddNetworks(true, network, networks);
        }

        public TraktShowFilter WithNetworks(string network, params string[] networks)
        {
            return AddNetworks(false, network, networks);
        }

        public TraktShowFilter AddStates(TraktShowStatus status, params TraktShowStatus[] states)
        {
            return AddStates(true, status, states);
        }

        public TraktShowFilter WithStates(TraktShowStatus status, params TraktShowStatus[] states)
        {
            return AddStates(false, status, states);
        }

        public override void Clear()
        {
            base.Clear();
            Networks = null;
            States = null;
        }

        public override IDictionary<string, object> GetParameters()
        {
            var parameters = base.GetParameters();

            if (HasNetworksSet)
                parameters.Add("networks", string.Join(",", Networks));

            if (HasStatesSet)
            {
                var statesAsString = new string[States.Length];

                for (int i = 0; i < States.Length; i++)
                    statesAsString[i] = States[i].AsString();

                parameters.Add("status", string.Join(",", statesAsString));
            }

            return parameters;
        }

        private TraktShowFilter AddNetworks(bool keepExisting, string network, params string[] networks)
        {
            var networksList = new List<string>();

            if (keepExisting && this.Networks != null && this.Networks.Length > 0)
                networksList.AddRange(this.Networks);

            if (!string.IsNullOrEmpty(network))
                networksList.Add(network);

            if (networks != null && networks.Length > 0)
                networksList.AddRange(networks);

            this.Networks = networksList.ToArray();

            return this;
        }

        private TraktShowFilter AddStates(bool keepExisting, TraktShowStatus status, params TraktShowStatus[] states)
        {
            var statesList = new List<TraktShowStatus>();

            if (keepExisting && this.States != null && this.States.Length > 0)
                statesList.AddRange(this.States);

            if (status != TraktShowStatus.Unspecified)
                statesList.Add(status);

            if (states != null && states.Length > 0)
            {
                for (int i = 0; i < states.Length; i++)
                {
                    if (states[i] == TraktShowStatus.Unspecified)
                        throw new ArgumentException("status not valid", nameof(states));
                }

                statesList.AddRange(states);
            }

            this.States = statesList.ToArray();

            return this;
        }
    }
}
