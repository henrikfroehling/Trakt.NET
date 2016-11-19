namespace TraktApiSharp.Experimental.Requests.Shows.OAuth
{
    using Base.Get;
    using Interfaces;
    using System.Collections.Generic;
    using TraktApiSharp.Requests;

    internal abstract class ATraktShowProgressRequest<TItem> : ATraktSingleItemGetByIdRequest<TItem>, ITraktObjectRequest
    {
        internal ATraktShowProgressRequest(TraktClient client) : base(client) { }

        internal bool? Hidden { get; set; }

        internal bool? Specials { get; set; }

        internal bool? CountSpecials { get; set; }

        public override IDictionary<string, object> GetUriPathParameters()
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

        public override TraktAuthorizationRequirement AuthorizationRequirement => TraktAuthorizationRequirement.Required;

        public TraktRequestObjectType RequestObjectType => TraktRequestObjectType.Shows;
    }
}
