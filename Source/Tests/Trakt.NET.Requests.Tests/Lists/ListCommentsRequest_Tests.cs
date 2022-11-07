namespace TraktNet.Requests.Tests.Lists
{
    using FluentAssertions;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Enums;
    using TraktNet.Exceptions;
    using TraktNet.Requests.Base;
    using TraktNet.Requests.Lists;
    using Xunit;

    [TestCategory("Requests.Lists")]
    public class ListCommentsRequest_Tests
    {
        [Fact]
        public void Test_ListCommentsRequest_Has_AuthorizationRequirement_Optional()
        {
            var request = new ListCommentsRequest();
            request.AuthorizationRequirement.Should().Be(AuthorizationRequirement.NotRequired);
        }

        [Fact]
        public void Test_ListCommentsRequest_Returns_Valid_RequestObjectType()
        {
            var requestMock = new ListCommentsRequest();
            requestMock.RequestObjectType.Should().Be(RequestObjectType.Lists);
        }

        [Fact]
        public void Test_ListCommentsRequest_Has_Valid_UriTemplate()
        {
            var request = new ListCommentsRequest();
            request.UriTemplate.Should().Be("lists/{id}/comments{/sort_order}{?page,limit}");
        }

        [Fact]
        public void Test_ListCommentsRequest_Validate_Throws_Exceptions()
        {
            // id is null
            var request = new ListCommentsRequest();

            Action act = () => request.Validate();
            act.Should().Throw<TraktRequestValidationException>();

            // empty id
            request = new ListCommentsRequest { Id = string.Empty };

            act = () => request.Validate();
            act.Should().Throw<TraktRequestValidationException>();

            // id with spaces
            request = new ListCommentsRequest { Id = "invalid id" };

            act = () => request.Validate();
            act.Should().Throw<TraktRequestValidationException>();
        }

        [Theory, ClassData(typeof(ListCommentsRequest_TestData))]
        public void Test_ListCommentsRequest_Returns_Valid_UriPathParameters(IDictionary<string, object> values,
                                                                             IDictionary<string, object> expected)
        {
            values.Should().NotBeNull().And.HaveCount(expected.Count);

            if (expected.Count > 0)
                values.Should().Contain(expected);
        }

        public class ListCommentsRequest_TestData : IEnumerable<object[]>
        {
            private const string _id = "123";
            private static readonly TraktCommentSortOrder _sortOrder = TraktCommentSortOrder.Likes;
            private const int _page = 4;
            private const int _limit = 20;

            private static readonly ListCommentsRequest _request1 = new ListCommentsRequest
            {
                Id = _id
            };

            private static readonly ListCommentsRequest _request2 = new ListCommentsRequest
            {
                Id = _id,
                SortOrder = _sortOrder
            };

            private static readonly ListCommentsRequest _request3 = new ListCommentsRequest
            {
                Id = _id,
                Page = _page
            };

            private static readonly ListCommentsRequest _request4 = new ListCommentsRequest
            {
                Id = _id,
                Limit = _limit
            };

            private static readonly ListCommentsRequest _request5 = new ListCommentsRequest
            {
                Id = _id,
                Page = _page,
                Limit = _limit
            };

            private static readonly ListCommentsRequest _request6 = new ListCommentsRequest
            {
                Id = _id,
                SortOrder = _sortOrder,
                Page = _page
            };

            private static readonly ListCommentsRequest _request7 = new ListCommentsRequest
            {
                Id = _id,
                SortOrder = _sortOrder,
                Limit = _limit
            };

            private static readonly ListCommentsRequest _request8 = new ListCommentsRequest
            {
                Id = _id,
                SortOrder = _sortOrder,
                Page = _page,
                Limit = _limit
            };

            private static readonly List<object[]> _data = new List<object[]>();

            public ListCommentsRequest_TestData()
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
                        ["page"] = strPage,
                        ["limit"] = strLimit
                    }});

                _data.Add(new object[] { _request6.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["id"] = _id,
                        ["sort_order"] = strSortOrder,
                        ["page"] = strPage
                    }});

                _data.Add(new object[] { _request7.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["id"] = _id,
                        ["sort_order"] = strSortOrder,
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
