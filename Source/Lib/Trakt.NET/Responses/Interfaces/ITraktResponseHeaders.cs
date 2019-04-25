namespace TraktNet.Responses.Interfaces
{
    using System;

    public interface ITraktResponseHeaders
    {
        /// <summary>Gets the value of the set "sort-by" response header. Might not be set.</summary>
        string SortBy { get; set; }

        /// <summary>Gets the value of the set "sort-how" response header. Might not be set.</summary>
        string SortHow { get; set; }

        /// <summary>Gets the value of the set "start-date" response header. Might not be set.</summary>
        DateTime? StartDate { get; set; }

        /// <summary>Gets the value of the set "end-date" response header. Might not be set.</summary>
        DateTime? EndDate { get; set; }

        /// <summary>Gets the value of the set "trending-user-count" response header. Might not be set.</summary>
        int? TrendingUserCount { get; set; }

        /// <summary>Gets the value of the set "page" response header. Might not be set.</summary>
        uint? Page { get; set; }

        /// <summary>Gets the value of the set "limit" response header. Might not be set.</summary>
        uint? Limit { get; set; }

        /// <summary>Gets the value of the set "is-private-user" response header. Might not be set.</summary>
        bool? IsPrivateUser { get; set; }

        /// <summary>Gets the value of the set "x-item-id" response header. Might not be set.</summary>
        int? XItemId { get; set; }

        /// <summary>Gets the value of the set "x-item-type" response header. Might not be set.</summary>
        string XItemType { get; set; }
    }
}
