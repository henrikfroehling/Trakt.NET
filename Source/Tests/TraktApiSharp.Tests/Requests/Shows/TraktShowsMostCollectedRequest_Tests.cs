namespace TraktApiSharp.Tests.Requests.Shows
{
    using FluentAssertions;
    using System.Collections;
    using System.Collections.Generic;
    using Traits;
    using TraktApiSharp.Enums;
    using TraktApiSharp.Objects.Get.Shows.Implementations;
    using TraktApiSharp.Requests.Parameters;
    using TraktApiSharp.Requests.Shows;
    using Xunit;

    [Category("Requests.Shows.Lists")]
    public class TraktShowsMostCollectedRequest_Tests
    {
        [Fact]
        public void Test_TraktShowsMostCollectedRequest_Is_Not_Abstract()
        {
            typeof(TraktShowsMostCollectedRequest).IsAbstract.Should().BeFalse();
        }

        [Fact]
        public void Test_TraktShowsMostCollectedRequest_Is_Sealed()
        {
            typeof(TraktShowsMostCollectedRequest).IsSealed.Should().BeTrue();
        }

        [Fact]
        public void Test_TraktShowsMostCollectedRequest_Inherits_ATraktShowsMostPWCRequest_1()
        {
            typeof(TraktShowsMostCollectedRequest).IsSubclassOf(typeof(ATraktShowsMostPWCRequest<TraktMostPWCShow>)).Should().BeTrue();
        }

        [Fact]
        public void Test_TraktShowsMostCollectedRequest_Has_Valid_UriTemplate()
        {
            var request = new TraktShowsMostCollectedRequest();
            request.UriTemplate.Should().Be("shows/collected{/period}{?extended,page,limit,query,years,genres,languages,countries,runtimes,ratings,certifications,networks,status}");
        }

        [Theory, ClassData(typeof(TraktShowsMostCollectedRequest_TestData))]
        public void Test_TraktShowsMostCollectedRequest_Returns_Valid_UriPathParameters(IDictionary<string, object> values,
                                                                                        IDictionary<string, object> expected)
        {
            values.Should().NotBeNull().And.HaveCount(expected.Count);

            if (expected.Count > 0)
                values.Should().Contain(expected);
        }

        public class TraktShowsMostCollectedRequest_TestData : IEnumerable<object[]>
        {
            private static readonly TraktExtendedInfo _extendedInfo = new TraktExtendedInfo { Full = true };
            private static readonly TraktShowFilter _filter = new TraktShowFilter().WithYears(2005, 2016);
            private static readonly TraktTimePeriod _timePeriod = TraktTimePeriod.Monthly;
            private const int _page = 5;
            private const int _limit = 20;

            private static readonly TraktShowsMostCollectedRequest _request1 = new TraktShowsMostCollectedRequest();

            private static readonly TraktShowsMostCollectedRequest _request2 = new TraktShowsMostCollectedRequest
            {
                ExtendedInfo = _extendedInfo
            };

            private static readonly TraktShowsMostCollectedRequest _request3 = new TraktShowsMostCollectedRequest
            {
                Filter = _filter
            };

            private static readonly TraktShowsMostCollectedRequest _request4 = new TraktShowsMostCollectedRequest
            {
                Period = _timePeriod
            };

            private static readonly TraktShowsMostCollectedRequest _request5 = new TraktShowsMostCollectedRequest
            {
                Page = _page
            };

            private static readonly TraktShowsMostCollectedRequest _request6 = new TraktShowsMostCollectedRequest
            {
                Limit = _limit
            };

            private static readonly TraktShowsMostCollectedRequest _request7 = new TraktShowsMostCollectedRequest
            {
                ExtendedInfo = _extendedInfo,
                Filter = _filter
            };

            private static readonly TraktShowsMostCollectedRequest _request8 = new TraktShowsMostCollectedRequest
            {
                ExtendedInfo = _extendedInfo,
                Period = _timePeriod
            };

            private static readonly TraktShowsMostCollectedRequest _request9 = new TraktShowsMostCollectedRequest
            {
                ExtendedInfo = _extendedInfo,
                Page = _page
            };

            private static readonly TraktShowsMostCollectedRequest _request10 = new TraktShowsMostCollectedRequest
            {
                ExtendedInfo = _extendedInfo,
                Limit = _limit
            };

            private static readonly TraktShowsMostCollectedRequest _request11 = new TraktShowsMostCollectedRequest
            {
                ExtendedInfo = _extendedInfo,
                Page = _page,
                Limit = _limit
            };

            private static readonly TraktShowsMostCollectedRequest _request12 = new TraktShowsMostCollectedRequest
            {
                Filter = _filter,
                Period = _timePeriod
            };

            private static readonly TraktShowsMostCollectedRequest _request13 = new TraktShowsMostCollectedRequest
            {
                Filter = _filter,
                Page = _page
            };

            private static readonly TraktShowsMostCollectedRequest _request14 = new TraktShowsMostCollectedRequest
            {
                Filter = _filter,
                Limit = _limit
            };

            private static readonly TraktShowsMostCollectedRequest _request15 = new TraktShowsMostCollectedRequest
            {
                Filter = _filter,
                Page = _page,
                Limit = _limit
            };

            private static readonly TraktShowsMostCollectedRequest _request16 = new TraktShowsMostCollectedRequest
            {
                Period = _timePeriod,
                Page = _page
            };

            private static readonly TraktShowsMostCollectedRequest _request17 = new TraktShowsMostCollectedRequest
            {
                Period = _timePeriod,
                Limit = _limit
            };

            private static readonly TraktShowsMostCollectedRequest _request18 = new TraktShowsMostCollectedRequest
            {
                Period = _timePeriod,
                Page = _page,
                Limit = _limit
            };

            private static readonly TraktShowsMostCollectedRequest _request19 = new TraktShowsMostCollectedRequest
            {
                Page = _page,
                Limit = _limit
            };

            private static readonly TraktShowsMostCollectedRequest _request20 = new TraktShowsMostCollectedRequest
            {
                ExtendedInfo = _extendedInfo,
                Filter = _filter,
                Period = _timePeriod,
                Page = _page,
                Limit = _limit
            };

            private static readonly List<object[]> _data = new List<object[]>();

            public TraktShowsMostCollectedRequest_TestData()
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
