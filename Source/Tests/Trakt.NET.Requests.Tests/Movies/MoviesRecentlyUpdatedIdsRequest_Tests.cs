namespace TraktNet.Requests.Tests.Movies
{
    using FluentAssertions;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Extensions;
    using TraktNet.Requests.Base;
    using TraktNet.Requests.Movies;
    using Xunit;

    [TestCategory("Requests.Movies.Lists")]
    public class MoviesRecentlyUpdatedIdsRequest_Tests
    {
        [Fact]
        public void Test_MoviesRecentlyUpdatedIdsRequest_Has_AuthorizationRequirement_NotRequired()
        {
            var request = new MoviesRecentlyUpdatedIdsRequest();
            request.AuthorizationRequirement.Should().Be(AuthorizationRequirement.NotRequired);
        }

        [Fact]
        public void Test_MoviesRecentlyUpdatedIdsRequest_Has_Valid_UriTemplate()
        {
            var request = new MoviesRecentlyUpdatedIdsRequest();
            request.UriTemplate.Should().Be("movies/updates/id{/start_date}{?page,limit}");
        }

        [Theory, ClassData(typeof(MoviesRecentlyUpdatedIdsRequest_TestData))]
        public void Test_MoviesRecentlyUpdatedIdsRequest_Returns_Valid_UriPathParameters(IDictionary<string, object> values,
                                                                                         IDictionary<string, object> expected)
        {
            values.Should().NotBeNull().And.HaveCount(expected.Count);

            if (expected.Count > 0)
                values.Should().Contain(expected);
        }

        public class MoviesRecentlyUpdatedIdsRequest_TestData : IEnumerable<object[]>
        {
            private static readonly DateTime _startDate = DateTime.Now;
            private const int _page = 5;
            private const int _limit = 20;

            private static readonly MoviesRecentlyUpdatedIdsRequest _request1 = new MoviesRecentlyUpdatedIdsRequest();

            private static readonly MoviesRecentlyUpdatedIdsRequest _request2 = new MoviesRecentlyUpdatedIdsRequest
            {
                StartDate = _startDate
            };

            private static readonly MoviesRecentlyUpdatedIdsRequest _request3 = new MoviesRecentlyUpdatedIdsRequest
            {
                Page = _page
            };

            private static readonly MoviesRecentlyUpdatedIdsRequest _request4 = new MoviesRecentlyUpdatedIdsRequest
            {
                Limit = _limit
            };

            private static readonly MoviesRecentlyUpdatedIdsRequest _request5 = new MoviesRecentlyUpdatedIdsRequest
            {
                Page = _page,
                Limit = _limit
            };

            private static readonly MoviesRecentlyUpdatedIdsRequest _request6 = new MoviesRecentlyUpdatedIdsRequest
            {
                StartDate = _startDate,
                Page = _page
            };

            private static readonly MoviesRecentlyUpdatedIdsRequest _request7 = new MoviesRecentlyUpdatedIdsRequest
            {
                StartDate = _startDate,
                Limit = _limit
            };

            private static readonly MoviesRecentlyUpdatedIdsRequest _request8 = new MoviesRecentlyUpdatedIdsRequest
            {
                StartDate = _startDate,
                Page = _page,
                Limit = _limit
            };

            private static readonly List<object[]> _data = new List<object[]>();

            public MoviesRecentlyUpdatedIdsRequest_TestData()
            {
                SetupPathParamters();
            }

            private void SetupPathParamters()
            {
                var strStartDate = _startDate.ToTraktCacheEfficientLongDateTimeString();
                var strPage = _page.ToString();
                var strLimit = _limit.ToString();

                _data.Add(new object[] { _request1.GetUriPathParameters(), new Dictionary<string, object>() });

                _data.Add(new object[] { _request2.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["start_date"] = strStartDate
                    }});

                _data.Add(new object[] { _request3.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["page"] = strPage
                    }});

                _data.Add(new object[] { _request4.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["limit"] = strLimit
                    }});

                _data.Add(new object[] { _request5.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["page"] = strPage,
                        ["limit"] = strLimit
                    }});

                _data.Add(new object[] { _request6.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["start_date"] = strStartDate,
                        ["page"] = strPage
                    }});

                _data.Add(new object[] { _request7.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["start_date"] = strStartDate,
                        ["limit"] = strLimit
                    }});

                _data.Add(new object[] { _request8.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["start_date"] = strStartDate,
                        ["page"] = strPage,
                        ["limit"] = strLimit
                    }});
            }

            public IEnumerator<object[]> GetEnumerator() => _data.GetEnumerator();

            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        }
    }
}
