namespace TraktApiSharp.Experimental.Requests.Base.Interfaces
{
    using Responses;
    using System.Threading.Tasks;

    internal interface ITraktNoContentQueryable
    {
        Task<TraktNoContentResponse> QueryAsync();
    }
}
