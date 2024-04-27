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
    public class UserWatchlistCommentsRequest_Tests
    {
        [Fact]
        public void Test_UserWatchlistCommentsRequest_Has_AuthorizationRequirement_OptionalButMightBeRequired()
        {
            var request = new UserWatchlistCommentsRequest();
            request.AuthorizationRequirement.Should().Be(AuthorizationRequirement.OptionalButMightBeRequired);
        }

        [Fact]
        public void Test_UserWatchlistCommentsRequest_Has_Valid_UriTemplate()
        {
            var request = new UserWatchlistCommentsRequest();
            request.UriTemplate.Should().Be("users/{username}/watchlist/comments{/sort}{?page,limit}");
        }

        [Fact]
        public void Test_UserWatchlistCommentsRequest_Validate_Throws_Exceptions()
        {
            // username is null
            var request = new UserWatchlistCommentsRequest();

            Action act = () => request.Validate();
            act.Should().Throw<TraktRequestValidationException>();

            // empty username
            request = new UserWatchlistCommentsRequest { Username = string.Empty };

            act = () => request.Validate();
            act.Should().Throw<TraktRequestValidationException>();

            // username with spaces
            request = new UserWatchlistCommentsRequest { Username = "invalid username" };

            act = () => request.Validate();
            act.Should().Throw<TraktRequestValidationException>();
        }

        [Theory, ClassData(typeof(UserWatchlistCommentsRequest_TestData))]
        public void Test_UserWatchlistCommentsRequest_Returns_Valid_UriPathParameters(IDictionary<string, object> values,
                                                                                      IDictionary<string, object> expected)
        {
            values.Should().NotBeNull().And.HaveCount(expected.Count);

            if (expected.Count > 0)
                values.Should().Contain(expected);
        }

        public class UserWatchlistCommentsRequest_TestData : IEnumerable<object[]>
        {
            private const string _username = "username";
            private static readonly TraktCommentSortOrder _sort = TraktCommentSortOrder.Newest;
            private const int _page = 4;
            private const int _limit = 20;

            private static readonly UserWatchlistCommentsRequest _request1 = new UserWatchlistCommentsRequest
            {
                Username = _username
            };

            private static readonly UserWatchlistCommentsRequest _request2 = new UserWatchlistCommentsRequest
            {
                Username = _username,
                Sort = _sort
            };

            private static readonly UserWatchlistCommentsRequest _request3 = new UserWatchlistCommentsRequest
            {
                Username = _username,
                Page = _page
            };

            private static readonly UserWatchlistCommentsRequest _request4 = new UserWatchlistCommentsRequest
            {
                Username = _username,
                Limit = _limit
            };

            private static readonly UserWatchlistCommentsRequest _request5 = new UserWatchlistCommentsRequest
            {
                Username = _username,
                Page = _page,
                Limit = _limit
            };

            private static readonly UserWatchlistCommentsRequest _request6 = new UserWatchlistCommentsRequest
            {
                Username = _username,
                Sort = _sort,
                Page = _page
            };

            private static readonly UserWatchlistCommentsRequest _request7 = new UserWatchlistCommentsRequest
            {
                Username = _username,
                Sort = _sort,
                Limit = _limit
            };

            private static readonly UserWatchlistCommentsRequest _request8 = new UserWatchlistCommentsRequest
            {
                Username = _username,
                Sort = _sort,
                Page = _page,
                Limit = _limit
            };

            private static readonly List<object[]> _data = new List<object[]>();

            public UserWatchlistCommentsRequest_TestData()
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
