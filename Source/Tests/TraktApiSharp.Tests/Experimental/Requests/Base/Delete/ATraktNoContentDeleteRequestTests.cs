namespace TraktApiSharp.Tests.Experimental.Requests.Base.Delete
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Experimental.Requests.Base;
    using TraktApiSharp.Experimental.Requests.Base.Delete;

    [TestClass]
    public class ATraktNoContentDeleteRequestTests
    {
        [TestMethod, TestCategory("Requests"), TestCategory("Base"), TestCategory("Delete")]
        public void TestATraktNoContentDeleteRequestIsAbstract()
        {
            typeof(ATraktNoContentDeleteRequest).IsAbstract.Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Base"), TestCategory("Delete")]
        public void TestATraktNoContentDeleteRequestIsSubclassOfATraktNoContentRequest()
        {
            typeof(ATraktNoContentDeleteRequest).IsSubclassOf(typeof(ATraktNoContentRequest)).Should().BeTrue();
        }
    }
}
