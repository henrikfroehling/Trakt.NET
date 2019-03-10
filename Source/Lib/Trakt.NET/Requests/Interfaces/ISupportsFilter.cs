namespace TraktNet.Requests.Interfaces
{
    using Parameters.Filter;

    internal interface ISupportsFilter
    {
        ITraktFilter Filter { get; set; }
    }
}
