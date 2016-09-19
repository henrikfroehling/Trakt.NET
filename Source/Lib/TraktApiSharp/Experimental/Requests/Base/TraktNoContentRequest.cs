namespace TraktApiSharp.Experimental.Requests.Base
{
    using Responses;
    using System;
    using System.Threading.Tasks;

    internal class TraktNoContentRequest : ITraktNoContentQueryable
    {
        public Task<TraktNoContentResponse> QueryAsync()
        {
            throw new NotImplementedException();
        }
    }
}
