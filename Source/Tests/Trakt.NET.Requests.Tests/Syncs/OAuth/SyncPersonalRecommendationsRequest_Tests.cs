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
    public class SyncPersonalRecommendationsRequest_Tests
    {
        [Fact]
        public void Test_SyncPersonalRecommendationsRequest_Has_AuthorizationRequirement_Required()
        {
            var request = new SyncPersonalRecommendationsRequest();
            request.AuthorizationRequirement.Should().Be(AuthorizationRequirement.Required);
        }

        [Fact]
        public void Test_SyncPersonalRecommendationsRequest_Has_Valid_UriTemplate()
        {
            var request = new SyncPersonalRecommendationsRequest();
            request.UriTemplate.Should().Be("sync/recommendations{/type}{/sort}{?extended,page,limit}");
        }

        [Theory, ClassData(typeof(SyncPersonalRecommendationsRequest_TestData))]
        public void Test_SyncPersonalRecommendationsRequest_Returns_Valid_UriPathParameters(IDictionary<string, object> values,
                                                                                            IDictionary<string, object> expected)
        {
            values.Should().NotBeNull().And.HaveCount(expected.Count);

            if (expected.Count > 0)
                values.Should().Contain(expected);
        }

        public class SyncPersonalRecommendationsRequest_TestData : IEnumerable<object[]>
        {
            private static readonly TraktFavoriteObjectType _type = TraktFavoriteObjectType.Show;
            private static readonly TraktWatchlistSortOrder _sort = TraktWatchlistSortOrder.Rank;
            private static readonly TraktExtendedInfo _extendedInfo = new TraktExtendedInfo { Full = true };
            private const int _page = 4;
            private const int _limit = 20;

            private static readonly SyncPersonalRecommendationsRequest _request1 = new SyncPersonalRecommendationsRequest
            {
                Type = _type
            };

            private static readonly SyncPersonalRecommendationsRequest _request2 = new SyncPersonalRecommendationsRequest
            {
                Sort = _sort
            };

            private static readonly SyncPersonalRecommendationsRequest _request3 = new SyncPersonalRecommendationsRequest
            {
                ExtendedInfo = _extendedInfo
            };

            private static readonly SyncPersonalRecommendationsRequest _request4 = new SyncPersonalRecommendationsRequest
            {
                Page = _page
            };

            private static readonly SyncPersonalRecommendationsRequest _request5 = new SyncPersonalRecommendationsRequest
            {
                Limit = _limit
            };

            private static readonly SyncPersonalRecommendationsRequest _request6 = new SyncPersonalRecommendationsRequest
            {
                Type = _type,
                Sort = _sort
            };

            private static readonly SyncPersonalRecommendationsRequest _request7 = new SyncPersonalRecommendationsRequest
            {
                Type = _type,
                ExtendedInfo = _extendedInfo
            };

            private static readonly SyncPersonalRecommendationsRequest _request8 = new SyncPersonalRecommendationsRequest
            {
                Type = _type,
                Page = _page
            };

            private static readonly SyncPersonalRecommendationsRequest _request9 = new SyncPersonalRecommendationsRequest
            {
                Type = _type,
                Limit = _limit
            };

            private static readonly SyncPersonalRecommendationsRequest _request10 = new SyncPersonalRecommendationsRequest
            {
                Type = _type,
                Limit = _limit,
                Page = _page
            };

            private static readonly SyncPersonalRecommendationsRequest _request11 = new SyncPersonalRecommendationsRequest
            {
                Type = _type,
                Sort = _sort,
                Page = _page
            };

            private static readonly SyncPersonalRecommendationsRequest _request12 = new SyncPersonalRecommendationsRequest
            {
                Type = _type,
                Sort = _sort,
                Limit = _limit
            };

            private static readonly SyncPersonalRecommendationsRequest _request13 = new SyncPersonalRecommendationsRequest
            {
                Type = _type,
                Sort = _sort,
                Page = _page,
                Limit = _limit
            };

            private static readonly SyncPersonalRecommendationsRequest _request14 = new SyncPersonalRecommendationsRequest
            {
                Type = _type,
                ExtendedInfo = _extendedInfo,
                Page = _page
            };

            private static readonly SyncPersonalRecommendationsRequest _request15 = new SyncPersonalRecommendationsRequest
            {
                Type = _type,
                ExtendedInfo = _extendedInfo,
                Limit = _limit
            };

            private static readonly SyncPersonalRecommendationsRequest _request16 = new SyncPersonalRecommendationsRequest
            {
                Type = _type,
                ExtendedInfo = _extendedInfo,
                Page = _page,
                Limit = _limit
            };

            private static readonly SyncPersonalRecommendationsRequest _request17 = new SyncPersonalRecommendationsRequest
            {
                Sort = _sort,
                ExtendedInfo = _extendedInfo
            };

            private static readonly SyncPersonalRecommendationsRequest _request18 = new SyncPersonalRecommendationsRequest
            {
                Sort = _sort,
                Page = _page
            };

            private static readonly SyncPersonalRecommendationsRequest _request19 = new SyncPersonalRecommendationsRequest
            {
                Sort = _sort,
                Limit = _limit
            };

            private static readonly SyncPersonalRecommendationsRequest _request20 = new SyncPersonalRecommendationsRequest
            {
                Sort = _sort,
                Page = _page,
                Limit = _limit
            };

            private static readonly SyncPersonalRecommendationsRequest _request21 = new SyncPersonalRecommendationsRequest
            {
                Sort = _sort,
                ExtendedInfo = _extendedInfo,
                Page = _page
            };

            private static readonly SyncPersonalRecommendationsRequest _request22 = new SyncPersonalRecommendationsRequest
            {
                Sort = _sort,
                ExtendedInfo = _extendedInfo,
                Limit = _limit
            };

            private static readonly SyncPersonalRecommendationsRequest _request23 = new SyncPersonalRecommendationsRequest
            {
                Sort = _sort,
                ExtendedInfo = _extendedInfo,
                Page = _page,
                Limit = _limit
            };

            private static readonly SyncPersonalRecommendationsRequest _request24 = new SyncPersonalRecommendationsRequest
            {
                ExtendedInfo = _extendedInfo,
                Page = _page
            };

            private static readonly SyncPersonalRecommendationsRequest _request25 = new SyncPersonalRecommendationsRequest
            {
                ExtendedInfo = _extendedInfo,
                Limit = _limit
            };

            private static readonly SyncPersonalRecommendationsRequest _request26 = new SyncPersonalRecommendationsRequest
            {
                ExtendedInfo = _extendedInfo,
                Page = _page,
                Limit = _limit
            };

            private static readonly SyncPersonalRecommendationsRequest _request27 = new SyncPersonalRecommendationsRequest
            {
                Type = _type,
                Sort = _sort,
                ExtendedInfo = _extendedInfo,
                Page = _page,
                Limit = _limit
            };

            private static readonly List<object[]> _data = new List<object[]>();

            public SyncPersonalRecommendationsRequest_TestData()
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
