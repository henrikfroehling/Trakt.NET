namespace TraktApiSharp.Experimental.Requests.Interfaces.Base
{
    internal interface ITraktHasId : ITraktObjectRequest, ITraktValidatable
    {
        string Id { get; set; }
    }
}
