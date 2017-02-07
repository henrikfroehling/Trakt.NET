namespace TraktApiSharp.Tests.Requests.Base
{
    using FluentAssertions;
    using System.Linq;
    using Traits;
    using TraktApiSharp.Requests.Base;
    using TraktApiSharp.Requests.Interfaces.Base;
    using Xunit;

    [Category("Requests.Base")]
    public class ATraktRequest_1_Tests
    {
        [Fact]
        public void Test_ATraktRequest_1_Is_AbstractClass()
        {
            typeof(ATraktRequest<>).IsAbstract.Should().BeTrue();
        }

        [Fact]
        public void Test_ATraktRequest_1_Has_GenericTypeParameter()
        {
            typeof(ATraktRequest<>).ContainsGenericParameters.Should().BeTrue();
            typeof(ATraktRequest<int>).GenericTypeArguments.Should().NotBeEmpty().And.HaveCount(1);
        }

        [Fact]
        public void Test_ATraktRequest_1_Implements_ITraktRequest_1_Interface()
        {
            typeof(ATraktRequest<int>).GetInterfaces().Should().Contain(typeof(ITraktRequest<int>));
        }

        [Fact]
        public void Test_ATraktRequest_1_Has_Abstract_AuthorizationRequirement_Property()
        {
            var propertyInfo = typeof(ATraktRequest<>).GetProperties()
                                                      .Where(p => p.Name == "AuthorizationRequirement")
                                                      .FirstOrDefault();

            propertyInfo.GetMethod.IsAbstract.Should().BeTrue();
        }

        [Fact]
        public void Test_ATraktRequest_1_Has_Abstract_Method_Property()
        {
            var propertyInfo = typeof(ATraktRequest<>).GetProperties()
                                                      .Where(p => p.Name == "Method")
                                                      .FirstOrDefault();

            propertyInfo.GetMethod.IsAbstract.Should().BeTrue();
        }

        [Fact]
        public void Test_ATraktRequest_1_Has_Abstract_UriTemplate_Property()
        {
            var propertyInfo = typeof(ATraktRequest<>).GetProperties()
                                                      .Where(p => p.Name == "UriTemplate")
                                                      .FirstOrDefault();

            propertyInfo.GetMethod.IsAbstract.Should().BeTrue();
        }

        [Fact]
        public void Test_ATraktRequest_1_Has_Abstract_GetUriPathParameters_Method()
        {
            var methodInfo = typeof(ATraktRequest<>).GetMethods()
                                                    .Where(m => m.Name == "GetUriPathParameters")
                                                    .FirstOrDefault();

            methodInfo.IsAbstract.Should().BeTrue();
        }

        [Fact]
        public void Test_ATraktRequest_1_Has_Abstract_Validate_Method()
        {
            var methodInfo = typeof(ATraktRequest<>).GetMethods()
                                                    .Where(m => m.Name == "Validate")
                                                    .FirstOrDefault();

            methodInfo.IsAbstract.Should().BeTrue();
        }
    }
}
