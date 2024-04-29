namespace TraktNet.Requests.Tests.Users.OAuth
{
    using FluentAssertions;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Enums;
    using TraktNet.Exceptions;
    using TraktNet.Requests.Base;
    using TraktNet.Requests.Users.OAuth;
    using Xunit;

    [TestCategory("Requests.Users.OAuth")]
    public class UserFavoritesCommentsRequest_Tests
    {
        [Fact]
        public void Test_UserFavoritesCommentsRequest_Has_AuthorizationRequirement_OptionalButMightBeRequired()
        {
            var request = new UserFavoritesCommentsRequest();
            request.AuthorizationRequirement.Should().Be(AuthorizationRequirement.OptionalButMightBeRequired);
        }

        [Fact]
        public void Test_UserFavoritesCommentsRequest_Has_Valid_UriTemplate()
        {
            var request = new UserFavoritesCommentsRequest();
            request.UriTemplate.Should().Be("users/{username}/favorites/comments{/sort}{?page,limit}");
        }

        [Fact]
        public void Test_UserFavoritesCommentsRequest_Validate_Throws_Exceptions()
        {
            // username is null
            var request = new UserFavoritesCommentsRequest();

            Action act = () => request.Validate();
            act.Should().Throw<TraktRequestValidationException>();

            // empty username
            request = new UserFavoritesCommentsRequest { Username = string.Empty };

            act = () => request.Validate();
            act.Should().Throw<TraktRequestValidationException>();

            // username with spaces
            request = new UserFavoritesCommentsRequest { Username = "invalid username" };

            act = () => request.Validate();
            act.Should().Throw<TraktRequestValidationException>();
        }

        [Theory, ClassData(typeof(UserFavoritesCommentsRequest_TestData))]
        public void Test_UserFavoritesCommentsRequest_Returns_Valid_UriPathParameters(IDictionary<string, object> values,
                                                                                      IDictionary<string, object> expected)
        {
            values.Should().NotBeNull().And.HaveCount(expected.Count);

            if (expected.Count > 0)
                values.Should().Contain(expected);
        }

        public class UserFavoritesCommentsRequest_TestData : IEnumerable<object[]>
        {
            private const string _username = "username";
            private static readonly TraktCommentSortOrder _sort = TraktCommentSortOrder.Newest;
            private const int _page = 4;
            private const int _limit = 20;

            private static readonly UserFavoritesCommentsRequest _request1 = new UserFavoritesCommentsRequest
            {
                Username = _username
            };

            private static readonly UserFavoritesCommentsRequest _request2 = new UserFavoritesCommentsRequest
            {
                Username = _username,
                Sort = _sort
            };

            private static readonly UserFavoritesCommentsRequest _request3 = new UserFavoritesCommentsRequest
            {
                Username = _username,
                Page = _page
            };

            private static readonly UserFavoritesCommentsRequest _request4 = new UserFavoritesCommentsRequest
            {
                Username = _username,
                Limit = _limit
            };

            private static readonly UserFavoritesCommentsRequest _request5 = new UserFavoritesCommentsRequest
            {
                Username = _username,
                Page = _page,
                Limit = _limit
            };

            private static readonly UserFavoritesCommentsRequest _request6 = new UserFavoritesCommentsRequest
            {
                Username = _username,
                Sort = _sort,
                Page = _page
            };

            private static readonly UserFavoritesCommentsRequest _request7 = new UserFavoritesCommentsRequest
            {
                Username = _username,
                Sort = _sort,
                Limit = _limit
            };

            private static readonly UserFavoritesCommentsRequest _request8 = new UserFavoritesCommentsRequest
            {
                Username = _username,
                Sort = _sort,
                Page = _page,
                Limit = _limit
            };

            private static readonly List<object[]> _data = new List<object[]>();

            public UserFavoritesCommentsRequest_TestData()
            {
                SetupPathParamters();
            }

            private void SetupPathParamters()
            {
                var strSort = _sort.UriName;
                var strPage = _page.ToString();
                var strLimit = _limit.ToString();

                _data.Add(new object[] { _request1.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["username"] = _username
                    }});

                _data.Add(new object[] { _request2.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["username"] = _username,
                        ["sort"] = strSort
                    }});

                _data.Add(new object[] { _request3.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["username"] = _username,
                        ["page"] = strPage
                    }});

                _data.Add(new object[] { _request4.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["username"] = _username,
                        ["limit"] = strLimit
                    }});

                _data.Add(new object[] { _request5.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["username"] = _username,
                        ["page"] = strPage,
                        ["limit"] = strLimit
                    }});

                _data.Add(new object[] { _request6.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["username"] = _username,
                        ["sort"] = strSort,
                        ["page"] = strPage
                    }});

                _data.Add(new object[] { _request7.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["username"] = _username,
                        ["sort"] = strSort,
                        ["limit"] = strLimit
                    }});

                _data.Add(new object[] { _request8.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["username"] = _username,
                        ["sort"] = strSort,
                        ["page"] = strPage,
                        ["limit"] = strLimit
                    }});
            }

            public IEnumerator<object[]> GetEnumerator() => _data.GetEnumerator();

            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        }
    }
}
