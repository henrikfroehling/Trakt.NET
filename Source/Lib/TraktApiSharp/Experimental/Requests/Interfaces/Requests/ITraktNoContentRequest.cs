namespace TraktApiSharp.Experimental.Requests.Interfaces.Requests
{
    using Responses;
    using System.Threading.Tasks;

    internal interface ITraktNoContentRequest
    {
        Task<TraktNoContentResponse> QueryAsync();
    }
}
