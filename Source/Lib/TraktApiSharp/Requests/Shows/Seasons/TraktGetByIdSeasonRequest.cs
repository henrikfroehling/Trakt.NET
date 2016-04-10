namespace TraktApiSharp.Requests.Shows.Seasons
{
    using Base.Get;
    using System;
    using System.Collections.Generic;
    using System.Globalization;

    internal abstract class TraktGetByIdSeasonRequest<ResultType, ItemType> : TraktGetByIdRequest<ResultType, ItemType>
    {
        protected TraktGetByIdSeasonRequest(TraktClient client) : base(client) { }

        protected override TraktAuthenticationRequirement AuthenticationRequirement { get { return TraktAuthenticationRequirement.NotRequired; } }

        protected override IEnumerable<KeyValuePair<string, string>> GetPathParameters()
        {
            var parameters = new Dictionary<string, string>();

            var baseParameters = base.GetPathParameters();
            foreach (var p in baseParameters)
                parameters.Add(p.Key, p.Value);

            parameters.Add("season", Season.ToString(CultureInfo.InvariantCulture));

            return parameters;
        }

        protected override void Validate()
        {
            base.Validate();

            if (Season <= 0)
                throw new ArgumentException("season must be a positive integer", "Season");
        }
    }
}
