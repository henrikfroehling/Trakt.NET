namespace TraktApiSharp.Experimental.Requests.Interfaces.Base
{
    using Requests.Base;

    internal interface ITraktHasId : ITraktObjectRequest, ITraktValidatable
    {
        string Id { get; set; }

        TraktRequestId RequestId { get; set; }
    }
}
