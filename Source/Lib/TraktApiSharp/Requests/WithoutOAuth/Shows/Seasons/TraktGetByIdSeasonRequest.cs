namespace TraktApiSharp.Requests.WithoutOAuth.Shows.Seasons
{
    using Base.Get;
    using System;
    using System.Collections.Generic;

    internal abstract class TraktGetByIdSeasonRequest<ResultType, ItemType> : TraktGetByIdRequest<ResultType, ItemType>
    {
        protected TraktGetByIdSeasonRequest(TraktClient client) : base(client) { }

        protected override TraktAuthorizationRequirement AuthorizationRequirement => TraktAuthorizationRequirement.NotRequired;

        protected override TraktRequestObjectType? RequestObjectType => TraktRequestObjectType.Seasons;

        protected override IDictionary<string, object> GetUriPathParameters()
        {
            var uriParams = base.GetUriPathParameters();
            uriParams.Add("season", Season.ToString());
            return uriParams;
        }

        protected override void Validate()
        {
            base.Validate();

            if (Season < 0)
                throw new ArgumentException("season must be a positive integer", "Season");
        }
    }
}
