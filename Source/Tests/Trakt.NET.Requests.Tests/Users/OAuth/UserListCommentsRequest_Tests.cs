namespace TraktNet.Requests.Tests.Users.OAuth
{
    using FluentAssertions;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Enums;
    using TraktNet.Requests.Base;
    using TraktNet.Requests.Users.OAuth;
    using Xunit;

    [TestCategory("Requests.Users")]
    public class UserListCommentsRequest_Tests
    {
        [Fact]
        public void Test_UserListCommentsRequest_Has_AuthorizationRequirement_Optional()
        {
            var request = new UserListCommentsRequest();
            request.AuthorizationRequirement.Should().Be(AuthorizationRequirement.Optional);
        }

        [Fact]
        public void Test_UserListCommentsRequest_Returns_Valid_RequestObjectType()
        {
            var requestMock = new UserListCommentsRequest();
            requestMock.RequestObjectType.Should().Be(RequestObjectType.Lists);
        }

        [Fact]
        public void Test_UserListCommentsRequest_Has_Valid_UriTemplate()
        {
            var request = new UserListCommentsRequest();
            request.UriTemplate.Should().Be("users/{username}/lists/{id}/comments{/sort_order}{?page,limit}");
        }

        [Fact]
        public void Test_UserListCommentsRequest_Validate_Throws_Exceptions()
        {
            // username is null
            var requestMock = new UserListCommentsRequest { Id = "123" };

            Action act = () => requestMock.Validate();
            act.Should().Throw<ArgumentNullException>();

            // empty username
            requestMock = new UserListCommentsRequest { Username = string.Empty, Id = "123" };

            act = () => requestMock.Validate();
            act.Should().Throw<ArgumentException>();

            // username with spaces
            requestMock = new UserListCommentsRequest { Username = "invalid username", Id = "123" };

            act = () => requestMock.Validate();
            act.Should().Throw<ArgumentException>();

            // id is null
            requestMock = new UserListCommentsRequest { Username = "username" };

            act = () => requestMock.Validate();
            act.Should().Throw<ArgumentNullException>();

            // empty id
            requestMock = new UserListCommentsRequest { Username = "username", Id = string.Empty };

            act = () => requestMock.Validate();
            act.Should().Throw<ArgumentException>();

            // id with spaces
            requestMock = new UserListCommentsRequest { Username = "username", Id = "invalid id" };

            act = () => requestMock.Validate();
            act.Should().Throw<ArgumentException>();
        }

        [Theory, ClassData(typeof(UserListCommentsRequest_TestData))]
        public void Test_UserListCommentsRequest_Returns_Valid_UriPathParameters(IDictionary<string, object> values,
                                                                                 IDictionary<string, object> expected)
        {
            values.Should().NotBeNull().And.HaveCount(expected.Count);

            if (expected.Count > 0)
                values.Should().Contain(expected);
        }

        public class UserListCommentsRequest_TestData : IEnumerable<object[]>
        {
            private const string _username = "username";
            private const string _id = "123";
            private static readonly TraktCommentSortOrder _sortOrder = TraktCommentSortOrder.Likes;
            private const int _page = 4;
            private const int _limit = 20;

            private static readonly UserListCommentsRequest _request1 = new UserListCommentsRequest
            {
                Username = _username,
                Id = _id
            };

            private static readonly UserListCommentsRequest _request2 = new UserListCommentsRequest
            {
                Username = _username,
                Id = _id,
                SortOrder = _sortOrder
            };

            private static readonly UserListCommentsRequest _request3 = new UserListCommentsRequest
            {
                Username = _username,
                Id = _id,
                Page = _page
            };

            private static readonly UserListCommentsRequest _request4 = new UserListCommentsRequest
            {
                Username = _username,
                Id = _id,
                Limit = _limit
            };

            private static readonly UserListCommentsRequest _request5 = new UserListCommentsRequest
            {
                Username = _username,
                Id = _id,
                Page = _page,
                Limit = _limit
            };

            private static readonly UserListCommentsRequest _request6 = new UserListCommentsRequest
            {
                Username = _username,
                Id = _id,
                SortOrder = _sortOrder,
                Page = _page
            };

            private static readonly UserListCommentsRequest _request7 = new UserListCommentsRequest
            {
                Username = _username,
                Id = _id,
                SortOrder = _sortOrder,
                Limit = _limit
            };

            private static readonly UserListCommentsRequest _request8 = new UserListCommentsRequest
            {
                Username = _username,
                Id = _id,
                SortOrder = _sortOrder,
                Page = _page,
                Limit = _limit
            };

            private static readonly List<object[]> _data = new List<object[]>();

            public UserListCommentsRequest_TestData()
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
                        ["username"] = _username,
                        ["id"] = _id
                    }});

                _data.Add(new object[] { _request2.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["username"] = _username,
                        ["id"] = _id,
                        ["sort_order"] = strSortOrder
                    }});

                _data.Add(new object[] { _request3.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["username"] = _username,
                        ["id"] = _id,
                        ["page"] = strPage
                    }});

                _data.Add(new object[] { _request4.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["username"] = _username,
                        ["id"] = _id,
                        ["limit"] = strLimit
                    }});

                _data.Add(new object[] { _request5.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["username"] = _username,
                        ["id"] = _id,
                        ["page"] = strPage,
                        ["limit"] = strLimit
                    }});

                _data.Add(new object[] { _request6.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["username"] = _username,
                        ["id"] = _id,
                        ["sort_order"] = strSortOrder,
                        ["page"] = strPage
                    }});

                _data.Add(new object[] { _request7.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["username"] = _username,
                        ["id"] = _id,
                        ["sort_order"] = strSortOrder,
                        ["limit"] = strLimit
                    }});

                _data.Add(new object[] { _request8.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["username"] = _username,
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
