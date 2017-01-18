namespace TraktApiSharp.Tests.Experimental.Requests.Base.Post.Bodyless
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Experimental.Requests.Base.Post.Bodyless;
    using TraktApiSharp.Experimental.Requests.Interfaces.Base.Post.Bodyless;

    [TestClass]
    public class ATraktListBodylessPostByIdRequestTests
    {
        [TestMethod, TestCategory("Requests"), TestCategory("Base"), TestCategory("Post"), TestCategory("Bodyless")]
        public void TestATraktListBodylessPostByIdRequestIsAbstract()
        {
            typeof(ATraktListBodylessPostByIdRequest<>).IsAbstract.Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Base"), TestCategory("Post"), TestCategory("Bodyless")]
        public void TestATraktListBodylessPostByIdRequestIsSubclassOfATraktListBodylessPostRequest()
        {
            typeof(ATraktListBodylessPostByIdRequest<int>).IsSubclassOf(typeof(ATraktListBodylessPostRequest<int>)).Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Base"), TestCategory("Post"), TestCategory("Bodyless")]
        public void TestATraktListBodylessPostByIdRequestHasGenericTypeParameter()
        {
            typeof(ATraktListBodylessPostByIdRequest<>).ContainsGenericParameters.Should().BeTrue();
            typeof(ATraktListBodylessPostByIdRequest<int>).GenericTypeArguments.Should().NotBeEmpty().And.HaveCount(1);
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Base"), TestCategory("Post"), TestCategory("Bodyless")]
        public void TestATraktListBodylessPostByIdRequestImplementsITraktListBodylessPostByIdRequestInterface()
        {
            typeof(ATraktListBodylessPostByIdRequest<int>).GetInterfaces().Should().Contain(typeof(ITraktListBodylessPostByIdRequest<int>));
        }
    }
}
