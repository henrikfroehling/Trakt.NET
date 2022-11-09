namespace TraktNet.Requests.Handler
{
    using Enums;
    using Responses.Interfaces;
    using System;

    internal class ResponseErrorHeaders : ITraktPagedResponseHeaders
    {
        public int? PageCount { get; set; }

        public int? ItemCount { get; set; }

        public TraktSortBy? SortBy { get; set; }

        public TraktSortHow? SortHow { get; set; }

        public TraktSortBy? AppliedSortBy { get; set; }

        public TraktSortHow? AppliedSortHow { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public int? TrendingUserCount { get; set; }

        public uint? Page { get; set; }

        public uint? Limit { get; set; }

        public bool? IsPrivateUser { get; set; }

        public int? ItemId { get; set; }

        public string ItemType { get; set; }

        public string RateLimit { get; set; }

        public int? RetryAfter { get; set; }

        public string UpgradeURL { get; set; }

        public bool? IsVIPUser { get; set; }

        public int? AccountLimit { get; set; }
    }
}
