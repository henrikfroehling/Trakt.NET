namespace TraktApiSharp.Experimental.Requests.Shows.OAuth
{
    using Base.Get;
    using Interfaces;
    using TraktApiSharp.Requests;

    internal abstract class ATraktShowProgressRequest<TItem> : ATraktSingleItemGetByIdRequest<TItem>, ITraktObjectRequest
    {
        public ATraktShowProgressRequest(TraktClient client) : base(client) { }

        public TraktRequestObjectType RequestObjectType => TraktRequestObjectType.Shows;
    }
}
