namespace TraktApiSharp.Experimental.Requests.Interfaces
{
    using Base;

    internal interface ITraktHasId
    {
        string Id { get; set; }

        TraktRequestId RequestId { get; set; }
    }
}
