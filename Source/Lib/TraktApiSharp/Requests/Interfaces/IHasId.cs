namespace TraktApiSharp.Requests.Interfaces
{
    internal interface IHasId : ITraktObjectRequest
    {
        string Id { get; set; }
    }
}
