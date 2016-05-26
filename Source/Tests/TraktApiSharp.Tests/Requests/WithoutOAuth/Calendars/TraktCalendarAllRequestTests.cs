namespace TraktApiSharp.Tests.Requests.WithoutOAuth.Calendars
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Objects.Basic;
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
            typeof(TraktGetRequest<TraktListResult<object>, object>).IsAssignableFrom(typeof(TraktCalendarAllRequest<object>)).Should().BeTrue();
        }
    }
}
