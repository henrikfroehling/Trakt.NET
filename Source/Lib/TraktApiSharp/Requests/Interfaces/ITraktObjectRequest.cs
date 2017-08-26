namespace TraktApiSharp.Requests.Interfaces
{
    using Requests.Base;

    internal interface ITraktObjectRequest
    {
        RequestObjectType RequestObjectType { get; }
    }
}
