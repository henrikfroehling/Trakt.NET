namespace TraktApiSharp.Experimental.Requests.Interfaces.Base
{
    internal interface ITraktHasRequestBody<TRequestBody>
    {
        TRequestBody RequestBody { get; set; }
    }
}
