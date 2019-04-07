namespace TraktNet.Requests.Tests.Syncs.OAuth
{
    using FluentAssertions;
    using System.Collections;
    using System.Collections.Generic;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Enums;
    using TraktNet.Requests.Parameters;
    using TraktNet.Requests.Syncs.OAuth;
    using Xunit;

    [Category("Requests.Syncs.OAuth")]
    public class SyncWatchlistRequest_Tests
    {
        [Fact]
        public void Test_SyncWatchlistRequest_Has_Valid_UriTemplate()
        {
            var request = new SyncWatchlistRequest();
            request.UriTemplate.Should().Be("sync/watchlist{/type}{?extended,page,limit}");
        }

        [Theory, ClassData(typeof(SyncWatchlistRequest_TestData))]
        public void Test_SyncWatchlistRequest_Returns_Valid_UriPathParameters(IDictionary<string, object> values,
                                                                              IDictionary<string, object> expected)
        {
            values.Should().NotBeNull().And.HaveCount(expected.Count);

            if (expected.Count > 0)
                values.Should().Contain(expected);
        }

        public class SyncWatchlistRequest_TestData : IEnumerable<object[]>
        {
            private static readonly TraktSyncItemType _type = TraktSyncItemType.Episode;
            private static readonly TraktExtendedInfo _extendedInfo = new TraktExtendedInfo { Full = true };
            private const int _page = 4;
            private const int _limit = 20;

            private static readonly SyncWatchlistRequest _request1 = new SyncWatchlistRequest();

            private static readonly SyncWatchlistRequest _request2 = new SyncWatchlistRequest
            {
                Type = _type
            };

            private static readonly SyncWatchlistRequest _request3 = new SyncWatchlistRequest
            {
                ExtendedInfo = _extendedInfo
            };

            private static readonly SyncWatchlistRequest _request4 = new SyncWatchlistRequest
            {
                Page = _page
            };

            private static readonly SyncWatchlistRequest _request5 = new SyncWatchlistRequest
            {
                Limit = _limit
            };

            private static readonly SyncWatchlistRequest _request6 = new SyncWatchlistRequest
            {
                Type = _type,
                ExtendedInfo = _extendedInfo
            };

            private static readonly SyncWatchlistRequest _request7 = new SyncWatchlistRequest
            {
                Type = _type,
                Page = _page
            };

            private static readonly SyncWatchlistRequest _request8 = new SyncWatchlistRequest
            {
                Type = _type,
                Limit = _limit
            };

            private static readonly SyncWatchlistRequest _request9 = new SyncWatchlistRequest
            {
                Type = _type,
                Page = _page,
                Limit = _limit
            };

            private static readonly SyncWatchlistRequest _request10 = new SyncWatchlistRequest
            {
                ExtendedInfo = _extendedInfo,
                Page = _page
            };

            private static readonly SyncWatchlistRequest _request11 = new SyncWatchlistRequest
            {
                ExtendedInfo = _extendedInfo,
                Limit = _limit
            };

            private static readonly SyncWatchlistRequest _request12 = new SyncWatchlistRequest
            {
                ExtendedInfo = _extendedInfo,
                Page = _page,
                Limit = _limit
            };

            private static readonly SyncWatchlistRequest _request13 = new SyncWatchlistRequest
            {
                Page = _page,
                Limit = _limit
            };

            private static readonly SyncWatchlistRequest _request14 = new SyncWatchlistRequest
            {
                Type = _type,
                ExtendedInfo = _extendedInfo,
                Page = _page,
                Limit = _limit
            };

            private static readonly List<object[]> _data = new List<object[]>();

            public SyncWatchlistRequest_TestData()
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
