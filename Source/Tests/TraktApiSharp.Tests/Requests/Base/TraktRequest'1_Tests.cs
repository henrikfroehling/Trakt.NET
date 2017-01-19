namespace TraktApiSharp.Tests.Requests.Base
{
    using FluentAssertions;
    using System.Linq;
    using TraktApiSharp.Experimental.Requests.Base;
    using TraktApiSharp.Experimental.Requests.Interfaces.Base;
    using TraktApiSharp.Tests.Traits;
    using Xunit;

    [Category("Requests.Base")]
    public class TraktRequest_1_Tests
    {
        [Fact]
        public void Test_TraktRequest_1_Is_AbstractClass()
        {
            typeof(TraktRequest<>).IsAbstract.Should().BeTrue();
        }

        [Fact]
        public void Test_TraktRequest_1_Has_GenericTypeParameter()
        {
            typeof(TraktRequest<>).ContainsGenericParameters.Should().BeTrue();
            typeof(TraktRequest<int>).GenericTypeArguments.Should().NotBeEmpty().And.HaveCount(1);
        }

        [Fact]
        public void Test_TraktRequest_1_Implements_ITraktRequest_1_Interface()
        {
            typeof(TraktRequest<int>).GetInterfaces().Should().Contain(typeof(ITraktRequest<int>));
        }

        [Fact]
        public void Test_TraktRequest_1_Has_Abstract_AuthorizationRequirement_Property()
        {
            var propertyInfo = typeof(TraktRequest<>).GetProperties()
                                                     .Where(p => p.Name == "AuthorizationRequirement")
                                                     .FirstOrDefault();

            propertyInfo.GetMethod.IsAbstract.Should().BeTrue();
        }

        [Fact]
        public void Test_TraktRequest_1_Has_Abstract_Method_Property()
        {
            var propertyInfo = typeof(TraktRequest<>).GetProperties()
                                                     .Where(p => p.Name == "Method")
                                                     .FirstOrDefault();

            propertyInfo.GetMethod.IsAbstract.Should().BeTrue();
        }

        [Fact]
        public void Test_TraktRequest_1_Has_Abstract_UriTemplate_Property()
        {
            var propertyInfo = typeof(TraktRequest<>).GetProperties()
                                                     .Where(p => p.Name == "UriTemplate")
                                                     .FirstOrDefault();

            propertyInfo.GetMethod.IsAbstract.Should().BeTrue();
        }

        [Fact]
        public void Test_TraktRequest_1_Has_Abstract_GetUriPathParameters_Method()
        {
            var methodInfo = typeof(TraktRequest<>).GetMethods()
                                                   .Where(m => m.Name == "GetUriPathParameters")
                                                   .FirstOrDefault();

            methodInfo.IsAbstract.Should().BeTrue();
        }

        [Fact]
        public void Test_TraktRequest_1_Has_Abstract_Validate_Method()
        {
            var methodInfo = typeof(TraktRequest<>).GetMethods()
                                                   .Where(m => m.Name == "Validate")
                                                   .FirstOrDefault();

            methodInfo.IsAbstract.Should().BeTrue();
        }
    }
}
