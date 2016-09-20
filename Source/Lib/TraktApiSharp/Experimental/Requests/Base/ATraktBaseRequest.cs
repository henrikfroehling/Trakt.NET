namespace TraktApiSharp.Experimental.Requests.Base
{
    using Interfaces;
    using System;
    using System.Collections.Generic;

    internal abstract class ATraktBaseRequest : ITraktUriBuildable
    {
        internal ATraktBaseRequest(TraktClient client)
        {
            Client = client;
        }

        public abstract string UriTemplate { get; }

        public string Url => BuildUrl();

        internal TraktClient Client { get; }

        public string BuildUrl()
        {
            throw new NotImplementedException();
        }

        public virtual IDictionary<string, object> GetUriPathParameters() => new Dictionary<string, object>();
    }
}
