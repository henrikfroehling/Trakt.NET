namespace TraktNet.Requests.Interfaces
{
    internal interface IHasId<T> : IObjectRequest
    {
        T Id { get; set; }
    }
}
