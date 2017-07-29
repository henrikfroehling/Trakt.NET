namespace TraktApiSharp.Tests.Requests.Movies
{
    using FluentAssertions;
    using System.Collections;
    using System.Collections.Generic;
    using Traits;
    using TraktApiSharp.Enums;
    using TraktApiSharp.Objects.Get.Movies;
    using TraktApiSharp.Requests.Movies;
    using TraktApiSharp.Requests.Parameters;
    using Xunit;

    [Category("Requests.Movies.Lists")]
    public class TraktMoviesMostCollectedRequest_Tests
    {
        [Fact]
        public void Test_TraktMoviesMostCollectedRequest_IsNotAbstract()
        {
            typeof(TraktMoviesMostCollectedRequest).IsAbstract.Should().BeFalse();
        }

        [Fact]
        public void Test_TraktMoviesMostCollectedRequest_IsSealed()
        {
            typeof(TraktMoviesMostCollectedRequest).IsSealed.Should().BeTrue();
        }

        [Fact]
        public void Test_TraktMoviesMostCollectedRequest_Inherits_ATraktMoviesMostPWCRequest_1()
        {
            typeof(TraktMoviesMostCollectedRequest).IsSubclassOf(typeof(ATraktMoviesMostPWCRequest<ITraktMostPWCMovie>)).Should().BeTrue();
        }

        [Fact]
        public void Test_TraktMoviesMostCollectedRequest_Has_Valid_UriTemplate()
        {
            var request = new TraktMoviesMostCollectedRequest();
            request.UriTemplate.Should().Be("movies/collected{/period}{?extended,page,limit,query,years,genres,languages,countries,runtimes,ratings,certifications}");
        }

        [Theory, ClassData(typeof(TraktMoviesMostCollectedRequest_TestData))]
        public void Test_TraktMoviesMostCollectedRequest_Returns_Valid_UriPathParameters(IDictionary<string, object> values,
                                                                                         IDictionary<string, object> expected)
        {
            values.Should().NotBeNull().And.HaveCount(expected.Count);

            if (expected.Count > 0)
                values.Should().Contain(expected);
        }

        public class TraktMoviesMostCollectedRequest_TestData : IEnumerable<object[]>
        {
            private static readonly TraktExtendedInfo _extendedInfo = new TraktExtendedInfo { Full = true };
            private static readonly TraktMovieFilter _filter = new TraktMovieFilter().WithYears(2005, 2016);
            private static readonly TraktTimePeriod _timePeriod = TraktTimePeriod.Monthly;
            private const int _page = 5;
            private const int _limit = 20;

            private static readonly TraktMoviesMostCollectedRequest _request1 = new TraktMoviesMostCollectedRequest();

            private static readonly TraktMoviesMostCollectedRequest _request2 = new TraktMoviesMostCollectedRequest
            {
                ExtendedInfo = _extendedInfo
            };

            private static readonly TraktMoviesMostCollectedRequest _request3 = new TraktMoviesMostCollectedRequest
            {
                Filter = _filter
            };

            private static readonly TraktMoviesMostCollectedRequest _request4 = new TraktMoviesMostCollectedRequest
            {
                Period = _timePeriod
            };

            private static readonly TraktMoviesMostCollectedRequest _request5 = new TraktMoviesMostCollectedRequest
            {
                Page = _page
            };

            private static readonly TraktMoviesMostCollectedRequest _request6 = new TraktMoviesMostCollectedRequest
            {
                Limit = _limit
            };

            private static readonly TraktMoviesMostCollectedRequest _request7 = new TraktMoviesMostCollectedRequest
            {
                ExtendedInfo = _extendedInfo,
                Filter = _filter
            };

            private static readonly TraktMoviesMostCollectedRequest _request8 = new TraktMoviesMostCollectedRequest
            {
                ExtendedInfo = _extendedInfo,
                Period = _timePeriod
            };

            private static readonly TraktMoviesMostCollectedRequest _request9 = new TraktMoviesMostCollectedRequest
            {
                ExtendedInfo = _extendedInfo,
                Page = _page
            };

            private static readonly TraktMoviesMostCollectedRequest _request10 = new TraktMoviesMostCollectedRequest
            {
                ExtendedInfo = _extendedInfo,
                Limit = _limit
            };

            private static readonly TraktMoviesMostCollectedRequest _request11 = new TraktMoviesMostCollectedRequest
            {
                ExtendedInfo = _extendedInfo,
                Page = _page,
                Limit = _limit
            };

            private static readonly TraktMoviesMostCollectedRequest _request12 = new TraktMoviesMostCollectedRequest
            {
                Filter = _filter,
                Period = _timePeriod
            };

            private static readonly TraktMoviesMostCollectedRequest _request13 = new TraktMoviesMostCollectedRequest
            {
                Filter = _filter,
                Page = _page
            };

            private static readonly TraktMoviesMostCollectedRequest _request14 = new TraktMoviesMostCollectedRequest
            {
                Filter = _filter,
                Limit = _limit
            };

            private static readonly TraktMoviesMostCollectedRequest _request15 = new TraktMoviesMostCollectedRequest
            {
                Filter = _filter,
                Page = _page,
                Limit = _limit
            };

            private static readonly TraktMoviesMostCollectedRequest _request16 = new TraktMoviesMostCollectedRequest
            {
                Period = _timePeriod,
                Page = _page
            };

            private static readonly TraktMoviesMostCollectedRequest _request17 = new TraktMoviesMostCollectedRequest
            {
                Period = _timePeriod,
                Limit = _limit
            };

            private static readonly TraktMoviesMostCollectedRequest _request18 = new TraktMoviesMostCollectedRequest
            {
                Period = _timePeriod,
                Page = _page,
                Limit = _limit
            };

            private static readonly TraktMoviesMostCollectedRequest _request19 = new TraktMoviesMostCollectedRequest
            {
                Page = _page,
                Limit = _limit
            };

            private static readonly TraktMoviesMostCollectedRequest _request20 = new TraktMoviesMostCollectedRequest
            {
                ExtendedInfo = _extendedInfo,
                Filter = _filter,
                Period = _timePeriod,
                Page = _page,
                Limit = _limit
            };

            private static readonly List<object[]> _data = new List<object[]>();

            public TraktMoviesMostCollectedRequest_TestData()
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
