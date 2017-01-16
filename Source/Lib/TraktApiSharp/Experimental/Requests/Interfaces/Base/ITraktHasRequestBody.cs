namespace TraktApiSharp.Experimental.Requests.Interfaces.Base
{
    internal interface ITraktHasRequestBody<TRequestBody>
    {
        TRequestBody RequestBodyContent { get; set; }

        ITraktPostable<TRequestBody> RequestBody { get; set; }
    }
}
