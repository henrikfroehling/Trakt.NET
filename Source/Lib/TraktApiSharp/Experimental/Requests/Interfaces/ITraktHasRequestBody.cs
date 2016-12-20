namespace TraktApiSharp.Experimental.Requests.Interfaces
{
    using Base;

    internal interface ITraktHasRequestBody<TRequestBody>
    {
        TRequestBody RequestBodyContent { get; set; }

        TraktRequestBody<TRequestBody> RequestBody { get; set; }
    }
}
