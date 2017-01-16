namespace TraktApiSharp.Tests.Experimental.Responses.Interfaces.Base
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Linq;
    using TraktApiSharp.Experimental.Responses;
    using TraktApiSharp.Experimental.Responses.Interfaces.Base;

    [TestClass]
    public class ITraktResponseTests
    {
        [TestMethod, TestCategory("Responses"), TestCategory("Interfaces")]
        public void TestITraktResponseIsInterface()
        {
            typeof(ITraktResponse<>).IsInterface.Should().BeTrue();
        }

        [TestMethod, TestCategory("Responses"), TestCategory("Interfaces")]
        public void TestITraktResponseHasGenericTypeParameter()
        {
            typeof(ITraktResponse<>).ContainsGenericParameters.Should().BeTrue();
            typeof(ITraktResponse<int>).GenericTypeArguments.Should().NotBeEmpty().And.HaveCount(1);
        }

        [TestMethod, TestCategory("Responses"), TestCategory("Interfaces")]
        public void TestITraktResponseDerivesFromITraktNoContentResponseInterface()
        {
            typeof(ITraktResponse<>).GetInterfaces().Should().Contain(typeof(ITraktNoContentResponse));
        }

        [TestMethod, TestCategory("Responses"), TestCategory("Interfaces")]
        public void TestITraktResponseDerivesFromITraktResponseHeadersInterface()
        {
            typeof(ITraktResponse<>).GetInterfaces().Should().Contain(typeof(ITraktResponseHeaders));
        }

        [TestMethod, TestCategory("Responses"), TestCategory("Interfaces")]
        public void TestITraktResponseHasHasValueProperty()
        {
            var hasValuePropertyInfo = typeof(ITraktResponse<>).GetProperties()
                                                               .Where(p => p.Name == "HasValue")
                                                               .FirstOrDefault();

            hasValuePropertyInfo.CanRead.Should().BeTrue();
            hasValuePropertyInfo.CanWrite.Should().BeFalse();
            hasValuePropertyInfo.PropertyType.Should().Be(typeof(bool));
        }

        [TestMethod, TestCategory("Responses"), TestCategory("Interfaces")]
        public void TestITraktResponseHasValueProperty()
        {
            var valuePropertyInfo = typeof(ITraktResponse<int>).GetProperties()
                                                            .Where(p => p.Name == "Value")
                                                            .FirstOrDefault();

            valuePropertyInfo.CanRead.Should().BeTrue();
            valuePropertyInfo.CanWrite.Should().BeFalse();
            valuePropertyInfo.PropertyType.Should().Be(typeof(int));
        }
    }
}
