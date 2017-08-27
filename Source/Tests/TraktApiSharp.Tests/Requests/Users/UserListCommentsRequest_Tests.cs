namespace TraktApiSharp.Tests.Requests.Users
{
    using FluentAssertions;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using Traits;
    using TraktApiSharp.Enums;
    using TraktApiSharp.Objects.Basic;
    using TraktApiSharp.Requests.Base;
    using TraktApiSharp.Requests.Interfaces;
    using TraktApiSharp.Requests.Users;
    using Xunit;

    [Category("Requests.Users")]
    public class UserListCommentsRequest_Tests
    {
        [Fact]
        public void Test_UserListCommentsRequest_Is_Not_Abstract()
        {
            typeof(UserListCommentsRequest).IsAbstract.Should().BeFalse();
        }

        [Fact]
        public void Test_UserListCommentsRequest_Is_Sealed()
        {
            typeof(UserListCommentsRequest).IsSealed.Should().BeTrue();
        }

        [Fact]
        public void Test_UserListCommentsRequest_Inherits_ATraktGetRequest_1()
        {
            typeof(UserListCommentsRequest).IsSubclassOf(typeof(AGetRequest<ITraktComment>)).Should().BeTrue();
        }

        [Fact]
        public void Test_UserListCommentsRequest_Implements_ITraktHasId_Interface()
        {
            typeof(UserListCommentsRequest).GetInterfaces().Should().Contain(typeof(IHasId));
        }

        [Fact]
        public void Test_UserListCommentsRequest_Implements_ITraktSupportsPagination_Interface()
        {
            typeof(UserListCommentsRequest).GetInterfaces().Should().Contain(typeof(ISupportsPagination));
        }

        [Fact]
        public void Test_UserListCommentsRequest_Has_AuthorizationRequirement_Not_Required()
        {
            var request = new UserListCommentsRequest();
            request.AuthorizationRequirement.Should().Be(AuthorizationRequirement.NotRequired);
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
        public void Test_UserListCommentsRequest_Has_Username_Property()
        {
            var propertyInfo = typeof(UserListCommentsRequest)
                    .GetProperties(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance)
                    .Where(p => p.Name == "Username")
                    .FirstOrDefault();

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(string));
        }

        [Fact]
        public void Test_UserListCommentsRequest_Has_SortOrder_Property()
        {
            var propertyInfo = typeof(UserListCommentsRequest)
                    .GetProperties(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance)
                    .Where(p => p.Name == "SortOrder")
                    .FirstOrDefault();

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(TraktCommentSortOrder));
        }

        [Fact]
        public void Test_UserListCommentsRequest_Validate_Throws_Exceptions()
        {
            // username is null
            var requestMock = new UserListCommentsRequest { Id = "123" };

            Action act = () => requestMock.Validate();
            act.ShouldThrow<ArgumentNullException>();

            // empty username
            requestMock = new UserListCommentsRequest { Username = string.Empty, Id = "123" };

            act = () => requestMock.Validate();
            act.ShouldThrow<ArgumentException>();

            // username with spaces
            requestMock = new UserListCommentsRequest { Username = "invalid username", Id = "123" };

            act = () => requestMock.Validate();
            act.ShouldThrow<ArgumentException>();

            // id is null
            requestMock = new UserListCommentsRequest { Username = "username" };

            act = () => requestMock.Validate();
            act.ShouldThrow<ArgumentNullException>();

            // empty id
            requestMock = new UserListCommentsRequest { Username = "username", Id = string.Empty };

            act = () => requestMock.Validate();
            act.ShouldThrow<ArgumentException>();

            // id with spaces
            requestMock = new UserListCommentsRequest { Username = "username", Id = "invalid id" };

            act = () => requestMock.Validate();
            act.ShouldThrow<ArgumentException>();
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
