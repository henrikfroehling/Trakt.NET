namespace TraktNet.Requests.Interfaces
{
    using Parameters.OldFilters;

    internal interface ISupportsFilter
    {
        TraktCommonFilter Filter { get; set; }
    }
}
