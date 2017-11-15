namespace TraktApiSharp.Tests.Objects.Basic.Implementations
{
    using FluentAssertions;
    using System.Threading.Tasks;
    using Traits;
    using TraktApiSharp.Objects.Basic.Implementations;
    using TraktApiSharp.Objects.Basic.Json;
    using Xunit;

    [Category("Objects.Basic.Implementations")]
    public class TraktImage_Tests
    {
        [Fact]
        public void Test_TraktImage_Default_Constructor()
        {
            var traktImage = new TraktImage();

            traktImage.Full.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktImage_From_Json()
        {
            var jsonReader = new ImageObjectJsonReader();
            var traktImage = await jsonReader.ReadObjectAsync(JSON) as TraktImage;

            traktImage.Should().NotBeNull();
            traktImage.Full.Should().Be("https://walter.trakt.us/images/shows/000/060/300/logos/original/ab151d1043.png");
        }

        private const string JSON =
            @"{
                ""full"": ""https://walter.trakt.us/images/shows/000/060/300/logos/original/ab151d1043.png"",
              }";
    }
}
