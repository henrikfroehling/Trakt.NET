namespace TraktApiSharp.Experimental.Requests.Base
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using TraktApiSharp.Requests;

    internal abstract class ATraktBaseRequest<TRequestBody>
    {
        protected abstract TraktAuthorizationRequirement AuthorizationRequirement { get; }

        public TraktClient Client
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        protected abstract HttpMethod Method { get; }

        internal string Id { get; set; }

        public TRequestBody RequestBody
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public HttpContent RequestBodyContent
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public string RequestBodyJson
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public TraktRequestObjectType? RequestObjectType
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public string UriTemplate
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public string Url
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public string BuildUrl()
        {
            throw new NotImplementedException();
        }

        protected virtual IDictionary<string, object> GetUriPathParameters() => new Dictionary<string, object>();

        protected virtual void Validate() { }
    }
}
