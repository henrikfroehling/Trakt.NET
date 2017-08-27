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
    public class MoviesPopularRequest_Tests
    {
        [Fact]
        public void Test_MoviesPopularRequest_IsNotAbstract()
        {
            typeof(MoviesPopularRequest).IsAbstract.Should().BeFalse();
        }

        [Fact]
        public void Test_MoviesPopularRequest_IsSealed()
        {
            typeof(MoviesPopularRequest).IsSealed.Should().BeTrue();
        }

        [Fact]
        public void Test_MoviesPopularRequest_Inherits_AMoviesRequest_1()
        {
            typeof(MoviesPopularRequest).IsSubclassOf(typeof(AMoviesRequest<ITraktMovie>)).Should().BeTrue();
        }

        [Fact]
        public void Test_MoviesPopularRequest_Has_Valid_UriTemplate()
        {
            var request = new MoviesPopularRequest();
            request.UriTemplate.Should().Be("movies/popular{?extended,page,limit,query,years,genres,languages,countries,runtimes,ratings,certifications}");
        }

        [Theory, ClassData(typeof(MoviesPopularRequest_TestData))]
        public void Test_MoviesPopularRequest_Returns_Valid_UriPathParameters(IDictionary<string, object> values,
                                                                              IDictionary<string, object> expected)
        {
            values.Should().NotBeNull().And.HaveCount(expected.Count);

            if (expected.Count > 0)
                values.Should().Contain(expected);
        }

        public class MoviesPopularRequest_TestData : IEnumerable<object[]>
        {
            private static readonly TraktExtendedInfo _extendedInfo = new TraktExtendedInfo { Full = true };
            private static readonly TraktMovieFilter _filter = new TraktMovieFilter().WithYears(2005, 2016);
            private const int _page = 5;
            private const int _limit = 20;

            private static readonly MoviesPopularRequest _request1 = new MoviesPopularRequest();

            private static readonly MoviesPopularRequest _request2 = new MoviesPopularRequest
            {
                ExtendedInfo = _extendedInfo
            };

            private static readonly MoviesPopularRequest _request3 = new MoviesPopularRequest
            {
                Filter = _filter
            };

            private static readonly MoviesPopularRequest _request4 = new MoviesPopularRequest
            {
                Page = _page
            };

            private static readonly MoviesPopularRequest _request5 = new MoviesPopularRequest
            {
                Limit = _limit
            };

            private static readonly MoviesPopularRequest _request6 = new MoviesPopularRequest
            {
                ExtendedInfo = _extendedInfo,
                Filter = _filter
            };

            private static readonly MoviesPopularRequest _request7 = new MoviesPopularRequest
            {
                ExtendedInfo = _extendedInfo,
                Page = _page
            };

            private static readonly MoviesPopularRequest _request8 = new MoviesPopularRequest
            {
                ExtendedInfo = _extendedInfo,
                Limit = _limit
            };

            private static readonly MoviesPopularRequest _request9 = new MoviesPopularRequest
            {
                ExtendedInfo = _extendedInfo,
                Page = _page,
                Limit = _limit
            };

            private static readonly MoviesPopularRequest _request10 = new MoviesPopularRequest
            {
                Filter = _filter,
                Page = _page
            };

            private static readonly MoviesPopularRequest _request11 = new MoviesPopularRequest
            {
                Filter = _filter,
                Limit = _limit
            };

            private static readonly MoviesPopularRequest _request12 = new MoviesPopularRequest
            {
                Filter = _filter,
                Page = _page,
                Limit = _limit
            };

            private static readonly MoviesPopularRequest _request13 = new MoviesPopularRequest
            {
                Page = _page,
                Limit = _limit
            };

            private static readonly MoviesPopularRequest _request14 = new MoviesPopularRequest
            {
                ExtendedInfo = _extendedInfo,
                Filter = _filter,
                Page = _page,
                Limit = _limit
            };

            private static readonly List<object[]> _data = new List<object[]>();

            public MoviesPopularRequest_TestData()
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
