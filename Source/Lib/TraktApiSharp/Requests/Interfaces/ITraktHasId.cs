namespace TraktApiSharp.Requests.Interfaces
{
    internal interface ITraktHasId : ITraktObjectRequest
    {
        string Id { get; set; }
    }
}
