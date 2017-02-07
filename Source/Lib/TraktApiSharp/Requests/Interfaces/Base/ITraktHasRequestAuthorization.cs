namespace TraktApiSharp.Requests.Interfaces.Base
{
    using Requests.Base;

    internal interface ITraktHasRequestAuthorization
    {
        TraktAuthorizationRequirement AuthorizationRequirement { get; }
    }
}
