namespace TraktApiSharp.Tests.Experimental.Requests.Calendars
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Experimental.Requests.Calendars;

    [TestClass]
    public class ATraktCalendarAllRequestTests
    {
        [TestMethod, TestCategory("Requests"), TestCategory("Calendars"), TestCategory("Without OAuth")]
        public void TestATraktCalendarAllRequestIsAbstract()
        {
            typeof(ATraktCalendarAllRequest).IsAbstract.Should().BeTrue();
        }
    }
}
