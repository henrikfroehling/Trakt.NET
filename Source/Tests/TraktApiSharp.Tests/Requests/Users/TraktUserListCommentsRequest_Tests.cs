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
    using TraktApiSharp.Objects.Basic.Implementations;
    using TraktApiSharp.Requests.Base;
    using TraktApiSharp.Requests.Interfaces;
    using TraktApiSharp.Requests.Users;
    using Xunit;

    [Category("Requests.Users")]
    public class TraktUserListCommentsRequest_Tests
    {
        [Fact]
        public void Test_TraktUserListCommentsRequest_Is_Not_Abstract()
        {
            typeof(TraktUserListCommentsRequest).IsAbstract.Should().BeFalse();
        }

        [Fact]
        public void Test_TraktUserListCommentsRequest_Is_Sealed()
        {
            typeof(TraktUserListCommentsRequest).IsSealed.Should().BeTrue();
        }

        [Fact]
        public void Test_TraktUserListCommentsRequest_Inherits_ATraktGetRequest_1()
        {
            typeof(TraktUserListCommentsRequest).IsSubclassOf(typeof(ATraktGetRequest<TraktComment>)).Should().BeTrue();
        }

        [Fact]
        public void Test_TraktUserListCommentsRequest_Implements_ITraktHasId_Interface()
        {
            typeof(TraktUserListCommentsRequest).GetInterfaces().Should().Contain(typeof(ITraktHasId));
        }

        [Fact]
        public void Test_TraktUserListCommentsRequest_Implements_ITraktSupportsPagination_Interface()
        {
            typeof(TraktUserListCommentsRequest).GetInterfaces().Should().Contain(typeof(ITraktSupportsPagination));
        }

        [Fact]
        public void Test_TraktUserListCommentsRequest_Has_AuthorizationRequirement_Not_Required()
        {
            var request = new TraktUserListCommentsRequest();
            request.AuthorizationRequirement.Should().Be(TraktAuthorizationRequirement.NotRequired);
        }

        [Fact]
        public void Test_TraktUserListCommentsRequest_Returns_Valid_RequestObjectType()
        {
            var requestMock = new TraktUserListCommentsRequest();
            requestMock.RequestObjectType.Should().Be(TraktRequestObjectType.Lists);
        }

        [Fact]
        public void Test_TraktUserListCommentsRequest_Has_Valid_UriTemplate()
        {
            var request = new TraktUserListCommentsRequest();
            request.UriTemplate.Should().Be("users/{username}/lists/{id}/comments{/sort_order}{?page,limit}");
        }

        [Fact]
        public void Test_TraktUserListCommentsRequest_Has_Username_Property()
        {
            var propertyInfo = typeof(TraktUserListCommentsRequest)
                    .GetProperties(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance)
                    .Where(p => p.Name == "Username")
                    .FirstOrDefault();

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(string));
        }

        [Fact]
        public void Test_TraktUserListCommentsRequest_Has_SortOrder_Property()
        {
            var propertyInfo = typeof(TraktUserListCommentsRequest)
                    .GetProperties(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance)
                    .Where(p => p.Name == "SortOrder")
                    .FirstOrDefault();

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(TraktCommentSortOrder));
        }

        [Fact]
        public void Test_TraktUserListCommentsRequest_Validate_Throws_Exceptions()
        {
            // username is null
            var requestMock = new TraktUserListCommentsRequest { Id = "123" };

            Action act = () => requestMock.Validate();
            act.ShouldThrow<ArgumentNullException>();

            // empty username
            requestMock = new TraktUserListCommentsRequest { Username = string.Empty, Id = "123" };

            act = () => requestMock.Validate();
            act.ShouldThrow<ArgumentException>();

            // username with spaces
            requestMock = new TraktUserListCommentsRequest { Username = "invalid username", Id = "123" };

            act = () => requestMock.Validate();
            act.ShouldThrow<ArgumentException>();

            // id is null
            requestMock = new TraktUserListCommentsRequest { Username = "username" };

            act = () => requestMock.Validate();
            act.ShouldThrow<ArgumentNullException>();

            // empty id
            requestMock = new TraktUserListCommentsRequest { Username = "username", Id = string.Empty };

            act = () => requestMock.Validate();
            act.ShouldThrow<ArgumentException>();

            // id with spaces
            requestMock = new TraktUserListCommentsRequest { Username = "username", Id = "invalid id" };

            act = () => requestMock.Validate();
            act.ShouldThrow<ArgumentException>();
        }

        [Theory, ClassData(typeof(TraktUserListCommentsRequest_TestData))]
        public void Test_TraktUserListCommentsRequest_Returns_Valid_UriPathParameters(IDictionary<string, object> values,
                                                                                      IDictionary<string, object> expected)
        {
            values.Should().NotBeNull().And.HaveCount(expected.Count);

            if (expected.Count > 0)
                values.Should().Contain(expected);
        }

        public class TraktUserListCommentsRequest_TestData : IEnumerable<object[]>
        {
            private const string _username = "username";
            private const string _id = "123";
            private static readonly TraktCommentSortOrder _sortOrder = TraktCommentSortOrder.Likes;
            private const int _page = 4;
            private const int _limit = 20;

            private static readonly TraktUserListCommentsRequest _request1 = new TraktUserListCommentsRequest
            {
                Username = _username,
                Id = _id
            };

            private static readonly TraktUserListCommentsRequest _request2 = new TraktUserListCommentsRequest
            {
                Username = _username,
                Id = _id,
                SortOrder = _sortOrder
            };

            private static readonly TraktUserListCommentsRequest _request3 = new TraktUserListCommentsRequest
            {
                Username = _username,
                Id = _id,
                Page = _page
            };

            private static readonly TraktUserListCommentsRequest _request4 = new TraktUserListCommentsRequest
            {
                Username = _username,
                Id = _id,
                Limit = _limit
            };

            private static readonly TraktUserListCommentsRequest _request5 = new TraktUserListCommentsRequest
            {
                Username = _username,
                Id = _id,
                Page = _page,
                Limit = _limit
            };

            private static readonly TraktUserListCommentsRequest _request6 = new TraktUserListCommentsRequest
            {
                Username = _username,
                Id = _id,
                SortOrder = _sortOrder,
                Page = _page
            };

            private static readonly TraktUserListCommentsRequest _request7 = new TraktUserListCommentsRequest
            {
                Username = _username,
                Id = _id,
                SortOrder = _sortOrder,
                Limit = _limit
            };

            private static readonly TraktUserListCommentsRequest _request8 = new TraktUserListCommentsRequest
            {
                Username = _username,
                Id = _id,
                SortOrder = _sortOrder,
                Page = _page,
                Limit = _limit
            };

            private static readonly List<object[]> _data = new List<object[]>();

            public TraktUserListCommentsRequest_TestData()
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
