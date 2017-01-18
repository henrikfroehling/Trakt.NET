namespace TraktApiSharp.Tests.Experimental.Requests.Base.Put
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Experimental.Requests.Base.Put;
    using TraktApiSharp.Experimental.Requests.Interfaces.Base.Put;

    [TestClass]
    public class ATraktSingleItemPutByIdRequestTests
    {
        [TestMethod, TestCategory("Requests"), TestCategory("Base"), TestCategory("Put")]
        public void TestATraktSingleItemPutByIdRequestIsAbstract()
        {
            typeof(ATraktSingleItemPutByIdRequest<,>).IsAbstract.Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Base"), TestCategory("Put")]
        public void TestATraktSingleItemPutByIdRequestIsSubclassOfATraktSingleItemPutRequest()
        {
            typeof(ATraktSingleItemPutByIdRequest<int, float>).IsSubclassOf(typeof(ATraktSingleItemPutRequest<int, float>)).Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Base"), TestCategory("Put")]
        public void TestATraktSingleItemPutByIdRequestHasGenericTypeParameter()
        {
            typeof(ATraktSingleItemPutByIdRequest<,>).ContainsGenericParameters.Should().BeTrue();
            typeof(ATraktSingleItemPutByIdRequest<int, float>).GenericTypeArguments.Should().NotBeEmpty().And.HaveCount(2);
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Base"), TestCategory("Put")]
        public void TestATraktSingleItemPutByIdRequestImplementsITraktSingleItemPutByIdRequestInterface()
        {
            typeof(ATraktSingleItemPutByIdRequest<int, float>).GetInterfaces().Should().Contain(typeof(ITraktSingleItemPutByIdRequest<int, float>));
        }
    }
}
