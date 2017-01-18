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
    public class TraktCalendarAllShowsRequestTests
    {
        [TestMethod, TestCategory("Requests"), TestCategory("Calendars"), TestCategory("Without OAuth"), TestCategory("Shows")]
        public void TestTraktCalendarAllShowsRequestIsNotAbstract()
        {
            typeof(TraktCalendarAllShowsRequest).IsAbstract.Should().BeFalse();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Calendars"), TestCategory("Without OAuth"), TestCategory("Shows")]
        public void TestTraktCalendarAllShowsRequestIsSealed()
        {
            typeof(TraktCalendarAllShowsRequest).IsSealed.Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Calendars"), TestCategory("Without OAuth"), TestCategory("Shows")]
        public void TestTraktCalendarAllShowsRequestIsSubclassOfATraktCalendarAllRequest()
        {
            typeof(TraktCalendarAllShowsRequest).IsSubclassOf(typeof(ATraktCalendarAllRequest<TraktCalendarShow>)).Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Calendars"), TestCategory("Without OAuth"), TestCategory("Shows")]
        public void TestTraktCalendarAllShowsRequestHasAuthorizationNotRequired()
        {
            var request = new TraktCalendarAllShowsRequest(null);
            request.AuthorizationRequirement.Should().Be(TraktAuthorizationRequirement.NotRequired);
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Calendars"), TestCategory("Without OAuth"), TestCategory("Shows")]
        public void TestTraktCalendarAllShowsRequestHasValidUriTemplate()
        {
            var request = new TraktCalendarAllShowsRequest(null);
            request.UriTemplate.Should().Be("calendars/all/shows{/start_date}{/days}{?extended,query,years,genres,languages,countries,runtimes,ratings}");
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Calendars"), TestCategory("Without OAuth"), TestCategory("Shows")]
        public void TestTraktCalendarAllShowsRequestUriParamsWithoutStartDateAndDays()
        {
            var request = new TraktCalendarAllShowsRequest(null);
            var uriParams = request.GetUriPathParameters();

            uriParams.Should().NotBeNull().And.BeEmpty();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Calendars"), TestCategory("Without OAuth"), TestCategory("Shows")]
        public void TestTraktCalendarAllShowsRequestUriParamsWithStartDate()
        {
            var startDate = DateTime.Now;

            var request = new TraktCalendarAllShowsRequest(null)
            {
                StartDate = startDate
            };

            var uriParams = request.GetUriPathParameters();

            uriParams.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(1);
            uriParams.Should().Contain("start_date", startDate.ToTraktDateString());
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Calendars"), TestCategory("Without OAuth"), TestCategory("Shows")]
        public void TestTraktCalendarAllShowsRequestUriParamsWithStartDateAndDays()
        {
            var startDate = DateTime.Now;
            var days = 14;

            var request = new TraktCalendarAllShowsRequest(null)
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

        [TestMethod, TestCategory("Requests"), TestCategory("Calendars"), TestCategory("Without OAuth"), TestCategory("Shows")]
        public void TestTraktCalendarAllShowsRequestUriParamsWithDays()
        {
            var startDate = DateTime.Now;
            var days = 14;

            var request = new TraktCalendarAllShowsRequest(null)
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
