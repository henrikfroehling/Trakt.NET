namespace TraktApiSharp.Requests.Base
{
    using System.Threading.Tasks;

    public interface ITraktRequest<ResultType, ItemType>
    {
        Task<ResultType> QueryAsync();
    }
}
