namespace TraktApiSharp.Tests.Experimental.Requests.Base.Post.Bodyless
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Experimental.Requests.Base;
    using TraktApiSharp.Experimental.Requests.Base.Post.Bodyless;
    using TraktApiSharp.Experimental.Requests.Interfaces.Base.Post.Bodyless;

    [TestClass]
    public class ATraktSingleItemBodylessPostRequestTests
    {
        [TestMethod, TestCategory("Requests"), TestCategory("Base"), TestCategory("Post"), TestCategory("Bodyless")]
        public void TestATraktSingleItemBodylessPostRequestIsAbstract()
        {
            typeof(ATraktSingleItemBodylessPostRequest<>).IsAbstract.Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Base"), TestCategory("Post"), TestCategory("Bodyless")]
        public void TestATraktSingleItemBodylessPostRequestIsSubclassOfATraktSingleItemRequest()
        {
            typeof(ATraktSingleItemBodylessPostRequest<int>).IsSubclassOf(typeof(ATraktSingleItemRequest<int>)).Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Base"), TestCategory("Post"), TestCategory("Bodyless")]
        public void TestATraktSingleItemBodylessPostRequestHasGenericTypeParameter()
        {
            typeof(ATraktSingleItemBodylessPostRequest<>).ContainsGenericParameters.Should().BeTrue();
            typeof(ATraktSingleItemBodylessPostRequest<int>).GenericTypeArguments.Should().NotBeEmpty().And.HaveCount(1);
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Base"), TestCategory("Delete")]
        public void TestATraktSingleItemBodylessPostRequestImplementsITraktSingleItemBodylessPostRequestInterface()
        {
            typeof(ATraktSingleItemBodylessPostRequest<int>).GetInterfaces().Should().Contain(typeof(ITraktSingleItemBodylessPostRequest<int>));
        }
    }
}
