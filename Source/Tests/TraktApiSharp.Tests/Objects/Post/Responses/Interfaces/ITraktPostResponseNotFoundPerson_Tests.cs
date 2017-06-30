namespace TraktApiSharp.Tests.Objects.Post.Responses.Interfaces
{
    using FluentAssertions;
    using System.Linq;
    using Traits;
    using TraktApiSharp.Objects.Get.People;
    using TraktApiSharp.Objects.Post.Responses;
    using Xunit;

    [Category("Objects.Post.Responses.Interfaces")]
    public class ITraktPostResponseNotFoundPerson_Tests
    {
        [Fact]
        public void Test_ITraktPostResponseNotFoundPerson_Is_Interface()
        {
            typeof(ITraktPostResponseNotFoundPerson).IsInterface.Should().BeTrue();
        }

        [Fact]
        public void Test_ITraktPostResponseNotFoundPerson_Has_Ids_Property()
        {
            var propertyInfo = typeof(ITraktPostResponseNotFoundPerson).GetProperties().FirstOrDefault(p => p.Name == "Ids");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(ITraktPersonIds));
        }
    }
}
