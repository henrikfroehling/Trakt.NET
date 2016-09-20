namespace TraktApiSharp.Experimental.Requests.Base
{
    internal interface ITraktHasId
    {
        string Id { get; set; }

        TraktRequestId RequestId { get; set; }
    }
}
