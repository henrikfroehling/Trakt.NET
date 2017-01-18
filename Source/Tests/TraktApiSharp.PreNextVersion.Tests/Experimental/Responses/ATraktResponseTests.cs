namespace TraktApiSharp.Tests.Experimental.Responses
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Linq;
    using TraktApiSharp.Experimental.Responses;

    [TestClass]
    public class ATraktResponseTests
    {
        [TestMethod, TestCategory("Responses"), TestCategory("Abstract Base Classes")]
        public void TestATraktResponseIsAbstract()
        {
            typeof(ATraktResponse<>).IsAbstract.Should().BeTrue();
        }

        [TestMethod, TestCategory("Responses"), TestCategory("Abstract Base Classes")]
        public void TestATraktResponseIsSubclassOfTraktNoContentResponse()
        {
            typeof(ATraktResponse<>).IsSubclassOf(typeof(TraktNoContentResponse)).Should().BeTrue();
        }

        [TestMethod, TestCategory("Responses"), TestCategory("Abstract Base Classes")]
        public void TestATraktResponseHasGenericTypeParameter()
        {
            typeof(ATraktResponse<>).ContainsGenericParameters.Should().BeTrue();
            typeof(ATraktResponse<int>).GenericTypeArguments.Should().NotBeEmpty().And.HaveCount(1);
        }

        [TestMethod, TestCategory("Responses"), TestCategory("Abstract Base Classes")]
        public void TestATraktResponseHasHasValueProperty()
        {
            var hasValuePropertyInfo = typeof(ATraktResponse<>).GetProperties()
                                                               .Where(p => p.Name == "HasValue")
                                                               .FirstOrDefault();

            hasValuePropertyInfo.CanRead.Should().BeTrue();
            hasValuePropertyInfo.CanWrite.Should().BeFalse();
            hasValuePropertyInfo.PropertyType.Should().Be(typeof(bool));
        }

        [TestMethod, TestCategory("Responses"), TestCategory("Abstract Base Classes")]
        public void TestATraktResponseHasValueProperty()
        {
            var valuePropertyInfo = typeof(ATraktResponse<>).GetProperties()
                                                            .Where(p => p.Name == "Value")
                                                            .FirstOrDefault();

            valuePropertyInfo.CanRead.Should().BeTrue();
            valuePropertyInfo.CanWrite.Should().BeFalse();
        }
    }
}
