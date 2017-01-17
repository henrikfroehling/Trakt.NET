namespace TraktApiSharp.Tests.Experimental.Requests.Base.Post.Bodyless
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Experimental.Requests.Base;
    using TraktApiSharp.Experimental.Requests.Base.Post.Bodyless;
    using TraktApiSharp.Experimental.Requests.Interfaces.Base.Post.Bodyless;

    [TestClass]
    public class ATraktPaginationBodylessPostRequestTests
    {
        [TestMethod, TestCategory("Requests"), TestCategory("Base"), TestCategory("Post"), TestCategory("Bodyless")]
        public void TestATraktPaginationBodylessPostRequestIsAbstract()
        {
            typeof(ATraktPaginationBodylessPostRequest<>).IsAbstract.Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Base"), TestCategory("Post"), TestCategory("Bodyless")]
        public void TestATraktPaginationBodylessPostRequestIsSubclassOfATraktPaginationRequest()
        {
            typeof(ATraktPaginationBodylessPostRequest<int>).IsSubclassOf(typeof(ATraktPaginationRequest<int>)).Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Base"), TestCategory("Post"), TestCategory("Bodyless")]
        public void TestATraktPaginationBodylessPostRequestHasGenericTypeParameter()
        {
            typeof(ATraktPaginationBodylessPostRequest<>).ContainsGenericParameters.Should().BeTrue();
            typeof(ATraktPaginationBodylessPostRequest<int>).GenericTypeArguments.Should().NotBeEmpty().And.HaveCount(1);
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Base"), TestCategory("Delete")]
        public void TestATraktPaginationBodylessPostRequestImplementsITraktPaginationBodylessPostRequestInterface()
        {
            typeof(ATraktPaginationBodylessPostRequest<int>).GetInterfaces().Should().Contain(typeof(ITraktPaginationBodylessPostRequest<int>));
        }
    }
}
