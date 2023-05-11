namespace TraktNet.Requests.Tests.Base
{
    using FluentAssertions;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Enums;
    using TraktNet.Parameters;
    using TraktNet.Requests.Base;
    using Xunit;

    [TestCategory("Requests.Base")]
    public class AMostRecommendedRequest_1_Tests
    {
        internal class MostRecommendedRequestMock : AMostRecommendedRequest<int>
        {
            public override string UriTemplate { get { throw new NotImplementedException(); } }
            public override void Validate() => throw new NotImplementedException();
        }

        [Fact]
        public void Test_AMostRecommendedRequest_1_Has_AuthorizationRequirement_NotRequired()
        {
            var requestMock = new MostRecommendedRequestMock();
            requestMock.AuthorizationRequirement.Should().Be(AuthorizationRequirement.NotRequired);
        }

        [Theory, ClassData(typeof(MostRecommendedRequestMock_TestData))]
        public void Test_AMostRecommendedRequest_1_Returns_Valid_UriPathParameters(IDictionary<string, object> values,
                                                                                   IDictionary<string, object> expected)
        {
            values.Should().NotBeNull().And.HaveCount(expected.Count);

            if (expected.Count > 0)
                values.Should().Contain(expected);
        }

        public class MostRecommendedRequestMock_TestData : IEnumerable<object[]>
        {
            private static readonly TraktExtendedInfo _extendedInfo = new TraktExtendedInfo { Full = true };
            private static readonly ITraktMovieFilter _filter = TraktFilter.NewMovieFilter().WithYears(2005, 2016).Build();
            private static readonly TraktTimePeriod _timePeriod = TraktTimePeriod.Monthly;
            private const int _page = 5;
            private const int _limit = 20;

            private static readonly MostRecommendedRequestMock _request1 = new MostRecommendedRequestMock();

            private static readonly MostRecommendedRequestMock _request2 = new MostRecommendedRequestMock
            {
                ExtendedInfo = _extendedInfo
            };

            private static readonly MostRecommendedRequestMock _request3 = new MostRecommendedRequestMock
            {
                Filter = _filter
            };

            private static readonly MostRecommendedRequestMock _request4 = new MostRecommendedRequestMock
            {
                Period = _timePeriod
            };

            private static readonly MostRecommendedRequestMock _request5 = new MostRecommendedRequestMock
            {
                Page = _page
            };

            private static readonly MostRecommendedRequestMock _request6 = new MostRecommendedRequestMock
            {
                Limit = _limit
            };

            private static readonly MostRecommendedRequestMock _request7 = new MostRecommendedRequestMock
            {
                ExtendedInfo = _extendedInfo,
                Filter = _filter
            };

            private static readonly MostRecommendedRequestMock _request8 = new MostRecommendedRequestMock
            {
                ExtendedInfo = _extendedInfo,
                Period = _timePeriod
            };

            private static readonly MostRecommendedRequestMock _request9 = new MostRecommendedRequestMock
            {
                ExtendedInfo = _extendedInfo,
                Page = _page
            };

            private static readonly MostRecommendedRequestMock _request10 = new MostRecommendedRequestMock
            {
                ExtendedInfo = _extendedInfo,
                Limit = _limit
            };

            private static readonly MostRecommendedRequestMock _request11 = new MostRecommendedRequestMock
            {
                ExtendedInfo = _extendedInfo,
                Page = _page,
                Limit = _limit
            };

            private static readonly MostRecommendedRequestMock _request12 = new MostRecommendedRequestMock
            {
                Filter = _filter,
                Period = _timePeriod
            };

            private static readonly MostRecommendedRequestMock _request13 = new MostRecommendedRequestMock
            {
                Filter = _filter,
                Page = _page
            };

            private static readonly MostRecommendedRequestMock _request14 = new MostRecommendedRequestMock
            {
                Filter = _filter,
                Limit = _limit
            };

            private static readonly MostRecommendedRequestMock _request15 = new MostRecommendedRequestMock
            {
                Filter = _filter,
                Page = _page,
                Limit = _limit
            };

            private static readonly MostRecommendedRequestMock _request16 = new MostRecommendedRequestMock
            {
                Period = _timePeriod,
                Page = _page
            };

            private static readonly MostRecommendedRequestMock _request17 = new MostRecommendedRequestMock
            {
                Period = _timePeriod,
                Limit = _limit
            };

            private static readonly MostRecommendedRequestMock _request18 = new MostRecommendedRequestMock
            {
                Period = _timePeriod,
                Page = _page,
                Limit = _limit
            };

            private static readonly MostRecommendedRequestMock _request19 = new MostRecommendedRequestMock
            {
                Page = _page,
                Limit = _limit
            };

            private static readonly MostRecommendedRequestMock _request20 = new MostRecommendedRequestMock
            {
                ExtendedInfo = _extendedInfo,
                Filter = _filter,
                Period = _timePeriod,
                Page = _page,
                Limit = _limit
            };

            private static readonly List<object[]> _data = new List<object[]>();

            public MostRecommendedRequestMock_TestData()
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
