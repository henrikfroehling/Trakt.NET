namespace TraktApiSharp.Tests.Experimental.Requests.Base.Post
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Experimental.Requests.Base;
    using TraktApiSharp.Experimental.Requests.Base.Post;
    using TraktApiSharp.Experimental.Requests.Interfaces;

    [TestClass]
    public class ATraktSingleItemPostByIdRequestTests
    {
        [TestMethod]
        public void TestATraktSingleItemPostByIdRequestIsAbstract()
        {
            typeof(ATraktSingleItemPostByIdRequest<,>).IsAbstract.Should().BeTrue();
        }

        [TestMethod]
        public void TestATraktSingleItemPostByIdRequestIsSubclassOfATraktSingleItemRequest()
        {
            typeof(ATraktSingleItemPostByIdRequest<int, float>).IsSubclassOf(typeof(ATraktSingleItemRequest<int>)).Should().BeTrue();
        }

        [TestMethod]
        public void TestATraktSingleItemPostByIdRequestHasGenericTypeParameter()
        {
            typeof(ATraktSingleItemPostByIdRequest<,>).ContainsGenericParameters.Should().BeTrue();
            typeof(ATraktSingleItemPostByIdRequest<int, float>).GenericTypeArguments.Should().NotBeEmpty().And.HaveCount(2);
        }

        [TestMethod]
        public void TestATraktSingleItemPostByIdRequestImplementsITraktRequestInterface()
        {
            typeof(ATraktSingleItemPostByIdRequest<,>).GetInterfaces().Should().Contain(typeof(ITraktRequest));
        }

        [TestMethod]
        public void TestATraktSingleItemPostByIdRequestImplementsITraktHasRequestBodyInterface()
        {
            typeof(ATraktSingleItemPostByIdRequest<int, float>).GetInterfaces().Should().Contain(typeof(ITraktHasRequestBody<float>));
        }

        [TestMethod]
        public void TestATraktSingleItemPostByIdRequestImplementsITraktHasIdInterface()
        {
            typeof(ATraktSingleItemPostByIdRequest<,>).GetInterfaces().Should().Contain(typeof(ITraktHasId));
        }
    }
}
