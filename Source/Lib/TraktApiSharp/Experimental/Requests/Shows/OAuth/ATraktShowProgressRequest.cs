namespace TraktApiSharp.Experimental.Requests.Shows.OAuth
{
    using Base.Get;

    internal abstract class ATraktShowProgressRequest<TItem> : ATraktSingleItemGetByIdRequest<TItem>
    {
        public ATraktShowProgressRequest(TraktClient client) : base(client) { }
    }
}
