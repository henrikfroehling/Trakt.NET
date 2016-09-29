namespace TraktApiSharp.Tests.Experimental.Requests.Checkins.OAuth
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Experimental.Requests.Base.Post;
    using TraktApiSharp.Experimental.Requests.Checkins.OAuth;

    [TestClass]
    public class TraktCheckinRequestTests
    {
        [TestMethod, TestCategory("Requests"), TestCategory("Checkins"), TestCategory("With OAuth")]
        public void TestTraktCheckinRequestIsNotAbstract()
        {
            typeof(TraktCheckinRequest<,>).IsAbstract.Should().BeFalse();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Checkins"), TestCategory("With OAuth")]
        public void TestTraktCheckinRequestIsSealed()
        {
            typeof(TraktCheckinRequest<,>).IsSealed.Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Checkins"), TestCategory("With OAuth")]
        public void TestTraktCheckinRequestHasGenericTypeParameter()
        {
            typeof(TraktCheckinRequest<,>).ContainsGenericParameters.Should().BeTrue();
            typeof(TraktCheckinRequest<int, float>).GenericTypeArguments.Should().NotBeEmpty().And.HaveCount(2);
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Checkins"), TestCategory("With OAuth")]
        public void TestTraktCheckinRequestIsSubclassOfATraktSingleItemPostRequest()
        {
            typeof(TraktCheckinRequest<int, float>).IsSubclassOf(typeof(ATraktSingleItemPostRequest<int, float>)).Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Checkins"), TestCategory("With OAuth")]
        public void TestTraktCheckinRequestHasValidUriTemplate()
        {
            var request = new TraktCheckinRequest<int, float>(null);
            request.UriTemplate.Should().Be("checkin");
        }
    }
}
