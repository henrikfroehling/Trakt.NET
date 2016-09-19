namespace TraktApiSharp.Experimental.Requests
{
    using Responses;
    using System.Threading.Tasks;

    internal interface ITraktNoContentQueryable
    {
        Task<TraktNoContentResponse> QueryAsync();
    }
}
