namespace TraktApiSharp.Experimental.Requests.Interfaces
{
    using Base;

    internal interface ITraktRequest : ITraktHttpRequest, ITraktRequestAuthorization, ITraktUriBuildable
    {

    }
}
