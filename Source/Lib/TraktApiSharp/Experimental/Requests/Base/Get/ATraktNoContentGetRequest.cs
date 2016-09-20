namespace TraktApiSharp.Experimental.Requests.Base.Get
{
    using System.Net.Http;

    internal abstract class ATraktNoContentGetRequest : ATraktNoContentRequest<object>
    {
        public ATraktNoContentGetRequest(TraktClient client) : base(client) { }

        protected override HttpMethod Method => HttpMethod.Get;
    }
}
