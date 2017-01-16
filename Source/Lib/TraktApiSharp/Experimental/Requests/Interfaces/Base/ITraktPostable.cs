namespace TraktApiSharp.Experimental.Requests.Interfaces.Base
{
    using System.Net.Http;

    internal interface ITraktPostable<TRequestBody>
    {
        TRequestBody RequestBody { get; set; }

        HttpContent RequestBodyContent { get; }

        string RequestBodyJson { get; }
    }
}
