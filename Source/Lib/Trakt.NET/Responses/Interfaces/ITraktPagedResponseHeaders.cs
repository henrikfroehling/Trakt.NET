namespace TraktNet.Responses.Interfaces
{
    public interface ITraktPagedResponseHeaders : ITraktResponseHeaders
    {
        int? PageCount { get; set; }

        int? ItemCount { get; set; }
    }
}
