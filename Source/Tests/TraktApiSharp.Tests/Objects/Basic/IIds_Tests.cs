namespace TraktApiSharp.Tests.Objects.Basic
{
    using FluentAssertions;
    using System.Linq;
    using Traits;
    using TraktApiSharp.Objects.Basic;
    using Xunit;

    [Category("Objects.Basic.Interfaces")]
    public class IIds_Tests
    {
        [Fact]
        public void Test_IIds_Is_Interface()
        {
            typeof(IIds).IsInterface.Should().BeTrue();
        }

        [Fact]
        public void Test_IIds_Has_HasAnyId_Property()
        {
            var propertyInfo = typeof(IIds).GetProperties().FirstOrDefault(p => p.Name == "HasAnyId");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeFalse();
            propertyInfo.PropertyType.Should().Be(typeof(bool));
        }

        [Fact]
        public void Test_IIds_Has_GetBestId_Method()
        {
            var methodInfo = typeof(IIds).GetMethods().FirstOrDefault(m => m.Name == "GetBestId");

            methodInfo.ReturnType.Should().Be(typeof(string));
            methodInfo.GetParameters().Should().BeEmpty();
        }
    }
}
