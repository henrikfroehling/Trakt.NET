namespace TraktApiSharp.Experimental.Requests.Interfaces.Requests
{
    using TraktApiSharp.Requests;

    internal interface ITraktRequestAuthorization
    {
        TraktAuthorizationRequirement AuthorizationRequirement { get; }
    }
}
