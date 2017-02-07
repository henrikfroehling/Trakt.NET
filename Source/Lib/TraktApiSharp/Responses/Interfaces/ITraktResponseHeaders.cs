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

        int? Page { get; set; }

        int? Limit { get; set; }

        bool? IsPrivateUser { get; set; }
    }
}
