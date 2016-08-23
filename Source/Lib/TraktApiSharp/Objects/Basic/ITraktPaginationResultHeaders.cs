namespace TraktApiSharp.Objects.Basic
{
    public interface ITraktPaginationResultHeaders : ITraktResultHeaders
    {
        int? Page { get; set; }

        int? Limit { get; set; }

        int? PageCount { get; set; }

        int? ItemCount { get; set; }
    }
}
