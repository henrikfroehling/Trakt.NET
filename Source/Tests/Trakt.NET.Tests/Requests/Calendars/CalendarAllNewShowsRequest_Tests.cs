namespace TraktNet.Tests.Requests.Calendars
{
    using FluentAssertions;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using Traits;
    using TraktNet.Extensions;
    using TraktNet.Requests.Base;
    using TraktNet.Requests.Calendars;
    using TraktNet.Requests.Parameters;
    using TraktNet.Requests.Parameters.OldFilters;
    using Xunit;

    [Category("Requests.Calendars.Shows")]
    public class CalendarAllNewShowsRequest_Tests
    {
        [Fact]
        public void Test_CalendarAllNewShowsRequest_Has_AuthorizationRequirement_NotRequired()
        {
            var request = new CalendarAllNewShowsRequest();
            request.AuthorizationRequirement.Should().Be(AuthorizationRequirement.NotRequired);
        }

        [Fact]
        public void Test_CalendarAllNewShowsRequest_Has_Valid_UriTemplate()
        {
            var request = new CalendarAllNewShowsRequest();
            request.UriTemplate.Should().Be("calendars/all/shows/new{/start_date}{/days}{?extended,query,years,genres,languages,countries,runtimes,ratings}");
        }

        [Theory, ClassData(typeof(CalendarAllNewShowsRequest_TestData))]
        public void Test_CalendarAllNewShowsRequest_Returns_Valid_UriPathParameters(IDictionary<string, object> values,
                                                                                    IDictionary<string, object> expected)
        {
            values.Should().NotBeNull().And.HaveCount(expected.Count);

            if (expected.Count > 0)
                values.Should().Contain(expected);
        }

        public class CalendarAllNewShowsRequest_TestData : IEnumerable<object[]>
        {
            private static readonly DateTime _startDate = DateTime.Now.AddDays(-7);
            private const int _days = 14;
            private static readonly TraktExtendedInfo _extendedInfo = new TraktExtendedInfo { Full = true };
            private static readonly TraktMovieFilter _filter = new TraktMovieFilter().WithYears(2010, 2017);

            private static readonly CalendarAllNewShowsRequest _request1 = new CalendarAllNewShowsRequest();

            private static readonly CalendarAllNewShowsRequest _request2 = new CalendarAllNewShowsRequest
            { StartDate = _startDate };

            private static readonly CalendarAllNewShowsRequest _request3 = new CalendarAllNewShowsRequest
            { StartDate = _startDate, Days = _days };

            private static readonly CalendarAllNewShowsRequest _request4 = new CalendarAllNewShowsRequest
            { Days = _days };

            // with extended info
            private static readonly CalendarAllNewShowsRequest _request5 = new CalendarAllNewShowsRequest
            { ExtendedInfo = _extendedInfo };

            private static readonly CalendarAllNewShowsRequest _request6 = new CalendarAllNewShowsRequest
            { StartDate = _startDate, ExtendedInfo = _extendedInfo };

            private static readonly CalendarAllNewShowsRequest _request7 = new CalendarAllNewShowsRequest
            { StartDate = _startDate, Days = _days, ExtendedInfo = _extendedInfo };

            private static readonly CalendarAllNewShowsRequest _request8 = new CalendarAllNewShowsRequest
            { Days = _days, ExtendedInfo = _extendedInfo };

            // with filter
            private static readonly CalendarAllNewShowsRequest _request9 = new CalendarAllNewShowsRequest
            { Filter = _filter };

            private static readonly CalendarAllNewShowsRequest _request10 = new CalendarAllNewShowsRequest
            { StartDate = _startDate, Filter = _filter };

            private static readonly CalendarAllNewShowsRequest _request11 = new CalendarAllNewShowsRequest
            { StartDate = _startDate, Days = _days, Filter = _filter };

            private static readonly CalendarAllNewShowsRequest _request12 = new CalendarAllNewShowsRequest
            { Days = _days, Filter = _filter };

            // with extended info and filter
            private static readonly CalendarAllNewShowsRequest _request13 = new CalendarAllNewShowsRequest
            { ExtendedInfo = _extendedInfo, Filter = _filter };

            private static readonly CalendarAllNewShowsRequest _request14 = new CalendarAllNewShowsRequest
            { StartDate = _startDate, ExtendedInfo = _extendedInfo, Filter = _filter };

            private static readonly CalendarAllNewShowsRequest _request15 = new CalendarAllNewShowsRequest
            { StartDate = _startDate, Days = _days, ExtendedInfo = _extendedInfo, Filter = _filter };

            private static readonly CalendarAllNewShowsRequest _request16 = new CalendarAllNewShowsRequest
            { Days = _days, ExtendedInfo = _extendedInfo, Filter = _filter };

            private static readonly List<object[]> _data = new List<object[]>();

            public CalendarAllNewShowsRequest_TestData()
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
