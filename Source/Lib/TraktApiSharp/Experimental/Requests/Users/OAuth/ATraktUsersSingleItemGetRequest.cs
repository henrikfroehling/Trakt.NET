namespace TraktApiSharp.Experimental.Requests.Users.OAuth
{
    using Base.Get;

    internal abstract class ATraktUsersSingleItemGetRequest<TItem> : ATraktSingleItemGetRequest<TItem>
    {
        internal ATraktUsersSingleItemGetRequest(TraktClient client) : base(client) {}
    }
}
