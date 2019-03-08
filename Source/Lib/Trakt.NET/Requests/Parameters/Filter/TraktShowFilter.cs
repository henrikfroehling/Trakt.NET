namespace TraktNet.Requests.Parameters.Filter
{
    using Enums;
    using Interfaces;
    using System.Collections.Generic;

    public class TraktShowFilter : ATraktShowAndMovieFilter, ITraktShowFilter
    {
        public string[] Networks { get; internal set; }

        public TraktShowStatus[] States { get; internal set; }

        public override bool HasValues => base.HasValues || HasNetworksSet || HasStatesSet;

        public override IDictionary<string, object> GetParameters()
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

        protected bool HasNetworksSet => Networks != null && Networks.Length > 0;

        protected bool HasStatesSet => States != null && States.Length > 0;
    }
}
