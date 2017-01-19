namespace TraktApiSharp.Experimental.Requests.Interfaces
{
    using TraktApiSharp.Requests.Params;

    internal interface ITraktSupportsFilter
    {
        TraktCommonFilter Filter { get; set; }
    }
}
