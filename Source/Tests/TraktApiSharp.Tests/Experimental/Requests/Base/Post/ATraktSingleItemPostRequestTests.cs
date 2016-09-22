namespace TraktApiSharp.Tests.Experimental.Requests.Base.Post
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Experimental.Requests.Base;
    using TraktApiSharp.Experimental.Requests.Base.Post;
    using TraktApiSharp.Experimental.Requests.Interfaces;

    [TestClass]
    public class ATraktSingleItemPostRequestTests
    {
        [TestMethod]
        public void TestATraktSingleItemPostRequestIsAbstract()
        {
            typeof(ATraktSingleItemPostRequest<,>).IsAbstract.Should().BeTrue();
        }

        [TestMethod]
        public void TestATraktSingleItemPostRequestIsSubclassOfATraktSingleItemRequest()
        {
            typeof(ATraktSingleItemPostRequest<int, float>).IsSubclassOf(typeof(ATraktSingleItemRequest<int>)).Should().BeTrue();
        }

        [TestMethod]
        public void TestATraktSingleItemPostRequestHasGenericTypeParameter()
        {
            typeof(ATraktSingleItemPostRequest<,>).ContainsGenericParameters.Should().BeTrue();
            typeof(ATraktSingleItemPostRequest<int, float>).GenericTypeArguments.Should().NotBeEmpty().And.HaveCount(2);
        }

        [TestMethod]
        public void TestATraktSingleItemPostRequestImplementsITraktRequestInterface()
        {
            typeof(ATraktSingleItemPostRequest<,>).GetInterfaces().Should().Contain(typeof(ITraktRequest));
        }

        [TestMethod]
        public void TestATraktSingleItemPostRequestImplementsITraktHasRequestBodyInterface()
        {
            typeof(ATraktSingleItemPostRequest<int, float>).GetInterfaces().Should().Contain(typeof(ITraktHasRequestBody<float>));
        }
    }
}
