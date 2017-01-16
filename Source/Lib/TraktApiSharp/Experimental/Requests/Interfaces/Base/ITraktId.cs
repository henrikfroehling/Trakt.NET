namespace TraktApiSharp.Experimental.Requests.Interfaces.Base
{
    internal interface ITraktId : ITraktValidatable, ITraktPathParameters
    {
        string Id { get; set; }
    }
}
