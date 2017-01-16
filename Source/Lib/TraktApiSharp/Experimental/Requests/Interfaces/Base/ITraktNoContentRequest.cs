namespace TraktApiSharp.Experimental.Requests.Interfaces.Base
{
    using Responses.Interfaces.Base;
    using System.Threading.Tasks;

    internal interface ITraktNoContentRequest : ITraktRequest
    {
        Task<ITraktNoContentResponse> QueryAsync();
    }
}
