namespace TraktApiSharp.Requests.Base.Get
{
    using System.Net.Http;

    internal abstract class TraktGetRequest<TResult, TItem> : TraktRequest<TResult, TItem>
    {
        protected TraktGetRequest(TraktClient client) : base(client) { }

        protected override HttpMethod Method { get { return HttpMethod.Get; } }
    }
}
