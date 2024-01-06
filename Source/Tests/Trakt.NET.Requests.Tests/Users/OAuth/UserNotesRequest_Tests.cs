namespace TraktNet.Requests.Tests.Users.OAuth
{
    using FluentAssertions;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Enums;
    using TraktNet.Exceptions;
    using TraktNet.Parameters;
    using TraktNet.Requests.Base;
    using TraktNet.Requests.Users.OAuth;
    using Xunit;

    [TestCategory("Requests.Users.OAuth")]
    public class UserNotesRequest_Tests
    {
        [Fact]
        public void Test_UserNotesRequest_Has_AuthorizationRequirement_OptionalButMightBeRequired()
        {
            var request = new UserNotesRequest();
            request.AuthorizationRequirement.Should().Be(AuthorizationRequirement.OptionalButMightBeRequired);
        }

        [Fact]
        public void Test_UserNotesRequest_Has_Valid_UriTemplate()
        {
            var request = new UserNotesRequest();
            request.UriTemplate.Should().Be("users/{username}/notes{/type}{?extended,page,limit}");
        }

        [Fact]
        public void Test_UserNotesRequest_Validate_Throws_Exceptions()
        {
            // username is null
            var request = new UserNotesRequest();

            Action act = () => request.Validate();
            act.Should().Throw<TraktRequestValidationException>();

            // empty username
            request = new UserNotesRequest { Username = string.Empty };

            act = () => request.Validate();
            act.Should().Throw<TraktRequestValidationException>();

            // username with spaces
            request = new UserNotesRequest { Username = "invalid username" };

            act = () => request.Validate();
            act.Should().Throw<TraktRequestValidationException>();
        }

        [Theory, ClassData(typeof(UserNotesRequest_TestData))]
        public void Test_UserNotesRequest_Returns_Valid_UriPathParameters(IDictionary<string, object> values,
                                                                          IDictionary<string, object> expected)
        {
            values.Should().NotBeNull().And.HaveCount(expected.Count);

            if (expected.Count > 0)
                values.Should().Contain(expected);
        }

        public class UserNotesRequest_TestData : IEnumerable<object[]>
        {
            private const string _username = "username";
            private static readonly TraktNotesObjectType _notesType = TraktNotesObjectType.Show;
            private static readonly TraktExtendedInfo _extendedInfo = new() { Full = true };
            private const int _page = 4;
            private const int _limit = 20;

            private static readonly UserNotesRequest _request1 = new()
            {
                Username = _username
            };

            private static readonly UserNotesRequest _request2 = new()
            {
                Username = _username,
                Type = _notesType
            };

            private static readonly UserNotesRequest _request3 = new()
            {
                Username = _username,
                ExtendedInfo = _extendedInfo
            };

            private static readonly UserNotesRequest _request4 = new()
            {
                Username = _username,
                Page = _page
            };

            private static readonly UserNotesRequest _request5 = new()
            {
                Username = _username,
                Limit = _limit
            };

            private static readonly UserNotesRequest _request6 = new()
            {
                Username = _username,
                Page = _page,
                Limit = _limit
            };

            private static readonly UserNotesRequest _request7 = new()
            {
                Username = _username,
                Type = _notesType,
                ExtendedInfo = _extendedInfo
            };

            private static readonly UserNotesRequest _request8 = new()
            {
                Username = _username,
                Type = _notesType,
                Page = _page
            };

            private static readonly UserNotesRequest _request9 = new()
            {
                Username = _username,
                Type = _notesType,
                Limit = _limit
            };

            private static readonly UserNotesRequest _request10 = new()
            {
                Username = _username,
                Type = _notesType,
                Page = _page,
                Limit = _limit
            };

            private static readonly UserNotesRequest _request11 = new()
            {
                Username = _username,
                ExtendedInfo = _extendedInfo,
                Page = _page
            };

            private static readonly UserNotesRequest _request12 = new()
            {
                Username = _username,
                ExtendedInfo = _extendedInfo,
                Limit = _limit
            };

            private static readonly UserNotesRequest _request13 = new()
            {
                Username = _username,
                ExtendedInfo = _extendedInfo,
                Page = _page,
                Limit = _limit
            };

            private static readonly UserNotesRequest _request14 = new()
            {
                Username = _username,
                Type = _notesType,
                ExtendedInfo = _extendedInfo,
                Page = _page
            };

            private static readonly UserNotesRequest _request15 = new()
            {
                Username = _username,
                Type = _notesType,
                ExtendedInfo = _extendedInfo,
                Limit = _limit
            };

            private static readonly UserNotesRequest _request16 = new()
            {
                Username = _username,
                Type = _notesType,
                ExtendedInfo = _extendedInfo,
                Page = _page,
                Limit = _limit
            };

            private static readonly List<object[]> _data = [];

            public UserNotesRequest_TestData()
            {
                SetupPathParamters();
            }

            private void SetupPathParamters()
            {
                var strNotesType = _notesType.UriName;
                var strExtendedInfo = _extendedInfo.ToString();
                var strPage = _page.ToString();
                var strLimit = _limit.ToString();

                _data.Add([_request1.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["username"] = _username
                    }]);

                _data.Add([_request2.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["username"] = _username,
                        ["type"] = strNotesType
                    }]);

                _data.Add([_request3.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["username"] = _username,
                        ["extended"] = strExtendedInfo
                    }]);

                _data.Add([_request4.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["username"] = _username,
                        ["page"] = strPage
                    }]);

                _data.Add([_request5.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["username"] = _username,
                        ["limit"] = strLimit
                    }]);

                _data.Add([_request6.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["username"] = _username,
                        ["page"] = strPage,
                        ["limit"] = strLimit
                    }]);

                _data.Add([_request7.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["username"] = _username,
                        ["type"] = strNotesType,
                        ["extended"] = strExtendedInfo
                    }]);

                _data.Add([_request8.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["username"] = _username,
                        ["type"] = strNotesType,
                        ["page"] = strPage
                    }]);

                _data.Add([_request9.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["username"] = _username,
                        ["type"] = strNotesType,
                        ["limit"] = strLimit
                    }]);

                _data.Add([_request10.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["username"] = _username,
                        ["type"] = strNotesType,
                        ["page"] = strPage,
                        ["limit"] = strLimit
                    }]);

                _data.Add([_request11.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["username"] = _username,
                        ["extended"] = strExtendedInfo,
                        ["page"] = strPage
                    }]);

                _data.Add([_request12.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["username"] = _username,
                        ["extended"] = strExtendedInfo,
                        ["limit"] = strLimit
                    }]);

                _data.Add([_request13.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["username"] = _username,
                        ["extended"] = strExtendedInfo,
                        ["page"] = strPage,
                        ["limit"] = strLimit
                    }]);

                _data.Add([_request14.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["username"] = _username,
                        ["type"] = strNotesType,
                        ["extended"] = strExtendedInfo,
                        ["page"] = strPage
                    }]);

                _data.Add([_request15.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["username"] = _username,
                        ["type"] = strNotesType,
                        ["extended"] = strExtendedInfo,
                        ["limit"] = strLimit
                    }]);

                _data.Add([_request16.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["username"] = _username,
                        ["type"] = strNotesType,
                        ["extended"] = strExtendedInfo,
                        ["page"] = strPage,
                        ["limit"] = strLimit
                    }]);
            }

            public IEnumerator<object[]> GetEnumerator() => _data.GetEnumerator();

            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        }
    }
}
