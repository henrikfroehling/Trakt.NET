﻿namespace TraktNet.Requests.Tests.Movies
{
    using FluentAssertions;
    using System.Collections;
    using System.Collections.Generic;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Requests.Movies;
    using TraktNet.Requests.Parameters;
    using TraktNet.Requests.Parameters.Filter;
    using Xunit;

    [Category("Requests.Movies.Lists")]
    public class MoviesMostAnticipatedRequest_Tests
    {
        [Fact]
        public void Test_MoviesMostAnticipatedRequest_Has_Valid_UriTemplate()
        {
            var request = new MoviesMostAnticipatedRequest();
            request.UriTemplate.Should().Be("movies/anticipated{?extended,page,limit,query,years,genres,languages,countries,runtimes,ratings,certifications}");
        }

        [Theory, ClassData(typeof(MoviesMostAnticipatedRequest_TestData))]
        public void Test_MoviesMostAnticipatedRequest_Returns_Valid_UriPathParameters(IDictionary<string, object> values,
                                                                                      IDictionary<string, object> expected)
        {
            values.Should().NotBeNull().And.HaveCount(expected.Count);

            if (expected.Count > 0)
                values.Should().Contain(expected);
        }

        public class MoviesMostAnticipatedRequest_TestData : IEnumerable<object[]>
        {
            private static readonly TraktExtendedInfo _extendedInfo = new TraktExtendedInfo { Full = true };
            private static readonly ITraktMovieFilter _filter = TraktFilterDirectory.MovieFilter.WithYears(2005, 2016).Build();
            private const int _page = 5;
            private const int _limit = 20;

            private static readonly MoviesMostAnticipatedRequest _request1 = new MoviesMostAnticipatedRequest();

            private static readonly MoviesMostAnticipatedRequest _request2 = new MoviesMostAnticipatedRequest
            {
                ExtendedInfo = _extendedInfo
            };

            private static readonly MoviesMostAnticipatedRequest _request3 = new MoviesMostAnticipatedRequest
            {
                Filter = _filter
            };

            private static readonly MoviesMostAnticipatedRequest _request4 = new MoviesMostAnticipatedRequest
            {
                Page = _page
            };

            private static readonly MoviesMostAnticipatedRequest _request5 = new MoviesMostAnticipatedRequest
            {
                Limit = _limit
            };

            private static readonly MoviesMostAnticipatedRequest _request6 = new MoviesMostAnticipatedRequest
            {
                ExtendedInfo = _extendedInfo,
                Filter = _filter
            };

            private static readonly MoviesMostAnticipatedRequest _request7 = new MoviesMostAnticipatedRequest
            {
                ExtendedInfo = _extendedInfo,
                Page = _page
            };

            private static readonly MoviesMostAnticipatedRequest _request8 = new MoviesMostAnticipatedRequest
            {
                ExtendedInfo = _extendedInfo,
                Limit = _limit
            };

            private static readonly MoviesMostAnticipatedRequest _request9 = new MoviesMostAnticipatedRequest
            {
                ExtendedInfo = _extendedInfo,
                Page = _page,
                Limit = _limit
            };

            private static readonly MoviesMostAnticipatedRequest _request10 = new MoviesMostAnticipatedRequest
            {
                Filter = _filter,
                Page = _page
            };

            private static readonly MoviesMostAnticipatedRequest _request11 = new MoviesMostAnticipatedRequest
            {
                Filter = _filter,
                Limit = _limit
            };

            private static readonly MoviesMostAnticipatedRequest _request12 = new MoviesMostAnticipatedRequest
            {
                Filter = _filter,
                Page = _page,
                Limit = _limit
            };

            private static readonly MoviesMostAnticipatedRequest _request13 = new MoviesMostAnticipatedRequest
            {
                Page = _page,
                Limit = _limit
            };

            private static readonly MoviesMostAnticipatedRequest _request14 = new MoviesMostAnticipatedRequest
            {
                ExtendedInfo = _extendedInfo,
                Filter = _filter,
                Page = _page,
                Limit = _limit
            };

            private static readonly List<object[]> _data = new List<object[]>();

            public MoviesMostAnticipatedRequest_TestData()
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
