namespace TraktApiSharp.Tests.Experimental.Requests.Calendars
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
    using System.Collections.Generic;
    using TraktApiSharp.Experimental.Requests.Calendars;
    using TraktApiSharp.Extensions;
    using TraktApiSharp.Objects.Get.Calendars;
    using TraktApiSharp.Requests;

    [TestClass]
    public class TraktCalendarAllMoviesRequestTests
    {
        [TestMethod, TestCategory("Requests"), TestCategory("Calendars"), TestCategory("Without OAuth"), TestCategory("Movies")]
        public void TestTraktCalendarAllMoviesRequestIsNotAbstract()
        {
            typeof(TraktCalendarAllMoviesRequest).IsAbstract.Should().BeFalse();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Calendars"), TestCategory("Without OAuth"), TestCategory("Movies")]
        public void TestTraktCalendarAllMoviesRequestIsSealed()
        {
            typeof(TraktCalendarAllMoviesRequest).IsSealed.Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Calendars"), TestCategory("Without OAuth"), TestCategory("Movies")]
        public void TestTraktCalendarAllMoviesRequestIsSubclassOfATraktCalendarAllRequest()
        {
            typeof(TraktCalendarAllMoviesRequest).IsSubclassOf(typeof(ATraktCalendarAllRequest<TraktCalendarMovie>)).Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Calendars"), TestCategory("Without OAuth"), TestCategory("Movies")]
        public void TestTraktCalendarAllMoviesRequestHasAuthorizationNotRequired()
        {
            var request = new TraktCalendarAllMoviesRequest(null);
            request.AuthorizationRequirement.Should().Be(TraktAuthorizationRequirement.NotRequired);
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Calendars"), TestCategory("Without OAuth"), TestCategory("Movies")]
        public void TestTraktCalendarAllMoviesRequestHasValidUriTemplate()
        {
            var request = new TraktCalendarAllMoviesRequest(null);
            request.UriTemplate.Should().Be("calendars/all/movies{/start_date}{/days}{?extended,query,years,genres,languages,countries,runtimes,ratings}");
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Calendars"), TestCategory("Without OAuth"), TestCategory("Movies")]
        public void TestTraktCalendarAllMoviesRequestUriParamsWithoutStartDateAndDays()
        {
            var request = new TraktCalendarAllMoviesRequest(null);
            var uriParams = request.GetUriPathParameters();

            uriParams.Should().NotBeNull().And.BeEmpty();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Calendars"), TestCategory("Without OAuth"), TestCategory("Movies")]
        public void TestTraktCalendarAllMoviesRequestUriParamsWithStartDate()
        {
            var startDate = DateTime.Now;

            var request = new TraktCalendarAllMoviesRequest(null)
            {
                StartDate = startDate
            };

            var uriParams = request.GetUriPathParameters();

            uriParams.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(1);
            uriParams.Should().Contain("start_date", startDate.ToTraktDateString());
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Calendars"), TestCategory("Without OAuth"), TestCategory("Movies")]
        public void TestTraktCalendarAllMoviesRequestUriParamsWithStartDateAndDays()
        {
            var startDate = DateTime.Now;
            var days = 14;

            var request = new TraktCalendarAllMoviesRequest(null)
            {
                StartDate = startDate,
                Days = days
            };

            var uriParams = request.GetUriPathParameters();

            uriParams.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(2);

            uriParams.Should().Contain(new Dictionary<string, object>
            {
                ["start_date"] = startDate.ToTraktDateString(),
                ["days"] = days
            });
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Calendars"), TestCategory("Without OAuth"), TestCategory("Movies")]
        public void TestTraktCalendarAllMoviesRequestUriParamsWithDays()
        {
            var startDate = DateTime.Now;
            var days = 14;

            var request = new TraktCalendarAllMoviesRequest(null)
            {
                Days = days
            };

            var uriParams = request.GetUriPathParameters();

            uriParams.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(2);

            uriParams.Should().Contain(new Dictionary<string, object>
            {
                ["start_date"] = startDate.ToTraktDateString(),
                ["days"] = days
            });
        }
    }
}
