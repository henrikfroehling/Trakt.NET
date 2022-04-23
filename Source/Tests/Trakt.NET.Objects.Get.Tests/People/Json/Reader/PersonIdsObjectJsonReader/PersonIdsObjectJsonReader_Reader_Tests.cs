﻿namespace TraktNet.Objects.Get.Tests.People.Json.Reader
{
    using FluentAssertions;
    using Newtonsoft.Json;
    using System;
    using System.IO;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Get.People;
    using TraktNet.Objects.Get.People.Json.Reader;
    using Xunit;

    [Category("Objects.Get.People.JsonReader")]
    public partial class PersonIdsObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_PersonIdsObjectJsonReader_ReadObject_From_JsonReader_Complete()
        {
            var traktJsonReader = new PersonIdsObjectJsonReader();

            using var reader = new StringReader(JSON_COMPLETE);
            using var jsonReader = new JsonTextReader(reader);
            var traktPersonIds = await traktJsonReader.ReadObjectAsync(jsonReader);

            traktPersonIds.Should().NotBeNull();
            traktPersonIds.Trakt.Should().Be(297737);
            traktPersonIds.Slug.Should().Be("bryan-cranston");
            traktPersonIds.Imdb.Should().Be("nm0186505");
            traktPersonIds.Tmdb.Should().Be(17419U);
            traktPersonIds.TvRage.Should().Be(1797U);
        }

        [Fact]
        public async Task Test_PersonIdsObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_1()
        {
            var traktJsonReader = new PersonIdsObjectJsonReader();

            using var reader = new StringReader(JSON_NOT_VALID);
            using var jsonReader = new JsonTextReader(reader);
            var traktPersonIds = await traktJsonReader.ReadObjectAsync(jsonReader);

            traktPersonIds.Should().NotBeNull();
            traktPersonIds.Trakt.Should().Be(0);
            traktPersonIds.Slug.Should().BeNull();
            traktPersonIds.Imdb.Should().BeNull();
            traktPersonIds.Tmdb.Should().BeNull();
            traktPersonIds.TvRage.Should().BeNull();
        }

        [Fact]
        public async Task Test_PersonIdsObjectJsonReader_ReadObject_From_JsonReader_Null()
        {
            var traktJsonReader = new PersonIdsObjectJsonReader();
            Func<Task<ITraktPersonIds>> traktPersonIds = () => traktJsonReader.ReadObjectAsync(default(JsonTextReader));
            await traktPersonIds.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_PersonIdsObjectJsonReader_ReadObject_From_JsonReader_Empty()
        {
            var traktJsonReader = new PersonIdsObjectJsonReader();

            using var reader = new StringReader(string.Empty);
            using var jsonReader = new JsonTextReader(reader);
            var traktPersonIds = await traktJsonReader.ReadObjectAsync(jsonReader);
            traktPersonIds.Should().BeNull();
        }
    }
}
