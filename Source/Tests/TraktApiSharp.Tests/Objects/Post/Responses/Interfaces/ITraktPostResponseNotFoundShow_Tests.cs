namespace TraktApiSharp.Tests.Objects.Post.Responses.Interfaces
{
    using FluentAssertions;
    using System.Linq;
    using Traits;
    using TraktApiSharp.Objects.Get.Shows;
    using TraktApiSharp.Objects.Post.Responses;
    using Xunit;

    [Category("Objects.Post.Responses.Interfaces")]
    public class ITraktPostResponseNotFoundShow_Tests
    {
        [Fact]
        public void Test_ITraktPostResponseNotFoundShow_Is_Interface()
        {
            typeof(ITraktPostResponseNotFoundShow).IsInterface.Should().BeTrue();
        }

        [Fact]
        public void Test_ITraktPostResponseNotFoundShow_Has_Ids_Property()
        {
            var propertyInfo = typeof(ITraktPostResponseNotFoundShow).GetProperties().FirstOrDefault(p => p.Name == "Ids");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(ITraktShowIds));
        }
    }
}
