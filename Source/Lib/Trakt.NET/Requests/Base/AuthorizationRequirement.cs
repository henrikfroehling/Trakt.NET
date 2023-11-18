namespace TraktNet.Requests.Base
{
    internal enum AuthorizationRequirement
    {
        Required,
        NotRequired,
        Optional,
        OptionalButMightBeRequired
    }
}
