namespace TraktApiSharp.Tests.Experimental.Requests.Base.Post
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Experimental.Requests.Base;
    using TraktApiSharp.Experimental.Requests.Base.Post;
    using TraktApiSharp.Experimental.Requests.Interfaces;

    [TestClass]
    public class ATraktListPostRequestTests
    {
        [TestMethod]
        public void TestATraktListPostRequestIsAbstract()
        {
            typeof(ATraktListPostRequest<,>).IsAbstract.Should().BeTrue();
        }

        [TestMethod]
        public void TestATraktListPostRequestIsSubclassOfATraktListRequest()
        {
            typeof(ATraktListPostRequest<int, float>).IsSubclassOf(typeof(ATraktListRequest<int>)).Should().BeTrue();
        }

        [TestMethod]
        public void TestATraktListPostRequestHasGenericTypeParameter()
        {
            typeof(ATraktListPostRequest<,>).ContainsGenericParameters.Should().BeTrue();
            typeof(ATraktListPostRequest<int, float>).GenericTypeArguments.Should().NotBeEmpty().And.HaveCount(2);
        }

        [TestMethod]
        public void TestATraktListPostRequestImplementsITraktRequestInterface()
        {
            typeof(ATraktListPostRequest<,>).GetInterfaces().Should().Contain(typeof(ITraktRequest));
        }

        [TestMethod]
        public void TestATraktListPostRequestImplementsITraktHasRequestBodyInterface()
        {
            typeof(ATraktListPostRequest<int, float>).GetInterfaces().Should().Contain(typeof(ITraktHasRequestBody<float>));
        }
    }
}
