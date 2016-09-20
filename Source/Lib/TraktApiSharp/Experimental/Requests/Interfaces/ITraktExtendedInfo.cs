namespace TraktApiSharp.Experimental.Requests.Interfaces
{
    using TraktApiSharp.Requests.Params;

    internal interface ITraktExtendedInfo
    {
        TraktExtendedOption ExtendedOption { get; set; }
    }
}
