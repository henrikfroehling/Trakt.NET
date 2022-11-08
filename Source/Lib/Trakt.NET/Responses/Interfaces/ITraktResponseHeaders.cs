namespace TraktNet.Responses.Interfaces
{
    using Enums;
    using System;

    public interface ITraktResponseHeaders
    {
        /// <summary>Gets the value of the set "sort-by" response header. Might not be set.</summary>
        TraktSortBy? SortBy { get; set; }

        /// <summary>Gets the value of the set "sort-how" response header. Might not be set.</summary>
        TraktSortHow? SortHow { get; set; }

        /// <summary>Gets the value of the set "applied-sort-by" response header. Might not be set.</summary>
        TraktSortBy? AppliedSortBy { get; set; }

        /// <summary>Gets the value of the set "applied-sort-how" response header. Might not be set.</summary>
        TraktSortHow? AppliedSortHow { get; set; }

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

        /// <summary>Gets the value of the set "item-id" response header. Might not be set.</summary>
        int? ItemId { get; set; }

        /// <summary>Gets the value of the set "item-type" response header. Might not be set.</summary>
        string ItemType { get; set; }

        /// <summary>Gets the value of the set "RateLimit" response header. Might not be set.</summary>
        string RateLimit { get; set; }

        /// <summary>Gets the value of the set "Retry-After" response header. Might not be set.</summary>
        int? RetryAfter { get; set; }

        /// <summary>The web URL where the user can sign up for Trakt VIP.</summary>
        string UpgradeURL { get; set; }

        /// <summary>Determines whether the user is a VIP user.</summary>
        bool? IsVIPUser { get; set; }

        /// <summary>The user's account limit.</summary>
        int? AccountLimit { get; set; }
    }
}
