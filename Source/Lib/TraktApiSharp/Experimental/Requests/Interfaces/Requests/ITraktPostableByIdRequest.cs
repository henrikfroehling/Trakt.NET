namespace TraktApiSharp.Experimental.Requests.Interfaces.Requests
{
    internal interface ITraktPostableByIdRequest<TRequestBody> : ITraktPostable<TRequestBody>, ITraktByIdRequest, ITraktValidatable
    {

    }
}
