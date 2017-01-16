namespace TraktApiSharp.Experimental.Requests.Interfaces.Base
{
    using Requests.Base;

    internal interface ITraktHasId
    {
        string Id { get; set; }

        TraktRequestId RequestId { get; set; }
    }
}
