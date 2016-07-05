namespace TraktApiSharp.Requests.Base
{
    using Enums;
    using System.Collections.Generic;

    public class TraktShowFilter
    {
        public string[] Certifications { get; set; }

        public string[] Networks { get; set; }

        public TraktShowStatus[] States { get; set; }

        public TraktShowFilter AddCertifications(string certification, params string[] certifications)
        {
            var certificationsList = new List<string>();

            certificationsList.AddRange(this.Certifications);
            certificationsList.Add(certification);
            certificationsList.AddRange(certifications);

            this.Certifications = certificationsList.ToArray();

            return this;
        }

        public TraktShowFilter WithCertifications(string certification, params string[] certifications)
        {
            this.Certifications = new string[certifications.Length + 1];

            this.Certifications[0] = certification;

            for (int i = 0; i < certifications.Length; i++)
                this.Certifications[i + 1] = certifications[i];

            return this;
        }

        public TraktShowFilter AddNetworks(string network, params string[] networks)
        {
            var networksList = new List<string>();

            networksList.AddRange(this.Networks);
            networksList.Add(network);
            networksList.AddRange(networks);

            this.Networks = networksList.ToArray();

            return this;
        }

        public TraktShowFilter WithNetworks(string network, params string[] networks)
        {
            this.Networks = new string[networks.Length + 1];

            this.Networks[0] = network;

            for (int i = 0; i < networks.Length; i++)
                this.Networks[i + 1] = networks[i];

            return this;
        }

        public TraktShowFilter AddStates(TraktShowStatus status, params TraktShowStatus[] states)
        {
            var statesList = new List<TraktShowStatus>();

            statesList.AddRange(this.States);
            statesList.Add(status);
            statesList.AddRange(states);

            this.States = statesList.ToArray();

            return this;
        }

        public TraktShowFilter WithStates(TraktShowStatus status, params TraktShowStatus[] states)
        {
            this.States = new TraktShowStatus[states.Length + 1];

            this.States[0] = status;

            for (int i = 0; i < states.Length; i++)
                this.States[i + 1] = states[i];

            return this;
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
    }
}
