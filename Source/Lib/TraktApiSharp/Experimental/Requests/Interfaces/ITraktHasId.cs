namespace TraktApiSharp.Experimental.Requests.Interfaces
{
    internal interface ITraktHasId : ITraktObjectRequest
    {
        string Id { get; set; }
    }
}
