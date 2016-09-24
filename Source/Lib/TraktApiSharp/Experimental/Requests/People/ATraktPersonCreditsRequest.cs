namespace TraktApiSharp.Experimental.Requests.People
{
    using Base.Get;

    internal abstract class ATraktPersonCreditsRequest<T> : ATraktSingleItemGetByIdRequest<T>
    {
        public ATraktPersonCreditsRequest(TraktClient client) : base(client) { }
    }
}
