namespace TraktApiSharp.Tests.Responses.Interfaces
{
    using FluentAssertions;
    using System;
    using System.Linq;
    using Traits;
    using TraktApiSharp.Responses.Interfaces;
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

        [Fact]
        public void Test_ITraktResponseHeaders_Has_StartDate_Property()
        {
            var userCountPropertyInfo = typeof(ITraktResponseHeaders).GetProperties()
                                                                     .Where(p => p.Name == "StartDate")
                                                                     .FirstOrDefault();

            userCountPropertyInfo.CanRead.Should().BeTrue();
            userCountPropertyInfo.CanWrite.Should().BeTrue();
            userCountPropertyInfo.PropertyType.Should().Be(typeof(DateTime?));
        }

        [Fact]
        public void Test_ITraktResponseHeaders_Has_EndDate_Property()
        {
            var userCountPropertyInfo = typeof(ITraktResponseHeaders).GetProperties()
                                                                     .Where(p => p.Name == "EndDate")
                                                                     .FirstOrDefault();

            userCountPropertyInfo.CanRead.Should().BeTrue();
            userCountPropertyInfo.CanWrite.Should().BeTrue();
            userCountPropertyInfo.PropertyType.Should().Be(typeof(DateTime?));
        }

        [Fact]
        public void Test_ITraktResponseHeaders_Has_TrendingUserCount_Property()
        {
            var userCountPropertyInfo = typeof(ITraktResponseHeaders).GetProperties()
                                                                     .Where(p => p.Name == "TrendingUserCount")
                                                                     .FirstOrDefault();

            userCountPropertyInfo.CanRead.Should().BeTrue();
            userCountPropertyInfo.CanWrite.Should().BeTrue();
            userCountPropertyInfo.PropertyType.Should().Be(typeof(int?));
        }

        [Fact]
        public void Test_ITraktResponseHeaders_Has_Page_Property()
        {
            var userCountPropertyInfo = typeof(ITraktResponseHeaders).GetProperties()
                                                                     .Where(p => p.Name == "Page")
                                                                     .FirstOrDefault();

            userCountPropertyInfo.CanRead.Should().BeTrue();
            userCountPropertyInfo.CanWrite.Should().BeTrue();
            userCountPropertyInfo.PropertyType.Should().Be(typeof(int?));
        }

        [Fact]
        public void Test_ITraktResponseHeaders_Has_Limit_Property()
        {
            var userCountPropertyInfo = typeof(ITraktResponseHeaders).GetProperties()
                                                                     .Where(p => p.Name == "Limit")
                                                                     .FirstOrDefault();

            userCountPropertyInfo.CanRead.Should().BeTrue();
            userCountPropertyInfo.CanWrite.Should().BeTrue();
            userCountPropertyInfo.PropertyType.Should().Be(typeof(int?));
        }

        [Fact]
        public void Test_ITraktResponseHeaders_Has_IsPrivateUser_Property()
        {
            var userCountPropertyInfo = typeof(ITraktResponseHeaders).GetProperties()
                                                                     .Where(p => p.Name == "IsPrivateUser")
                                                                     .FirstOrDefault();

            userCountPropertyInfo.CanRead.Should().BeTrue();
            userCountPropertyInfo.CanWrite.Should().BeTrue();
            userCountPropertyInfo.PropertyType.Should().Be(typeof(bool?));
        }
    }
}
