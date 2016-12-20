namespace TraktApiSharp.Experimental.Requests.Interfaces
{
    internal interface ITraktId : ITraktValidatable, ITraktPathParameters
    {
        string Id { get; set; }
    }
}
