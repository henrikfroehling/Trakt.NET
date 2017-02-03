namespace TraktApiSharp.Tests.Responses.Interfaces
{
    using FluentAssertions;
    using System.Linq;
    using TraktApiSharp.Experimental.Responses.Interfaces.Base;
    using TraktApiSharp.Tests.Traits;
    using Xunit;

    [Category("Responses.Interfaces")]
    public class ITraktResponseHeaders_Tests
    {
        [Fact]
        public void Test_ITraktResponseHeaders_Is_Interface()
        {
            typeof(ITraktResponseHeaders).IsInterface.Should().BeTrue();
        }

        [Fact]
        public void Test_ITraktResponseHeaders_Has_UserCount_Property()
        {
            var userCountPropertyInfo = typeof(ITraktResponseHeaders).GetProperties()
                                                                     .Where(p => p.Name == "UserCount")
                                                                     .FirstOrDefault();

            userCountPropertyInfo.CanRead.Should().BeTrue();
            userCountPropertyInfo.CanWrite.Should().BeTrue();
            userCountPropertyInfo.PropertyType.Should().Be(typeof(int?));
        }

        [Fact]
        public void Test_ITraktResponseHeaders_Has_SortBy_Property()
        {
            var userCountPropertyInfo = typeof(ITraktResponseHeaders).GetProperties()
                                                                     .Where(p => p.Name == "SortBy")
                                                                     .FirstOrDefault();

            userCountPropertyInfo.CanRead.Should().BeTrue();
            userCountPropertyInfo.CanWrite.Should().BeTrue();
            userCountPropertyInfo.PropertyType.Should().Be(typeof(string));
        }

        [Fact]
        public void Test_ITraktResponseHeaders_Has_SortHow_Property()
        {
            var userCountPropertyInfo = typeof(ITraktResponseHeaders).GetProperties()
                                                                     .Where(p => p.Name == "SortHow")
                                                                     .FirstOrDefault();

            userCountPropertyInfo.CanRead.Should().BeTrue();
            userCountPropertyInfo.CanWrite.Should().BeTrue();
            userCountPropertyInfo.PropertyType.Should().Be(typeof(string));
        }
    }
}
