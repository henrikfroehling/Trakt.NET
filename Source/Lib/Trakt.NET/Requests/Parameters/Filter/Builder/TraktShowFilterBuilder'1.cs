namespace TraktNet.Requests.Parameters.Filter.Builder
{
    using Enums;
    using System;
    using System.Collections.Generic;

    public abstract class TraktShowFilterBuilder<T, U> : TraktShowAndMovieFilterBuilder<TraktShowFilterBuilder<T, U>, U> where T : TraktShowFilterBuilder<T, U> where U : TraktShowFilter
    {
        protected TraktShowFilterBuilder(U filter) : base(filter)
        {
        }

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
            _filter.Networks = null;
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
            _filter.States = null;
            return (T)this;
        }

        protected override void ClearAll()
        {
            base.ClearAll();
            ClearNetworks();
            ClearStates();
        }

        private void AddNetworks(bool keepExisting, string network, params string[] networks)
        {
            if (string.IsNullOrEmpty(network) && (networks == null || networks.Length <= 0))
            {
                if (!keepExisting)
                    _filter.Networks = null;

                return;
            }

            var networksList = new List<string>();

            if (keepExisting && _filter.Networks != null && _filter.Networks.Length > 0)
                networksList.AddRange(_filter.Networks);

            if (!string.IsNullOrEmpty(network))
                networksList.Add(network);

            if (networks != null && networks.Length > 0)
                networksList.AddRange(networks);

            _filter.Networks = networksList.ToArray();
        }

        private void AddStates(bool keepExisting, TraktShowStatus status, params TraktShowStatus[] states)
        {
            if ((status == null || status == TraktShowStatus.Unspecified) && (states == null || states.Length <= 0))
            {
                if (!keepExisting)
                    _filter.States = null;

                return;
            }

            var statesList = new List<TraktShowStatus>();

            if (keepExisting && _filter.States != null && _filter.States.Length > 0)
                statesList.AddRange(_filter.States);

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

            _filter.States = statesList.ToArray();
        }
    }
}
