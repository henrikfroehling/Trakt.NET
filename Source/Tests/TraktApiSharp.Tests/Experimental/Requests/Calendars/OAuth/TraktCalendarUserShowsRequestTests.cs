namespace TraktApiSharp.Tests.Experimental.Requests.Calendars.OAuth
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Experimental.Requests.Calendars.OAuth;
    using TraktApiSharp.Objects.Get.Calendars;

    [TestClass]
    public class TraktCalendarUserShowsRequestTests
    {
        [TestMethod, TestCategory("Requests"), TestCategory("Calendars"), TestCategory("With OAuth"), TestCategory("Shows")]
        public void TestTraktCalendarUserShowsRequestIsNotAbstract()
        {
            typeof(TraktCalendarUserShowsRequest).IsAbstract.Should().BeFalse();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Calendars"), TestCategory("With OAuth"), TestCategory("Shows")]
        public void TestTraktCalendarUserShowsRequestIsSealed()
        {
            typeof(TraktCalendarUserShowsRequest).IsSealed.Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Calendars"), TestCategory("With OAuth"), TestCategory("Shows")]
        public void TestTraktCalendarUserShowsRequestIsSubclassOfATraktCalendarUserRequest()
        {
            typeof(TraktCalendarUserShowsRequest).IsSubclassOf(typeof(ATraktCalendarUserRequest<TraktCalendarShow>)).Should().BeTrue();
        }
    }
}
