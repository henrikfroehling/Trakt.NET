namespace TraktApiSharp.Experimental.Requests.People
{
    using Base.Get;
    using Interfaces;
    using TraktApiSharp.Requests;

    internal abstract class ATraktPersonCreditsRequest<T> : ATraktSingleItemGetByIdRequest<T>, ITraktObjectRequest
    {
        public ATraktPersonCreditsRequest(TraktClient client) : base(client) { }

        public TraktRequestObjectType? RequestObjectType => TraktRequestObjectType.People;
    }
}
