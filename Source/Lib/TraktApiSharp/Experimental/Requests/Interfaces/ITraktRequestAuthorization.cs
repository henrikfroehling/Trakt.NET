namespace TraktApiSharp.Experimental.Requests.Interfaces
{
    using TraktApiSharp.Requests;

    internal interface ITraktRequestAuthorization
    {
        TraktAuthorizationRequirement AuthorizationRequirement { get; }
    }
}
