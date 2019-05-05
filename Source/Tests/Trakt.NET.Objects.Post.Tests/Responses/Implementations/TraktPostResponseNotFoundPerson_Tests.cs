namespace TraktNet.Objects.Post.Tests.Responses.Implementations
{
    using FluentAssertions;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Post.Responses;
    using TraktNet.Objects.Post.Responses.Json.Reader;
    using Xunit;

    [Category("Objects.Post.Responses.Implementations")]
    public class TraktPostResponseNotFoundPerson_Tests
    {
        [Fact]
        public void Test_TraktPostResponseNotFoundPerson_Default_Constructor()
        {
            var postResponseNotFoundPerson = new TraktPostResponseNotFoundPerson();

            postResponseNotFoundPerson.Ids.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktPostResponseNotFoundPerson_From_Json()
        {
            var jsonReader = new PostResponseNotFoundPersonObjectJsonReader();
            var postResponseNotFoundPerson = await jsonReader.ReadObjectAsync(JSON) as TraktPostResponseNotFoundPerson;

            postResponseNotFoundPerson.Should().NotBeNull();
            postResponseNotFoundPerson.Ids.Should().NotBeNull();
            postResponseNotFoundPerson.Ids.Trakt.Should().Be(297737U);
            postResponseNotFoundPerson.Ids.Slug.Should().Be("bryan-cranston");
            postResponseNotFoundPerson.Ids.Imdb.Should().Be("nm0186505");
            postResponseNotFoundPerson.Ids.Tmdb.Should().Be(17419U);
            postResponseNotFoundPerson.Ids.TvRage.Should().Be(1797U);
        }

        private const string JSON =
            @"{
                ""ids"": {
                  ""trakt"": 297737,
                  ""slug"": ""bryan-cranston"",
                  ""imdb"": ""nm0186505"",
                  ""tmdb"": 17419,
                  ""tvrage"": 1797
                }
              }";
    }
}
