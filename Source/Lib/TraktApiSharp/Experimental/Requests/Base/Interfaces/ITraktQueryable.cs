namespace TraktApiSharp.Experimental.Requests.Base.Interfaces
{
    using Responses;
    using System.Threading.Tasks;

    internal interface ITraktQueryable<TItem>
    {
        Task<TraktResponse<TItem>> QueryAsync();
    }
}
