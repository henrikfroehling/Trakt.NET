namespace TraktApiSharp.Tests.Experimental.Requests.Base.Post.Bodyless
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Experimental.Requests.Base;
    using TraktApiSharp.Experimental.Requests.Base.Post.Bodyless;
    using TraktApiSharp.Experimental.Requests.Interfaces;

    [TestClass]
    public class ATraktListBodylessPostRequestTests
    {
        [TestMethod]
        public void TestATraktListBodylessPostRequestIsAbstract()
        {
            typeof(ATraktListBodylessPostRequest<>).IsAbstract.Should().BeTrue();
        }

        [TestMethod]
        public void TestATraktListBodylessPostRequestIsSubclassOfATraktListRequest()
        {
            typeof(ATraktListBodylessPostRequest<int>).IsSubclassOf(typeof(ATraktListRequest<int>)).Should().BeTrue();
        }

        [TestMethod]
        public void TestATraktListBodylessPostRequestHasGenericTypeParameter()
        {
            typeof(ATraktListBodylessPostRequest<>).ContainsGenericParameters.Should().BeTrue();
            typeof(ATraktListBodylessPostRequest<int>).GenericTypeArguments.Should().NotBeEmpty().And.HaveCount(1);
        }

        [TestMethod]
        public void TestATraktListBodylessPostRequestImplementsITraktRequestInterface()
        {
            typeof(ATraktListBodylessPostRequest<>).GetInterfaces().Should().Contain(typeof(ITraktRequest));
        }
    }
}
