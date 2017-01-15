namespace TraktApiSharp.Experimental.Requests.Users.OAuth
{
    using Base.Post;

    internal abstract class ATraktUsersPostByIdRequest<TItem, TRequestBody> : ATraktSingleItemPostByIdRequest<TItem, TRequestBody>
    {
        internal ATraktUsersPostByIdRequest(TraktClient client) : base(client) {}
    }
}
