namespace TraktApiSharp.Experimental.Requests.Base.Get
{
    using System.Net.Http;

    internal abstract class ATraktGetRequest<TItem> : ATraktRequest<TItem, object>
    {
        protected override HttpMethod Method => HttpMethod.Get;
    }
}
