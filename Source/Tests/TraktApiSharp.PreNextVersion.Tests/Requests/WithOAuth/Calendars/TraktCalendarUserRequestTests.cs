namespace TraktApiSharp.Tests.Requests.WithOAuth.Calendars
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Collections.Generic;
    using TraktApiSharp.Requests.Base.Get;
    using TraktApiSharp.Requests.WithOAuth.Calendars;

    [TestClass]
    public class TraktCalendarUserRequestTests
    {
        [TestMethod]
        public void TestTraktCalendarUserRequestIsAbstract()
        {
            typeof(TraktCalendarUserRequest<object>).IsAbstract.Should().BeTrue();
        }

        [TestMethod]
        public void TestTraktCalendarUserRequestIsTraktGetRequest()
        {
            typeof(TraktGetRequest<IEnumerable<object>, object>).IsAssignableFrom(typeof(TraktCalendarUserRequest<object>)).Should().BeTrue();
        }
    }
}
