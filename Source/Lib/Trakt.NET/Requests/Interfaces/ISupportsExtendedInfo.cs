namespace TraktNet.Requests.Interfaces
{
    using Parameters;
    using TraktNet.Parameters;

    internal interface ISupportsExtendedInfo
    {
        TraktExtendedInfo ExtendedInfo { get; set; }
    }
}
