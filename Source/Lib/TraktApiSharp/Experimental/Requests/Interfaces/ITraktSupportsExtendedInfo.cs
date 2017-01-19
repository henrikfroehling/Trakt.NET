namespace TraktApiSharp.Experimental.Requests.Interfaces
{
    using TraktApiSharp.Requests.Params;

    internal interface ITraktSupportsExtendedInfo
    {
        TraktExtendedInfo ExtendedInfo { get; set; }
    }
}
