namespace TraktNet.Requests.Interfaces
{
    using TraktNet.Parameters;

    internal interface ISupportsFilter
    {
        ITraktFilter Filter { get; set; }
    }
}
