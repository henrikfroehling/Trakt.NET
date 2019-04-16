﻿namespace TraktNet.Requests.Tests.Shows
{
    using FluentAssertions;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Enums;
    using TraktNet.Requests.Shows;
    using Xunit;

    [Category("Requests.Shows")]
    public class ShowCommentsRequest_Tests
    {
        [Fact]
        public void Test_ShowCommentsRequest_Has_Valid_UriTemplate()
        {
            var request = new ShowCommentsRequest();
            request.UriTemplate.Should().Be("shows/{id}/comments{/sort_order}{?page,limit}");
        }

        [Fact]
        public void Test_ShowCommentsRequest_Validate_Throws_Exceptions()
        {
            // id is null
            var request = new ShowCommentsRequest();

            Action act = () => request.Validate();
            act.Should().Throw<ArgumentNullException>();

            // empty id
            request = new ShowCommentsRequest { Id = string.Empty };

            act = () => request.Validate();
            act.Should().Throw<ArgumentException>();

            // id with spaces
            request = new ShowCommentsRequest { Id = "invalid id" };

            act = () => request.Validate();
            act.Should().Throw<ArgumentException>();
        }

        [Theory, ClassData(typeof(ShowCommentsRequest_TestData))]
        public void Test_ShowCommentsRequest_Returns_Valid_UriPathParameters(IDictionary<string, object> values,
                                                                             IDictionary<string, object> expected)
        {
            values.Should().NotBeNull().And.HaveCount(expected.Count);

            if (expected.Count > 0)
                values.Should().Contain(expected);
        }

        public class ShowCommentsRequest_TestData : IEnumerable<object[]>
        {
            private const string _id = "123";
            private static readonly TraktCommentSortOrder _sortOrder = TraktCommentSortOrder.Newest;
            private const int _page = 5;
            private const int _limit = 20;

            private static readonly ShowCommentsRequest _request1 = new ShowCommentsRequest
            {
                Id = _id
            };

            private static readonly ShowCommentsRequest _request2 = new ShowCommentsRequest
            {
                Id = _id,
                SortOrder = _sortOrder
            };

            private static readonly ShowCommentsRequest _request3 = new ShowCommentsRequest
            {
                Id = _id,
                Page = _page
            };

            private static readonly ShowCommentsRequest _request4 = new ShowCommentsRequest
            {
                Id = _id,
                Limit = _limit
            };

            private static readonly ShowCommentsRequest _request5 = new ShowCommentsRequest
            {
                Id = _id,
                SortOrder = _sortOrder,
                Page = _page
            };

            private static readonly ShowCommentsRequest _request6 = new ShowCommentsRequest
            {
                Id = _id,
                SortOrder = _sortOrder,
                Limit = _limit
            };

            private static readonly ShowCommentsRequest _request7 = new ShowCommentsRequest
            {
                Id = _id,
                Page = _page,
                Limit = _limit
            };

            private static readonly ShowCommentsRequest _request8 = new ShowCommentsRequest
            {
                Id = _id,
                SortOrder = _sortOrder,
                Page = _page,
                Limit = _limit
            };

            private static readonly List<object[]> _data = new List<object[]>();

            public ShowCommentsRequest_TestData()
            {
                SetupPathParamters();
            }

            private void SetupPathParamters()
            {
                var strSortOrder = _sortOrder.UriName;
                var strPage = _page.ToString();
                var strLimit = _limit.ToString();

                _data.Add(new object[] { _request1.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["id"] = _id
                    }});

                _data.Add(new object[] { _request2.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["id"] = _id,
                        ["sort_order"] = strSortOrder
                    }});

                _data.Add(new object[] { _request3.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["id"] = _id,
                        ["page"] = strPage
                    }});

                _data.Add(new object[] { _request4.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["id"] = _id,
                        ["limit"] = strLimit
                    }});

                _data.Add(new object[] { _request5.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["id"] = _id,
                        ["sort_order"] = strSortOrder,
                        ["page"] = strPage
                    }});

                _data.Add(new object[] { _request6.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["id"] = _id,
                        ["sort_order"] = strSortOrder,
                        ["limit"] = strLimit
                    }});

                _data.Add(new object[] { _request7.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["id"] = _id,
                        ["page"] = strPage,
                        ["limit"] = strLimit
                    }});

                _data.Add(new object[] { _request8.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["id"] = _id,
                        ["sort_order"] = strSortOrder,
                        ["page"] = strPage,
                        ["limit"] = strLimit
                    }});
            }

            public IEnumerator<object[]> GetEnumerator() => _data.GetEnumerator();

            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        }
    }
}
