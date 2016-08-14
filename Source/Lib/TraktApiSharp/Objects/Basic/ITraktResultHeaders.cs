namespace TraktApiSharp.Objects.Basic
{
    public interface ITraktResultHeaders
    {
        int? UserCount { get; set; }

        string SortBy { get; set; }

        string SortHow { get; set; }
    }
}
