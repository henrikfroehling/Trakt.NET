namespace TraktApiSharp.Tests.Requests.Calendars
{
    using FluentAssertions;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using Traits;
    using TraktApiSharp.Extensions;
    using TraktApiSharp.Objects.Get.Calendars;
    using TraktApiSharp.Requests.Base;
    using TraktApiSharp.Requests.Calendars;
    using TraktApiSharp.Requests.Parameters;
    using Xunit;

    [Category("Requests.Calendars.Shows")]
    public class TraktCalendarAllShowsRequest_Tests
    {
        [Fact]
        public void Test_TraktCalendarAllShowsRequest_IsNotAbstract()
        {
            typeof(TraktCalendarAllShowsRequest).IsAbstract.Should().BeFalse();
        }

        [Fact]
        public void Test_TraktCalendarAllShowsRequest_IsSealed()
        {
            typeof(TraktCalendarAllShowsRequest).IsSealed.Should().BeTrue();
        }

        [Fact]
        public void Test_TraktCalendarAllShowsRequest_Inherits_ATraktCalendarRequest()
        {
            typeof(TraktCalendarAllShowsRequest).IsSubclassOf(typeof(ACalendarRequest<ITraktCalendarShow>)).Should().BeTrue();
        }

        [Fact]
        public void Test_TraktCalendarAllShowsRequest_Has_AuthorizationRequirement_NotRequired()
        {
            var request = new TraktCalendarAllShowsRequest();
            request.AuthorizationRequirement.Should().Be(AuthorizationRequirement.NotRequired);
        }

        [Fact]
        public void Test_TraktCalendarAllShowsRequest_Has_Valid_UriTemplate()
        {
            var request = new TraktCalendarAllShowsRequest();
            request.UriTemplate.Should().Be("calendars/all/shows{/start_date}{/days}{?extended,query,years,genres,languages,countries,runtimes,ratings}");
        }

        [Theory, ClassData(typeof(TraktCalendarAllShowsRequest_TestData))]
        public void Test_TraktCalendarAllShowsRequest_Returns_Valid_UriPathParameters(IDictionary<string, object> values,
                                                                                      IDictionary<string, object> expected)
        {
            values.Should().NotBeNull().And.HaveCount(expected.Count);

            if (expected.Count > 0)
                values.Should().Contain(expected);
        }

        public class TraktCalendarAllShowsRequest_TestData : IEnumerable<object[]>
        {
            private static readonly DateTime _startDate = DateTime.Now.AddDays(-7);
            private const int _days = 14;
            private static readonly TraktExtendedInfo _extendedInfo = new TraktExtendedInfo { Full = true };
            private static readonly TraktMovieFilter _filter = new TraktMovieFilter().WithYears(2010, 2017);

            private static readonly TraktCalendarAllShowsRequest _request1 = new TraktCalendarAllShowsRequest();

            private static readonly TraktCalendarAllShowsRequest _request2 = new TraktCalendarAllShowsRequest
            { StartDate = _startDate };

            private static readonly TraktCalendarAllShowsRequest _request3 = new TraktCalendarAllShowsRequest
            { StartDate = _startDate, Days = _days };

            private static readonly TraktCalendarAllShowsRequest _request4 = new TraktCalendarAllShowsRequest
            { Days = _days };

            // with extended info
            private static readonly TraktCalendarAllShowsRequest _request5 = new TraktCalendarAllShowsRequest
            { ExtendedInfo = _extendedInfo };

            private static readonly TraktCalendarAllShowsRequest _request6 = new TraktCalendarAllShowsRequest
            { StartDate = _startDate, ExtendedInfo = _extendedInfo };

            private static readonly TraktCalendarAllShowsRequest _request7 = new TraktCalendarAllShowsRequest
            { StartDate = _startDate, Days = _days, ExtendedInfo = _extendedInfo };

            private static readonly TraktCalendarAllShowsRequest _request8 = new TraktCalendarAllShowsRequest
            { Days = _days, ExtendedInfo = _extendedInfo };

            // with filter
            private static readonly TraktCalendarAllShowsRequest _request9 = new TraktCalendarAllShowsRequest
            { Filter = _filter };

            private static readonly TraktCalendarAllShowsRequest _request10 = new TraktCalendarAllShowsRequest
            { StartDate = _startDate, Filter = _filter };

            private static readonly TraktCalendarAllShowsRequest _request11 = new TraktCalendarAllShowsRequest
            { StartDate = _startDate, Days = _days, Filter = _filter };

            private static readonly TraktCalendarAllShowsRequest _request12 = new TraktCalendarAllShowsRequest
            { Days = _days, Filter = _filter };

            // with extended info and filter
            private static readonly TraktCalendarAllShowsRequest _request13 = new TraktCalendarAllShowsRequest
            { ExtendedInfo = _extendedInfo, Filter = _filter };

            private static readonly TraktCalendarAllShowsRequest _request14 = new TraktCalendarAllShowsRequest
            { StartDate = _startDate, ExtendedInfo = _extendedInfo, Filter = _filter };

            private static readonly TraktCalendarAllShowsRequest _request15 = new TraktCalendarAllShowsRequest
            { StartDate = _startDate, Days = _days, ExtendedInfo = _extendedInfo, Filter = _filter };

            private static readonly TraktCalendarAllShowsRequest _request16 = new TraktCalendarAllShowsRequest
            { Days = _days, ExtendedInfo = _extendedInfo, Filter = _filter };

            private static readonly List<object[]> _data = new List<object[]>();

            public TraktCalendarAllShowsRequest_TestData()
            {
                SetupPathParamters();
            }

            private void SetupPathParamters()
            {
                var strStartDate = _startDate.ToTraktDateString();
                var strDays = _days.ToString();
                var strExtendedInfo = _extendedInfo.ToString();
                var filterParameters = _filter.GetParameters();

                _data.Add(new object[] { _request1.GetUriPathParameters(), new Dictionary<string, object> { } });

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
                _data.Add(new object[] { _request9.GetUriPathParameters(), new Dictionary<string, object>(filterParameters) { } });

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
