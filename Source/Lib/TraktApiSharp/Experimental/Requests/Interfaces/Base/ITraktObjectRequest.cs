namespace TraktApiSharp.Experimental.Requests.Interfaces.Base
{
    using TraktApiSharp.Requests;

    internal interface ITraktObjectRequest
    {
        TraktRequestObjectType RequestObjectType { get; }
    }
}
