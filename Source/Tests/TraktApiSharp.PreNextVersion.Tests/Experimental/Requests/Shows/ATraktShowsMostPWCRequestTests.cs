namespace TraktApiSharp.Tests.Experimental.Requests.Shows
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using TraktApiSharp.Enums;
    using TraktApiSharp.Experimental.Requests.Shows;

    [TestClass]
    public class ATraktShowsMostPWCRequestTests
    {
        [TestMethod, TestCategory("Requests"), TestCategory("Shows"), TestCategory("Lists")]
        public void TestATraktShowsMostPWCRequestIsAbstract()
        {
            typeof(ATraktShowsMostPWCRequest<>).IsAbstract.Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Shows"), TestCategory("Lists")]
        public void TestATraktShowsMostPWCRequestHasGenericTypeParameter()
        {
            typeof(ATraktShowsMostPWCRequest<>).ContainsGenericParameters.Should().BeTrue();
            typeof(ATraktShowsMostPWCRequest<int>).GenericTypeArguments.Should().NotBeEmpty().And.HaveCount(1);
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Shows"), TestCategory("Lists")]
        public void TestATraktShowsMostPWCRequestIsSubclassOfATraktShowsRequest()
        {
            typeof(ATraktShowsMostPWCRequest<int>).IsSubclassOf(typeof(ATraktShowsRequest<int>)).Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Shows"), TestCategory("Lists")]
        public void TestATraktShowsMostPWCRequestHasPeriodProperty()
        {
            var periodPropertyInfo = typeof(ATraktShowsMostPWCRequest<>)
                    .GetProperties(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance)
                    .Where(p => p.Name == "Period")
                    .FirstOrDefault();

            periodPropertyInfo.CanRead.Should().BeTrue();
            periodPropertyInfo.CanWrite.Should().BeTrue();
            periodPropertyInfo.PropertyType.Should().Be(typeof(TraktTimePeriod));
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Shows"), TestCategory("Lists")]
        public void TestATraktShowsMostPWCRequestHasGetUriPathParametersMethod()
        {
            var methodInfo = typeof(ATraktShowsMostPWCRequest<>).GetMethods()
                                                                .Where(m => m.Name == "GetUriPathParameters")
                                                                .FirstOrDefault();

            methodInfo.ReturnType.Should().Be(typeof(IDictionary<string, object>));
            methodInfo.GetParameters().Should().BeEmpty();
        }
    }
}
