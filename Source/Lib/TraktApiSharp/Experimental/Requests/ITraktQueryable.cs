namespace TraktApiSharp.Experimental.Requests
{
    using Responses;
    using System.Threading.Tasks;

    internal interface ITraktQueryable<TItem>
    {
        Task<TraktResponse<TItem>> QueryAsync();
    }
}
