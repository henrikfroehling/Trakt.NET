namespace TraktNet.Objects.Get.Tests.People.Json.Reader
{
    using FluentAssertions;
    using System;
    using System.IO;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Get.People;
    using TraktNet.Objects.Get.People.Json.Reader;
    using Xunit;

    [Category("Objects.Get.People.JsonReader")]
    public partial class PersonIdsObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_PersonIdsObjectJsonReader_ReadObject_From_Stream_Complete()
        {
            var traktJsonReader = new PersonIdsObjectJsonReader();

            using Stream stream = JSON_COMPLETE.ToStream();
            var traktPersonIds = await traktJsonReader.ReadObjectAsync(stream);

            traktPersonIds.Should().NotBeNull();
            traktPersonIds.Trakt.Should().Be(297737);
            traktPersonIds.Slug.Should().Be("bryan-cranston");
            traktPersonIds.Imdb.Should().Be("nm0186505");
            traktPersonIds.Tmdb.Should().Be(17419U);
            traktPersonIds.TvRage.Should().Be(1797U);
        }

        [Fact]
        public async Task Test_PersonIdsObjectJsonReader_ReadObject_From_Stream_Not_Valid_1()
        {
            var traktJsonReader = new PersonIdsObjectJsonReader();

            using Stream stream = JSON_NOT_VALID.ToStream();
            var traktPersonIds = await traktJsonReader.ReadObjectAsync(stream);

            traktPersonIds.Should().NotBeNull();
            traktPersonIds.Trakt.Should().Be(0);
            traktPersonIds.Slug.Should().BeNull();
            traktPersonIds.Imdb.Should().BeNull();
            traktPersonIds.Tmdb.Should().BeNull();
            traktPersonIds.TvRage.Should().BeNull();
        }

        [Fact]
        public async Task Test_PersonIdsObjectJsonReader_ReadObject_From_Stream_Null()
        {
            var traktJsonReader = new PersonIdsObjectJsonReader();
            Func<Task<ITraktPersonIds>> traktPersonIds = () => traktJsonReader.ReadObjectAsync(default(Stream));
            await traktPersonIds.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_PersonIdsObjectJsonReader_ReadObject_From_Stream_Empty()
        {
            var traktJsonReader = new PersonIdsObjectJsonReader();

            using Stream stream = string.Empty.ToStream();
            var traktPersonIds = await traktJsonReader.ReadObjectAsync(stream);
            traktPersonIds.Should().BeNull();
        }
    }
}
