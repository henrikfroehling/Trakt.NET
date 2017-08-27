namespace TraktApiSharp.Requests.Interfaces.Base
{
    internal interface IHasRequestBody<TRequestBodyType>
    {
        TRequestBodyType RequestBody { get; set; }
    }
}
