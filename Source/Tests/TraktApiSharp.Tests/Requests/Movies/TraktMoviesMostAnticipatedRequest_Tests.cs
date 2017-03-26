namespace TraktApiSharp.Tests.Requests.Movies
{
    using FluentAssertions;
    using System.Collections;
    using System.Collections.Generic;
    using Traits;
    using TraktApiSharp.Objects.Get.Movies.Implementations;
    using TraktApiSharp.Requests.Movies;
    using TraktApiSharp.Requests.Parameters;
    using Xunit;

    [Category("Requests.Movies.Lists")]
    public class TraktMoviesMostAnticipatedRequest_Tests
    {
        [Fact]
        public void Test_TraktMoviesMostAnticipatedRequest_IsNotAbstract()
        {
            typeof(TraktMoviesMostAnticipatedRequest).IsAbstract.Should().BeFalse();
        }

        [Fact]
        public void Test_TraktMoviesMostAnticipatedRequest_IsSealed()
        {
            typeof(TraktMoviesMostAnticipatedRequest).IsSealed.Should().BeTrue();
        }

        [Fact]
        public void Test_TraktMoviesMostAnticipatedRequest_Inherits_ATraktMoviesRequest_1()
        {
            typeof(TraktMoviesMostAnticipatedRequest).IsSubclassOf(typeof(ATraktMoviesRequest<TraktMostAnticipatedMovie>)).Should().BeTrue();
        }

        [Fact]
        public void Test_TraktMoviesMostAnticipatedRequest_Has_Valid_UriTemplate()
        {
            var request = new TraktMoviesMostAnticipatedRequest();
            request.UriTemplate.Should().Be("movies/anticipated{?extended,page,limit,query,years,genres,languages,countries,runtimes,ratings,certifications}");
        }

        [Theory, ClassData(typeof(TraktMoviesMostAnticipatedRequest_TestData))]
        public void Test_TraktMoviesMostAnticipatedRequest_Returns_Valid_UriPathParameters(IDictionary<string, object> values,
                                                                                           IDictionary<string, object> expected)
        {
            values.Should().NotBeNull().And.HaveCount(expected.Count);

            if (expected.Count > 0)
                values.Should().Contain(expected);
        }

        public class TraktMoviesMostAnticipatedRequest_TestData : IEnumerable<object[]>
        {
            private static readonly TraktExtendedInfo _extendedInfo = new TraktExtendedInfo { Full = true };
            private static readonly TraktMovieFilter _filter = new TraktMovieFilter().WithYears(2005, 2016);
            private const int _page = 5;
            private const int _limit = 20;

            private static readonly TraktMoviesMostAnticipatedRequest _request1 = new TraktMoviesMostAnticipatedRequest();

            private static readonly TraktMoviesMostAnticipatedRequest _request2 = new TraktMoviesMostAnticipatedRequest
            {
                ExtendedInfo = _extendedInfo
            };

            private static readonly TraktMoviesMostAnticipatedRequest _request3 = new TraktMoviesMostAnticipatedRequest
            {
                Filter = _filter
            };

            private static readonly TraktMoviesMostAnticipatedRequest _request4 = new TraktMoviesMostAnticipatedRequest
            {
                Page = _page
            };

            private static readonly TraktMoviesMostAnticipatedRequest _request5 = new TraktMoviesMostAnticipatedRequest
            {
                Limit = _limit
            };

            private static readonly TraktMoviesMostAnticipatedRequest _request6 = new TraktMoviesMostAnticipatedRequest
            {
                ExtendedInfo = _extendedInfo,
                Filter = _filter
            };

            private static readonly TraktMoviesMostAnticipatedRequest _request7 = new TraktMoviesMostAnticipatedRequest
            {
                ExtendedInfo = _extendedInfo,
                Page = _page
            };

            private static readonly TraktMoviesMostAnticipatedRequest _request8 = new TraktMoviesMostAnticipatedRequest
            {
                ExtendedInfo = _extendedInfo,
                Limit = _limit
            };

            private static readonly TraktMoviesMostAnticipatedRequest _request9 = new TraktMoviesMostAnticipatedRequest
            {
                ExtendedInfo = _extendedInfo,
                Page = _page,
                Limit = _limit
            };

            private static readonly TraktMoviesMostAnticipatedRequest _request10 = new TraktMoviesMostAnticipatedRequest
            {
                Filter = _filter,
                Page = _page
            };

            private static readonly TraktMoviesMostAnticipatedRequest _request11 = new TraktMoviesMostAnticipatedRequest
            {
                Filter = _filter,
                Limit = _limit
            };

            private static readonly TraktMoviesMostAnticipatedRequest _request12 = new TraktMoviesMostAnticipatedRequest
            {
                Filter = _filter,
                Page = _page,
                Limit = _limit
            };

            private static readonly TraktMoviesMostAnticipatedRequest _request13 = new TraktMoviesMostAnticipatedRequest
            {
                Page = _page,
                Limit = _limit
            };

            private static readonly TraktMoviesMostAnticipatedRequest _request14 = new TraktMoviesMostAnticipatedRequest
            {
                ExtendedInfo = _extendedInfo,
                Filter = _filter,
                Page = _page,
                Limit = _limit
            };

            private static readonly List<object[]> _data = new List<object[]>();

            public TraktMoviesMostAnticipatedRequest_TestData()
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
