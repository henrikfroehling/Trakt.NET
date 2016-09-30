namespace TraktApiSharp.Tests.Experimental.Requests.Calendars
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using TraktApiSharp.Experimental.Requests.Base.Get;
    using TraktApiSharp.Experimental.Requests.Calendars;
    using TraktApiSharp.Experimental.Requests.Interfaces;

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

        [TestMethod, TestCategory("Requests"), TestCategory("Calendars")]
        public void TestATraktCalendarRequestImplementsITraktExtendedInfoInterface()
        {
            typeof(ATraktCalendarRequest<>).GetInterfaces().Should().Contain(typeof(ITraktExtendedInfo));
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Calendars")]
        public void TestATraktCalendarRequestImplementsITraktFilterableInterface()
        {
            typeof(ATraktCalendarRequest<>).GetInterfaces().Should().Contain(typeof(ITraktFilterable));
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Calendars")]
        public void TestATraktCalendarRequestHasStartDateProperty()
        {
            var startDatePropertyInfo = typeof(ATraktCalendarRequest<>)
                    .GetProperties(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance)
                    .Where(p => p.Name == "StartDate")
                    .FirstOrDefault();

            startDatePropertyInfo.CanRead.Should().BeTrue();
            startDatePropertyInfo.CanWrite.Should().BeTrue();
            startDatePropertyInfo.PropertyType.Should().Be(typeof(DateTime?));
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Calendars")]
        public void TestATraktCalendarRequestHasDaysProperty()
        {
            var daysPropertyInfo = typeof(ATraktCalendarRequest<>)
                    .GetProperties(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance)
                    .Where(p => p.Name == "Days")
                    .FirstOrDefault();

            daysPropertyInfo.CanRead.Should().BeTrue();
            daysPropertyInfo.CanWrite.Should().BeTrue();
            daysPropertyInfo.PropertyType.Should().Be(typeof(int?));
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Calendars")]
        public void TestATraktCalendarRequestHasGetUriPathParametersMethod()
        {
            var methodInfo = typeof(ATraktCalendarRequest<>).GetMethods()
                                                            .Where(m => m.Name == "GetUriPathParameters")
                                                            .FirstOrDefault();

            methodInfo.ReturnType.Should().Be(typeof(IDictionary<string, object>));
            methodInfo.GetParameters().Should().BeEmpty();
        }
    }
}
