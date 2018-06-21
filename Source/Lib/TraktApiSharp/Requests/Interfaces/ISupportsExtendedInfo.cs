namespace TraktNet.Requests.Interfaces
{
    using Parameters;

    internal interface ISupportsExtendedInfo
    {
        TraktExtendedInfo ExtendedInfo { get; set; }
    }
}
