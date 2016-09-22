namespace TraktApiSharp.Tests.Experimental.Requests.Base.Post.Bodyless
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Experimental.Requests.Base;
    using TraktApiSharp.Experimental.Requests.Base.Post.Bodyless;
    using TraktApiSharp.Experimental.Requests.Interfaces;

    [TestClass]
    public class ATraktPaginationBodylessPostByIdRequestTests
    {
        [TestMethod]
        public void TestATraktPaginationBodylessPostByIdRequestIsAbstract()
        {
            typeof(ATraktPaginationBodylessPostByIdRequest<>).IsAbstract.Should().BeTrue();
        }

        [TestMethod]
        public void TestATraktPaginationBodylessPostByIdRequestIsSubclassOfATraktPaginationRequestt()
        {
            typeof(ATraktPaginationBodylessPostByIdRequest<int>).IsSubclassOf(typeof(ATraktPaginationRequest<int>)).Should().BeTrue();
        }

        [TestMethod]
        public void TestATraktPaginationBodylessPostByIdRequestHasGenericTypeParameter()
        {
            typeof(ATraktPaginationBodylessPostByIdRequest<>).ContainsGenericParameters.Should().BeTrue();
            typeof(ATraktPaginationBodylessPostByIdRequest<int>).GenericTypeArguments.Should().NotBeEmpty().And.HaveCount(1);
        }

        [TestMethod]
        public void TestATraktPaginationBodylessPostByIdRequestImplementsITraktRequestInterface()
        {
            typeof(ATraktPaginationBodylessPostByIdRequest<>).GetInterfaces().Should().Contain(typeof(ITraktRequest));
        }

        [TestMethod]
        public void TestATraktPaginationBodylessPostByIdRequestImplementsITraktHasIdInterface()
        {
            typeof(ATraktPaginationBodylessPostByIdRequest<>).GetInterfaces().Should().Contain(typeof(ITraktHasId));
        }
    }
}
