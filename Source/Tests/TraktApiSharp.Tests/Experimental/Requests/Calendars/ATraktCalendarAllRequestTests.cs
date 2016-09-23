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
            typeof(ATraktCalendarAllRequest<>).IsAbstract.Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Calendars"), TestCategory("Without OAuth")]
        public void TestATraktCalendarAllRequestHasGenericTypeParameter()
        {
            typeof(ATraktCalendarAllRequest<>).ContainsGenericParameters.Should().BeTrue();
            typeof(ATraktCalendarAllRequest<int>).GenericTypeArguments.Should().NotBeEmpty().And.HaveCount(1);
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Calendars"), TestCategory("Without OAuth")]
        public void TestATraktCalendarAllRequestIsSubclassOfATraktCalendarRequest()
        {
            typeof(ATraktCalendarAllRequest<int>).IsSubclassOf(typeof(ATraktCalendarRequest<int>)).Should().BeTrue();
        }
    }
}
