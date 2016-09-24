namespace TraktApiSharp.Tests.Experimental.Requests.People
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Experimental.Requests.People;

    [TestClass]
    public class ATraktPersonCreditsRequestTests
    {
        [TestMethod, TestCategory("Requests"), TestCategory("People")]
        public void TestATraktPersonCreditsRequestIsAbstract()
        {
            typeof(ATraktPersonCreditsRequest<>).IsAbstract.Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("People")]
        public void TestATraktPersonCreditsRequestHasGenericTypeParameter()
        {
            typeof(ATraktPersonCreditsRequest<>).ContainsGenericParameters.Should().BeTrue();
            typeof(ATraktPersonCreditsRequest<int>).GenericTypeArguments.Should().NotBeEmpty().And.HaveCount(1);
        }
    }
}
