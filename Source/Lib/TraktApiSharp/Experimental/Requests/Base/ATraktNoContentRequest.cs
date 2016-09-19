namespace TraktApiSharp.Experimental.Requests.Base
{
    using Interfaces;
    using Responses;
    using System;
    using System.Threading.Tasks;

    internal abstract class ATraktNoContentRequest<TRequestBody> : ATraktBaseRequest<TRequestBody>, ITraktNoContentQueryable
    {
        public Task<TraktNoContentResponse> QueryAsync()
        {
            throw new NotImplementedException();
        }
    }
}
