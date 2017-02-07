namespace TraktApiSharp.Requests.Interfaces
{
    using Parameters;

    internal interface ITraktSupportsFilter
    {
        TraktCommonFilter Filter { get; set; }
    }
}
