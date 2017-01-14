namespace TraktApiSharp.Experimental.Requests.Users.OAuth
{
    using Base.Get;
    using Interfaces;
    using TraktApiSharp.Requests.Params;

    internal abstract class ATraktUsersListGetRequest<TItem> : ATraktListGetRequest<TItem>, ITraktExtendedInfo
    {
        internal ATraktUsersListGetRequest(TraktClient client) : base(client){}

        public TraktExtendedInfo ExtendedInfo { get; set; }
    }
}
