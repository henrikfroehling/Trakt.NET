namespace TraktApiSharp.Experimental.Requests.Users.OAuth
{
    using Base.Delete;

    internal abstract class ATraktUsersDeleteByIdRequest : ATraktNoContentDeleteByIdRequest
    {
        internal ATraktUsersDeleteByIdRequest(TraktClient client) : base(client) { }
    }
}
