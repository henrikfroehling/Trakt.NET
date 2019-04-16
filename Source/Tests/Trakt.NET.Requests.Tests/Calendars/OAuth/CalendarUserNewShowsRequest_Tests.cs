﻿namespace TraktNet.Requests.Tests.Calendars.OAuth
{
    using FluentAssertions;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Extensions;
    using TraktNet.Requests.Base;
    using TraktNet.Requests.Calendars.OAuth;
    using TraktNet.Requests.Parameters;
    using TraktNet.Requests.Parameters.Filter;
    using Xunit;

    [Category("Requests.Calendars.OAuth.Shows")]
    public class CalendarUserNewShowsRequest_Tests
    {
        [Fact]
        public void Test_CalendarUserNewShowsRequest_Has_AuthorizationRequirement_Required()
        {
            var request = new CalendarUserNewShowsRequest();
            request.AuthorizationRequirement.Should().Be(AuthorizationRequirement.Required);
        }

        [Fact]
        public void Test_CalendarUserNewShowsRequest_Has_Valid_UriTemplate()
        {
            var request = new CalendarUserNewShowsRequest();
            request.UriTemplate.Should().Be("calendars/my/shows/new{/start_date}{/days}{?extended,query,years,genres,languages,countries,runtimes,ratings}");
        }

        [Theory, ClassData(typeof(CalendarUserNewShowsRequest_TestData))]
        public void Test_CalendarUserNewShowsRequest_Returns_Valid_UriPathParameters(IDictionary<string, object> values,
                                                                                     IDictionary<string, object> expected)
        {
            values.Should().NotBeNull().And.HaveCount(expected.Count);

            if (expected.Count > 0)
                values.Should().Contain(expected);
        }

        public class CalendarUserNewShowsRequest_TestData : IEnumerable<object[]>
        {
            private static readonly DateTime _startDate = DateTime.Now.AddDays(-7);
            private const int _days = 14;
            private static readonly TraktExtendedInfo _extendedInfo = new TraktExtendedInfo { Full = true };
            private static readonly ITraktCalendarFilter _filter = TraktFilterDirectory.CalendarFilter.WithYears(2010, 2017).Build();

            private static readonly CalendarUserNewShowsRequest _request1 = new CalendarUserNewShowsRequest();

            private static readonly CalendarUserNewShowsRequest _request2 = new CalendarUserNewShowsRequest
            { StartDate = _startDate };

            private static readonly CalendarUserNewShowsRequest _request3 = new CalendarUserNewShowsRequest
            { StartDate = _startDate, Days = _days };

            private static readonly CalendarUserNewShowsRequest _request4 = new CalendarUserNewShowsRequest
            { Days = _days };

            // with extended info
            private static readonly CalendarUserNewShowsRequest _request5 = new CalendarUserNewShowsRequest
            { ExtendedInfo = _extendedInfo };

            private static readonly CalendarUserNewShowsRequest _request6 = new CalendarUserNewShowsRequest
            { StartDate = _startDate, ExtendedInfo = _extendedInfo };

            private static readonly CalendarUserNewShowsRequest _request7 = new CalendarUserNewShowsRequest
            { StartDate = _startDate, Days = _days, ExtendedInfo = _extendedInfo };

            private static readonly CalendarUserNewShowsRequest _request8 = new CalendarUserNewShowsRequest
            { Days = _days, ExtendedInfo = _extendedInfo };

            // with filter
            private static readonly CalendarUserNewShowsRequest _request9 = new CalendarUserNewShowsRequest
            { Filter = _filter };

            private static readonly CalendarUserNewShowsRequest _request10 = new CalendarUserNewShowsRequest
            { StartDate = _startDate, Filter = _filter };

            private static readonly CalendarUserNewShowsRequest _request11 = new CalendarUserNewShowsRequest
            { StartDate = _startDate, Days = _days, Filter = _filter };

            private static readonly CalendarUserNewShowsRequest _request12 = new CalendarUserNewShowsRequest
            { Days = _days, Filter = _filter };

            // with extended info and filter
            private static readonly CalendarUserNewShowsRequest _request13 = new CalendarUserNewShowsRequest
            { ExtendedInfo = _extendedInfo, Filter = _filter };

            private static readonly CalendarUserNewShowsRequest _request14 = new CalendarUserNewShowsRequest
            { StartDate = _startDate, ExtendedInfo = _extendedInfo, Filter = _filter };

            private static readonly CalendarUserNewShowsRequest _request15 = new CalendarUserNewShowsRequest
            { StartDate = _startDate, Days = _days, ExtendedInfo = _extendedInfo, Filter = _filter };

            private static readonly CalendarUserNewShowsRequest _request16 = new CalendarUserNewShowsRequest
            { Days = _days, ExtendedInfo = _extendedInfo, Filter = _filter };

            private static readonly List<object[]> _data = new List<object[]>();

            public CalendarUserNewShowsRequest_TestData()
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
