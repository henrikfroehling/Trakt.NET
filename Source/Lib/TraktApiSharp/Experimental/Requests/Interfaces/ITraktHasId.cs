namespace TraktApiSharp.Experimental.Requests.Interfaces
{
    internal interface ITraktHasId : ITraktObjectRequest, ITraktValidatable
    {
        string Id { get; set; }
    }
}
