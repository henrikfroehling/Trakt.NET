namespace TraktApiSharp.Requests.Interfaces
{
    using Parameters;

    internal interface ISupportsExtendedInfo
    {
        TraktExtendedInfo ExtendedInfo { get; set; }
    }
}
