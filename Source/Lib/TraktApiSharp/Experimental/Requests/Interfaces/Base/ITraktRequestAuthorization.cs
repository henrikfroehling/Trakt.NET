namespace TraktApiSharp.Experimental.Requests.Interfaces.Base
{
    using TraktApiSharp.Requests;

    internal interface ITraktRequestAuthorization
    {
        TraktAuthorizationRequirement AuthorizationRequirement { get; }
    }
}
