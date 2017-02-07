namespace TraktApiSharp.Tests.Requests.Shows
{
    using FluentAssertions;
    using System.Collections;
    using System.Collections.Generic;
    using Traits;
    using TraktApiSharp.Enums;
    using TraktApiSharp.Objects.Get.Shows.Common;
    using TraktApiSharp.Requests.Parameters;
    using TraktApiSharp.Requests.Shows;
    using Xunit;

    [Category("Requests.Shows.Lists")]
    public class TraktShowsMostPlayedRequest_Tests
    {
        [Fact]
        public void Test_TraktShowsMostPlayedRequest_Is_Not_Abstract()
        {
            typeof(TraktShowsMostPlayedRequest).IsAbstract.Should().BeFalse();
        }

        [Fact]
        public void Test_TraktShowsMostPlayedRequest_Is_Sealed()
        {
            typeof(TraktShowsMostPlayedRequest).IsSealed.Should().BeTrue();
        }

        [Fact]
        public void Test_TraktShowsMostPlayedRequest_Inherits_ATraktShowsMostPWCRequest_1()
        {
            typeof(TraktShowsMostPlayedRequest).IsSubclassOf(typeof(ATraktShowsMostPWCRequest<TraktMostPlayedShow>)).Should().BeTrue();
        }

        [Fact]
        public void Test_TraktShowsMostPlayedRequest_Has_Valid_UriTemplate()
        {
            var request = new TraktShowsMostPlayedRequest();
            request.UriTemplate.Should().Be("shows/played{/period}{?extended,page,limit,query,years,genres,languages,countries,runtimes,ratings,certifications,networks,status}");
        }

        [Theory, ClassData(typeof(TraktShowsMostPlayedRequest_TestData))]
        public void Test_TraktShowsMostPlayedRequest_Returns_Valid_UriPathParameters(IDictionary<string, object> values,
                                                                                     IDictionary<string, object> expected)
        {
            values.Should().NotBeNull().And.HaveCount(expected.Count);

            if (expected.Count > 0)
                values.Should().Contain(expected);
        }

        public class TraktShowsMostPlayedRequest_TestData : IEnumerable<object[]>
        {
            private static readonly TraktExtendedInfo _extendedInfo = new TraktExtendedInfo { Full = true };
            private static readonly TraktShowFilter _filter = new TraktShowFilter().WithYears(2005, 2016);
            private static readonly TraktTimePeriod _timePeriod = TraktTimePeriod.Monthly;
            private const int _page = 5;
            private const int _limit = 20;

            private static readonly TraktShowsMostPlayedRequest _request1 = new TraktShowsMostPlayedRequest();

            private static readonly TraktShowsMostPlayedRequest _request2 = new TraktShowsMostPlayedRequest
            {
                ExtendedInfo = _extendedInfo
            };

            private static readonly TraktShowsMostPlayedRequest _request3 = new TraktShowsMostPlayedRequest
            {
                Filter = _filter
            };

            private static readonly TraktShowsMostPlayedRequest _request4 = new TraktShowsMostPlayedRequest
            {
                Period = _timePeriod
            };

            private static readonly TraktShowsMostPlayedRequest _request5 = new TraktShowsMostPlayedRequest
            {
                Page = _page
            };

            private static readonly TraktShowsMostPlayedRequest _request6 = new TraktShowsMostPlayedRequest
            {
                Limit = _limit
            };

            private static readonly TraktShowsMostPlayedRequest _request7 = new TraktShowsMostPlayedRequest
            {
                ExtendedInfo = _extendedInfo,
                Filter = _filter
            };

            private static readonly TraktShowsMostPlayedRequest _request8 = new TraktShowsMostPlayedRequest
            {
                ExtendedInfo = _extendedInfo,
                Period = _timePeriod
            };

            private static readonly TraktShowsMostPlayedRequest _request9 = new TraktShowsMostPlayedRequest
            {
                ExtendedInfo = _extendedInfo,
                Page = _page
            };

            private static readonly TraktShowsMostPlayedRequest _request10 = new TraktShowsMostPlayedRequest
            {
                ExtendedInfo = _extendedInfo,
                Limit = _limit
            };

            private static readonly TraktShowsMostPlayedRequest _request11 = new TraktShowsMostPlayedRequest
            {
                ExtendedInfo = _extendedInfo,
                Page = _page,
                Limit = _limit
            };

            private static readonly TraktShowsMostPlayedRequest _request12 = new TraktShowsMostPlayedRequest
            {
                Filter = _filter,
                Period = _timePeriod
            };

            private static readonly TraktShowsMostPlayedRequest _request13 = new TraktShowsMostPlayedRequest
            {
                Filter = _filter,
                Page = _page
            };

            private static readonly TraktShowsMostPlayedRequest _request14 = new TraktShowsMostPlayedRequest
            {
                Filter = _filter,
                Limit = _limit
            };

            private static readonly TraktShowsMostPlayedRequest _request15 = new TraktShowsMostPlayedRequest
            {
                Filter = _filter,
                Page = _page,
                Limit = _limit
            };

            private static readonly TraktShowsMostPlayedRequest _request16 = new TraktShowsMostPlayedRequest
            {
                Period = _timePeriod,
                Page = _page
            };

            private static readonly TraktShowsMostPlayedRequest _request17 = new TraktShowsMostPlayedRequest
            {
                Period = _timePeriod,
                Limit = _limit
            };

            private static readonly TraktShowsMostPlayedRequest _request18 = new TraktShowsMostPlayedRequest
            {
                Period = _timePeriod,
                Page = _page,
                Limit = _limit
            };

            private static readonly TraktShowsMostPlayedRequest _request19 = new TraktShowsMostPlayedRequest
            {
                Page = _page,
                Limit = _limit
            };

            private static readonly TraktShowsMostPlayedRequest _request20 = new TraktShowsMostPlayedRequest
            {
                ExtendedInfo = _extendedInfo,
                Filter = _filter,
                Period = _timePeriod,
                Page = _page,
                Limit = _limit
            };

            private static readonly List<object[]> _data = new List<object[]>();

            public TraktShowsMostPlayedRequest_TestData()
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
