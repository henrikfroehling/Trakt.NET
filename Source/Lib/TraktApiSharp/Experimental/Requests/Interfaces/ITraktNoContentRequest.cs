namespace TraktApiSharp.Experimental.Requests.Interfaces
{
    using Responses;
    using System.Threading.Tasks;

    internal interface ITraktNoContentRequest
    {
        Task<TraktNoContentResponse> QueryAsync();
    }
}
