namespace TraktApiSharp.Experimental.Requests.Interfaces
{
    using Base;

    internal interface ITraktId : ITraktValidatable, ITraktPathParameters
    {
        string Id { get; set; }
    }
}
