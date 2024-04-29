﻿namespace TraktNet.Requests.Tests.Users.OAuth
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
    public class UserLikesRequest_Tests
    {
        [Fact]
        public void Test_UserLikesRequest_Has_AuthorizationRequirement_OptionalButMightBeRequired()
        {
            var request = new UserLikesRequest();
            request.AuthorizationRequirement.Should().Be(AuthorizationRequirement.OptionalButMightBeRequired);
        }

        [Fact]
        public void Test_UserLikesRequest_Has_Valid_UriTemplate()
        {
            var request = new UserLikesRequest();
            request.UriTemplate.Should().Be("users/{username}/likes{/type}{?page,limit}");
        }

        [Theory, ClassData(typeof(UserLikesRequest_TestData))]
        public void Test_UserLikesRequest_Returns_Valid_UriPathParameters(IDictionary<string, object> values,
                                                                          IDictionary<string, object> expected)
        {
            values.Should().NotBeNull().And.HaveCount(expected.Count);

            if (expected.Count > 0)
                values.Should().Contain(expected);
        }

        [Fact]
        public void Test_UserLikesRequest_Validate_Throws_Exceptions()
        {
            // username is null
            var request = new UserLikesRequest();

            Action act = () => request.Validate();
            act.Should().Throw<TraktRequestValidationException>();

            // empty username
            request = new UserLikesRequest { Username = string.Empty };

            act = () => request.Validate();
            act.Should().Throw<TraktRequestValidationException>();

            // username with spaces
            request = new UserLikesRequest { Username = "invalid username" };

            act = () => request.Validate();
            act.Should().Throw<TraktRequestValidationException>();
        }

        public class UserLikesRequest_TestData : IEnumerable<object[]>
        {
            private const string _username = "username";
            private static readonly TraktUserLikeType _type = TraktUserLikeType.Comment;
            private const int _page = 4;
            private const int _limit = 20;

            private static readonly UserLikesRequest _request1 = new UserLikesRequest
            {
                Username = _username
            };

            private static readonly UserLikesRequest _request2 = new UserLikesRequest
            {
                Username = _username,
                Type = _type
            };

            private static readonly UserLikesRequest _request3 = new UserLikesRequest
            {
                Username = _username,
                Page = _page
            };

            private static readonly UserLikesRequest _request4 = new UserLikesRequest
            {
                Username = _username,
                Limit = _limit
            };

            private static readonly UserLikesRequest _request5 = new UserLikesRequest
            {
                Username = _username,
                Page = _page,
                Limit = _limit
            };

            private static readonly UserLikesRequest _request6 = new UserLikesRequest
            {
                Username = _username,
                Type = _type,
                Page = _page
            };

            private static readonly UserLikesRequest _request7 = new UserLikesRequest
            {
                Username = _username,
                Type = _type,
                Limit = _limit
            };

            private static readonly UserLikesRequest _request8 = new UserLikesRequest
            {
                Username = _username,
                Type = _type,
                Page = _page,
                Limit = _limit
            };

            private static readonly List<object[]> _data = new List<object[]>();

            public UserLikesRequest_TestData()
            {
                SetupPathParamters();
            }

            private void SetupPathParamters()
            {
                var strType = _type.UriName;

                var strPage = _page.ToString();
                var strLimit = _limit.ToString();

                _data.Add(new object[] { _request1.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["username"] = _username
                    }});

                _data.Add(new object[] { _request2.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["username"] = _username,
                        ["type"] = strType
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
                        ["type"] = strType,
                        ["page"] = strPage
                    }});

                _data.Add(new object[] { _request7.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["username"] = _username,
                        ["type"] = strType,
                        ["limit"] = strLimit
                    }});

                _data.Add(new object[] { _request8.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["username"] = _username,
                        ["type"] = strType,
                        ["page"] = strPage,
                        ["limit"] = strLimit
                    }});
            }

            public IEnumerator<object[]> GetEnumerator() => _data.GetEnumerator();

            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        }
    }
}
