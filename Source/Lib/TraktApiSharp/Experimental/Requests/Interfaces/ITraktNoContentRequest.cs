namespace TraktApiSharp.Experimental.Requests.Interfaces
{
    using Responses;
    using System.Threading.Tasks;

    internal interface ITraktNoContentRequest : ITraktRequest
    {
        Task<TraktNoContentResponse> QueryAsync();
    }
}
