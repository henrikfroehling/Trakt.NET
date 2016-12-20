namespace TraktApiSharp.Tests.Experimental.Requests.Users.OAuth
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Experimental.Requests.Base.Get;
    using TraktApiSharp.Experimental.Requests.Users.OAuth;
    using TraktApiSharp.Objects.Get.Users.Lists;
    using TraktApiSharp.Requests;

    [TestClass]
    public class TraktUserCustomListItemsRequestTests
    {
        [TestMethod, TestCategory("Requests"), TestCategory("Users")]
        public void TestTraktUserCustomListItemsRequestIsNotAbstract()
        {
            typeof(TraktUserCustomListItemsRequest).IsAbstract.Should().BeFalse();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Users")]
        public void TestTraktUserCustomListItemsRequestIsSealed()
        {
            typeof(TraktUserCustomListItemsRequest).IsSealed.Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Users")]
        public void TestTraktUserCustomListItemsRequestIsSubclassOfATraktListGetByIdRequest()
        {
            typeof(TraktUserCustomListItemsRequest).IsSubclassOf(typeof(ATraktListGetByIdRequest<TraktListItem>)).Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Users")]
        public void TestTraktUserCustomListItemsRequestHasValidRequestObjectType()
        {
            var request = new TraktUserCustomListItemsRequest(null);
            request.RequestObjectType.Should().Be(TraktRequestObjectType.Lists);
        }
    }
}
