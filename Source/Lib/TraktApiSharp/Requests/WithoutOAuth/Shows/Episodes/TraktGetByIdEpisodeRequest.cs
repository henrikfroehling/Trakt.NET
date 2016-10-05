namespace TraktApiSharp.Requests.WithoutOAuth.Shows.Episodes
{
    using Base.Get;
    using System;
    using System.Collections.Generic;

    internal abstract class TraktGetByIdEpisodeRequest<ResultType, ItemType> : TraktGetByIdRequest<ResultType, ItemType>
    {
        protected TraktGetByIdEpisodeRequest(TraktClient client) : base(client) { }

        protected override TraktAuthorizationRequirement AuthorizationRequirement => TraktAuthorizationRequirement.NotRequired;

        protected override TraktRequestObjectType? RequestObjectType => TraktRequestObjectType.Episodes;

        protected override IDictionary<string, object> GetUriPathParameters()
        {
            var uriParams = base.GetUriPathParameters();

            uriParams.Add("season", Season.ToString());
            uriParams.Add("episode", Episode.ToString());

            return uriParams;
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
