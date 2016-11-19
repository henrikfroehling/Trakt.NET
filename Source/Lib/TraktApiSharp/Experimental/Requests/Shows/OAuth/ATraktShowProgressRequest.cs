namespace TraktApiSharp.Experimental.Requests.Shows.OAuth
{
    using Base.Get;
    using Interfaces;
    using TraktApiSharp.Requests;

    internal abstract class ATraktShowProgressRequest<TItem> : ATraktSingleItemGetByIdRequest<TItem>, ITraktObjectRequest
    {
        public ATraktShowProgressRequest(TraktClient client) : base(client) { }

        internal bool? Hidden { get; set; }

        internal bool? Specials { get; set; }

        public TraktRequestObjectType RequestObjectType => TraktRequestObjectType.Shows;
    }
}
