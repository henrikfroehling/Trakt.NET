namespace TraktApiSharp.Experimental.Requests.Base
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using TraktApiSharp.Requests;

    internal abstract class ATraktBaseRequest<TRequestBody>
    {
        public TraktAuthorizationRequirement AuthorizationRequirement
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public TraktClient Client
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public HttpMethod Method
        {
            get
            {
                throw new NotImplementedException();
            }
        }

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

        public IDictionary<string, object> GetUriPathParameters()
        {
            throw new NotImplementedException();
        }

        public void Validate()
        {
            throw new NotImplementedException();
        }
    }
}
