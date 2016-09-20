namespace TraktApiSharp.Experimental.Requests.Base
{
    internal interface ITraktHasRequestBody<TRequestBody>
    {
        TRequestBody RequestBodyContent { get; set; }

        TraktRequestBody<TRequestBody> RequestBody { get; set; }
    }
}
