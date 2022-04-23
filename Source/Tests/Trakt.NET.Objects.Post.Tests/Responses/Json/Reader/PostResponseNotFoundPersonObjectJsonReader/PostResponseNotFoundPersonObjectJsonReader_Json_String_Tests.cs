namespace TraktNet.Objects.Post.Tests.Responses.Json.Reader
{
    using FluentAssertions;
    using System;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Post.Responses;
    using TraktNet.Objects.Post.Responses.Json.Reader;
    using Xunit;

    [Category("Objects.Post.Responses.JsonReader")]
    public partial class PostResponseNotFoundPersonObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_PostResponseNotFoundPersonObjectJsonReader_ReadObject_From_Json_String_Complete()
        {
            var jsonReader = new PostResponseNotFoundPersonObjectJsonReader();

            var postResponseNotFoundPerson = await jsonReader.ReadObjectAsync(JSON_COMPLETE);

            postResponseNotFoundPerson.Should().NotBeNull();
            postResponseNotFoundPerson.Ids.Should().NotBeNull();
            postResponseNotFoundPerson.Ids.Trakt.Should().Be(297737U);
            postResponseNotFoundPerson.Ids.Slug.Should().Be("bryan-cranston");
            postResponseNotFoundPerson.Ids.Imdb.Should().Be("nm0186505");
            postResponseNotFoundPerson.Ids.Tmdb.Should().Be(17419U);
            postResponseNotFoundPerson.Ids.TvRage.Should().Be(1797U);
        }

        [Fact]
        public async Task Test_PostResponseNotFoundPersonObjectJsonReader_ReadObject_From_Json_String_Not_Valid()
        {
            var jsonReader = new PostResponseNotFoundPersonObjectJsonReader();

            var postResponseNotFoundPerson = await jsonReader.ReadObjectAsync(JSON_NOT_VALID);

            postResponseNotFoundPerson.Should().NotBeNull();
            postResponseNotFoundPerson.Ids.Should().BeNull();
        }

        [Fact]
        public async Task Test_PostResponseNotFoundPersonObjectJsonReader_ReadObject_From_Json_String_Null()
        {
            var jsonReader = new PostResponseNotFoundPersonObjectJsonReader();
            Func<Task<ITraktPostResponseNotFoundPerson>> postResponseNotFoundPerson = () => jsonReader.ReadObjectAsync(default(string));
            await postResponseNotFoundPerson.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_PostResponseNotFoundPersonObjectJsonReader_ReadObject_From_Json_String_Empty()
        {
            var jsonReader = new PostResponseNotFoundPersonObjectJsonReader();

            var postResponseNotFoundPerson = await jsonReader.ReadObjectAsync(string.Empty);
            postResponseNotFoundPerson.Should().BeNull();
        }
    }
}
