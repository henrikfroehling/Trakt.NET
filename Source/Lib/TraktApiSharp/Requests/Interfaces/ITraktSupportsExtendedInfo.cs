namespace TraktApiSharp.Requests.Interfaces
{
    using Parameters;

    internal interface ITraktSupportsExtendedInfo
    {
        TraktExtendedInfo ExtendedInfo { get; set; }
    }
}
