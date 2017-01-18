namespace TraktApiSharp.Tests.Experimental.Requests.Calendars.OAuth
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
    using System.Collections.Generic;
    using TraktApiSharp.Experimental.Requests.Calendars.OAuth;
    using TraktApiSharp.Extensions;
    using TraktApiSharp.Objects.Get.Calendars;
    using TraktApiSharp.Requests;

    [TestClass]
    public class TraktCalendarUserNewShowsRequestTests
    {
        [TestMethod, TestCategory("Requests"), TestCategory("Calendars"), TestCategory("With OAuth"), TestCategory("Shows")]
        public void TestTraktCalendarUserNewShowsRequestIsNotAbstract()
        {
            typeof(TraktCalendarUserNewShowsRequest).IsAbstract.Should().BeFalse();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Calendars"), TestCategory("With OAuth"), TestCategory("Shows")]
        public void TestTraktCalendarUserNewShowsRequestIsSealed()
        {
            typeof(TraktCalendarUserNewShowsRequest).IsSealed.Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Calendars"), TestCategory("With OAuth"), TestCategory("Shows")]
        public void TestTraktCalendarUserNewShowsRequestIsSubclassOfATraktCalendarUserRequest()
        {
            typeof(TraktCalendarUserNewShowsRequest).IsSubclassOf(typeof(ATraktCalendarUserRequest<TraktCalendarShow>)).Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Calendars"), TestCategory("With OAuth"), TestCategory("Shows")]
        public void TestTraktCalendarUserNewShowsRequestHasAuthorizationRequired()
        {
            var request = new TraktCalendarUserNewShowsRequest(null);
            request.AuthorizationRequirement.Should().Be(TraktAuthorizationRequirement.Required);
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Calendars"), TestCategory("With OAuth"), TestCategory("Shows")]
        public void TestTraktCalendarUserNewShowsRequestHasValidUriTemplate()
        {
            var request = new TraktCalendarUserNewShowsRequest(null);
            request.UriTemplate.Should().Be("calendars/my/shows/new{/start_date}{/days}{?extended,query,years,genres,languages,countries,runtimes,ratings}");
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Calendars"), TestCategory("With OAuth"), TestCategory("Shows")]
        public void TestTraktCalendarUserNewShowsRequestUriParamsWithoutStartDateAndDays()
        {
            var request = new TraktCalendarUserNewShowsRequest(null);
            var uriParams = request.GetUriPathParameters();

            uriParams.Should().NotBeNull().And.BeEmpty();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Calendars"), TestCategory("With OAuth"), TestCategory("Shows")]
        public void TestTraktCalendarUserNewShowsRequestUriParamsWithStartDate()
        {
            var startDate = DateTime.Now;

            var request = new TraktCalendarUserNewShowsRequest(null)
            {
                StartDate = startDate
            };

            var uriParams = request.GetUriPathParameters();

            uriParams.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(1);
            uriParams.Should().Contain("start_date", startDate.ToTraktDateString());
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Calendars"), TestCategory("With OAuth"), TestCategory("Shows")]
        public void TestTraktCalendarUserNewShowsRequestUriParamsWithStartDateAndDays()
        {
            var startDate = DateTime.Now;
            var days = 14;

            var request = new TraktCalendarUserNewShowsRequest(null)
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

        [TestMethod, TestCategory("Requests"), TestCategory("Calendars"), TestCategory("With OAuth"), TestCategory("Shows")]
        public void TestTraktCalendarUserNewShowsRequestUriParamsWithDays()
        {
            var startDate = DateTime.Now;
            var days = 14;

            var request = new TraktCalendarUserNewShowsRequest(null)
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
