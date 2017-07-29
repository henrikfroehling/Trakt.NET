namespace TraktApiSharp.Requests.Interfaces.Base
{
    internal interface ITraktHasRequestBody<TRequestBodyType>
    {
        TRequestBodyType RequestBody { get; set; }
    }
}
