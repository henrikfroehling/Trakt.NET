namespace TraktApiSharp.Tests.Experimental.Requests.Base.Post.Bodyless
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Experimental.Requests.Base.Post.Bodyless;
    using TraktApiSharp.Experimental.Requests.Interfaces.Base.Post.Bodyless;

    [TestClass]
    public class ATraktPaginationBodylessPostByIdRequestTests
    {
        [TestMethod, TestCategory("Requests"), TestCategory("Base"), TestCategory("Post"), TestCategory("Bodyless")]
        public void TestATraktPaginationBodylessPostByIdRequestIsAbstract()
        {
            typeof(ATraktPaginationBodylessPostByIdRequest<>).IsAbstract.Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Base"), TestCategory("Post"), TestCategory("Bodyless")]
        public void TestATraktPaginationBodylessPostByIdRequestIsSubclassOfATraktPaginationBodylessPostRequest()
        {
            typeof(ATraktPaginationBodylessPostByIdRequest<int>).IsSubclassOf(typeof(ATraktPaginationBodylessPostRequest<int>)).Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Base"), TestCategory("Post"), TestCategory("Bodyless")]
        public void TestATraktPaginationBodylessPostByIdRequestHasGenericTypeParameter()
        {
            typeof(ATraktPaginationBodylessPostByIdRequest<>).ContainsGenericParameters.Should().BeTrue();
            typeof(ATraktPaginationBodylessPostByIdRequest<int>).GenericTypeArguments.Should().NotBeEmpty().And.HaveCount(1);
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Base"), TestCategory("Post"), TestCategory("Bodyless")]
        public void TestATraktPaginationBodylessPostByIdRequestImplementsITraktPaginationBodylessPostByIdRequestInterface()
        {
            typeof(ATraktPaginationBodylessPostByIdRequest<int>).GetInterfaces().Should().Contain(typeof(ITraktPaginationBodylessPostByIdRequest<int>));
        }
    }
}
