namespace TraktApiSharp.Experimental.Requests.Base.Get
{
    using System.Net.Http;

    internal abstract class ATraktNoContentGetRequest : ATraktNoContentRequest<object>
    {
        protected override HttpMethod Method => HttpMethod.Get;
    }
}
