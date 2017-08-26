namespace TraktApiSharp.Tests.Requests.Movies
{
    using FluentAssertions;
    using System.Collections;
    using System.Collections.Generic;
    using Traits;
    using TraktApiSharp.Objects.Get.Movies;
    using TraktApiSharp.Requests.Movies;
    using TraktApiSharp.Requests.Parameters;
    using Xunit;

    [Category("Requests.Movies.Lists")]
    public class TraktMoviesTrendingRequest_Tests
    {
        [Fact]
        public void Test_TraktMoviesTrendingRequest_IsNotAbstract()
        {
            typeof(TraktMoviesTrendingRequest).IsAbstract.Should().BeFalse();
        }

        [Fact]
        public void Test_TraktMoviesTrendingRequest_IsSealed()
        {
            typeof(TraktMoviesTrendingRequest).IsSealed.Should().BeTrue();
        }

        [Fact]
        public void Test_TraktMoviesTrendingRequest_Inherits_ATraktMoviesRequest_1()
        {
            typeof(TraktMoviesTrendingRequest).IsSubclassOf(typeof(AMoviesRequest<ITraktTrendingMovie>)).Should().BeTrue();
        }

        [Fact]
        public void Test_TraktMoviesTrendingRequest_Has_Valid_UriTemplate()
        {
            var request = new TraktMoviesTrendingRequest();
            request.UriTemplate.Should().Be("movies/trending{?extended,page,limit,query,years,genres,languages,countries,runtimes,ratings,certifications}");
        }

        [Theory, ClassData(typeof(TraktMoviesTrendingRequest_TestData))]
        public void Test_TraktMoviesTrendingRequest_Returns_Valid_UriPathParameters(IDictionary<string, object> values,
                                                                                    IDictionary<string, object> expected)
        {
            values.Should().NotBeNull().And.HaveCount(expected.Count);

            if (expected.Count > 0)
                values.Should().Contain(expected);
        }

        public class TraktMoviesTrendingRequest_TestData : IEnumerable<object[]>
        {
            private static readonly TraktExtendedInfo _extendedInfo = new TraktExtendedInfo { Full = true };
            private static readonly TraktMovieFilter _filter = new TraktMovieFilter().WithYears(2005, 2016);
            private const int _page = 5;
            private const int _limit = 20;

            private static readonly TraktMoviesTrendingRequest _request1 = new TraktMoviesTrendingRequest();

            private static readonly TraktMoviesTrendingRequest _request2 = new TraktMoviesTrendingRequest
            {
                ExtendedInfo = _extendedInfo
            };

            private static readonly TraktMoviesTrendingRequest _request3 = new TraktMoviesTrendingRequest
            {
                Filter = _filter
            };

            private static readonly TraktMoviesTrendingRequest _request4 = new TraktMoviesTrendingRequest
            {
                Page = _page
            };

            private static readonly TraktMoviesTrendingRequest _request5 = new TraktMoviesTrendingRequest
            {
                Limit = _limit
            };

            private static readonly TraktMoviesTrendingRequest _request6 = new TraktMoviesTrendingRequest
            {
                ExtendedInfo = _extendedInfo,
                Filter = _filter
            };

            private static readonly TraktMoviesTrendingRequest _request7 = new TraktMoviesTrendingRequest
            {
                ExtendedInfo = _extendedInfo,
                Page = _page
            };

            private static readonly TraktMoviesTrendingRequest _request8 = new TraktMoviesTrendingRequest
            {
                ExtendedInfo = _extendedInfo,
                Limit = _limit
            };

            private static readonly TraktMoviesTrendingRequest _request9 = new TraktMoviesTrendingRequest
            {
                ExtendedInfo = _extendedInfo,
                Page = _page,
                Limit = _limit
            };

            private static readonly TraktMoviesTrendingRequest _request10 = new TraktMoviesTrendingRequest
            {
                Filter = _filter,
                Page = _page
            };

            private static readonly TraktMoviesTrendingRequest _request11 = new TraktMoviesTrendingRequest
            {
                Filter = _filter,
                Limit = _limit
            };

            private static readonly TraktMoviesTrendingRequest _request12 = new TraktMoviesTrendingRequest
            {
                Filter = _filter,
                Page = _page,
                Limit = _limit
            };

            private static readonly TraktMoviesTrendingRequest _request13 = new TraktMoviesTrendingRequest
            {
                Page = _page,
                Limit = _limit
            };

            private static readonly TraktMoviesTrendingRequest _request14 = new TraktMoviesTrendingRequest
            {
                ExtendedInfo = _extendedInfo,
                Filter = _filter,
                Page = _page,
                Limit = _limit
            };

            private static readonly List<object[]> _data = new List<object[]>();

            public TraktMoviesTrendingRequest_TestData()
            {
                SetupPathParamters();
            }

            private void SetupPathParamters()
            {
                var strExtendedInfo = _extendedInfo.ToString();
                var filterParameters = _filter.GetParameters();
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
                        ["page"] = strPage
                    }});

                _data.Add(new object[] { _request5.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["limit"] = strLimit
                    }});

                _data.Add(new object[] { _request6.GetUriPathParameters(), new Dictionary<string, object>(filterParameters)
                    {
                        ["extended"] = strExtendedInfo
                    }});

                _data.Add(new object[] { _request7.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["extended"] = strExtendedInfo,
                        ["page"] = strPage
                    }});

                _data.Add(new object[] { _request8.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["extended"] = strExtendedInfo,
                        ["limit"] = strLimit
                    }});

                _data.Add(new object[] { _request9.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["extended"] = strExtendedInfo,
                        ["page"] = strPage,
                        ["limit"] = strLimit
                    }});

                _data.Add(new object[] { _request10.GetUriPathParameters(), new Dictionary<string, object>(filterParameters)
                    {
                        ["page"] = strPage
                    }});

                _data.Add(new object[] { _request11.GetUriPathParameters(), new Dictionary<string, object>(filterParameters)
                    {
                        ["limit"] = strLimit
                    }});

                _data.Add(new object[] { _request12.GetUriPathParameters(), new Dictionary<string, object>(filterParameters)
                    {
                        ["page"] = strPage,
                        ["limit"] = strLimit
                    }});

                _data.Add(new object[] { _request13.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["page"] = strPage,
                        ["limit"] = strLimit
                    }});

                _data.Add(new object[] { _request14.GetUriPathParameters(), new Dictionary<string, object>(filterParameters)
                    {
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
