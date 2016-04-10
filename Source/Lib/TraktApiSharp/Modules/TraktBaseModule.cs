namespace TraktApiSharp.Modules
{
    using Requests.Base;
    using System.Threading.Tasks;

    public abstract class TraktBaseModule
    {
        protected TraktBaseModule(TraktClient client)
        {
            Client = client;
        }

        public TraktClient Client { get; set; }

        protected async Task<T> QueryAsync<T, U>(ITraktRequest<T, U> request)
        {
            return await request.QueryAsync();
        }
    }
}
