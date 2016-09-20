namespace TraktApiSharp.Experimental.Requests.Base
{
    internal abstract class ATraktBaseRequest//<TRequestBody>
    {
        internal ATraktBaseRequest(TraktClient client)
        {
            Client = client;
        }

        //protected abstract TraktAuthorizationRequirement AuthorizationRequirement { get; }

        internal TraktClient Client { get; }

        //protected abstract HttpMethod Method { get; }

        //internal string Id { get; set; }

        //public TRequestBody RequestBody
        //{
        //    get
        //    {
        //        throw new NotImplementedException();
        //    }

        //    set
        //    {
        //        throw new NotImplementedException();
        //    }
        //}

        //public HttpContent RequestBodyContent
        //{
        //    get
        //    {
        //        throw new NotImplementedException();
        //    }
        //}

        //public string RequestBodyJson
        //{
        //    get
        //    {
        //        throw new NotImplementedException();
        //    }
        //}

        //public TraktRequestObjectType? RequestObjectType
        //{
        //    get
        //    {
        //        throw new NotImplementedException();
        //    }
        //}

        //public string UriTemplate
        //{
        //    get
        //    {
        //        throw new NotImplementedException();
        //    }
        //}

        //public string Url
        //{
        //    get
        //    {
        //        throw new NotImplementedException();
        //    }
        //}

        //public string BuildUrl()
        //{
        //    throw new NotImplementedException();
        //}

        //protected virtual IDictionary<string, object> GetUriPathParameters() => new Dictionary<string, object>();

        //protected virtual void Validate() { }
    }
}
