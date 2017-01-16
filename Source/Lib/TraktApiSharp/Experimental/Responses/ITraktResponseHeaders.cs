namespace TraktApiSharp.Experimental.Responses
{
    public interface ITraktResponseHeaders
    {
        int? UserCount { get; set; }

        string SortBy { get; set; }

        string SortHow { get; set; }
    }
}
