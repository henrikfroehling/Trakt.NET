﻿namespace TraktNet.Requests.Tests.Users.OAuth
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
    public class UserWatchlistRequest_Tests
    {
        [Fact]
        public void Test_UserWatchlistRequest_Has_AuthorizationRequirement_OptionalButMightBeRequired()
        {
            var request = new UserWatchlistRequest();
            request.AuthorizationRequirement.Should().Be(AuthorizationRequirement.OptionalButMightBeRequired);
        }

        [Fact]
        public void Test_UserWatchlistRequest_Has_Valid_UriTemplate()
        {
            var request = new UserWatchlistRequest();
            request.UriTemplate.Should().Be("users/{username}/watchlist{/type}{/sort}{?extended,page,limit}");
        }

        [Fact]
        public void Test_UserWatchlistRequest_Validate_Throws_Exceptions()
        {
            // username is null
            var request = new UserWatchlistRequest();

            Action act = () => request.Validate();
            act.Should().Throw<TraktRequestValidationException>();

            // empty username
            request = new UserWatchlistRequest { Username = string.Empty };

            act = () => request.Validate();
            act.Should().Throw<TraktRequestValidationException>();

            // username with spaces
            request = new UserWatchlistRequest { Username = "invalid username" };

            act = () => request.Validate();
            act.Should().Throw<TraktRequestValidationException>();
        }

        [Theory, ClassData(typeof(UserWatchlistRequest_TestData))]
        public void Test_UserWatchlistRequest_Returns_Valid_UriPathParameters(IDictionary<string, object> values,
                                                                              IDictionary<string, object> expected)
        {
            values.Should().NotBeNull().And.HaveCount(expected.Count);

            if (expected.Count > 0)
                values.Should().Contain(expected);
        }

        public class UserWatchlistRequest_TestData : IEnumerable<object[]>
        {
            private const string _username = "username";
            private static readonly TraktSyncItemType _type = TraktSyncItemType.Episode;
            private static readonly TraktWatchlistSortOrder _sort = TraktWatchlistSortOrder.Rank;
            private static readonly TraktExtendedInfo _extendedInfo = new TraktExtendedInfo { Full = true };
            private const int _page = 4;
            private const int _limit = 20;

            private static readonly UserWatchlistRequest _request1 = new UserWatchlistRequest
            {
                Username = _username
            };

            private static readonly UserWatchlistRequest _request2 = new UserWatchlistRequest
            {
                Username = _username,
                Type = _type
            };

            private static readonly UserWatchlistRequest _request3 = new UserWatchlistRequest
            {
                Username = _username,
                Sort = _sort
            };

            private static readonly UserWatchlistRequest _request4 = new UserWatchlistRequest
            {
                Username = _username,
                ExtendedInfo = _extendedInfo
            };

            private static readonly UserWatchlistRequest _request5 = new UserWatchlistRequest
            {
                Username = _username,
                Page = _page
            };

            private static readonly UserWatchlistRequest _request6 = new UserWatchlistRequest
            {
                Username = _username,
                Limit = _limit
            };

            private static readonly UserWatchlistRequest _request7 = new UserWatchlistRequest
            {
                Username = _username,
                Type = _type,
                Sort = _sort
            };

            private static readonly UserWatchlistRequest _request8 = new UserWatchlistRequest
            {
                Username = _username,
                Type = _type,
                ExtendedInfo = _extendedInfo
            };

            private static readonly UserWatchlistRequest _request9 = new UserWatchlistRequest
            {
                Username = _username,
                Type = _type,
                Page = _page
            };

            private static readonly UserWatchlistRequest _request10 = new UserWatchlistRequest
            {
                Username = _username,
                Type = _type,
                Limit = _limit
            };

            private static readonly UserWatchlistRequest _request11 = new UserWatchlistRequest
            {
                Username = _username,
                Type = _type,
                Limit = _limit,
                Page = _page
            };

            private static readonly UserWatchlistRequest _request12 = new UserWatchlistRequest
            {
                Username = _username,
                Type = _type,
                Sort = _sort,
                Page = _page
            };

            private static readonly UserWatchlistRequest _request13 = new UserWatchlistRequest
            {
                Username = _username,
                Type = _type,
                Sort = _sort,
                Limit = _limit
            };

            private static readonly UserWatchlistRequest _request14 = new UserWatchlistRequest
            {
                Username = _username,
                Type = _type,
                Sort = _sort,
                Page = _page,
                Limit = _limit
            };

            private static readonly UserWatchlistRequest _request15 = new UserWatchlistRequest
            {
                Username = _username,
                Type = _type,
                ExtendedInfo = _extendedInfo,
                Page = _page
            };

            private static readonly UserWatchlistRequest _request16 = new UserWatchlistRequest
            {
                Username = _username,
                Type = _type,
                ExtendedInfo = _extendedInfo,
                Limit = _limit
            };

            private static readonly UserWatchlistRequest _request17 = new UserWatchlistRequest
            {
                Username = _username,
                Type = _type,
                ExtendedInfo = _extendedInfo,
                Page = _page,
                Limit = _limit
            };

            private static readonly UserWatchlistRequest _request18 = new UserWatchlistRequest
            {
                Username = _username,
                Sort = _sort,
                ExtendedInfo = _extendedInfo
            };

            private static readonly UserWatchlistRequest _request19 = new UserWatchlistRequest
            {
                Username = _username,
                Sort = _sort,
                Page = _page
            };

            private static readonly UserWatchlistRequest _request20 = new UserWatchlistRequest
            {
                Username = _username,
                Sort = _sort,
                Limit = _limit
            };

            private static readonly UserWatchlistRequest _request21 = new UserWatchlistRequest
            {
                Username = _username,
                Sort = _sort,
                Page = _page,
                Limit = _limit
            };

            private static readonly UserWatchlistRequest _request22 = new UserWatchlistRequest
            {
                Username = _username,
                Sort = _sort,
                ExtendedInfo = _extendedInfo,
                Page = _page
            };

            private static readonly UserWatchlistRequest _request23 = new UserWatchlistRequest
            {
                Username = _username,
                Sort = _sort,
                ExtendedInfo = _extendedInfo,
                Limit = _limit
            };

            private static readonly UserWatchlistRequest _request24 = new UserWatchlistRequest
            {
                Username = _username,
                Sort = _sort,
                ExtendedInfo = _extendedInfo,
                Page = _page,
                Limit = _limit
            };

            private static readonly UserWatchlistRequest _request25 = new UserWatchlistRequest
            {
                Username = _username,
                ExtendedInfo = _extendedInfo,
                Page = _page
            };

            private static readonly UserWatchlistRequest _request26 = new UserWatchlistRequest
            {
                Username = _username,
                ExtendedInfo = _extendedInfo,
                Limit = _limit
            };

            private static readonly UserWatchlistRequest _request27 = new UserWatchlistRequest
            {
                Username = _username,
                ExtendedInfo = _extendedInfo,
                Page = _page,
                Limit = _limit
            };

            private static readonly List<object[]> _data = new List<object[]>();

            public UserWatchlistRequest_TestData()
            {
                SetupPathParamters();
            }

            private void SetupPathParamters()
            {
                var strType = _type.UriName;
                var strSort = _sort.UriName;
                var strExtendedInfo = _extendedInfo.ToString();
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
                        ["username"] = _username
                    }});

                _data.Add(new object[] { _request4.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["username"] = _username,
                        ["extended"] = strExtendedInfo
                    }});

                _data.Add(new object[] { _request5.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["username"] = _username,
                        ["page"] = strPage
                    }});

                _data.Add(new object[] { _request6.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["username"] = _username,
                        ["limit"] = strLimit
                    }});

                _data.Add(new object[] { _request7.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["username"] = _username,
                        ["type"] = strType,
                        ["sort"] = strSort
                    }});

                _data.Add(new object[] { _request8.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["username"] = _username,
                        ["type"] = strType,
                        ["extended"] = strExtendedInfo
                    }});

                _data.Add(new object[] { _request9.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["username"] = _username,
                        ["type"] = strType,
                        ["page"] = strPage
                    }});

                _data.Add(new object[] { _request10.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["username"] = _username,
                        ["type"] = strType,
                        ["limit"] = strLimit
                    }});

                _data.Add(new object[] { _request11.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["username"] = _username,
                        ["type"] = strType,
                        ["page"] = strPage,
                        ["limit"] = strLimit
                    }});

                _data.Add(new object[] { _request12.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["username"] = _username,
                        ["type"] = strType,
                        ["sort"] = strSort,
                        ["page"] = strPage
                    }});

                _data.Add(new object[] { _request13.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["username"] = _username,
                        ["type"] = strType,
                        ["sort"] = strSort,
                        ["limit"] = strLimit
                    }});

                _data.Add(new object[] { _request14.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["username"] = _username,
                        ["type"] = strType,
                        ["sort"] = strSort,
                        ["page"] = strPage,
                        ["limit"] = strLimit
                    }});

                _data.Add(new object[] { _request15.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["username"] = _username,
                        ["type"] = strType,
                        ["extended"] = strExtendedInfo,
                        ["page"] = strPage
                    }});

                _data.Add(new object[] { _request16.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["username"] = _username,
                        ["type"] = strType,
                        ["extended"] = strExtendedInfo,
                        ["limit"] = strLimit
                    }});

                _data.Add(new object[] { _request17.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["username"] = _username,
                        ["type"] = strType,
                        ["extended"] = strExtendedInfo,
                        ["page"] = strPage,
                        ["limit"] = strLimit
                    }});

                _data.Add(new object[] { _request18.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["username"] = _username,
                        ["extended"] = strExtendedInfo
                    }});

                _data.Add(new object[] { _request19.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["username"] = _username,
                        ["page"] = strPage
                    }});

                _data.Add(new object[] { _request20.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["username"] = _username,
                        ["limit"] = strLimit
                    }});

                _data.Add(new object[] { _request21.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["username"] = _username,
                        ["page"] = strPage,
                        ["limit"] = strLimit
                    }});

                _data.Add(new object[] { _request22.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["username"] = _username,
                        ["extended"] = strExtendedInfo,
                        ["page"] = strPage
                    }});

                _data.Add(new object[] { _request23.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["username"] = _username,
                        ["extended"] = strExtendedInfo,
                        ["limit"] = strLimit
                    }});

                _data.Add(new object[] { _request24.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["username"] = _username,
                        ["extended"] = strExtendedInfo,
                        ["page"] = strPage,
                        ["limit"] = strLimit
                    }});

                _data.Add(new object[] { _request25.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["username"] = _username,
                        ["extended"] = strExtendedInfo,
                        ["page"] = strPage
                    }});

                _data.Add(new object[] { _request26.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["username"] = _username,
                        ["extended"] = strExtendedInfo,
                        ["limit"] = strLimit
                    }});

                _data.Add(new object[] { _request27.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["username"] = _username,
                        ["extended"] = strExtendedInfo,
                        ["page"] = strPage,
                        ["limit"] = strLimit
                    }});
            }

            public IEnumerator<object[]> GetEnumerator() => _data.GetEnumerator();

            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        }
    }
}
