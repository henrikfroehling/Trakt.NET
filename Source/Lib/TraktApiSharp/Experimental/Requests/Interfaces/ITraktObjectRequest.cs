namespace TraktApiSharp.Experimental.Requests.Interfaces
{
    using TraktApiSharp.Requests;

    internal interface ITraktObjectRequest
    {
        TraktRequestObjectType RequestObjectType { get; }
    }
}
