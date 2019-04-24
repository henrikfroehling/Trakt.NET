namespace TraktNet.Responses.Interfaces
{
    public interface ITraktPagedResponseHeaders : ITraktResponseHeaders
    {
        /// <summary>Gets the page count for this response.</summary>
        int? PageCount { get; set; }

        /// <summary>Gets the item count per page for this response.</summary>
        int? ItemCount { get; set; }
    }
}
