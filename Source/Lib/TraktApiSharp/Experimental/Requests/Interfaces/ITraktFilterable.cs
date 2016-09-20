namespace TraktApiSharp.Experimental.Requests.Interfaces
{
    using TraktApiSharp.Requests.Params;

    internal interface ITraktFilterable
    {
        TraktCommonFilter Filter { get; set; }
    }
}
