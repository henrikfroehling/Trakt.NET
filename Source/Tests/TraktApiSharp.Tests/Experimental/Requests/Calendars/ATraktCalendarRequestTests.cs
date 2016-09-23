namespace TraktApiSharp.Tests.Experimental.Requests.Calendars
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Experimental.Requests.Base.Get;
    using TraktApiSharp.Experimental.Requests.Calendars;

    [TestClass]
    public class ATraktCalendarRequestTests
    {
        [TestMethod, TestCategory("Requests"), TestCategory("Calendars")]
        public void TestATraktCalendarRequestIsAbstract()
        {
            typeof(ATraktCalendarRequest<>).IsAbstract.Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Calendars")]
        public void TestATraktCalendarRequestHasGenericTypeParameter()
        {
            typeof(ATraktCalendarRequest<>).ContainsGenericParameters.Should().BeTrue();
            typeof(ATraktCalendarRequest<int>).GenericTypeArguments.Should().NotBeEmpty().And.HaveCount(1);
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Calendars")]
        public void TestATraktCalendarRequestIsSubclassOfATraktListGetRequest()
        {
            typeof(ATraktCalendarRequest<int>).IsSubclassOf(typeof(ATraktListGetRequest<int>)).Should().BeTrue();
        }
    }
}
