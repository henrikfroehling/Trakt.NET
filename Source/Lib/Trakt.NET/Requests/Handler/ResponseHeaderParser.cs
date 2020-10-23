namespace TraktNet.Requests.Handler
{
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
                headerResults.SortBy = values.First();

            if (responseHeaders.TryGetValues(HEADER_SORT_HOW_KEY, out values))
                headerResults.SortHow = values.First();

            if (responseHeaders.TryGetValues(HEADER_APPLIED_SORT_BY, out values))
                headerResults.AppliedSortBy = values.First();

            if (responseHeaders.TryGetValues(HEADER_APPLIED_SORT_HOW, out values))
                headerResults.AppliedSortHow = values.First();

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
    }
}
