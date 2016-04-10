namespace TraktApiSharp.Requests.Base
{
    using System.Threading.Tasks;

    public interface ITraktRequest<TResult, TItem>
    {
        Task<TResult> QueryAsync();
    }
}
