namespace TraktApiSharp.Tests.Experimental.Responses.Interfaces.Base
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Collections.Generic;
    using TraktApiSharp.Experimental.Responses.Interfaces.Base;

    [TestClass]
    public class ITraktListResponseTests
    {
        [TestMethod, TestCategory("Responses"), TestCategory("Interfaces")]
        public void TestITraktListResponseIsInterface()
        {
            typeof(ITraktListResponse<>).IsInterface.Should().BeTrue();
        }

        [TestMethod, TestCategory("Responses"), TestCategory("Interfaces")]
        public void TestITraktListResponseHasGenericTypeParameter()
        {
            typeof(ITraktListResponse<>).ContainsGenericParameters.Should().BeTrue();
            typeof(ITraktListResponse<int>).GenericTypeArguments.Should().NotBeEmpty().And.HaveCount(1);
        }

        [TestMethod, TestCategory("Responses"), TestCategory("Interfaces")]
        public void TestITraktListResponseDerivesFromITraktResponseInterface()
        {
            typeof(ITraktListResponse<int>).GetInterfaces().Should().Contain(typeof(ITraktResponse<IEnumerable<int>>));
        }

        [TestMethod, TestCategory("Responses"), TestCategory("Interfaces")]
        public void TestITraktListResponseDerivesFromIEnumerableInterface()
        {
            typeof(ITraktListResponse<int>).GetInterfaces().Should().Contain(typeof(IEnumerable<int>));
        }
    }
}
