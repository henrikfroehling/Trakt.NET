namespace TraktApiSharp.Requests.Interfaces
{
    internal interface IHasId : IObjectRequest
    {
        string Id { get; set; }
    }
}
