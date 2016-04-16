namespace TraktApiSharp.Requests.WithoutOAuth.Shows.Episodes
{
    using Base.Get;
    using System;
    using System.Collections.Generic;
    using System.Globalization;

    internal abstract class TraktGetByIdEpisodeRequest<ResultType, ItemType> : TraktGetByIdRequest<ResultType, ItemType>
    {
        protected TraktGetByIdEpisodeRequest(TraktClient client) : base(client) { }

        protected override TraktAuthenticationRequirement AuthenticationRequirement { get { return TraktAuthenticationRequirement.NotRequired; } }

        protected override IEnumerable<KeyValuePair<string, string>> GetPathParameters()
        {
            var parameters = new Dictionary<string, string>();

            var baseParameters = base.GetPathParameters();
            foreach (var p in baseParameters)
                parameters.Add(p.Key, p.Value);

            parameters.Add("season", Season.ToString(CultureInfo.InvariantCulture));
            parameters.Add("episode", Episode.ToString(CultureInfo.InvariantCulture));

            return parameters;
        }

        protected override void Validate()
        {
            base.Validate();

            if (Season <= 0)
                throw new ArgumentException("season must be a positive integer", "Season");

            if (Episode <= 0)
                throw new ArgumentException("episode must be a positive integer", "Episode");
        }
    }
}
