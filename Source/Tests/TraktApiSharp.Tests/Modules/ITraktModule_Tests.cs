namespace TraktApiSharp.Tests.Modules
{
    using FluentAssertions;
    using System.Linq;
    using Traits;
    using TraktApiSharp.Modules;
    using Xunit;

    [Category("Modules")]
    public class ITraktModule_Tests
    {
        [Fact]
        public void Test_ITraktModule_Is_Interface()
        {
            typeof(ITraktModule).IsInterface.Should().BeTrue();
        }

        [Fact]
        public void Test_ITraktModule_Has_Client_Property()
        {
            var propertyInfo = typeof(ITraktModule).GetProperties()
                                                   .Where(p => p.Name == "Client")
                                                   .FirstOrDefault();

            propertyInfo.Should().NotBeNull();
            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeFalse();
            propertyInfo.PropertyType.Should().Be(typeof(TraktClient));
        }
    }
}
