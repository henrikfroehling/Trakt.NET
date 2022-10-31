namespace TraktNet.Requests.Tests.Shows
{
    using FluentAssertions;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Extensions;
    using TraktNet.Requests.Base;
    using TraktNet.Requests.Shows;
    using Xunit;

    [TestCategory("Requests.Shows.Lists")]
    public class ShowsRecentlyUpdatedIdsRequest_Tests
    {
        [Fact]
        public void Test_ShowsRecentlyUpdatedIdsRequest_Has_AuthorizationRequirement_NotRequired()
        {
            var request = new ShowsRecentlyUpdatedIdsRequest();
            request.AuthorizationRequirement.Should().Be(AuthorizationRequirement.NotRequired);
        }

        [Fact]
        public void Test_ShowsRecentlyUpdatedIdsRequest_Has_Valid_UriTemplate()
        {
            var request = new ShowsRecentlyUpdatedIdsRequest();
            request.UriTemplate.Should().Be("shows/updates/id{/start_date}{?page,limit}");
        }

        [Theory, ClassData(typeof(ShowsRecentlyUpdatedIdsRequest_TestData))]
        public void Test_ShowsRecentlyUpdatedIdsRequest_Returns_Valid_UriPathParameters(IDictionary<string, object> values,
                                                                                        IDictionary<string, object> expected)
        {
            values.Should().NotBeNull().And.HaveCount(expected.Count);

            if (expected.Count > 0)
                values.Should().Contain(expected);
        }

        public class ShowsRecentlyUpdatedIdsRequest_TestData : IEnumerable<object[]>
        {
            private static readonly DateTime _startDate = DateTime.Now;
            private const int _page = 5;
            private const int _limit = 20;

            private static readonly ShowsRecentlyUpdatedIdsRequest _request1 = new ShowsRecentlyUpdatedIdsRequest();

            private static readonly ShowsRecentlyUpdatedIdsRequest _request2 = new ShowsRecentlyUpdatedIdsRequest
            {
                StartDate = _startDate
            };

            private static readonly ShowsRecentlyUpdatedIdsRequest _request3 = new ShowsRecentlyUpdatedIdsRequest
            {
                Page = _page
            };

            private static readonly ShowsRecentlyUpdatedIdsRequest _request4 = new ShowsRecentlyUpdatedIdsRequest
            {
                Limit = _limit
            };

            private static readonly ShowsRecentlyUpdatedIdsRequest _request5 = new ShowsRecentlyUpdatedIdsRequest
            {
                Page = _page,
                Limit = _limit
            };

            private static readonly ShowsRecentlyUpdatedIdsRequest _request6 = new ShowsRecentlyUpdatedIdsRequest
            {
                StartDate = _startDate,
                Page = _page
            };

            private static readonly ShowsRecentlyUpdatedIdsRequest _request7 = new ShowsRecentlyUpdatedIdsRequest
            {
                StartDate = _startDate,
                Limit = _limit
            };

            private static readonly ShowsRecentlyUpdatedIdsRequest _request8 = new ShowsRecentlyUpdatedIdsRequest
            {
                StartDate = _startDate,
                Page = _page,
                Limit = _limit
            };

            private static readonly List<object[]> _data = new List<object[]>();

            public ShowsRecentlyUpdatedIdsRequest_TestData()
            {
                SetupPathParamters();
            }

            private void SetupPathParamters()
            {
                var strStartDate = _startDate.ToTraktDateString();
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
