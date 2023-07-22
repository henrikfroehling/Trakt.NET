namespace TraktNet.Requests.Tests.Syncs.OAuth
{
    using FluentAssertions;
    using System.Collections;
    using System.Collections.Generic;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Enums;
    using TraktNet.Parameters;
    using TraktNet.Requests.Base;
    using TraktNet.Requests.Syncs.OAuth;
    using Xunit;

    [TestCategory("Requests.Syncs.OAuth")]
    public class SyncFavoritesRequest_Tests
    {
        [Fact]
        public void Test_SyncFavoritesRequest_Has_AuthorizationRequirement_Required()
        {
            var request = new SyncFavoritesRequest();
            request.AuthorizationRequirement.Should().Be(AuthorizationRequirement.Required);
        }

        [Fact]
        public void Test_SyncFavoritesRequest_Has_Valid_UriTemplate()
        {
            var request = new SyncFavoritesRequest();
            request.UriTemplate.Should().Be("sync/favorites{/type}{/sort}{?extended,page,limit}");
        }

        [Theory, ClassData(typeof(SyncFavoritesRequest_TestData))]
        public void Test_SyncFavoritesRequest_Returns_Valid_UriPathParameters(IDictionary<string, object> values,
                                                                              IDictionary<string, object> expected)
        {
            values.Should().NotBeNull().And.HaveCount(expected.Count);

            if (expected.Count > 0)
                values.Should().Contain(expected);
        }

        public class SyncFavoritesRequest_TestData : IEnumerable<object[]>
        {
            private static readonly TraktFavoriteObjectType _type = TraktFavoriteObjectType.Show;
            private static readonly TraktWatchlistSortOrder _sort = TraktWatchlistSortOrder.Rank;
            private static readonly TraktExtendedInfo _extendedInfo = new TraktExtendedInfo { Full = true };
            private const int _page = 4;
            private const int _limit = 20;

            private static readonly SyncFavoritesRequest _request1 = new SyncFavoritesRequest
            {
                Type = _type
            };

            private static readonly SyncFavoritesRequest _request2 = new SyncFavoritesRequest
            {
                Sort = _sort
            };

            private static readonly SyncFavoritesRequest _request3 = new SyncFavoritesRequest
            {
                ExtendedInfo = _extendedInfo
            };

            private static readonly SyncFavoritesRequest _request4 = new SyncFavoritesRequest
            {
                Page = _page
            };

            private static readonly SyncFavoritesRequest _request5 = new SyncFavoritesRequest
            {
                Limit = _limit
            };

            private static readonly SyncFavoritesRequest _request6 = new SyncFavoritesRequest
            {
                Type = _type,
                Sort = _sort
            };

            private static readonly SyncFavoritesRequest _request7 = new SyncFavoritesRequest
            {
                Type = _type,
                ExtendedInfo = _extendedInfo
            };

            private static readonly SyncFavoritesRequest _request8 = new SyncFavoritesRequest
            {
                Type = _type,
                Page = _page
            };

            private static readonly SyncFavoritesRequest _request9 = new SyncFavoritesRequest
            {
                Type = _type,
                Limit = _limit
            };

            private static readonly SyncFavoritesRequest _request10 = new SyncFavoritesRequest
            {
                Type = _type,
                Limit = _limit,
                Page = _page
            };

            private static readonly SyncFavoritesRequest _request11 = new SyncFavoritesRequest
            {
                Type = _type,
                Sort = _sort,
                Page = _page
            };

            private static readonly SyncFavoritesRequest _request12 = new SyncFavoritesRequest
            {
                Type = _type,
                Sort = _sort,
                Limit = _limit
            };

            private static readonly SyncFavoritesRequest _request13 = new SyncFavoritesRequest
            {
                Type = _type,
                Sort = _sort,
                Page = _page,
                Limit = _limit
            };

            private static readonly SyncFavoritesRequest _request14 = new SyncFavoritesRequest
            {
                Type = _type,
                ExtendedInfo = _extendedInfo,
                Page = _page
            };

            private static readonly SyncFavoritesRequest _request15 = new SyncFavoritesRequest
            {
                Type = _type,
                ExtendedInfo = _extendedInfo,
                Limit = _limit
            };

            private static readonly SyncFavoritesRequest _request16 = new SyncFavoritesRequest
            {
                Type = _type,
                ExtendedInfo = _extendedInfo,
                Page = _page,
                Limit = _limit
            };

            private static readonly SyncFavoritesRequest _request17 = new SyncFavoritesRequest
            {
                Sort = _sort,
                ExtendedInfo = _extendedInfo
            };

            private static readonly SyncFavoritesRequest _request18 = new SyncFavoritesRequest
            {
                Sort = _sort,
                Page = _page
            };

            private static readonly SyncFavoritesRequest _request19 = new SyncFavoritesRequest
            {
                Sort = _sort,
                Limit = _limit
            };

            private static readonly SyncFavoritesRequest _request20 = new SyncFavoritesRequest
            {
                Sort = _sort,
                Page = _page,
                Limit = _limit
            };

            private static readonly SyncFavoritesRequest _request21 = new SyncFavoritesRequest
            {
                Sort = _sort,
                ExtendedInfo = _extendedInfo,
                Page = _page
            };

            private static readonly SyncFavoritesRequest _request22 = new SyncFavoritesRequest
            {
                Sort = _sort,
                ExtendedInfo = _extendedInfo,
                Limit = _limit
            };

            private static readonly SyncFavoritesRequest _request23 = new SyncFavoritesRequest
            {
                Sort = _sort,
                ExtendedInfo = _extendedInfo,
                Page = _page,
                Limit = _limit
            };

            private static readonly SyncFavoritesRequest _request24 = new SyncFavoritesRequest
            {
                ExtendedInfo = _extendedInfo,
                Page = _page
            };

            private static readonly SyncFavoritesRequest _request25 = new SyncFavoritesRequest
            {
                ExtendedInfo = _extendedInfo,
                Limit = _limit
            };

            private static readonly SyncFavoritesRequest _request26 = new SyncFavoritesRequest
            {
                ExtendedInfo = _extendedInfo,
                Page = _page,
                Limit = _limit
            };

            private static readonly SyncFavoritesRequest _request27 = new SyncFavoritesRequest
            {
                Type = _type,
                Sort = _sort,
                ExtendedInfo = _extendedInfo,
                Page = _page,
                Limit = _limit
            };

            private static readonly List<object[]> _data = new List<object[]>();

            public SyncFavoritesRequest_TestData()
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
                        ["type"] = strType
                    }});

                _data.Add(new object[] { _request2.GetUriPathParameters(), new Dictionary<string, object>() });

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
                        ["sort"] = strSort
                    }});

                _data.Add(new object[] { _request7.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["type"] = strType,
                        ["extended"] = strExtendedInfo
                    }});

                _data.Add(new object[] { _request8.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["type"] = strType,
                        ["page"] = strPage
                    }});

                _data.Add(new object[] { _request9.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["type"] = strType,
                        ["limit"] = strLimit
                    }});

                _data.Add(new object[] { _request10.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["type"] = strType,
                        ["page"] = strPage,
                        ["limit"] = strLimit
                    }});

                _data.Add(new object[] { _request11.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["type"] = strType,
                        ["sort"] = strSort,
                        ["page"] = strPage
                    }});

                _data.Add(new object[] { _request12.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["type"] = strType,
                        ["sort"] = strSort,
                        ["limit"] = strLimit
                    }});

                _data.Add(new object[] { _request13.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["type"] = strType,
                        ["sort"] = strSort,
                        ["page"] = strPage,
                        ["limit"] = strLimit
                    }});

                _data.Add(new object[] { _request14.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["type"] = strType,
                        ["extended"] = strExtendedInfo,
                        ["page"] = strPage
                    }});

                _data.Add(new object[] { _request15.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["type"] = strType,
                        ["extended"] = strExtendedInfo,
                        ["limit"] = strLimit
                    }});

                _data.Add(new object[] { _request16.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["type"] = strType,
                        ["extended"] = strExtendedInfo,
                        ["page"] = strPage,
                        ["limit"] = strLimit
                    }});

                _data.Add(new object[] { _request17.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["extended"] = strExtendedInfo
                    }});

                _data.Add(new object[] { _request18.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["page"] = strPage
                    }});

                _data.Add(new object[] { _request19.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["limit"] = strLimit
                    }});

                _data.Add(new object[] { _request20.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["page"] = strPage,
                        ["limit"] = strLimit
                    }});

                _data.Add(new object[] { _request21.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["extended"] = strExtendedInfo,
                        ["page"] = strPage
                    }});

                _data.Add(new object[] { _request22.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["extended"] = strExtendedInfo,
                        ["limit"] = strLimit
                    }});

                _data.Add(new object[] { _request23.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["extended"] = strExtendedInfo,
                        ["page"] = strPage,
                        ["limit"] = strLimit
                    }});

                _data.Add(new object[] { _request24.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["extended"] = strExtendedInfo,
                        ["page"] = strPage
                    }});

                _data.Add(new object[] { _request25.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["extended"] = strExtendedInfo,
                        ["limit"] = strLimit
                    }});

                _data.Add(new object[] { _request26.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["extended"] = strExtendedInfo,
                        ["page"] = strPage,
                        ["limit"] = strLimit
                    }});

                _data.Add(new object[] { _request27.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["type"] = strType,
                        ["sort"] = strSort,
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
