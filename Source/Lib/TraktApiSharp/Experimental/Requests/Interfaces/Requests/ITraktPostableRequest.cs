namespace TraktApiSharp.Experimental.Requests.Interfaces.Requests
{
    internal interface ITraktPostableRequest<TRequestBody> : ITraktPostable<TRequestBody>, ITraktRequest, ITraktValidatable
    {

    }
}
