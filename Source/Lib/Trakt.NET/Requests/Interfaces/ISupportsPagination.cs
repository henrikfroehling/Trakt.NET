namespace TraktNet.Requests.Interfaces
{
    internal interface ISupportsPagination
    {
        uint? Page { get; set; }

        uint? Limit { get; set; }
    }
}
