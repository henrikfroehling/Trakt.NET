namespace TraktApiSharp.Tests.Requests.Base
{
    using FluentAssertions;
    using System.Linq;
    using TraktApiSharp.Experimental.Requests.Base;
    using TraktApiSharp.Experimental.Requests.Interfaces.Base;
    using TraktApiSharp.Tests.Traits;
    using Xunit;

    [Category("Requests.Base")]
    public class ATraktRequest_Tests
    {
        [Fact]
        public void Test_ATraktRequest_Is_AbstractClass()
        {
            typeof(ATraktRequest).IsAbstract.Should().BeTrue();
        }
        
        [Fact]
        public void Test_ATraktRequest_Implements_ITraktRequest_Interface()
        {
            typeof(ATraktRequest).GetInterfaces().Should().Contain(typeof(ITraktRequest));
        }

        [Fact]
        public void Test_ATraktRequest_Has_Abstract_AuthorizationRequirement_Property()
        {
            var propertyInfo = typeof(ATraktRequest).GetProperties()
                                                    .Where(p => p.Name == "AuthorizationRequirement")
                                                    .FirstOrDefault();

            propertyInfo.GetMethod.IsAbstract.Should().BeTrue();
        }

        [Fact]
        public void Test_ATraktRequest_Has_Abstract_Method_Property()
        {
            var propertyInfo = typeof(ATraktRequest).GetProperties()
                                                    .Where(p => p.Name == "Method")
                                                    .FirstOrDefault();

            propertyInfo.GetMethod.IsAbstract.Should().BeTrue();
        }

        [Fact]
        public void Test_ATraktRequest_Has_Abstract_UriTemplate_Property()
        {
            var propertyInfo = typeof(ATraktRequest).GetProperties()
                                                    .Where(p => p.Name == "UriTemplate")
                                                    .FirstOrDefault();

            propertyInfo.GetMethod.IsAbstract.Should().BeTrue();
        }

        [Fact]
        public void Test_ATraktRequest_Has_Abstract_GetUriPathParameters_Method()
        {
            var methodInfo = typeof(ATraktRequest).GetMethods()
                                                  .Where(m => m.Name == "GetUriPathParameters")
                                                  .FirstOrDefault();

            methodInfo.IsAbstract.Should().BeTrue();
        }

        [Fact]
        public void Test_ATraktRequest_Has_Abstract_Validate_Method()
        {
            var methodInfo = typeof(ATraktRequest).GetMethods()
                                                  .Where(m => m.Name == "Validate")
                                                  .FirstOrDefault();

            methodInfo.IsAbstract.Should().BeTrue();
        }
    }
}
