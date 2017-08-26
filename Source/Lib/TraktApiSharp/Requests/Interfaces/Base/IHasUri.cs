namespace TraktApiSharp.Requests.Interfaces.Base
{
    internal interface IHasUri : IHasUriPathParameters
    {
        string UriTemplate { get; }
    }
}
