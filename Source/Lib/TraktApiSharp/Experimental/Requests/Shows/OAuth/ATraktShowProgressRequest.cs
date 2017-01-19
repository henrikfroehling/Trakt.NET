namespace TraktApiSharp.Experimental.Requests.Shows.OAuth
{
    using System.Collections.Generic;
    using TraktApiSharp.Requests;

    internal abstract class ATraktShowProgressRequest<TItem>
    {
        internal ATraktShowProgressRequest(TraktClient client) { }

        internal bool? Hidden { get; set; }

        internal bool? Specials { get; set; }

        internal bool? CountSpecials { get; set; }

        public IDictionary<string, object> GetUriPathParameters()
        {
            var uriParams = new Dictionary<string, object>();

            if (Hidden.HasValue)
                uriParams.Add("hidden", Hidden.Value.ToString().ToLower());

            if (Specials.HasValue)
                uriParams.Add("specials", Specials.Value.ToString().ToLower());

            if (CountSpecials.HasValue)
                uriParams.Add("count_specials", CountSpecials.Value.ToString().ToLower());

            return uriParams;
        }

        public TraktAuthorizationRequirement AuthorizationRequirement => TraktAuthorizationRequirement.Required;

        public TraktRequestObjectType RequestObjectType => TraktRequestObjectType.Shows;
    }
}
