namespace TraktApiSharp.Tests.Experimental.Requests.Base.Post.Bodyless
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Experimental.Requests.Base;
    using TraktApiSharp.Experimental.Requests.Base.Post.Bodyless;
    using TraktApiSharp.Experimental.Requests.Interfaces;

    [TestClass]
    public class ATraktListBodylessPostByIdRequestTests
    {
        [TestMethod]
        public void TestATraktListBodylessPostByIdRequestIsAbstract()
        {
            typeof(ATraktListBodylessPostByIdRequest<>).IsAbstract.Should().BeTrue();
        }

        [TestMethod]
        public void TestATraktListBodylessPostByIdRequestIsSubclassOfATraktListRequest()
        {
            typeof(ATraktListBodylessPostByIdRequest<int>).IsSubclassOf(typeof(ATraktListRequest<int>)).Should().BeTrue();
        }

        [TestMethod]
        public void TestATraktListBodylessPostByIdRequestHasGenericTypeParameter()
        {
            typeof(ATraktListBodylessPostByIdRequest<>).ContainsGenericParameters.Should().BeTrue();
            typeof(ATraktListBodylessPostByIdRequest<int>).GenericTypeArguments.Should().NotBeEmpty().And.HaveCount(1);
        }

        [TestMethod]
        public void TestATraktListBodylessPostByIdRequestImplementsITraktRequestInterface()
        {
            typeof(ATraktListBodylessPostByIdRequest<>).GetInterfaces().Should().Contain(typeof(ITraktRequest));
        }

        [TestMethod]
        public void TestATraktListBodylessPostByIdRequestImplementsITraktHasIdInterface()
        {
            typeof(ATraktListBodylessPostByIdRequest<>).GetInterfaces().Should().Contain(typeof(ITraktHasId));
        }
    }
}
