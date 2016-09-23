namespace TraktApiSharp.Tests.Experimental.Requests.Calendars
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
    using System.Linq;
    using System.Reflection;
    using TraktApiSharp.Experimental.Requests.Base.Get;
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
        public void TestATraktCalendarAllRequestIsSubclassOfATraktListGetRequest()
        {
            typeof(ATraktCalendarAllRequest<int>).IsSubclassOf(typeof(ATraktListGetRequest<int>)).Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Calendars"), TestCategory("Without OAuth")]
        public void TestATraktCalendarAllRequestHasStartDateProperty()
        {
            var startDatePropertyInfo = typeof(ATraktCalendarAllRequest<>)
                .GetProperties(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance)
                .Where(p => p.Name == "StartDate").FirstOrDefault();

            startDatePropertyInfo.CanRead.Should().BeTrue();
            startDatePropertyInfo.CanWrite.Should().BeTrue();
            startDatePropertyInfo.PropertyType.Should().Be(typeof(DateTime?));
        }
    }
}
