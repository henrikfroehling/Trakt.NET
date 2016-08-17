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

        /// <summary>Gets a reference to the associated <see cref="TraktClient" /> instance.</summary>
        public TraktClient Client { get; }

        internal async Task<T> QueryAsync<T, U>(ITraktRequest<T, U> request)
        {
            return await request.QueryAsync();
        }
    }
}
