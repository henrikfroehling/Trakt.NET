namespace TraktApiSharp.Responses.Interfaces
{
    using System;

    public interface ITraktResponseHeaders
    {
        string SortBy { get; set; }

        string SortHow { get; set; }

        DateTime? StartDate { get; set; }

        DateTime? EndDate { get; set; }

        int? TrendingUserCount { get; set; }

        uint? Page { get; set; }

        uint? Limit { get; set; }

        bool? IsPrivateUser { get; set; }

        int? XItemId { get; set; }

        string XItemType { get; set; }
    }
}
