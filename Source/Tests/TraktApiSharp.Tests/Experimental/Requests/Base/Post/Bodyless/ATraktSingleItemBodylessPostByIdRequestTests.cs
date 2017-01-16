namespace TraktApiSharp.Tests.Experimental.Requests.Base.Post.Bodyless
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Experimental.Requests.Base.Post.Bodyless;
    using TraktApiSharp.Experimental.Requests.Interfaces;
    using TraktApiSharp.Experimental.Requests.Interfaces.Base;

    [TestClass]
    public class ATraktSingleItemBodylessPostByIdRequestTests
    {
        [TestMethod, TestCategory("Requests"), TestCategory("Base"), TestCategory("Post"), TestCategory("Bodyless")]
        public void TestATraktSingleItemBodylessPostByIdRequestIsAbstract()
        {
            typeof(ATraktSingleItemBodylessPostByIdRequest<>).IsAbstract.Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Base"), TestCategory("Post"), TestCategory("Bodyless")]
        public void TestATraktSingleItemBodylessPostByIdRequestIsSubclassOfATraktSingleItemBodylessPostRequest()
        {
            typeof(ATraktSingleItemBodylessPostByIdRequest<int>).IsSubclassOf(typeof(ATraktSingleItemBodylessPostRequest<int>)).Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Base"), TestCategory("Post"), TestCategory("Bodyless")]
        public void TestATraktSingleItemBodylessPostByIdRequestHasGenericTypeParameter()
        {
            typeof(ATraktSingleItemBodylessPostByIdRequest<>).ContainsGenericParameters.Should().BeTrue();
            typeof(ATraktSingleItemBodylessPostByIdRequest<int>).GenericTypeArguments.Should().NotBeEmpty().And.HaveCount(1);
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Base"), TestCategory("Post"), TestCategory("Bodyless")]
        public void TestATraktSingleItemBodylessPostByIdRequestImplementsITraktHasIdInterface()
        {
            typeof(ATraktSingleItemBodylessPostByIdRequest<>).GetInterfaces().Should().Contain(typeof(ITraktHasId));
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Base"), TestCategory("Post"), TestCategory("Bodyless")]
        public void TestATraktSingleItemBodylessPostByIdRequestImplementsITraktObjectRequestInterface()
        {
            typeof(ATraktSingleItemBodylessPostByIdRequest<>).GetInterfaces().Should().Contain(typeof(ITraktObjectRequest));
        }
    }
}
