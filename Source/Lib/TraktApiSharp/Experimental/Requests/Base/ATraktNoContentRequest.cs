namespace TraktApiSharp.Experimental.Requests.Base
{
    using Interfaces;
    using Responses;
    using System;
    using System.Threading.Tasks;

    internal abstract class ATraktNoContentRequest : ATraktBaseRequest, ITraktNoContentRequest
    {
        internal ATraktNoContentRequest(TraktClient client) : base(client) { }

        public Task<TraktNoContentResponse> QueryAsync()
        {
            throw new NotImplementedException();
        }
    }
}
