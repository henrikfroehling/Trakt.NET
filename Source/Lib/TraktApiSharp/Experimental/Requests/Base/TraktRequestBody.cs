namespace TraktApiSharp.Experimental.Requests.Base
{
    using Interfaces;
    using System;
    using System.Net.Http;
    using System.Text;
    using Utils;

    internal sealed class TraktRequestBody<TRequestBody> : ITraktPostable<TRequestBody>, ITraktValidatable
    {
        public TRequestBody RequestBody { get; set; }

        public HttpContent RequestBodyContent
        {
            get
            {
                var json = RequestBodyJson;
                return !string.IsNullOrEmpty(json) ? new StringContent(json, Encoding.UTF8, "application/json") : null;
            }
        }

        public string RequestBodyJson
        {
            get
            {
                if (RequestBody == null)
                    return null;

                return Json.Serialize(RequestBody);
            }
        }

        public void Validate()
        {
            if (RequestBody == null)
                throw new ArgumentException("request body not set");
        }
    }
}
