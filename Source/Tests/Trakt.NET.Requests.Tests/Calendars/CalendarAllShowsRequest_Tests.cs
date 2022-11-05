namespace TraktNet.Requests.Tests.Calendars
{
    using FluentAssertions;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Extensions;
    using TraktNet.Parameters;
    using TraktNet.Requests.Base;
    using TraktNet.Requests.Calendars;
    using TraktNet.Requests.Parameters;
    using Xunit;

    [TestCategory("Requests.Calendars.Shows")]
    public class CalendarAllShowsRequest_Tests
    {
        [Fact]
        public void Test_CalendarAllShowsRequest_Has_AuthorizationRequirement_NotRequired()
        {
            var request = new CalendarAllShowsRequest();
            request.AuthorizationRequirement.Should().Be(AuthorizationRequirement.NotRequired);
        }

        [Fact]
        public void Test_CalendarAllShowsRequest_Has_Valid_UriTemplate()
        {
            var request = new CalendarAllShowsRequest();
            request.UriTemplate.Should().Be("calendars/all/shows{/start_date}{/days}{?extended,query,years,genres,languages,countries,runtimes,ratings}");
        }

        [Theory, ClassData(typeof(CalendarAllShowsRequest_TestData))]
        public void Test_CalendarAllShowsRequest_Returns_Valid_UriPathParameters(IDictionary<string, object> values,
                                                                                 IDictionary<string, object> expected)
        {
            values.Should().NotBeNull().And.HaveCount(expected.Count);

            if (expected.Count > 0)
                values.Should().Contain(expected);
        }

        public class CalendarAllShowsRequest_TestData : IEnumerable<object[]>
        {
            private static readonly DateTime _startDate = DateTime.Now.AddDays(-7);
            private const int _days = 14;
            private static readonly TraktExtendedInfo _extendedInfo = new TraktExtendedInfo { Full = true };
            private static readonly ITraktCalendarFilter _filter = TraktFilter.NewCalendarFilter().WithYears(2010, 2017).Build();

            private static readonly CalendarAllShowsRequest _request1 = new CalendarAllShowsRequest();

            private static readonly CalendarAllShowsRequest _request2 = new CalendarAllShowsRequest
            { StartDate = _startDate };

            private static readonly CalendarAllShowsRequest _request3 = new CalendarAllShowsRequest
            { StartDate = _startDate, Days = _days };

            private static readonly CalendarAllShowsRequest _request4 = new CalendarAllShowsRequest
            { Days = _days };

            // with extended info
            private static readonly CalendarAllShowsRequest _request5 = new CalendarAllShowsRequest
            { ExtendedInfo = _extendedInfo };

            private static readonly CalendarAllShowsRequest _request6 = new CalendarAllShowsRequest
            { StartDate = _startDate, ExtendedInfo = _extendedInfo };

            private static readonly CalendarAllShowsRequest _request7 = new CalendarAllShowsRequest
            { StartDate = _startDate, Days = _days, ExtendedInfo = _extendedInfo };

            private static readonly CalendarAllShowsRequest _request8 = new CalendarAllShowsRequest
            { Days = _days, ExtendedInfo = _extendedInfo };

            // with filter
            private static readonly CalendarAllShowsRequest _request9 = new CalendarAllShowsRequest
            { Filter = _filter };

            private static readonly CalendarAllShowsRequest _request10 = new CalendarAllShowsRequest
            { StartDate = _startDate, Filter = _filter };

            private static readonly CalendarAllShowsRequest _request11 = new CalendarAllShowsRequest
            { StartDate = _startDate, Days = _days, Filter = _filter };

            private static readonly CalendarAllShowsRequest _request12 = new CalendarAllShowsRequest
            { Days = _days, Filter = _filter };

            // with extended info and filter
            private static readonly CalendarAllShowsRequest _request13 = new CalendarAllShowsRequest
            { ExtendedInfo = _extendedInfo, Filter = _filter };

            private static readonly CalendarAllShowsRequest _request14 = new CalendarAllShowsRequest
            { StartDate = _startDate, ExtendedInfo = _extendedInfo, Filter = _filter };

            private static readonly CalendarAllShowsRequest _request15 = new CalendarAllShowsRequest
            { StartDate = _startDate, Days = _days, ExtendedInfo = _extendedInfo, Filter = _filter };

            private static readonly CalendarAllShowsRequest _request16 = new CalendarAllShowsRequest
            { Days = _days, ExtendedInfo = _extendedInfo, Filter = _filter };

            private static readonly List<object[]> _data = new List<object[]>();

            public CalendarAllShowsRequest_TestData()
            {
                SetupPathParamters();
            }

            private void SetupPathParamters()
            {
                var strStartDate = _startDate.ToTraktDateString();
                var strDays = _days.ToString();
                var strExtendedInfo = _extendedInfo.ToString();
                var filterParameters = _filter.GetParameters();

                _data.Add(new object[] { _request1.GetUriPathParameters(), new Dictionary<string, object>() });

                _data.Add(new object[] { _request2.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["start_date"] = strStartDate
                    }});

                _data.Add(new object[] { _request3.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["start_date"] = strStartDate,
                        ["days"] = strDays
                    }});

                var requestParameters = _request4.GetUriPathParameters();
                _data.Add(new object[] { requestParameters, new Dictionary<string, object>
                    {
                        ["start_date"] = requestParameters["start_date"],
                        ["days"] = strDays
                    }});

                // with extended info
                _data.Add(new object[] { _request5.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["extended"] = strExtendedInfo
                    }});

                _data.Add(new object[] { _request6.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["start_date"] = strStartDate,
                        ["extended"] = strExtendedInfo
                    }});

                _data.Add(new object[] { _request7.GetUriPathParameters(), new Dictionary<string, object>
                    {
                        ["start_date"] = strStartDate,
                        ["days"] = strDays,
                        ["extended"] = strExtendedInfo
                    }});

                requestParameters = _request8.GetUriPathParameters();
                _data.Add(new object[] { requestParameters, new Dictionary<string, object>
                    {
                        ["start_date"] = requestParameters["start_date"],
                        ["days"] = strDays,
                        ["extended"] = strExtendedInfo
                    }});

                // with filter
                _data.Add(new object[] { _request9.GetUriPathParameters(), new Dictionary<string, object>(filterParameters) });

                _data.Add(new object[] { _request10.GetUriPathParameters(), new Dictionary<string, object>(filterParameters)
                    {
                        ["start_date"] = strStartDate
                    }});

                _data.Add(new object[] { _request11.GetUriPathParameters(), new Dictionary<string, object>(filterParameters)
                    {
                        ["start_date"] = strStartDate,
                        ["days"] = strDays
                    }});

                requestParameters = _request12.GetUriPathParameters();
                _data.Add(new object[] { _request12.GetUriPathParameters(), new Dictionary<string, object>(filterParameters)
                    {
                        ["start_date"] = requestParameters["start_date"],
                        ["days"] = strDays
                    }});

                // with extended info and filter
                _data.Add(new object[] { _request13.GetUriPathParameters(), new Dictionary<string, object>(filterParameters)
                    {
                        ["extended"] = strExtendedInfo
                    }});

                _data.Add(new object[] { _request14.GetUriPathParameters(), new Dictionary<string, object>(filterParameters)
                    {
                        ["start_date"] = strStartDate,
                        ["extended"] = strExtendedInfo
                    }});

                _data.Add(new object[] { _request15.GetUriPathParameters(), new Dictionary<string, object>(filterParameters)
                    {
                        ["start_date"] = strStartDate,
                        ["days"] = strDays,
                        ["extended"] = strExtendedInfo
                    }});

                requestParameters = _request16.GetUriPathParameters();
                _data.Add(new object[] { _request16.GetUriPathParameters(), new Dictionary<string, object>(filterParameters)
                    {
                        ["start_date"] = requestParameters["start_date"],
                        ["days"] = strDays,
                        ["extended"] = strExtendedInfo
                    }});
            }

            public IEnumerator<object[]> GetEnumerator() => _data.GetEnumerator();

            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        }
    }
}
