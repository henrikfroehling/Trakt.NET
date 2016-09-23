namespace TraktApiSharp.Tests.Experimental.Requests.Calendars
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Experimental.Requests.Calendars;

    [TestClass]
    public class ATraktCalendarRequestTests
    {
        [TestMethod, TestCategory("Requests"), TestCategory("Calendars")]
        public void TestATraktCalendarRequestIsAbstract()
        {
            typeof(ATraktCalendarRequest).IsAbstract.Should().BeTrue();
        }
    }
}
