namespace TraktApiSharp.Tests.Experimental.Requests.Base.Post
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Experimental.Requests.Base;
    using TraktApiSharp.Experimental.Requests.Base.Post;
    using TraktApiSharp.Experimental.Requests.Interfaces;

    [TestClass]
    public class ATraktPaginationPostRequestTests
    {
        [TestMethod]
        public void TestATraktPaginationPostRequestIsAbstract()
        {
            typeof(ATraktPaginationPostRequest<,>).IsAbstract.Should().BeTrue();
        }

        [TestMethod]
        public void TestATraktPaginationPostRequestIsSubclassOfATraktPaginationRequest()
        {
            typeof(ATraktPaginationPostRequest<int, float>).IsSubclassOf(typeof(ATraktPaginationRequest<int>)).Should().BeTrue();
        }

        [TestMethod]
        public void TestATraktPaginationPostRequestHasGenericTypeParameter()
        {
            typeof(ATraktPaginationPostRequest<,>).ContainsGenericParameters.Should().BeTrue();
            typeof(ATraktPaginationPostRequest<int, float>).GenericTypeArguments.Should().NotBeEmpty().And.HaveCount(2);
        }

        [TestMethod]
        public void TestATraktPaginationPostRequestImplementsITraktRequestInterface()
        {
            typeof(ATraktPaginationPostRequest<,>).GetInterfaces().Should().Contain(typeof(ITraktRequest));
        }

        [TestMethod]
        public void TestATraktPaginationPostRequestImplementsITraktHasRequestBodyInterface()
        {
            typeof(ATraktPaginationPostRequest<int, float>).GetInterfaces().Should().Contain(typeof(ITraktHasRequestBody<float>));
        }
    }
}
