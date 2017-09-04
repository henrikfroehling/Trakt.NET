namespace TraktApiSharp.Tests.Objects.Get.Users.Implementations
{
    using FluentAssertions;
    using System.Threading.Tasks;
    using Traits;
    using TraktApiSharp.Objects.Get.Users;
    using TraktApiSharp.Objects.Get.Users.Implementations;
    using TraktApiSharp.Objects.Get.Users.JsonReader;
    using Xunit;

    [Category("Objects.Get.Users.Implementations")]
    public class TraktSharingText_Tests
    {
        [Fact]
        public void Test_TraktSharingText_Implements_ITraktSharingText_Interface()
        {
            typeof(TraktSharingText).GetInterfaces().Should().Contain(typeof(ITraktSharingText));
        }

        [Fact]
        public void Test_TraktSharingText_Default_Constructor()
        {
            var sharingText = new TraktSharingText();

            sharingText.Watching.Should().BeNull();
            sharingText.Watched.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktSharingText_From_Json()
        {
            var jsonReader = new SharingTextObjectJsonReader();
            var sharingText = await jsonReader.ReadObjectAsync(JSON) as TraktSharingText;

            sharingText.Should().NotBeNull();
            sharingText.Watching.Should().Be("I'm watching [item]");
            sharingText.Watched.Should().Be("I just watched [item]");
        }

        private const string JSON =
            @"{
                ""watching"": ""I'm watching [item]"",
                ""watched"": ""I just watched [item]""
              }";
    }
}
