namespace TraktApiSharp.Experimental.Requests.Interfaces
{
    using Requests.Base;

    internal interface ITraktHasId
    {
        string Id { get; set; }

        TraktRequestId RequestId { get; set; }
    }
}
