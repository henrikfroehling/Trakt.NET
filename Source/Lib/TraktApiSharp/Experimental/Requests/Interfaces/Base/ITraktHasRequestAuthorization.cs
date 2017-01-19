namespace TraktApiSharp.Experimental.Requests.Interfaces.Base
{
    using TraktApiSharp.Requests;

    internal interface ITraktHasRequestAuthorization
    {
        TraktAuthorizationRequirement AuthorizationRequirement { get; }
    }
}
