namespace TraktNet.Requests.Tests.Calendars.OAuth
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

    [TestCategory("Requests.Calendars.OAuth.Movies")]
    public class CalendarUserMoviesRequest_Tests
    {
        [Fact]
        public void Test_CalendarUserMoviesRequest_Has_AuthorizationRequirement_Required()
        {
            var request = new CalendarUserMoviesRequest();
            request.AuthorizationRequirement.Should().Be(AuthorizationRequirement.Required);
        }

        [Fact]
        public void Test_CalendarUserMoviesRequest_Has_Valid_UriTemplate()
        {
            var request = new CalendarUserMoviesRequest();
            request.UriTemplate.Should().Be("calendars/my/movies{/start_date}{/days}{?extended,query,years,genres,languages,countries,runtimes,ratings}");
        }

        [Theory, ClassData(typeof(CalendarUserMoviesRequest_TestData))]
        public void Test_CalendarUserMoviesRequest_Returns_Valid_UriPathParameters(IDictionary<string, object> values,
                                                                                   IDictionary<string, object> expected)
        {
            values.Should().NotBeNull().And.HaveCount(expected.Count);

            if (expected.Count > 0)
                values.Should().Contain(expected);
        }

        public class CalendarUserMoviesRequest_TestData : IEnumerable<object[]>
        {
            private static readonly DateTime _startDate = DateTime.Now.AddDays(-7);
            private const int _days = 14;
            private static readonly TraktExtendedInfo _extendedInfo = new TraktExtendedInfo { Full = true };
            private static readonly ITraktCalendarFilter _filter = TraktFilterDirectory.CalendarFilter.WithYears(2010, 2017).Build();

            private static readonly CalendarUserMoviesRequest _request1 = new CalendarUserMoviesRequest();

            private static readonly CalendarUserMoviesRequest _request2 = new CalendarUserMoviesRequest
            { StartDate = _startDate };

            private static readonly CalendarUserMoviesRequest _request3 = new CalendarUserMoviesRequest
            { StartDate = _startDate, Days = _days };

            private static readonly CalendarUserMoviesRequest _request4 = new CalendarUserMoviesRequest
            { Days = _days };

            // with extended info
            private static readonly CalendarUserMoviesRequest _request5 = new CalendarUserMoviesRequest
            { ExtendedInfo = _extendedInfo };

            private static readonly CalendarUserMoviesRequest _request6 = new CalendarUserMoviesRequest
            { StartDate = _startDate, ExtendedInfo = _extendedInfo };

            private static readonly CalendarUserMoviesRequest _request7 = new CalendarUserMoviesRequest
            { StartDate = _startDate, Days = _days, ExtendedInfo = _extendedInfo };

            private static readonly CalendarUserMoviesRequest _request8 = new CalendarUserMoviesRequest
            { Days = _days, ExtendedInfo = _extendedInfo };

            // with filter
            private static readonly CalendarUserMoviesRequest _request9 = new CalendarUserMoviesRequest
            { Filter = _filter };

            private static readonly CalendarUserMoviesRequest _request10 = new CalendarUserMoviesRequest
            { StartDate = _startDate, Filter = _filter };

            private static readonly CalendarUserMoviesRequest _request11 = new CalendarUserMoviesRequest
            { StartDate = _startDate, Days = _days, Filter = _filter };

            private static readonly CalendarUserMoviesRequest _request12 = new CalendarUserMoviesRequest
            { Days = _days, Filter = _filter };

            // with extended info and filter
            private static readonly CalendarUserMoviesRequest _request13 = new CalendarUserMoviesRequest
            { ExtendedInfo = _extendedInfo, Filter = _filter };

            private static readonly CalendarUserMoviesRequest _request14 = new CalendarUserMoviesRequest
            { StartDate = _startDate, ExtendedInfo = _extendedInfo, Filter = _filter };

            private static readonly CalendarUserMoviesRequest _request15 = new CalendarUserMoviesRequest
            { StartDate = _startDate, Days = _days, ExtendedInfo = _extendedInfo, Filter = _filter };

            private static readonly CalendarUserMoviesRequest _request16 = new CalendarUserMoviesRequest
            { Days = _days, ExtendedInfo = _extendedInfo, Filter = _filter };

            private static readonly List<object[]> _data = new List<object[]>();

            public CalendarUserMoviesRequest_TestData()
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
