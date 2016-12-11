namespace TraktApiSharp.Tests.Experimental.Requests.Base.Delete
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Experimental.Requests.Base;
    using TraktApiSharp.Experimental.Requests.Base.Delete;

    [TestClass]
    public class ATraktNoContentDeleteByIdRequestTests
    {
        [TestMethod, TestCategory("Requests"), TestCategory("Base"), TestCategory("Delete")]
        public void TestATraktNoContentDeleteByIdRequestIsAbstract()
        {
            typeof(ATraktNoContentDeleteByIdRequest).IsAbstract.Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Base"), TestCategory("Delete")]
        public void TestATraktNoContentDeleteByIdRequestIsSubclassOfATraktNoContentDeleteRequest()
        {
            typeof(ATraktNoContentDeleteByIdRequest).IsSubclassOf(typeof(ATraktNoContentDeleteRequest)).Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Base"), TestCategory("Delete")]
        public void TestATraktNoContentDeleteByIdRequestImplementsITraktHasIdInterface()
        {
            typeof(ATraktNoContentDeleteByIdRequest).GetInterfaces().Should().Contain(typeof(ITraktHasId));
        }
    }
}
