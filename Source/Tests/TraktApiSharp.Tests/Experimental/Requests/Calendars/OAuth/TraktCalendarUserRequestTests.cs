namespace TraktApiSharp.Tests.Experimental.Requests.Calendars.OAuth
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Experimental.Requests.Calendars.OAuth;

    [TestClass]
    public class TraktCalendarUserRequestTests
    {
        [TestMethod, TestCategory("Requests"), TestCategory("Calendars"), TestCategory("With OAuth")]
        public void TestATraktCalendarUserRequestIsAbstract()
        {
            typeof(ATraktCalendarUserRequest<>).IsAbstract.Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Calendars"), TestCategory("With OAuth")]
        public void TestATraktCalendarUserRequestHasGenericTypeParameter()
        {
            typeof(ATraktCalendarUserRequest<>).ContainsGenericParameters.Should().BeTrue();
            typeof(ATraktCalendarUserRequest<int>).GenericTypeArguments.Should().NotBeEmpty().And.HaveCount(1);
        }
    }
}
