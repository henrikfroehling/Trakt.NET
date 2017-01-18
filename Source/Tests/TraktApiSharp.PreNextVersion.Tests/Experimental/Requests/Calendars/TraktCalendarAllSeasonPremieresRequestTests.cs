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
    public class TraktCalendarAllSeasonPremieresRequestTests
    {
        [TestMethod, TestCategory("Requests"), TestCategory("Calendars"), TestCategory("Without OAuth"), TestCategory("Shows")]
        public void TestTraktCalendarAllSeasonPremieresRequestIsNotAbstract()
        {
            typeof(TraktCalendarAllSeasonPremieresRequest).IsAbstract.Should().BeFalse();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Calendars"), TestCategory("Without OAuth"), TestCategory("Shows")]
        public void TestTraktCalendarAllSeasonPremieresRequestIsSealed()
        {
            typeof(TraktCalendarAllSeasonPremieresRequest).IsSealed.Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Calendars"), TestCategory("Without OAuth"), TestCategory("Shows")]
        public void TestTraktCalendarAllSeasonPremieresRequestIsSubclassOfATraktCalendarAllRequest()
        {
            typeof(TraktCalendarAllSeasonPremieresRequest).IsSubclassOf(typeof(ATraktCalendarAllRequest<TraktCalendarShow>)).Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Calendars"), TestCategory("Without OAuth"), TestCategory("Shows")]
        public void TestTraktCalendarAllSeasonPremieresRequestHasAuthorizationNotRequired()
        {
            var request = new TraktCalendarAllSeasonPremieresRequest(null);
            request.AuthorizationRequirement.Should().Be(TraktAuthorizationRequirement.NotRequired);
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Calendars"), TestCategory("Without OAuth"), TestCategory("Shows")]
        public void TestTraktCalendarAllSeasonPremieresRequestHasValidUriTemplate()
        {
            var request = new TraktCalendarAllSeasonPremieresRequest(null);
            request.UriTemplate.Should().Be("calendars/all/shows/premieres{/start_date}{/days}{?extended,query,years,genres,languages,countries,runtimes,ratings}");
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Calendars"), TestCategory("Without OAuth"), TestCategory("Shows")]
        public void TestTraktCalendarAllSeasonPremieresRequestUriParamsWithoutStartDateAndDays()
        {
            var request = new TraktCalendarAllSeasonPremieresRequest(null);
            var uriParams = request.GetUriPathParameters();

            uriParams.Should().NotBeNull().And.BeEmpty();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Calendars"), TestCategory("Without OAuth"), TestCategory("Shows")]
        public void TestTraktCalendarAllSeasonPremieresRequestUriParamsWithStartDate()
        {
            var startDate = DateTime.Now;

            var request = new TraktCalendarAllSeasonPremieresRequest(null)
            {
                StartDate = startDate
            };

            var uriParams = request.GetUriPathParameters();

            uriParams.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(1);
            uriParams.Should().Contain("start_date", startDate.ToTraktDateString());
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Calendars"), TestCategory("Without OAuth"), TestCategory("Shows")]
        public void TestTraktCalendarAllSeasonPremieresRequestUriParamsWithStartDateAndDays()
        {
            var startDate = DateTime.Now;
            var days = 14;

            var request = new TraktCalendarAllSeasonPremieresRequest(null)
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
        public void TestTraktCalendarAllSeasonPremieresRequestUriParamsWithDays()
        {
            var startDate = DateTime.Now;
            var days = 14;

            var request = new TraktCalendarAllSeasonPremieresRequest(null)
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
