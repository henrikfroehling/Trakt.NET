namespace TraktApiSharp.Tests.Experimental.Requests.Base.Post.Bodyless
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Experimental.Requests.Base;
    using TraktApiSharp.Experimental.Requests.Base.Post.Bodyless;
    using TraktApiSharp.Experimental.Requests.Interfaces;

    [TestClass]
    public class ATraktSingleItemBodylessPostByIdRequestTests
    {
        [TestMethod]
        public void TestATraktSingleItemBodylessPostByIdRequestIsAbstract()
        {
            typeof(ATraktSingleItemBodylessPostByIdRequest<>).IsAbstract.Should().BeTrue();
        }

        [TestMethod]
        public void TestATraktSingleItemBodylessPostByIdRequestIsSubclassOfATraktSingleItemRequest()
        {
            typeof(ATraktSingleItemBodylessPostByIdRequest<int>).IsSubclassOf(typeof(ATraktSingleItemRequest<int>)).Should().BeTrue();
        }

        [TestMethod]
        public void TestATraktSingleItemBodylessPostByIdRequestHasGenericTypeParameter()
        {
            typeof(ATraktSingleItemBodylessPostByIdRequest<>).ContainsGenericParameters.Should().BeTrue();
            typeof(ATraktSingleItemBodylessPostByIdRequest<int>).GenericTypeArguments.Should().NotBeEmpty().And.HaveCount(1);
        }

        [TestMethod]
        public void TestATraktSingleItemBodylessPostByIdRequestImplementsITraktRequestInterface()
        {
            typeof(ATraktSingleItemBodylessPostByIdRequest<>).GetInterfaces().Should().Contain(typeof(ITraktRequest));
        }

        [TestMethod]
        public void TestATraktSingleItemBodylessPostByIdRequestImplementsITraktHasIdInterface()
        {
            typeof(ATraktSingleItemBodylessPostByIdRequest<>).GetInterfaces().Should().Contain(typeof(ITraktHasId));
        }
    }
}
