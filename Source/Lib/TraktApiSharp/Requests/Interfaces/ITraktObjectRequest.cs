namespace TraktApiSharp.Requests.Interfaces
{
    using Requests.Base;

    internal interface ITraktObjectRequest
    {
        TraktRequestObjectType RequestObjectType { get; }
    }
}
