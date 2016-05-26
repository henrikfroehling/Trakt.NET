namespace TraktApiSharp.Tests.Requests.Base.Delete
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Requests.Base;
    using TraktApiSharp.Requests.Base.Delete;

    [TestClass]
    public class TraktDeleteRequestTests
    {
        [TestMethod]
        public void TestTraktDeleteRequestIsAbstract()
        {
            typeof(TraktDeleteRequest).IsAbstract.Should().BeTrue();
        }

        [TestMethod]
        public void TestTraktDeleteRequestIsTraktRequest()
        {
            typeof(TraktRequest<object, object, object>).IsAssignableFrom(typeof(TraktDeleteRequest)).Should().BeTrue();
        }
    }
}
