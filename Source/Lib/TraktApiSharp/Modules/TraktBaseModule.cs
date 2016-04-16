namespace TraktApiSharp.Modules
{
    using Requests.Base;
    using System.Threading.Tasks;

    public abstract class TraktBaseModule
    {
        internal TraktBaseModule(TraktClient client)
        {
            Client = client;
        }

        public TraktClient Client { get; set; }

        internal async Task<T> QueryAsync<T, U>(ITraktRequest<T, U> request)
        {
            return await request.QueryAsync();
        }
    }
}
