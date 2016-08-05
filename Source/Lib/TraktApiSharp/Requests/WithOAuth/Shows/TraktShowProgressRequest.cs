namespace TraktApiSharp.Requests.WithOAuth.Shows
{
    using Base.Get;
    using System.Collections.Generic;

    internal abstract class TraktShowProgressRequest<T> : TraktGetByIdRequest<T, T>
    {
        internal TraktShowProgressRequest(TraktClient client) : base(client) { }

        protected override TraktAuthorizationRequirement AuthorizationRequirement => TraktAuthorizationRequirement.Required;

        internal bool? Hidden { get; set; }

        internal bool? Specials { get; set; }

        internal bool? CountSpecials { get; set; }

        protected override IDictionary<string, object> GetUriPathParameters()
        {
            var uriParams = base.GetUriPathParameters();

            if (Hidden.HasValue)
                uriParams.Add("hidden", Hidden.Value.ToString().ToLower());

            if (Specials.HasValue)
                uriParams.Add("specials", Specials.Value.ToString().ToLower());

            if (CountSpecials.HasValue)
                uriParams.Add("count_specials", CountSpecials.Value.ToString().ToLower());

            return uriParams;
        }
    }
}
