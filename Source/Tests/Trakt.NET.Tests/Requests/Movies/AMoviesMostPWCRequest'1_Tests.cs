namespace TraktNet.Tests.Requests.Movies
{
    using FluentAssertions;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using Traits;
    using TraktNet.Enums;
    using TraktNet.Requests.Base;
    using TraktNet.Requests.Movies;
    using TraktNet.Requests.Parameters;
    using Xunit;

    [Category("Requests.Movies.Lists")]
    public class AMoviesMostPWCRequest_1_Tests
    {
        internal class MoviesMostPWCRequestMock : AMoviesMostPWCRequest<int>
        {
            public override string UriTemplate { get { throw new NotImplementedException(); } }
            public override void Validate() => throw new NotImplementedException();
        }

        [Fact]
        public void Test_AMoviesMostPWCRequest_1_Has_AuthorizationRequirement_NotRequired()
        {
            var requestMock = new MoviesMostPWCRequestMock();
            requestMock.AuthorizationRequirement.Should().Be(AuthorizationRequirement.NotRequired);
        }

        [Theory, ClassData(typeof(MoviesMostPWCRequestMock_TestData))]
        public void Test_AMoviesMostPWCRequest_1_Returns_Valid_UriPathParameters(IDictionary<string, object> values,
                                                                                 IDictionary<string, object> expected)
        {
            values.Should().NotBeNull().And.HaveCount(expected.Count);

            if (expected.Count > 0)
                values.Should().Contain(expected);
        }

        public class MoviesMostPWCRequestMock_TestData : IEnumerable<object[]>
        {
            private static readonly TraktExtendedInfo _extendedInfo = new TraktExtendedInfo { Full = true };
            private static readonly TraktMovieFilter _filter = new TraktMovieFilter().WithYears(2005, 2016);
            private static readonly TraktTimePeriod _timePeriod = TraktTimePeriod.Monthly;
            private const int _page = 5;
            private const int _limit = 20;

            private static readonly MoviesMostPWCRequestMock _request1 = new MoviesMostPWCRequestMock();

            private static readonly MoviesMostPWCRequestMock _request2 = new MoviesMostPWCRequestMock
            {
                ExtendedInfo = _extendedInfo
            };

            private static readonly MoviesMostPWCRequestMock _request3 = new MoviesMostPWCRequestMock
            {
                Filter = _filter
            };

            private static readonly MoviesMostPWCRequestMock _request4 = new MoviesMostPWCRequestMock
            {
                Period = _timePeriod
            };

            private static readonly MoviesMostPWCRequestMock _request5 = new MoviesMostPWCRequestMock
            {
                Page = _page
            };

            private static readonly MoviesMostPWCRequestMock _request6 = new MoviesMostPWCRequestMock
            {
                Limit = _limit
            };

            private static readonly MoviesMostPWCRequestMock _request7 = new MoviesMostPWCRequestMock
            {
                ExtendedInfo = _extendedInfo,
                Filter = _filter
            };

            private static readonly MoviesMostPWCRequestMock _request8 = new MoviesMostPWCRequestMock
            {
                ExtendedInfo = _extendedInfo,
                Period = _timePeriod
            };

            private static readonly MoviesMostPWCRequestMock _request9 = new MoviesMostPWCRequestMock
            {
                ExtendedInfo = _extendedInfo,
                Page = _page
            };

            private static readonly MoviesMostPWCRequestMock _request10 = new MoviesMostPWCRequestMock
            {
                ExtendedInfo = _extendedInfo,
                Limit = _limit
            };

            private static readonly MoviesMostPWCRequestMock _request11 = new MoviesMostPWCRequestMock
            {
                ExtendedInfo = _extendedInfo,
                Page = _page,
                Limit = _limit
            };

            private static readonly MoviesMostPWCRequestMock _request12 = new MoviesMostPWCRequestMock
            {
                Filter = _filter,
                Period = _timePeriod
            };

            private static readonly MoviesMostPWCRequestMock _request13 = new MoviesMostPWCRequestMock
            {
                Filter = _filter,
                Page = _page
            };

            private static readonly MoviesMostPWCRequestMock _request14 = new MoviesMostPWCRequestMock
            {
                Filter = _filter,
                Limit = _limit
            };

            private static readonly MoviesMostPWCRequestMock _request15 = new MoviesMostPWCRequestMock
            {
                Filter = _filter,
                Page = _page,
                Limit = _limit
            };

            private static readonly MoviesMostPWCRequestMock _request16 = new MoviesMostPWCRequestMock
            {
                Period = _timePeriod,
                Page = _page
            };

            private static readonly MoviesMostPWCRequestMock _request17 = new MoviesMostPWCRequestMock
            {
                Period = _timePeriod,
                Limit = _limit
            };

            private static readonly MoviesMostPWCRequestMock _request18 = new MoviesMostPWCRequestMock
            {
                Period = _timePeriod,
                Page = _page,
                Limit = _limit
            };

            private static readonly MoviesMostPWCRequestMock _request19 = new MoviesMostPWCRequestMock
            {
                Page = _page,
                Limit = _limit
            };

            private static readonly MoviesMostPWCRequestMock _request20 = new MoviesMostPWCRequestMock
            {
                ExtendedInfo = _extendedInfo,
                Filter = _filter,
                Period = _timePeriod,
                Page = _page,
                Limit = _limit
            };

            private static readonly List<object[]> _data = new List<object[]>();

            public MoviesMostPWCRequestMock_TestData()
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
