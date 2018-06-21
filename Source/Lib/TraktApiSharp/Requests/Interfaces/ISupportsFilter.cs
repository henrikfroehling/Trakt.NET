namespace TraktNet.Requests.Interfaces
{
    using Parameters;

    internal interface ISupportsFilter
    {
        TraktCommonFilter Filter { get; set; }
    }
}
