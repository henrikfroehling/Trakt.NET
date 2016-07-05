namespace TraktApiSharp.Requests.Base
{
    using Enums;
    using System;
    using System.Collections.Generic;

    public class TraktShowFilter : TraktFilter
    {
        public TraktShowFilter() { }

        public TraktShowFilter(string query, int years, string[] genres = null, string[] languages = null,
                               string[] countries = null, Range<int> runtimes = null, Range<int> ratings = null,
                               string[] certifications = null, string[] networks = null, TraktShowStatus[] states = null)
            : base(query, years, genres, languages, countries, runtimes, ratings)
        {
            WithCertifications(null, certifications);
            WithNetworks(null, networks);
            WithStates(TraktShowStatus.Unspecified, states);
        }

        public string[] Certifications { get; private set; }

        public string[] Networks { get; private set; }

        public TraktShowStatus[] States { get; private set; }

        public TraktShowFilter AddCertifications(string certification, params string[] certifications)
        {
            return AddCertifications(true, certification, certifications);
        }

        public TraktShowFilter WithCertifications(string certification, params string[] certifications)
        {
            return AddCertifications(false, certification, certifications);
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
            Certifications = null;
            Networks = null;
            States = null;
        }

        public override string ToString()
        {
            var parameters = new List<string>();

            parameters.Add(base.ToString());

            if (Certifications != null && Certifications.Length > 0)
                parameters.Add($"certifications={string.Join(",", Certifications)}");

            if (Networks != null && Networks.Length > 0)
                parameters.Add($"networks={string.Join(",", Networks)}");

            if (States != null && States.Length > 0)
            {
                var statesAsString = new string[States.Length];

                for (int i = 0; i < States.Length; i++)
                    statesAsString[i] = States[i].AsString();

                parameters.Add($"status={string.Join(",", statesAsString)}");
            }

            return parameters.Count > 0 ? string.Join("&", parameters) : string.Empty;
        }

        private TraktShowFilter AddCertifications(bool keepExisting, string certification, params string[] certifications)
        {
            var certificationsList = new List<string>();

            if (keepExisting && this.Certifications != null && this.Certifications.Length > 0)
                certificationsList.AddRange(this.Certifications);

            if (!string.IsNullOrEmpty(certification))
                certificationsList.Add(certification);

            if (certifications != null && certifications.Length > 0)
                certificationsList.AddRange(certifications);

            this.Certifications = certificationsList.ToArray();

            return this;
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
