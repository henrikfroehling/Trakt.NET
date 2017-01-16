namespace TraktApiSharp.Experimental.Requests.Base
{
    using Interfaces.Base;
    using Responses.Interfaces.Base;
    using System;
    using System.Threading.Tasks;

    internal abstract class ATraktNoContentRequest : ATraktBaseRequest, ITraktNoContentRequest
    {
        internal ATraktNoContentRequest(TraktClient client) : base(client) { }

        public Task<ITraktNoContentResponse> QueryAsync()
        {
            throw new NotImplementedException();
        }
    }
}
