namespace TraktApiSharp.Experimental.Requests.Users.OAuth
{
    using Base.Get;
    using Interfaces;
    using TraktApiSharp.Requests.Params;

    internal abstract class ATraktUsersPaginationGetRequest<TItem> : ATraktPaginationGetRequest<TItem>, ITraktExtendedInfo
    {
        internal ATraktUsersPaginationGetRequest(TraktClient client) : base(client) {}

        public TraktExtendedInfo ExtendedInfo { get; set; }
    }
}
