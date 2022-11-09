﻿namespace TraktNet.Requests.Handler
{
    using Enums;
    using Responses.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http.Headers;

    internal static class ResponseHeaderParser
    {
        private const string HEADER_PAGINATION_PAGE_KEY = "X-Pagination-Page";
        private const string HEADER_PAGINATION_LIMIT_KEY = "X-Pagination-Limit";
        private const string HEADER_PAGINATION_PAGE_COUNT_KEY = "X-Pagination-Page-Count";
        private const string HEADER_PAGINATION_ITEM_COUNT_KEY = "X-Pagination-Item-Count";
        private const string HEADER_TRENDING_USER_COUNT_KEY = "X-Trending-User-Count";
        private const string HEADER_SORT_BY_KEY = "X-Sort-By";
        private const string HEADER_SORT_HOW_KEY = "X-Sort-How";
        private const string HEADER_STARTDATE_KEY = "X-Start-Date";
        private const string HEADER_ENDDATE_KEY = "X-End-Date";
        private const string HEADER_PRIVATE_USER_KEY = "X-Private-User";
        private const string HEADER_ITEM_ID = "X-Item-ID";
        private const string HEADER_ITEM_TYPE = "X-Item-Type";
        private const string HEADER_APPLIED_SORT_BY = "X-Applied-Sort-By";
        private const string HEADER_APPLIED_SORT_HOW = "X-Applied-Sort-How";
        private const string HEADER_RATE_LIMIT = "X-RateLimit";
        private const string HEADER_RETRY_AFTER = "Retry-After";
        private const string HEADER_UPGRADE_URL = "X-Upgrade-URL";
        private const string HEADER_VIP_USER = "X-VIP-User";
        private const string HEADER_ACCOUNT_LIMIT = "X-Account-Limit";

        internal static void ParseResponseHeaderValues(ITraktResponseHeaders headerResults, HttpResponseHeaders responseHeaders)
        {
            if (responseHeaders.TryGetValues(HEADER_PAGINATION_PAGE_KEY, out IEnumerable<string> values))
            {
                string strPage = values.First();

                if (uint.TryParse(strPage, out uint page))
                    headerResults.Page = page;
            }

            if (responseHeaders.TryGetValues(HEADER_PAGINATION_LIMIT_KEY, out values))
            {
                string strLimit = values.First();

                if (uint.TryParse(strLimit, out uint limit))
                    headerResults.Limit = limit;
            }

            if (responseHeaders.TryGetValues(HEADER_TRENDING_USER_COUNT_KEY, out values))
            {
                string strTrendingUserCount = values.First();

                if (int.TryParse(strTrendingUserCount, out int userCount))
                    headerResults.TrendingUserCount = userCount;
            }

            if (responseHeaders.TryGetValues(HEADER_SORT_BY_KEY, out values))
                headerResults.SortBy = ParseSortBy(values.First());

            if (responseHeaders.TryGetValues(HEADER_SORT_HOW_KEY, out values))
                headerResults.SortHow = ParseSortHow(values.First());

            if (responseHeaders.TryGetValues(HEADER_APPLIED_SORT_BY, out values))
                headerResults.AppliedSortBy = ParseSortBy(values.First());

            if (responseHeaders.TryGetValues(HEADER_APPLIED_SORT_HOW, out values))
                headerResults.AppliedSortHow = ParseSortHow(values.First());

            if (responseHeaders.TryGetValues(HEADER_PRIVATE_USER_KEY, out values))
            {
                string strIsPrivateUser = values.First();

                if (bool.TryParse(strIsPrivateUser, out bool isPrivateUser))
                    headerResults.IsPrivateUser = isPrivateUser;
            }

            if (responseHeaders.TryGetValues(HEADER_STARTDATE_KEY, out values))
            {
                string strStartDate = values.First();

                if (DateTime.TryParse(strStartDate, out DateTime startDate))
                    headerResults.StartDate = startDate.ToUniversalTime();
            }

            if (responseHeaders.TryGetValues(HEADER_ENDDATE_KEY, out values))
            {
                string strEndDate = values.First();

                if (DateTime.TryParse(strEndDate, out DateTime endDate))
                    headerResults.EndDate = endDate.ToUniversalTime();
            }

            if (responseHeaders.TryGetValues(HEADER_ITEM_ID, out values))
            {
                string strXItemId = values.First();

                if (int.TryParse(strXItemId, out int id))
                    headerResults.ItemId = id;
            }

            if (responseHeaders.TryGetValues(HEADER_ITEM_TYPE, out values))
                headerResults.ItemType = values.First();

            if (responseHeaders.TryGetValues(HEADER_RATE_LIMIT, out values))
                headerResults.RateLimit = values.First();

            if (responseHeaders.TryGetValues(HEADER_RETRY_AFTER, out values))
            {
                string strRetryAfter = values.First();

                if (int.TryParse(strRetryAfter, out int retryAfter))
                    headerResults.RetryAfter = retryAfter;
            }

            if (responseHeaders.TryGetValues(HEADER_UPGRADE_URL, out values))
                headerResults.UpgradeURL = values.First();

            if (responseHeaders.TryGetValues(HEADER_VIP_USER, out values))
            {
                string strVIPUser = values.First();

                if (bool.TryParse(strVIPUser, out bool isVIPUser))
                    headerResults.IsVIPUser = isVIPUser;
            }

            if (responseHeaders.TryGetValues(HEADER_ACCOUNT_LIMIT, out values))
            {
                string strAccountLimit = values.First();

                if (int.TryParse(strAccountLimit, out int accountLimit))
                    headerResults.AccountLimit = accountLimit;
            }
        }

        internal static void ParsePagedResponseHeaderValues(ITraktPagedResponseHeaders headerResults, HttpResponseHeaders responseHeaders)
        {
            ParseResponseHeaderValues(headerResults, responseHeaders);

            if (responseHeaders.TryGetValues(HEADER_PAGINATION_PAGE_COUNT_KEY, out IEnumerable<string> values))
            {
                string strPageCount = values.First();

                if (int.TryParse(strPageCount, out int pageCount))
                    headerResults.PageCount = pageCount;
            }

            if (responseHeaders.TryGetValues(HEADER_PAGINATION_ITEM_COUNT_KEY, out values))
            {
                string strItemCount = values.First();

                if (int.TryParse(strItemCount, out int itemCount))
                    headerResults.ItemCount = itemCount;
            }
        }

        private static TraktSortBy? ParseSortBy(string sortBy)
        {
            if (!string.IsNullOrEmpty(sortBy))
            {
                return sortBy switch
                {
                    "rank" => TraktSortBy.Rank,
                    "added" => TraktSortBy.Added,
                    "title" => TraktSortBy.Title,
                    "released" => TraktSortBy.Released,
                    "runtime" => TraktSortBy.Runtime,
                    "popularity" => TraktSortBy.Popularity,
                    "percentage" => TraktSortBy.Percentage,
                    "votes" => TraktSortBy.Votes,
                    "my_rating" => TraktSortBy.MyRating,
                    "random" => TraktSortBy.Random,
                    "watched" => TraktSortBy.Watched,
                    "collected" => TraktSortBy.Collected,
                    _ => null,
                };
            }

            return null;
        }

        private static TraktSortHow? ParseSortHow(string sortHow)
        {
            if (!string.IsNullOrEmpty(sortHow))
            {
                return sortHow switch
                {
                    "asc" => TraktSortHow.Ascending,
                    "desc" => TraktSortHow.Descending,
                    _ => null,
                };
            }

            return null;
        }
    }
}
