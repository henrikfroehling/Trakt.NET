namespace TraktApiSharp.Tests.Requests.Syncs.OAuth
{
    using FluentAssertions;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using Traits;
    using TraktApiSharp.Enums;
    using TraktApiSharp.Objects.Get.Watchlist.Implementations;
    using TraktApiSharp.Requests.Interfaces;
    using TraktApiSharp.Requests.Parameters;
    using TraktApiSharp.Requests.Syncs.OAuth;
    using Xunit;

    [Category("Requests.Syncs.OAuth")]
    public class TraktSyncWatchlistRequest_Tests
    {
        [Fact]
        public void Test_TraktSyncWatchlistRequest_Is_Not_Abstract()
        {
            typeof(TraktSyncWatchlistRequest).IsAbstract.Should().BeFalse();
        }

        [Fact]
        public void Test_TraktSyncWatchlistRequest_Is_Sealed()
        {
            typeof(TraktSyncWatchlistRequest).IsSealed.Should().BeTrue();
        }

        [Fact]
        public void Test_TraktSyncWatchlistRequest_Inherits_ATraktSyncGetRequest_1()
        {
            typeof(TraktSyncWatchlistRequest).IsSubclassOf(typeof(ATraktSyncGetRequest<TraktWatchlistItem>)).Should().BeTrue();
        }

        [Fact]
        public void Test_TraktSyncWatchlistRequest_Implements_ITraktSupportsExtendedInfo_Interface()
        {
            typeof(TraktSyncWatchlistRequest).GetInterfaces().Should().Contain(typeof(ITraktSupportsExtendedInfo));
        }

        [Fact]
        public void Test_TraktSyncWatchlistRequest_Implements_ITraktSupportsPagination_Interface()
        {
            typeof(TraktSyncWatchlistRequest).GetInterfaces().Should().Contain(typeof(ITraktSupportsPagination));
        }

        [Fact]
        public void Test_TraktSyncWatchlistRequest_Has_Valid_UriTemplate()
        {
            var request = new TraktSyncWatchlistRequest();
            request.UriTemplate.Should().Be("sync/watchlist{/type}{?extended,page,limit}");
        }

        [Fact]
        public void Test_TraktSyncWatchlistRequest_Has_Type_Property()
        {
            var propertyInfo = typeof(TraktSyncWatchlistRequest)
                    .GetProperties(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance)
                    .Where(p => p.Name == "Type")
                    .FirstOrDefault();

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(TraktSyncItemType));
        }

        [Theory, ClassData(typeof(TraktSyncWatchlistRequest_TestData))]
        public void Test_TraktSyncWatchlistRequest_Returns_Valid_UriPathParameters(IDictionary<string, object> values,
                                                                                   IDictionary<string, object> expected)
        {
            values.Should().NotBeNull().And.HaveCount(expected.Count);

            if (expected.Count > 0)
                values.Should().Contain(expected);
        }

        public class TraktSyncWatchlistRequest_TestData : IEnumerable<object[]>
        {
            private static readonly TraktSyncItemType _type = TraktSyncItemType.Episode;
            private static readonly TraktExtendedInfo _extendedInfo = new TraktExtendedInfo { Full = true };
            private const int _page = 4;
            private const int _limit = 20;

            private static readonly TraktSyncWatchlistRequest _request1 = new TraktSyncWatchlistRequest();

            private static readonly TraktSyncWatchlistRequest _request2 = new TraktSyncWatchlistRequest
            {
                Type = _type
            };

            private static readonly TraktSyncWatchlistRequest _request3 = new TraktSyncWatchlistRequest
            {
                ExtendedInfo = _extendedInfo
            };

            private static readonly TraktSyncWatchlistRequest _request4 = new TraktSyncWatchlistRequest
            {
                Page = _page
            };

            private static readonly TraktSyncWatchlistRequest _request5 = new TraktSyncWatchlistRequest
            {
                Limit = _limit
            };

            private static readonly TraktSyncWatchlistRequest _request6 = new TraktSyncWatchlistRequest
            {
                Type = _type,
                ExtendedInfo = _extendedInfo
            };

            private static readonly TraktSyncWatchlistRequest _request7 = new TraktSyncWatchlistRequest
            {
                Type = _type,
                Page = _page
            };

            private static readonly TraktSyncWatchlistRequest _request8 = new TraktSyncWatchlistRequest
            {
                Type = _type,
                Limit = _limit
            };

            private static readonly TraktSyncWatchlistRequest _request9 = new TraktSyncWatchlistRequest
            {
                Type = _type,
                Page = _page,
                Limit = _limit
            };

            private static readonly TraktSyncWatchlistRequest _request10 = new TraktSyncWatchlistRequest
            {
                ExtendedInfo = _extendedInfo,
                Page = _page
            };

            private static readonly TraktSyncWatchlistRequest _request11 = new TraktSyncWatchlistRequest
            {
                ExtendedInfo = _extendedInfo,
                Limit = _limit
            };

            private static readonly TraktSyncWatchlistRequest _request12 = new TraktSyncWatchlistRequest
            {
                ExtendedInfo = _extendedInfo,
                Page = _page,
                Limit = _limit
            };

            private static readonly TraktSyncWatchlistRequest _request13 = new TraktSyncWatchlistRequest
            {
                Page = _page,
                Limit = _limit
            };

            private static readonly TraktSyncWatchlistRequest _request14 = new TraktSyncWatchlistRequest
            {
                Type = _type,
                ExtendedInfo = _extendedInfo,
                Page = _page,
                Limit = _limit
            };

            private static readonly List<object[]> _data = new List<object[]>();

            public TraktSyncWatchlistRequest_TestData()
            {
                SetupPathParamters();
            }

            private void SetupPathParamters()
            {
                var strType = _type.UriName;
                var strExtendedInfo = _extendedInfo.ToString();
                var strPage = _page.ToString();
                var strLimit = _limit.ToString();

                _data.Add(new object[] { _request1.GetUriPathParameters(), new Dictionary<string, object>() });

                _data.Add(new object[] { _request2.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["type"] = strType
                    }});

                _data.Add(new object[] { _request3.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["extended"] = strExtendedInfo
                    }});

                _data.Add(new object[] { _request4.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["page"] = strPage
                    }});

                _data.Add(new object[] { _request5.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["limit"] = strLimit
                    }});

                _data.Add(new object[] { _request6.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["type"] = strType,
                        ["extended"] = strExtendedInfo
                    }});

                _data.Add(new object[] { _request7.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["type"] = strType,
                        ["page"] = strPage
                    }});

                _data.Add(new object[] { _request8.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["type"] = strType,
                        ["limit"] = strLimit
                    }});

                _data.Add(new object[] { _request9.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["type"] = strType,
                        ["page"] = strPage,
                        ["limit"] = strLimit
                    }});

                _data.Add(new object[] { _request10.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["extended"] = strExtendedInfo,
                        ["page"] = strPage
                    }});

                _data.Add(new object[] { _request11.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["extended"] = strExtendedInfo,
                        ["limit"] = strLimit
                    }});

                _data.Add(new object[] { _request12.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["extended"] = strExtendedInfo,
                        ["page"] = strPage,
                        ["limit"] = strLimit
                    }});

                _data.Add(new object[] { _request13.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["page"] = strPage,
                        ["limit"] = strLimit
                    }});

                _data.Add(new object[] { _request14.GetUriPathParameters(), new Dictionary<string, object>
                    {
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
