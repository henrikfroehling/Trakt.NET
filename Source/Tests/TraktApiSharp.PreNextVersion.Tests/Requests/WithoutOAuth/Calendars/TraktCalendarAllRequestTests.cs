namespace TraktApiSharp.Tests.Requests.WithoutOAuth.Calendars
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Collections.Generic;
    using TraktApiSharp.Requests.Base.Get;
    using TraktApiSharp.Requests.WithoutOAuth.Calendars;

    [TestClass]
    public class TraktCalendarAllRequestTests
    {
        [TestMethod]
        public void TestTraktCalendarAllRequestIsAbstract()
        {
            typeof(TraktCalendarAllRequest<object>).IsAbstract.Should().BeTrue();
        }

        [TestMethod]
        public void TestTraktCalendarAllRequestIsTraktGetRequest()
        {
            typeof(TraktGetRequest<IEnumerable<object>, object>).IsAssignableFrom(typeof(TraktCalendarAllRequest<object>)).Should().BeTrue();
        }
    }
}
