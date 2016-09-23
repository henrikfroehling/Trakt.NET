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
    public class TraktCalendarAllNewShowsRequestTests
    {
        [TestMethod, TestCategory("Requests"), TestCategory("Calendars"), TestCategory("Without OAuth"), TestCategory("Shows")]
        public void TestTraktCalendarAllNewShowsRequestIsNotAbstract()
        {
            typeof(TraktCalendarAllNewShowsRequest).IsAbstract.Should().BeFalse();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Calendars"), TestCategory("Without OAuth"), TestCategory("Shows")]
        public void TestTraktCalendarAllNewShowsRequestIsSealed()
        {
            typeof(TraktCalendarAllNewShowsRequest).IsSealed.Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Calendars"), TestCategory("Without OAuth"), TestCategory("Shows")]
        public void TestTraktCalendarAllNewShowsRequestIsSubclassOfATraktCalendarAllRequest()
        {
            typeof(TraktCalendarAllNewShowsRequest).IsSubclassOf(typeof(ATraktCalendarAllRequest<TraktCalendarShow>)).Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Calendars"), TestCategory("Without OAuth"), TestCategory("Shows")]
        public void TestTraktCalendarAllNewShowsRequestHasAuthorizationNotRequired()
        {
            var request = new TraktCalendarAllNewShowsRequest(null);
            request.AuthorizationRequirement.Should().Be(TraktAuthorizationRequirement.NotRequired);
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Calendars"), TestCategory("Without OAuth"), TestCategory("Shows")]
        public void TestTraktCalendarAllNewShowsRequestHasValidUriTemplate()
        {
            var request = new TraktCalendarAllNewShowsRequest(null);
            request.UriTemplate.Should().Be("calendars/all/shows/new{/start_date}{/days}{?extended,query,years,genres,languages,countries,runtimes,ratings}");
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Calendars"), TestCategory("Without OAuth"), TestCategory("Shows")]
        public void TestTraktCalendarAllNewShowsRequestUriParamsWithoutStartDateAndDays()
        {
            var request = new TraktCalendarAllNewShowsRequest(null);
            var uriParams = request.GetUriPathParameters();

            uriParams.Should().NotBeNull().And.BeEmpty();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Calendars"), TestCategory("Without OAuth"), TestCategory("Shows")]
        public void TestTraktCalendarAllNewShowsRequestUriParamsWithStartDate()
        {
            var startDate = DateTime.Now;

            var request = new TraktCalendarAllNewShowsRequest(null)
            {
                StartDate = startDate
            };

            var uriParams = request.GetUriPathParameters();

            uriParams.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(1);
            uriParams.Should().Contain("start_date", startDate.ToTraktDateString());
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Calendars"), TestCategory("Without OAuth"), TestCategory("Shows")]
        public void TestTraktCalendarAllNewShowsRequestUriParamsWithStartDateAndDays()
        {
            var startDate = DateTime.Now;
            var days = 14;

            var request = new TraktCalendarAllNewShowsRequest(null)
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
        public void TestTraktCalendarAllNewShowsRequestUriParamsWithDays()
        {
            var startDate = DateTime.Now;
            var days = 14;

            var request = new TraktCalendarAllNewShowsRequest(null)
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
