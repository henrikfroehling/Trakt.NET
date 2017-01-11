namespace TraktApiSharp.Requests.Base
{
    using System.Threading.Tasks;

    internal interface ITraktRequest<TResult, TItem>
    {
        Task<TResult> QueryAsync();
    }
}
