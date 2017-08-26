namespace TraktApiSharp.Tests.Requests.Base
{
    using FluentAssertions;
    using System.Linq;
    using Traits;
    using TraktApiSharp.Requests.Base;
    using TraktApiSharp.Requests.Interfaces.Base;
    using Xunit;

    [Category("Requests.Base")]
    public class ARequest_Tests
    {
        [Fact]
        public void Test_ARequest_Is_AbstractClass()
        {
            typeof(ARequest).IsAbstract.Should().BeTrue();
        }
        
        [Fact]
        public void Test_ARequest_Implements_ITraktRequest_Interface()
        {
            typeof(ARequest).GetInterfaces().Should().Contain(typeof(ITraktRequest));
        }

        [Fact]
        public void Test_ARequest_Has_Abstract_AuthorizationRequirement_Property()
        {
            var propertyInfo = typeof(ARequest).GetProperties()
                                                    .Where(p => p.Name == "AuthorizationRequirement")
                                                    .FirstOrDefault();

            propertyInfo.GetMethod.IsAbstract.Should().BeTrue();
        }

        [Fact]
        public void Test_ARequest_Has_Abstract_Method_Property()
        {
            var propertyInfo = typeof(ARequest).GetProperties()
                                                    .Where(p => p.Name == "Method")
                                                    .FirstOrDefault();

            propertyInfo.GetMethod.IsAbstract.Should().BeTrue();
        }

        [Fact]
        public void Test_ARequest_Has_Abstract_UriTemplate_Property()
        {
            var propertyInfo = typeof(ARequest).GetProperties()
                                                    .Where(p => p.Name == "UriTemplate")
                                                    .FirstOrDefault();

            propertyInfo.GetMethod.IsAbstract.Should().BeTrue();
        }

        [Fact]
        public void Test_ARequest_Has_Abstract_GetUriPathParameters_Method()
        {
            var methodInfo = typeof(ARequest).GetMethods()
                                                  .Where(m => m.Name == "GetUriPathParameters")
                                                  .FirstOrDefault();

            methodInfo.IsAbstract.Should().BeTrue();
        }

        [Fact]
        public void Test_ARequest_Has_Abstract_Validate_Method()
        {
            var methodInfo = typeof(ARequest).GetMethods()
                                                  .Where(m => m.Name == "Validate")
                                                  .FirstOrDefault();

            methodInfo.IsAbstract.Should().BeTrue();
        }
    }
}
