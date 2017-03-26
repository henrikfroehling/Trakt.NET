namespace TraktApiSharp.Tests.Requests.Movies
{
    using FluentAssertions;
    using System.Collections;
    using System.Collections.Generic;
    using Traits;
    using TraktApiSharp.Enums;
    using TraktApiSharp.Objects.Get.Movies.Implementations;
    using TraktApiSharp.Requests.Movies;
    using TraktApiSharp.Requests.Parameters;
    using Xunit;

    [Category("Requests.Movies.Lists")]
    public class TraktMoviesMostPlayedRequest_Tests
    {
        [Fact]
        public void Test_TraktMoviesMostPlayedRequest_IsNotAbstract()
        {
            typeof(TraktMoviesMostPlayedRequest).IsAbstract.Should().BeFalse();
        }

        [Fact]
        public void Test_TraktMoviesMostPlayedRequest_IsSealed()
        {
            typeof(TraktMoviesMostPlayedRequest).IsSealed.Should().BeTrue();
        }

        [Fact]
        public void Test_TraktMoviesMostPlayedRequest_Inherits_ATraktMoviesMostPWCRequest_1()
        {
            typeof(TraktMoviesMostPlayedRequest).IsSubclassOf(typeof(ATraktMoviesMostPWCRequest<TraktMostPWCMovie>)).Should().BeTrue();
        }

        [Fact]
        public void Test_TraktMoviesMostPlayedRequest_Has_Valid_UriTemplate()
        {
            var request = new TraktMoviesMostPlayedRequest();
            request.UriTemplate.Should().Be("movies/played{/period}{?extended,page,limit,query,years,genres,languages,countries,runtimes,ratings,certifications}");
        }

        [Theory, ClassData(typeof(TraktMoviesMostPlayedRequest_TestData))]
        public void Test_TraktMoviesMostPlayedRequest_Returns_Valid_UriPathParameters(IDictionary<string, object> values,
                                                                                      IDictionary<string, object> expected)
        {
            values.Should().NotBeNull().And.HaveCount(expected.Count);

            if (expected.Count > 0)
                values.Should().Contain(expected);
        }

        public class TraktMoviesMostPlayedRequest_TestData : IEnumerable<object[]>
        {
            private static readonly TraktExtendedInfo _extendedInfo = new TraktExtendedInfo { Full = true };
            private static readonly TraktMovieFilter _filter = new TraktMovieFilter().WithYears(2005, 2016);
            private static readonly TraktTimePeriod _timePeriod = TraktTimePeriod.Monthly;
            private const int _page = 5;
            private const int _limit = 20;

            private static readonly TraktMoviesMostPlayedRequest _request1 = new TraktMoviesMostPlayedRequest();

            private static readonly TraktMoviesMostPlayedRequest _request2 = new TraktMoviesMostPlayedRequest
            {
                ExtendedInfo = _extendedInfo
            };

            private static readonly TraktMoviesMostPlayedRequest _request3 = new TraktMoviesMostPlayedRequest
            {
                Filter = _filter
            };

            private static readonly TraktMoviesMostPlayedRequest _request4 = new TraktMoviesMostPlayedRequest
            {
                Period = _timePeriod
            };

            private static readonly TraktMoviesMostPlayedRequest _request5 = new TraktMoviesMostPlayedRequest
            {
                Page = _page
            };

            private static readonly TraktMoviesMostPlayedRequest _request6 = new TraktMoviesMostPlayedRequest
            {
                Limit = _limit
            };

            private static readonly TraktMoviesMostPlayedRequest _request7 = new TraktMoviesMostPlayedRequest
            {
                ExtendedInfo = _extendedInfo,
                Filter = _filter
            };

            private static readonly TraktMoviesMostPlayedRequest _request8 = new TraktMoviesMostPlayedRequest
            {
                ExtendedInfo = _extendedInfo,
                Period = _timePeriod
            };

            private static readonly TraktMoviesMostPlayedRequest _request9 = new TraktMoviesMostPlayedRequest
            {
                ExtendedInfo = _extendedInfo,
                Page = _page
            };

            private static readonly TraktMoviesMostPlayedRequest _request10 = new TraktMoviesMostPlayedRequest
            {
                ExtendedInfo = _extendedInfo,
                Limit = _limit
            };

            private static readonly TraktMoviesMostPlayedRequest _request11 = new TraktMoviesMostPlayedRequest
            {
                ExtendedInfo = _extendedInfo,
                Page = _page,
                Limit = _limit
            };

            private static readonly TraktMoviesMostPlayedRequest _request12 = new TraktMoviesMostPlayedRequest
            {
                Filter = _filter,
                Period = _timePeriod
            };

            private static readonly TraktMoviesMostPlayedRequest _request13 = new TraktMoviesMostPlayedRequest
            {
                Filter = _filter,
                Page = _page
            };

            private static readonly TraktMoviesMostPlayedRequest _request14 = new TraktMoviesMostPlayedRequest
            {
                Filter = _filter,
                Limit = _limit
            };

            private static readonly TraktMoviesMostPlayedRequest _request15 = new TraktMoviesMostPlayedRequest
            {
                Filter = _filter,
                Page = _page,
                Limit = _limit
            };

            private static readonly TraktMoviesMostPlayedRequest _request16 = new TraktMoviesMostPlayedRequest
            {
                Period = _timePeriod,
                Page = _page
            };

            private static readonly TraktMoviesMostPlayedRequest _request17 = new TraktMoviesMostPlayedRequest
            {
                Period = _timePeriod,
                Limit = _limit
            };

            private static readonly TraktMoviesMostPlayedRequest _request18 = new TraktMoviesMostPlayedRequest
            {
                Period = _timePeriod,
                Page = _page,
                Limit = _limit
            };

            private static readonly TraktMoviesMostPlayedRequest _request19 = new TraktMoviesMostPlayedRequest
            {
                Page = _page,
                Limit = _limit
            };

            private static readonly TraktMoviesMostPlayedRequest _request20 = new TraktMoviesMostPlayedRequest
            {
                ExtendedInfo = _extendedInfo,
                Filter = _filter,
                Period = _timePeriod,
                Page = _page,
                Limit = _limit
            };

            private static readonly List<object[]> _data = new List<object[]>();

            public TraktMoviesMostPlayedRequest_TestData()
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
