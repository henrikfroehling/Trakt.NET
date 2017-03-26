namespace TraktApiSharp.Tests.Requests.Calendars.OAuth
{
    using FluentAssertions;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using Traits;
    using TraktApiSharp.Extensions;
    using TraktApiSharp.Objects.Get.Calendars.Implementations;
    using TraktApiSharp.Requests.Base;
    using TraktApiSharp.Requests.Calendars.OAuth;
    using TraktApiSharp.Requests.Parameters;
    using Xunit;

    [Category("Requests.Calendars.OAuth.Movies")]
    public class TraktCalendarUserMoviesRequest_Tests
    {
        [Fact]
        public void Test_TraktCalendarUserMoviesRequest_IsNotAbstract()
        {
            typeof(TraktCalendarUserMoviesRequest).IsAbstract.Should().BeFalse();
        }

        [Fact]
        public void Test_TraktCalendarUserMoviesRequest_IsSealed()
        {
            typeof(TraktCalendarUserMoviesRequest).IsSealed.Should().BeTrue();
        }

        [Fact]
        public void Test_TraktCalendarUserMoviesRequest_Inherits_ATraktCalendarUserRequest()
        {
            typeof(TraktCalendarUserMoviesRequest).IsSubclassOf(typeof(ATraktCalendarUserRequest<TraktCalendarMovie>)).Should().BeTrue();
        }

        [Fact]
        public void Test_TraktCalendarUserMoviesRequest_Has_AuthorizationRequirement_Required()
        {
            var request = new TraktCalendarUserMoviesRequest();
            request.AuthorizationRequirement.Should().Be(TraktAuthorizationRequirement.Required);
        }

        [Fact]
        public void Test_TraktCalendarUserMoviesRequest_Has_Valid_UriTemplate()
        {
            var request = new TraktCalendarUserMoviesRequest();
            request.UriTemplate.Should().Be("calendars/my/movies{/start_date}{/days}{?extended,query,years,genres,languages,countries,runtimes,ratings}");
        }

        [Theory, ClassData(typeof(TraktCalendarUserMoviesRequest_TestData))]
        public void Test_TraktCalendarUserMoviesRequest_Returns_Valid_UriPathParameters(IDictionary<string, object> values,
                                                                                        IDictionary<string, object> expected)
        {
            values.Should().NotBeNull().And.HaveCount(expected.Count);

            if (expected.Count > 0)
                values.Should().Contain(expected);
        }

        public class TraktCalendarUserMoviesRequest_TestData : IEnumerable<object[]>
        {
            private static readonly DateTime _startDate = DateTime.Now.AddDays(-7);
            private const int _days = 14;
            private static readonly TraktExtendedInfo _extendedInfo = new TraktExtendedInfo { Full = true };
            private static readonly TraktMovieFilter _filter = new TraktMovieFilter().WithYears(2010, 2017);

            private static readonly TraktCalendarUserMoviesRequest _request1 = new TraktCalendarUserMoviesRequest();

            private static readonly TraktCalendarUserMoviesRequest _request2 = new TraktCalendarUserMoviesRequest
            { StartDate = _startDate };

            private static readonly TraktCalendarUserMoviesRequest _request3 = new TraktCalendarUserMoviesRequest
            { StartDate = _startDate, Days = _days };

            private static readonly TraktCalendarUserMoviesRequest _request4 = new TraktCalendarUserMoviesRequest
            { Days = _days };

            // with extended info
            private static readonly TraktCalendarUserMoviesRequest _request5 = new TraktCalendarUserMoviesRequest
            { ExtendedInfo = _extendedInfo };

            private static readonly TraktCalendarUserMoviesRequest _request6 = new TraktCalendarUserMoviesRequest
            { StartDate = _startDate, ExtendedInfo = _extendedInfo };

            private static readonly TraktCalendarUserMoviesRequest _request7 = new TraktCalendarUserMoviesRequest
            { StartDate = _startDate, Days = _days, ExtendedInfo = _extendedInfo };

            private static readonly TraktCalendarUserMoviesRequest _request8 = new TraktCalendarUserMoviesRequest
            { Days = _days, ExtendedInfo = _extendedInfo };

            // with filter
            private static readonly TraktCalendarUserMoviesRequest _request9 = new TraktCalendarUserMoviesRequest
            { Filter = _filter };

            private static readonly TraktCalendarUserMoviesRequest _request10 = new TraktCalendarUserMoviesRequest
            { StartDate = _startDate, Filter = _filter };

            private static readonly TraktCalendarUserMoviesRequest _request11 = new TraktCalendarUserMoviesRequest
            { StartDate = _startDate, Days = _days, Filter = _filter };

            private static readonly TraktCalendarUserMoviesRequest _request12 = new TraktCalendarUserMoviesRequest
            { Days = _days, Filter = _filter };

            // with extended info and filter
            private static readonly TraktCalendarUserMoviesRequest _request13 = new TraktCalendarUserMoviesRequest
            { ExtendedInfo = _extendedInfo, Filter = _filter };

            private static readonly TraktCalendarUserMoviesRequest _request14 = new TraktCalendarUserMoviesRequest
            { StartDate = _startDate, ExtendedInfo = _extendedInfo, Filter = _filter };

            private static readonly TraktCalendarUserMoviesRequest _request15 = new TraktCalendarUserMoviesRequest
            { StartDate = _startDate, Days = _days, ExtendedInfo = _extendedInfo, Filter = _filter };

            private static readonly TraktCalendarUserMoviesRequest _request16 = new TraktCalendarUserMoviesRequest
            { Days = _days, ExtendedInfo = _extendedInfo, Filter = _filter };

            private static readonly List<object[]> _data = new List<object[]>();

            public TraktCalendarUserMoviesRequest_TestData()
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
