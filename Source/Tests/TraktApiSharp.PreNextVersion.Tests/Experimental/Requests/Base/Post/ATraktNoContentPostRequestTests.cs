namespace TraktApiSharp.Tests.Experimental.Requests.Base.Post
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Experimental.Requests.Base;
    using TraktApiSharp.Experimental.Requests.Base.Post;
    using TraktApiSharp.Experimental.Requests.Interfaces.Base.Post;

    [TestClass]
    public class ATraktNoContentPostRequestTests
    {
        [TestMethod, TestCategory("Requests"), TestCategory("Base"), TestCategory("Post")]
        public void TestATraktNoContentPostRequestIsAbstract()
        {
            typeof(ATraktNoContentPostRequest<>).IsAbstract.Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Base"), TestCategory("Post")]
        public void TestATraktNoContentPostRequestIsSubclassOfATraktNoContentRequest()
        {
            typeof(ATraktNoContentPostRequest<float>).IsSubclassOf(typeof(ATraktNoContentRequest)).Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Base"), TestCategory("Post")]
        public void TestATraktNoContentPostRequestHasGenericTypeParameter()
        {
            typeof(ATraktNoContentPostRequest<>).ContainsGenericParameters.Should().BeTrue();
            typeof(ATraktNoContentPostRequest<float>).GenericTypeArguments.Should().NotBeEmpty().And.HaveCount(1);
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Base"), TestCategory("Post")]
        public void TestATraktNoContentPostRequestImplementsITraktNoContentPostRequestInterface()
        {
            typeof(ATraktNoContentPostRequest<float>).GetInterfaces().Should().Contain(typeof(ITraktNoContentPostRequest<float>));
        }
    }
}
