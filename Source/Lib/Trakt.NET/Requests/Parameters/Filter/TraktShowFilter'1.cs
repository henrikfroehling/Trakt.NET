namespace TraktNet.Requests.Parameters.Filter
{
    using Enums;
    using System;
    using System.Collections.Generic;

    public abstract class TraktShowFilter<T> : TraktShowAndMovieFilter<TraktShowFilter<T>> where T : TraktShowFilter<T>
    {
        public string[] Networks { get; protected set; }

        public TraktShowStatus[] States { get; protected set; }

        public T AddNetworks(string network, params string[] networks)
        {
            AddNetworks(true, network, networks);
            return (T)this;
        }

        public T WithNetworks(string network, params string[] networks)
        {
            AddNetworks(false, network, networks);
            return (T)this;
        }

        public T ClearNetworks()
        {
            Networks = null;
            return (T)this;
        }

        public T AddStates(TraktShowStatus status, params TraktShowStatus[] states)
        {
            AddStates(true, status, states);
            return (T)this;
        }

        public T WithStates(TraktShowStatus status, params TraktShowStatus[] states)
        {
            AddStates(false, status, states);
            return (T)this;
        }

        public T ClearStates()
        {
            States = null;
            return (T)this;
        }

        protected override void ClearAll()
        {
            base.ClearAll();
            ClearNetworks();
            ClearStates();
        }

        protected bool HasNetworksSet => Networks != null && Networks.Length > 0;

        protected bool HasStatesSet => States != null && States.Length > 0;

        internal override bool HasValues => base.HasValues || HasNetworksSet || HasStatesSet;

        internal override IDictionary<string, object> GetParameters()
        {
            var parameters = base.GetParameters();

            if (HasNetworksSet)
                parameters.Add("networks", string.Join(",", Networks));

            if (HasStatesSet)
            {
                var statesAsString = new string[States.Length];

                for (int i = 0; i < States.Length; i++)
                    statesAsString[i] = States[i].UriName;

                parameters.Add("status", string.Join(",", statesAsString));
            }

            return parameters;
        }

        private void AddNetworks(bool keepExisting, string network, params string[] networks)
        {
            if (string.IsNullOrEmpty(network) && (networks == null || networks.Length <= 0))
            {
                if (!keepExisting)
                    Networks = null;

                return;
            }

            var networksList = new List<string>();

            if (keepExisting && Networks != null && Networks.Length > 0)
                networksList.AddRange(Networks);

            if (!string.IsNullOrEmpty(network))
                networksList.Add(network);

            if (networks != null && networks.Length > 0)
                networksList.AddRange(networks);

            Networks = networksList.ToArray();
        }

        private void AddStates(bool keepExisting, TraktShowStatus status, params TraktShowStatus[] states)
        {
            if ((status == null || status == TraktShowStatus.Unspecified) && (states == null || states.Length <= 0))
            {
                if (!keepExisting)
                    States = null;

                return;
            }

            var statesList = new List<TraktShowStatus>();

            if (keepExisting && States != null && States.Length > 0)
                statesList.AddRange(States);

            if (status != null && status != TraktShowStatus.Unspecified)
                statesList.Add(status);

            if (states != null && states.Length > 0)
            {
                for (int i = 0; i < states.Length; i++)
                {
                    if (states[i] == null || states[i] == TraktShowStatus.Unspecified)
                        throw new ArgumentException("status not valid", nameof(states));
                }

                statesList.AddRange(states);
            }

            States = statesList.ToArray();
        }
    }
}
