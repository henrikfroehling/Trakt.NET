namespace TraktNet.Requests.Tests.Shows
{
    using FluentAssertions;
    using System.Collections;
    using System.Collections.Generic;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Enums;
    using TraktNet.Parameters;
    using TraktNet.Requests.Shows;
    using Xunit;

    [TestCategory("Requests.Shows.Lists")]
    public class ShowsMostFavoritedRequest_Tests
    {
        [Fact]
        public void Test_ShowsMostFavoritedRequest_Has_Valid_UriTemplate()
        {
            var request = new ShowsMostFavoritedRequest();
            request.UriTemplate.Should().Be("shows/favorited{/period}{?extended,page,limit,query,years,genres,languages,countries,runtimes,ratings,certifications,networks,status}");
        }

        [Theory, ClassData(typeof(ShowsMostFavoritedRequest_TestData))]
        public void Test_ShowsMostFavoritedRequest_Returns_Valid_UriPathParameters(IDictionary<string, object> values,
                                                                                   IDictionary<string, object> expected)
        {
            values.Should().NotBeNull().And.HaveCount(expected.Count);

            if (expected.Count > 0)
                values.Should().Contain(expected);
        }

        public class ShowsMostFavoritedRequest_TestData : IEnumerable<object[]>
        {
            private static readonly TraktExtendedInfo _extendedInfo = new TraktExtendedInfo { Full = true };
            private static readonly ITraktShowFilter _filter = TraktFilter.NewShowFilter().WithYears(2005, 2016).Build();
            private static readonly TraktTimePeriod _timePeriod = TraktTimePeriod.Monthly;
            private const int _page = 5;
            private const int _limit = 20;

            private static readonly ShowsMostFavoritedRequest _request1 = new ShowsMostFavoritedRequest();

            private static readonly ShowsMostFavoritedRequest _request2 = new ShowsMostFavoritedRequest
            {
                ExtendedInfo = _extendedInfo
            };

            private static readonly ShowsMostFavoritedRequest _request3 = new ShowsMostFavoritedRequest
            {
                Filter = _filter
            };

            private static readonly ShowsMostFavoritedRequest _request4 = new ShowsMostFavoritedRequest
            {
                Period = _timePeriod
            };

            private static readonly ShowsMostFavoritedRequest _request5 = new ShowsMostFavoritedRequest
            {
                Page = _page
            };

            private static readonly ShowsMostFavoritedRequest _request6 = new ShowsMostFavoritedRequest
            {
                Limit = _limit
            };

            private static readonly ShowsMostFavoritedRequest _request7 = new ShowsMostFavoritedRequest
            {
                ExtendedInfo = _extendedInfo,
                Filter = _filter
            };

            private static readonly ShowsMostFavoritedRequest _request8 = new ShowsMostFavoritedRequest
            {
                ExtendedInfo = _extendedInfo,
                Period = _timePeriod
            };

            private static readonly ShowsMostFavoritedRequest _request9 = new ShowsMostFavoritedRequest
            {
                ExtendedInfo = _extendedInfo,
                Page = _page
            };

            private static readonly ShowsMostFavoritedRequest _request10 = new ShowsMostFavoritedRequest
            {
                ExtendedInfo = _extendedInfo,
                Limit = _limit
            };

            private static readonly ShowsMostFavoritedRequest _request11 = new ShowsMostFavoritedRequest
            {
                ExtendedInfo = _extendedInfo,
                Page = _page,
                Limit = _limit
            };

            private static readonly ShowsMostFavoritedRequest _request12 = new ShowsMostFavoritedRequest
            {
                Filter = _filter,
                Period = _timePeriod
            };

            private static readonly ShowsMostFavoritedRequest _request13 = new ShowsMostFavoritedRequest
            {
                Filter = _filter,
                Page = _page
            };

            private static readonly ShowsMostFavoritedRequest _request14 = new ShowsMostFavoritedRequest
            {
                Filter = _filter,
                Limit = _limit
            };

            private static readonly ShowsMostFavoritedRequest _request15 = new ShowsMostFavoritedRequest
            {
                Filter = _filter,
                Page = _page,
                Limit = _limit
            };

            private static readonly ShowsMostFavoritedRequest _request16 = new ShowsMostFavoritedRequest
            {
                Period = _timePeriod,
                Page = _page
            };

            private static readonly ShowsMostFavoritedRequest _request17 = new ShowsMostFavoritedRequest
            {
                Period = _timePeriod,
                Limit = _limit
            };

            private static readonly ShowsMostFavoritedRequest _request18 = new ShowsMostFavoritedRequest
            {
                Period = _timePeriod,
                Page = _page,
                Limit = _limit
            };

            private static readonly ShowsMostFavoritedRequest _request19 = new ShowsMostFavoritedRequest
            {
                Page = _page,
                Limit = _limit
            };

            private static readonly ShowsMostFavoritedRequest _request20 = new ShowsMostFavoritedRequest
            {
                ExtendedInfo = _extendedInfo,
                Filter = _filter,
                Period = _timePeriod,
                Page = _page,
                Limit = _limit
            };

            private static readonly List<object[]> _data = new List<object[]>();

            public ShowsMostFavoritedRequest_TestData()
            {
                SetupPathParamters();
            }

            private void SetupPathParamters()
            {
                var strExtendedInfo = _extendedInfo.ToString();
                var filterParameters = _filter.GetParameters();
                var strTimePeriod = _timePeriod.UriName;
                var strPage = _page.ToString();
                var strLimit = _limit.ToString();

                _data.Add(new object[] { _request1.GetUriPathParameters(), new Dictionary<string, object>() });

                _data.Add(new object[] { _request2.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["extended"] = strExtendedInfo
                    }});

                _data.Add(new object[] { _request3.GetUriPathParameters(), new Dictionary<string, object>(filterParameters) });

                _data.Add(new object[] { _request4.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["period"] = strTimePeriod
                    }});

                _data.Add(new object[] { _request5.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["page"] = strPage
                    }});

                _data.Add(new object[] { _request6.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["limit"] = strLimit
                    }});

                _data.Add(new object[] { _request7.GetUriPathParameters(), new Dictionary<string, object>(filterParameters)
                    {
                        ["extended"] = strExtendedInfo
                    }});

                _data.Add(new object[] { _request8.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["extended"] = strExtendedInfo,
                        ["period"] = strTimePeriod
                    }});

                _data.Add(new object[] { _request9.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["extended"] = strExtendedInfo,
                        ["page"] = strPage
                    }});

                _data.Add(new object[] { _request10.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["extended"] = strExtendedInfo,
                        ["limit"] = strLimit
                    }});

                _data.Add(new object[] { _request11.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["extended"] = strExtendedInfo,
                        ["page"] = strPage,
                        ["limit"] = strLimit
                    }});

                _data.Add(new object[] { _request12.GetUriPathParameters(), new Dictionary<string, object>(filterParameters)
                    {
                        ["period"] = strTimePeriod
                    }});

                _data.Add(new object[] { _request13.GetUriPathParameters(), new Dictionary<string, object>(filterParameters)
                    {
                        ["page"] = strPage
                    }});

                _data.Add(new object[] { _request14.GetUriPathParameters(), new Dictionary<string, object>(filterParameters)
                    {
                        ["limit"] = strLimit
                    }});

                _data.Add(new object[] { _request15.GetUriPathParameters(), new Dictionary<string, object>(filterParameters)
                    {
                        ["page"] = strPage,
                        ["limit"] = strLimit
                    }});

                _data.Add(new object[] { _request16.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["period"] = strTimePeriod,
                        ["page"] = strPage
                    }});

                _data.Add(new object[] { _request17.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["period"] = strTimePeriod,
                        ["limit"] = strLimit
                    }});

                _data.Add(new object[] { _request18.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["period"] = strTimePeriod,
                        ["page"] = strPage,
                        ["limit"] = strLimit
                    }});

                _data.Add(new object[] { _request19.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["page"] = strPage,
                        ["limit"] = strLimit
                    }});

                _data.Add(new object[] { _request20.GetUriPathParameters(), new Dictionary<string, object>(filterParameters)
                    {
                        ["extended"] = strExtendedInfo,
                        ["period"] = strTimePeriod,
                        ["page"] = strPage,
                        ["limit"] = strLimit
                    }});
            }

            public IEnumerator<object[]> GetEnumerator() => _data.GetEnumerator();

            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        }
    }
}
