namespace TraktApiSharp.Requests.Interfaces.Base
{
    using Requests.Base;

    internal interface ITraktHasRequestAuthorization
    {
        AuthorizationRequirement AuthorizationRequirement { get; }
    }
}
