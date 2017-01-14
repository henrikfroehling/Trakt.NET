namespace TraktApiSharp.Experimental.Requests.Users.OAuth
{
    using Base.Get;

    internal abstract class ATraktUsersListGetRequest<TItem> : ATraktListGetRequest<TItem>
    {
        internal ATraktUsersListGetRequest(TraktClient client) : base(client){}
    }
}
