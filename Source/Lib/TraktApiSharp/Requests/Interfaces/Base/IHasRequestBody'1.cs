namespace TraktApiSharp.Requests.Interfaces.Base
{
    internal interface IHasRequestBody<TRequestBodyType> where TRequestBodyType : IRequestBody
    {
        TRequestBodyType RequestBody { get; set; }
    }
}
