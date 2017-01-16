namespace TraktApiSharp.Experimental.Requests.Interfaces.Base
{
    using Requests.Base;

    internal interface ITraktHasId : ITraktObjectRequest
    {
        string Id { get; set; }

        TraktRequestId RequestId { get; set; }
    }
}
