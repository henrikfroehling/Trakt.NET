namespace TraktApiSharp.Tests.Requests.Users.OAuth
{
    using FluentAssertions;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using Traits;
    using TraktApiSharp.Enums;
    using TraktApiSharp.Objects.Get.Watchlist;
    using TraktApiSharp.Objects.Get.Watchlist.Implementations;
    using TraktApiSharp.Requests.Base;
    using TraktApiSharp.Requests.Parameters;
    using TraktApiSharp.Requests.Users.OAuth;
    using Xunit;

    [Category("Requests.Users.OAuth")]
    public class TraktUserWatchlistRequest_Tests
    {
        [Fact]
        public void Test_TraktUserWatchlistRequest_Is_Not_Abstract()
        {
            typeof(TraktUserWatchlistRequest).IsAbstract.Should().BeFalse();
        }

        [Fact]
        public void Test_TraktUserWatchlistRequest_Is_Sealed()
        {
            typeof(TraktUserWatchlistRequest).IsSealed.Should().BeTrue();
        }

        [Fact]
        public void Test_TraktUserWatchlistRequest_Inherits_ATraktUsersPagedGetRequest_1()
        {
            typeof(TraktUserWatchlistRequest).IsSubclassOf(typeof(ATraktUsersPagedGetRequest<TraktWatchlistItem>)).Should().BeTrue();
        }

        [Fact]
        public void Test_TraktUserWatchlistRequest_Has_Username_Property()
        {
            var propertyInfo = typeof(TraktUserWatchlistRequest)
                    .GetProperties(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance)
                    .Where(p => p.Name == "Username")
                    .FirstOrDefault();

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(string));
        }

        [Fact]
        public void Test_TraktUserWatchlistRequest_Has_Type_Property()
        {
            var propertyInfo = typeof(TraktUserWatchlistRequest)
                    .GetProperties(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance)
                    .Where(p => p.Name == "Type")
                    .FirstOrDefault();

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(TraktSyncItemType));
        }

        [Fact]
        public void Test_TraktUserWatchlistRequest_Has_AuthorizationRequirement_Optional()
        {
            var request = new TraktUserWatchlistRequest();
            request.AuthorizationRequirement.Should().Be(TraktAuthorizationRequirement.Optional);
        }

        [Fact]
        public void Test_TraktUserWatchlistRequest_Has_Valid_UriTemplate()
        {
            var request = new TraktUserWatchlistRequest();
            request.UriTemplate.Should().Be("users/{username}/watchlist{/type}{?extended,page,limit}");
        }

        [Fact]
        public void Test_TraktUserWatchlistRequest_Validate_Throws_Exceptions()
        {
            // username is null
            var request = new TraktUserWatchlistRequest();

            Action act = () => request.Validate();
            act.ShouldThrow<ArgumentNullException>();

            // empty username
            request = new TraktUserWatchlistRequest { Username = string.Empty };

            act = () => request.Validate();
            act.ShouldThrow<ArgumentException>();

            // username with spaces
            request = new TraktUserWatchlistRequest { Username = "invalid username" };

            act = () => request.Validate();
            act.ShouldThrow<ArgumentException>();
        }

        [Theory, ClassData(typeof(TraktUserWatchlistRequest_TestData))]
        public void Test_TraktUserWatchlistRequest_Returns_Valid_UriPathParameters(IDictionary<string, object> values,
                                                                                   IDictionary<string, object> expected)
        {
            values.Should().NotBeNull().And.HaveCount(expected.Count);

            if (expected.Count > 0)
                values.Should().Contain(expected);
        }

        public class TraktUserWatchlistRequest_TestData : IEnumerable<object[]>
        {
            private const string _username = "username";
            private static readonly TraktSyncItemType _type = TraktSyncItemType.Episode;
            private static readonly TraktExtendedInfo _extendedInfo = new TraktExtendedInfo { Full = true };
            private const int _page = 4;
            private const int _limit = 20;

            private static readonly TraktUserWatchlistRequest _request1 = new TraktUserWatchlistRequest
            {
                Username = _username
            };

            private static readonly TraktUserWatchlistRequest _request2 = new TraktUserWatchlistRequest
            {
                Username = _username,
                Type = _type
            };

            private static readonly TraktUserWatchlistRequest _request3 = new TraktUserWatchlistRequest
            {
                Username = _username,
                ExtendedInfo = _extendedInfo
            };

            private static readonly TraktUserWatchlistRequest _request4 = new TraktUserWatchlistRequest
            {
                Username = _username,
                Page = _page
            };

            private static readonly TraktUserWatchlistRequest _request5 = new TraktUserWatchlistRequest
            {
                Username = _username,
                Limit = _limit
            };

            private static readonly TraktUserWatchlistRequest _request6 = new TraktUserWatchlistRequest
            {
                Username = _username,
                Page = _page,
                Limit = _limit
            };

            private static readonly TraktUserWatchlistRequest _request7 = new TraktUserWatchlistRequest
            {
                Username = _username,
                Type = _type,
                ExtendedInfo = _extendedInfo
            };

            private static readonly TraktUserWatchlistRequest _request8 = new TraktUserWatchlistRequest
            {
                Username = _username,
                Type = _type,
                Page = _page
            };

            private static readonly TraktUserWatchlistRequest _request9 = new TraktUserWatchlistRequest
            {
                Username = _username,
                Type = _type,
                Limit = _limit
            };

            private static readonly TraktUserWatchlistRequest _request10 = new TraktUserWatchlistRequest
            {
                Username = _username,
                Type = _type,
                Page = _page,
                Limit = _limit
            };

            private static readonly TraktUserWatchlistRequest _request11 = new TraktUserWatchlistRequest
            {
                Username = _username,
                ExtendedInfo = _extendedInfo,
                Page = _page
            };

            private static readonly TraktUserWatchlistRequest _request12 = new TraktUserWatchlistRequest
            {
                Username = _username,
                ExtendedInfo = _extendedInfo,
                Limit = _limit
            };

            private static readonly TraktUserWatchlistRequest _request13 = new TraktUserWatchlistRequest
            {
                Username = _username,
                ExtendedInfo = _extendedInfo,
                Page = _page,
                Limit = _limit
            };

            private static readonly TraktUserWatchlistRequest _request14 = new TraktUserWatchlistRequest
            {
                Username = _username,
                Type = _type,
                ExtendedInfo = _extendedInfo,
                Page = _page,
                Limit = _limit
            };
            
            private static readonly List<object[]> _data = new List<object[]>();

            public TraktUserWatchlistRequest_TestData()
            {
                SetupPathParamters();
            }

            private void SetupPathParamters()
            {
                var strType = _type.UriName;
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
                        ["username"] = _username,
                        ["extended"] = strExtendedInfo
                    }});

                _data.Add(new object[] { _request4.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["username"] = _username,
                        ["page"] = strPage
                    }});

                _data.Add(new object[] { _request5.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["username"] = _username,
                        ["limit"] = strLimit
                    }});

                _data.Add(new object[] { _request6.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["username"] = _username,
                        ["page"] = strPage,
                        ["limit"] = strLimit
                    }});

                _data.Add(new object[] { _request7.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["username"] = _username,
                        ["type"] = strType,
                        ["extended"] = strExtendedInfo
                    }});

                _data.Add(new object[] { _request8.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["username"] = _username,
                        ["type"] = strType,
                        ["page"] = strPage
                    }});

                _data.Add(new object[] { _request9.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["username"] = _username,
                        ["type"] = strType,
                        ["limit"] = strLimit
                    }});

                _data.Add(new object[] { _request10.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["username"] = _username,
                        ["type"] = strType,
                        ["page"] = strPage,
                        ["limit"] = strLimit
                    }});

                _data.Add(new object[] { _request11.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["username"] = _username,
                        ["extended"] = strExtendedInfo,
                        ["page"] = strPage
                    }});

                _data.Add(new object[] { _request12.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["username"] = _username,
                        ["extended"] = strExtendedInfo,
                        ["limit"] = strLimit
                    }});

                _data.Add(new object[] { _request13.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["username"] = _username,
                        ["extended"] = strExtendedInfo,
                        ["page"] = strPage,
                        ["limit"] = strLimit
                    }});

                _data.Add(new object[] { _request14.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["username"] = _username,
                        ["type"] = strType,
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
