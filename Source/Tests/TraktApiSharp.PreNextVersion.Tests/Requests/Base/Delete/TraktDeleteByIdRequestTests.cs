namespace TraktApiSharp.Tests.Requests.Base.Delete
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Requests.Base.Delete;

    [TestClass]
    public class TraktDeleteByIdRequestTests
    {
        [TestMethod]
        public void TestTraktDeleteByIdRequestIsAbstract()
        {
            typeof(TraktDeleteByIdRequest).IsAbstract.Should().BeTrue();
        }

        [TestMethod]
        public void TestTraktDeleteByIdRequestIsTraktDeleteRequest()
        {
            typeof(TraktDeleteRequest).IsAssignableFrom(typeof(TraktDeleteByIdRequest)).Should().BeTrue();
        }
    }
}
