namespace TraktApiSharp.Tests.Experimental.Requests.Calendars.OAuth
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
    using System.Linq;
    using System.Reflection;
    using TraktApiSharp.Experimental.Requests.Base.Get;
    using TraktApiSharp.Experimental.Requests.Calendars.OAuth;

    [TestClass]
    public class ATraktCalendarUserRequestTests
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

        [TestMethod, TestCategory("Requests"), TestCategory("Calendars"), TestCategory("With OAuth")]
        public void TestATraktCalendarUserRequestIsSubclassOfATraktListGetRequest()
        {
            typeof(ATraktCalendarUserRequest<int>).IsSubclassOf(typeof(ATraktListGetRequest<int>)).Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Calendars"), TestCategory("With OAuth")]
        public void TestATraktCalendarUserRequestHasStartDateProperty()
        {
            var startDatePropertyInfo = typeof(ATraktCalendarUserRequest<>)
                    .GetProperties(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance)
                    .Where(p => p.Name == "StartDate")
                    .FirstOrDefault();

            startDatePropertyInfo.CanRead.Should().BeTrue();
            startDatePropertyInfo.CanWrite.Should().BeTrue();
            startDatePropertyInfo.PropertyType.Should().Be(typeof(DateTime?));
        }
    }
}
