namespace TraktApiSharp.Tests.Requests.Movies
{
    using FluentAssertions;
    using System.Collections;
    using System.Collections.Generic;
    using Traits;
    using TraktApiSharp.Enums;
    using TraktApiSharp.Objects.Get.Movies;
    using TraktApiSharp.Objects.Get.Movies.Implementations;
    using TraktApiSharp.Requests.Movies;
    using TraktApiSharp.Requests.Parameters;
    using Xunit;

    [Category("Requests.Movies.Lists")]
    public class TraktMoviesMostWatchedRequest_Tests
    {
        [Fact]
        public void Test_TraktMoviesMostWatchedRequest_IsNotAbstract()
        {
            typeof(TraktMoviesMostWatchedRequest).IsAbstract.Should().BeFalse();
        }

        [Fact]
        public void Test_TraktMoviesMostWatchedRequest_IsSealed()
        {
            typeof(TraktMoviesMostWatchedRequest).IsSealed.Should().BeTrue();
        }

        [Fact]
        public void Test_TraktMoviesMostWatchedRequest_Inherits_ATraktMoviesMostPWCRequest_1()
        {
            typeof(TraktMoviesMostWatchedRequest).IsSubclassOf(typeof(ATraktMoviesMostPWCRequest<TraktMostPWCMovie>)).Should().BeTrue();
        }

        [Fact]
        public void Test_TraktMoviesMostWatchedRequest_Has_Valid_UriTemplate()
        {
            var request = new TraktMoviesMostWatchedRequest();
            request.UriTemplate.Should().Be("movies/watched{/period}{?extended,page,limit,query,years,genres,languages,countries,runtimes,ratings,certifications}");
        }

        [Theory, ClassData(typeof(TraktMoviesMostWatchedRequest_TestData))]
        public void Test_TraktMoviesMostWatchedRequest_Returns_Valid_UriPathParameters(IDictionary<string, object> values,
                                                                                       IDictionary<string, object> expected)
        {
            values.Should().NotBeNull().And.HaveCount(expected.Count);

            if (expected.Count > 0)
                values.Should().Contain(expected);
        }

        public class TraktMoviesMostWatchedRequest_TestData : IEnumerable<object[]>
        {
            private static readonly TraktExtendedInfo _extendedInfo = new TraktExtendedInfo { Full = true };
            private static readonly TraktMovieFilter _filter = new TraktMovieFilter().WithYears(2005, 2016);
            private static readonly TraktTimePeriod _timePeriod = TraktTimePeriod.Monthly;
            private const int _page = 5;
            private const int _limit = 20;

            private static readonly TraktMoviesMostWatchedRequest _request1 = new TraktMoviesMostWatchedRequest();

            private static readonly TraktMoviesMostWatchedRequest _request2 = new TraktMoviesMostWatchedRequest
            {
                ExtendedInfo = _extendedInfo
            };

            private static readonly TraktMoviesMostWatchedRequest _request3 = new TraktMoviesMostWatchedRequest
            {
                Filter = _filter
            };

            private static readonly TraktMoviesMostWatchedRequest _request4 = new TraktMoviesMostWatchedRequest
            {
                Period = _timePeriod
            };

            private static readonly TraktMoviesMostWatchedRequest _request5 = new TraktMoviesMostWatchedRequest
            {
                Page = _page
            };

            private static readonly TraktMoviesMostWatchedRequest _request6 = new TraktMoviesMostWatchedRequest
            {
                Limit = _limit
            };

            private static readonly TraktMoviesMostWatchedRequest _request7 = new TraktMoviesMostWatchedRequest
            {
                ExtendedInfo = _extendedInfo,
                Filter = _filter
            };

            private static readonly TraktMoviesMostWatchedRequest _request8 = new TraktMoviesMostWatchedRequest
            {
                ExtendedInfo = _extendedInfo,
                Period = _timePeriod
            };

            private static readonly TraktMoviesMostWatchedRequest _request9 = new TraktMoviesMostWatchedRequest
            {
                ExtendedInfo = _extendedInfo,
                Page = _page
            };

            private static readonly TraktMoviesMostWatchedRequest _request10 = new TraktMoviesMostWatchedRequest
            {
                ExtendedInfo = _extendedInfo,
                Limit = _limit
            };

            private static readonly TraktMoviesMostWatchedRequest _request11 = new TraktMoviesMostWatchedRequest
            {
                ExtendedInfo = _extendedInfo,
                Page = _page,
                Limit = _limit
            };

            private static readonly TraktMoviesMostWatchedRequest _request12 = new TraktMoviesMostWatchedRequest
            {
                Filter = _filter,
                Period = _timePeriod
            };

            private static readonly TraktMoviesMostWatchedRequest _request13 = new TraktMoviesMostWatchedRequest
            {
                Filter = _filter,
                Page = _page
            };

            private static readonly TraktMoviesMostWatchedRequest _request14 = new TraktMoviesMostWatchedRequest
            {
                Filter = _filter,
                Limit = _limit
            };

            private static readonly TraktMoviesMostWatchedRequest _request15 = new TraktMoviesMostWatchedRequest
            {
                Filter = _filter,
                Page = _page,
                Limit = _limit
            };

            private static readonly TraktMoviesMostWatchedRequest _request16 = new TraktMoviesMostWatchedRequest
            {
                Period = _timePeriod,
                Page = _page
            };

            private static readonly TraktMoviesMostWatchedRequest _request17 = new TraktMoviesMostWatchedRequest
            {
                Period = _timePeriod,
                Limit = _limit
            };

            private static readonly TraktMoviesMostWatchedRequest _request18 = new TraktMoviesMostWatchedRequest
            {
                Period = _timePeriod,
                Page = _page,
                Limit = _limit
            };

            private static readonly TraktMoviesMostWatchedRequest _request19 = new TraktMoviesMostWatchedRequest
            {
                Page = _page,
                Limit = _limit
            };

            private static readonly TraktMoviesMostWatchedRequest _request20 = new TraktMoviesMostWatchedRequest
            {
                ExtendedInfo = _extendedInfo,
                Filter = _filter,
                Period = _timePeriod,
                Page = _page,
                Limit = _limit
            };

            private static readonly List<object[]> _data = new List<object[]>();

            public TraktMoviesMostWatchedRequest_TestData()
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
