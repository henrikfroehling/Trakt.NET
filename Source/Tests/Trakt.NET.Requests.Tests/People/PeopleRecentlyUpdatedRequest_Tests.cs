namespace TraktNet.Requests.Tests.People
{
    using FluentAssertions;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Extensions;
    using TraktNet.Parameters;
    using TraktNet.Requests.Base;
    using TraktNet.Requests.People;
    using Xunit;

    [TestCategory("Requests.People.Lists")]
    public class PeopleRecentlyUpdatedRequest_Tests
    {
        [Fact]
        public void Test_PeopleRecentlyUpdatedRequest_Has_AuthorizationRequirement_NotRequired()
        {
            var requestMock = new PeopleRecentlyUpdatedRequest();
            requestMock.AuthorizationRequirement.Should().Be(AuthorizationRequirement.NotRequired);
        }

        [Fact]
        public void Test_PeopleRecentlyUpdatedRequest_Has_Valid_UriTemplate()
        {
            var request = new PeopleRecentlyUpdatedRequest();
            request.UriTemplate.Should().Be("people/updates{/start_date}{?extended,page,limit}");
        }

        [Theory, ClassData(typeof(PeopleRecentlyUpdatedRequest_TestData))]
        public void Test_PeopleRecentlyUpdatedRequest_Returns_Valid_UriPathParameters(IDictionary<string, object> values,
                                                                                      IDictionary<string, object> expected)
        {
            values.Should().NotBeNull().And.HaveCount(expected.Count);

            if (expected.Count > 0)
                values.Should().Contain(expected);
        }

        public class PeopleRecentlyUpdatedRequest_TestData : IEnumerable<object[]>
        {
            private static readonly DateTime _startDate = DateTime.Now;
            private static readonly TraktExtendedInfo _extendedInfo = new TraktExtendedInfo { Full = true };
            private const int _page = 5;
            private const int _limit = 20;

            private static readonly PeopleRecentlyUpdatedRequest _request1 = new PeopleRecentlyUpdatedRequest();

            private static readonly PeopleRecentlyUpdatedRequest _request2 = new PeopleRecentlyUpdatedRequest
            {
                StartDate = _startDate
            };

            private static readonly PeopleRecentlyUpdatedRequest _request3 = new PeopleRecentlyUpdatedRequest
            {
                ExtendedInfo = _extendedInfo
            };

            private static readonly PeopleRecentlyUpdatedRequest _request4 = new PeopleRecentlyUpdatedRequest
            {
                Page = _page
            };

            private static readonly PeopleRecentlyUpdatedRequest _request5 = new PeopleRecentlyUpdatedRequest
            {
                Limit = _limit
            };

            private static readonly PeopleRecentlyUpdatedRequest _request6 = new PeopleRecentlyUpdatedRequest
            {
                StartDate = _startDate,
                ExtendedInfo = _extendedInfo
            };

            private static readonly PeopleRecentlyUpdatedRequest _request7 = new PeopleRecentlyUpdatedRequest
            {
                StartDate = _startDate,
                Page = _page
            };

            private static readonly PeopleRecentlyUpdatedRequest _request8 = new PeopleRecentlyUpdatedRequest
            {
                StartDate = _startDate,
                Limit = _limit
            };

            private static readonly PeopleRecentlyUpdatedRequest _request9 = new PeopleRecentlyUpdatedRequest
            {
                StartDate = _startDate,
                Page = _page,
                Limit = _limit
            };

            private static readonly PeopleRecentlyUpdatedRequest _request10 = new PeopleRecentlyUpdatedRequest
            {
                ExtendedInfo = _extendedInfo,
                Page = _page
            };

            private static readonly PeopleRecentlyUpdatedRequest _request11 = new PeopleRecentlyUpdatedRequest
            {
                ExtendedInfo = _extendedInfo,
                Limit = _limit
            };

            private static readonly PeopleRecentlyUpdatedRequest _request12 = new PeopleRecentlyUpdatedRequest
            {
                ExtendedInfo = _extendedInfo,
                Page = _page,
                Limit = _limit
            };

            private static readonly PeopleRecentlyUpdatedRequest _request13 = new PeopleRecentlyUpdatedRequest
            {
                Page = _page,
                Limit = _limit
            };

            private static readonly PeopleRecentlyUpdatedRequest _request14 = new PeopleRecentlyUpdatedRequest
            {
                StartDate = _startDate,
                ExtendedInfo = _extendedInfo,
                Page = _page,
                Limit = _limit
            };

            private static readonly List<object[]> _data = new List<object[]>();

            public PeopleRecentlyUpdatedRequest_TestData()
            {
                SetupPathParamters();
            }

            private void SetupPathParamters()
            {
                var strStartDate = _startDate.ToTraktDateString();
                var strExtendedInfo = _extendedInfo.ToString();
                var strPage = _page.ToString();
                var strLimit = _limit.ToString();

                _data.Add(new object[] { _request1.GetUriPathParameters(), new Dictionary<string, object>() });

                _data.Add(new object[] { _request2.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["start_date"] = strStartDate
                    }});

                _data.Add(new object[] { _request3.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["extended"] = strExtendedInfo
                    }});

                _data.Add(new object[] { _request4.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["page"] = strPage
                    }});

                _data.Add(new object[] { _request5.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["limit"] = strLimit
                    }});

                _data.Add(new object[] { _request6.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["start_date"] = strStartDate,
                        ["extended"] = strExtendedInfo
                    }});

                _data.Add(new object[] { _request7.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["start_date"] = strStartDate,
                        ["page"] = strPage
                    }});

                _data.Add(new object[] { _request8.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["start_date"] = strStartDate,
                        ["limit"] = strLimit
                    }});

                _data.Add(new object[] { _request9.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["start_date"] = strStartDate,
                        ["page"] = strPage,
                        ["limit"] = strLimit
                    }});

                _data.Add(new object[] { _request10.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["extended"] = strExtendedInfo,
                        ["page"] = strPage
                    }});

                _data.Add(new object[] { _request11.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["extended"] = strExtendedInfo,
                        ["limit"] = strLimit
                    }});

                _data.Add(new object[] { _request12.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["extended"] = strExtendedInfo,
                        ["page"] = strPage,
                        ["limit"] = strLimit
                    }});

                _data.Add(new object[] { _request13.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["page"] = strPage,
                        ["limit"] = strLimit
                    }});

                _data.Add(new object[] { _request14.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["start_date"] = strStartDate,
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
