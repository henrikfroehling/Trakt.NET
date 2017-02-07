namespace TraktApiSharp.Tests.Responses.Interfaces
{
    using FluentAssertions;
    using System.Linq;
    using TraktApiSharp.Responses.Interfaces;
    using Traits;
    using Xunit;

    [Category("Responses.Interfaces")]
    public class ITraktPagedResponseHeaders_Tests
    {
        [Fact]
        public void Test_ITraktPagedResponseHeaders_Is_Interface()
        {
            typeof(ITraktPagedResponseHeaders).IsInterface.Should().BeTrue();
        }

        [Fact]
        public void Test_ITraktPagedResponseHeaders_Inherits_ITraktResponseHeaders_Interface()
        {
            typeof(ITraktPagedResponseHeaders).GetInterfaces().Should().Contain(typeof(ITraktResponseHeaders));
        }
        
        [Fact]
        public void Test_ITraktPagedResponseHeaders_Has_PageCount_Property()
        {
            var userCountPropertyInfo = typeof(ITraktPagedResponseHeaders).GetProperties()
                                                                          .Where(p => p.Name == "PageCount")
                                                                          .FirstOrDefault();

            userCountPropertyInfo.CanRead.Should().BeTrue();
            userCountPropertyInfo.CanWrite.Should().BeTrue();
            userCountPropertyInfo.PropertyType.Should().Be(typeof(int?));
        }

        [Fact]
        public void Test_ITraktPagedResponseHeaders_Has_ItemCount_Property()
        {
            var userCountPropertyInfo = typeof(ITraktPagedResponseHeaders).GetProperties()
                                                                          .Where(p => p.Name == "ItemCount")
                                                                          .FirstOrDefault();

            userCountPropertyInfo.CanRead.Should().BeTrue();
            userCountPropertyInfo.CanWrite.Should().BeTrue();
            userCountPropertyInfo.PropertyType.Should().Be(typeof(int?));
        }
    }
}
