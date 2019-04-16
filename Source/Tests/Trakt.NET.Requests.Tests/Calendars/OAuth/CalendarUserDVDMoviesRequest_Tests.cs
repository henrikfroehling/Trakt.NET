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

    [Category("Requests.Calendars.OAuth.Movies")]
    public class CalendarUserDVDMoviesRequest_Tests
    {
        [Fact]
        public void Test_CalendarUserDVDMoviesRequest_Has_AuthorizationRequirement_Required()
        {
            var request = new CalendarUserDVDMoviesRequest();
            request.AuthorizationRequirement.Should().Be(AuthorizationRequirement.Required);
        }

        [Fact]
        public void Test_CalendarUserDVDMoviesRequest_Has_Valid_UriTemplate()
        {
            var request = new CalendarUserDVDMoviesRequest();
            request.UriTemplate.Should().Be("calendars/my/dvd{/start_date}{/days}{?extended,query,years,genres,languages,countries,runtimes,ratings}");
        }

        [Theory, ClassData(typeof(CalendarUserDVDMoviesRequest_TestData))]
        public void Test_CalendarUserDVDMoviesRequest_Returns_Valid_UriPathParameters(IDictionary<string, object> values,
                                                                                      IDictionary<string, object> expected)
        {
            values.Should().NotBeNull().And.HaveCount(expected.Count);

            if (expected.Count > 0)
                values.Should().Contain(expected);
        }

        public class CalendarUserDVDMoviesRequest_TestData : IEnumerable<object[]>
        {
            private static readonly DateTime _startDate = DateTime.Now.AddDays(-7);
            private const int _days = 14;
            private static readonly TraktExtendedInfo _extendedInfo = new TraktExtendedInfo { Full = true };
            private static readonly ITraktCalendarFilter _filter = TraktFilterDirectory.CalendarFilter.WithYears(2010, 2017).Build();

            private static readonly CalendarUserDVDMoviesRequest _request1 = new CalendarUserDVDMoviesRequest();

            private static readonly CalendarUserDVDMoviesRequest _request2 = new CalendarUserDVDMoviesRequest
            { StartDate = _startDate };

            private static readonly CalendarUserDVDMoviesRequest _request3 = new CalendarUserDVDMoviesRequest
            { StartDate = _startDate, Days = _days };

            private static readonly CalendarUserDVDMoviesRequest _request4 = new CalendarUserDVDMoviesRequest
            { Days = _days };

            // with extended info
            private static readonly CalendarUserDVDMoviesRequest _request5 = new CalendarUserDVDMoviesRequest
            { ExtendedInfo = _extendedInfo };

            private static readonly CalendarUserDVDMoviesRequest _request6 = new CalendarUserDVDMoviesRequest
            { StartDate = _startDate, ExtendedInfo = _extendedInfo };

            private static readonly CalendarUserDVDMoviesRequest _request7 = new CalendarUserDVDMoviesRequest
            { StartDate = _startDate, Days = _days, ExtendedInfo = _extendedInfo };

            private static readonly CalendarUserDVDMoviesRequest _request8 = new CalendarUserDVDMoviesRequest
            { Days = _days, ExtendedInfo = _extendedInfo };

            // with filter
            private static readonly CalendarUserDVDMoviesRequest _request9 = new CalendarUserDVDMoviesRequest
            { Filter = _filter };

            private static readonly CalendarUserDVDMoviesRequest _request10 = new CalendarUserDVDMoviesRequest
            { StartDate = _startDate, Filter = _filter };

            private static readonly CalendarUserDVDMoviesRequest _request11 = new CalendarUserDVDMoviesRequest
            { StartDate = _startDate, Days = _days, Filter = _filter };

            private static readonly CalendarUserDVDMoviesRequest _request12 = new CalendarUserDVDMoviesRequest
            { Days = _days, Filter = _filter };

            // with extended info and filter
            private static readonly CalendarUserDVDMoviesRequest _request13 = new CalendarUserDVDMoviesRequest
            { ExtendedInfo = _extendedInfo, Filter = _filter };

            private static readonly CalendarUserDVDMoviesRequest _request14 = new CalendarUserDVDMoviesRequest
            { StartDate = _startDate, ExtendedInfo = _extendedInfo, Filter = _filter };

            private static readonly CalendarUserDVDMoviesRequest _request15 = new CalendarUserDVDMoviesRequest
            { StartDate = _startDate, Days = _days, ExtendedInfo = _extendedInfo, Filter = _filter };

            private static readonly CalendarUserDVDMoviesRequest _request16 = new CalendarUserDVDMoviesRequest
            { Days = _days, ExtendedInfo = _extendedInfo, Filter = _filter };

            private static readonly List<object[]> _data = new List<object[]>();

            public CalendarUserDVDMoviesRequest_TestData()
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
